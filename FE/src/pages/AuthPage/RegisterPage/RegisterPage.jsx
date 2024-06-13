import React, { useEffect } from "react";
import './RegisterPage.css';

import Header from "../../../components/Header/Header";

import Logo_White from "../../../assets/Logo_White.png";
import { FaUser } from "react-icons/fa";
import { RiLockPasswordFill } from "react-icons/ri";
import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import { TiSocialFacebook } from "react-icons/ti";
import { FaGoogle } from "react-icons/fa";


export default function RegisterPage() {
    useEffect(() => {
        document.body.classList.add('no-scroll');
    }, [])
    return (
        <div id="register">
            <Header />
            <diiv className="progress-bar">
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
            </diiv>
        </div>
    )
}