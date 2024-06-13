import React, { useEffect } from "react";
import './RegisterPage.css';

import Header from "../../../components/Header/Header";

import Logo from "../../../assets/Logo.png";
import background_forest from '../../../assets/background_forest.png'


export default function RegisterPage() {
    useEffect(() => {
        document.body.classList.add('no-scroll');
    }, [])
    return (
        <div id="register">
            <Header />
            <div className="register-container" style={{ backgroundImage: `url(${background_forest})` }}>
                <div className="progress-bar-container">
                    <div className="1 step-container">
                        <div className="step">1</div>
                        <p>Enter Email</p>
                    </div>
                    <div className="2 step-container">
                        <div className="step">2</div>
                        <p>Email Authentication</p>
                    </div>
                    <div className="3 step-container">
                        <div className="step">3</div>
                        <p>Enter Password</p>
                    </div>
                    <div className="4 step-container">
                        <div className="step">4</div>
                        <p>Successful</p>
                    </div>
                    <div className="progress-bar">
                        <div className="progressing"></div>
                    </div>
                </div>
                <div className="form-register">
                    <img src={Logo} alt="" className="logo-img" />
                    <p className="title-cr">Create Your Account to Ignite Your Learning Journey!</p>
                </div>
            </div>
        </div>
    )
}