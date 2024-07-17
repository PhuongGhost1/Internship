import React from "react";
import './PayoutPage.css';

import Header from "../../../components/Items/Header/Header";
import PayoutDetail from "../../../components/Student/Payout/PayoutDetail/PayoutDetail";
import Footer from "../../../components/Items/Footer/Footer";

export default function PayoutPage() {
    return (
        <div id="payout-page">
            <Header />
            <div className="payout-container">
                <PayoutDetail />
            </div>
            <Footer />
        </div>
    )
}