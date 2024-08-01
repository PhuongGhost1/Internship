import React from "react";
import "./ErrorPage.css";
import { useNavigate } from "react-router-dom";

const ErrorPage = () => {
  const nav = useNavigate();

  const returnBack = () => {
    nav("/");
  };

  return (
    <div id="error-page">
      <p>Something went wrong. Please try again!</p>
      <button onClick={returnBack}>Go Back</button>
    </div>
  );
};

export default ErrorPage;
