import React, { useEffect, useState } from "react";
import "./SuccessPayment.css";
import ApiService from "../../../api/ApiService";
import { useNavigate } from "react-router-dom";

const SuccessPayment = () => {
  const [status, setStatus] = useState("");
  const nav = useNavigate();

  useEffect(() => {
    const handleRedirectPayout = async () => {
      const urlParams = new URLSearchParams(window.location.search);
      const orderId = urlParams.get("token");
      const payerId = urlParams.get("PayerID");
      const hasCaptured = localStorage.getItem(`order-captured-${orderId}`);

      if (hasCaptured === "true") {
        console.log("Order has already been captured.");
        setStatus("success");
        return;
      }

      if (orderId && payerId) {
        try {
          console.log(`Token: ${orderId}, PayerId: ${payerId}`);
          await ApiService.capturePaypalOrder(orderId);
          localStorage.setItem(`order-captured-${orderId}`, "true");
          setStatus("success");
        } catch (error) {
          console.error("Error capturing order:", error);
          setStatus("error");
        }
      }
    };

    const handleCancelOrder = async () => {
      const urlParams = new URLSearchParams(window.location.search);
      const orderId = urlParams.get("token");

      if (orderId) {
        try {
          await ApiService.cancelPaypalOrder(orderId);
          localStorage.removeItem(`order-captured-${orderId}`);
          setStatus("cancel");
        } catch (error) {
          console.error("Error canceling order:", error);
          setStatus("error");
        }
      }
    };

    const urlParams = new URLSearchParams(window.location.search);
    const payerId = urlParams.get("PayerID");

    if (payerId) {
      handleRedirectPayout();
    } else {
      handleCancelOrder();
    }
  }, []);

  const returnBack = () => {
    nav("/");
  };

  return (
    <div id="success-payment-page">
      {status === "success" && (
        <div className="Success-page">
          <p className="text">
            Your transaction has been completed successfully. Thank you for your
            support!
          </p>
        </div>
      )}
      {status === "cancel" && (
        <div className="Cancel-page">
          <p className="text">
            Your transaction has been cancelled. Please try again or contact
            support if you need assistance.
          </p>
        </div>
      )}
      {status === "error" && (
        <div className="Error-page">
          <p className="text">
            There was an error processing your transaction. Please try again or
            contact support.
          </p>
        </div>
      )}
      <button onClick={returnBack}>Go Back To Home Page</button>
    </div>
  );
};

export default SuccessPayment;
