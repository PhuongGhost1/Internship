import React from "react";
import './CertificationPage.css';
import Certification from "../../../components/Student/Certification/Certification";

import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";

export default function CertificationPage() {
    return (
        <div id="CertificationPage">
            <div className="certification-container">
                <Certification />
            </div>
            <Header />
            <Footer />
        </div>
    );
}