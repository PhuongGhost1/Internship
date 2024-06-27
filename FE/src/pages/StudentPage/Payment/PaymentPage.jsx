import React from "react";
import './PaymentPage.css';

import Header from "../../../components/Items/Header/Header";
import PaymentDetail from "../../../components/Student/Payment/PaymentDetail/PaymentDetail";
import Footer from "../../../components/Items/Footer/Footer";

export default function PaymentPage() {
    return (
        <div id="payment-page">
            <Header />
            <div className="payment-container">
                <PaymentDetail />
            </div>
            <Footer />
        </div>
    )
}