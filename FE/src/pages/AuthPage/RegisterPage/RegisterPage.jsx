import React, { useEffect, useState } from "react";
import './RegisterPage.css';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import { useLocation } from 'react-router-dom'

import Header from "../../../components/Header/Header";

import Logo from "../../../assets/Logo.png";
import background_forest from '../../../assets/background_forest.png'


export default function RegisterPage() {
    const location = useLocation()
    const queryParams = new URLSearchParams(location.search)
    const step = queryParams.get('step')
    useEffect(() => {
        console.log(step)
        document.body.classList.add('no-scroll');
    }, [])
    return (
        <div id="register">
            <Header />
            <div className="register-container" style={{ backgroundImage: `url(${background_forest})` }}>
                {(step) && (
                    <div className="progress-bar-container">
                        <div className="1 step-container">
                            <div className="step">1</div>
                            <p>Email Authentication</p>
                        </div>
                        <div className="2 step-container">
                            <div className="step">2</div>
                            <p>EnterPassword</p>
                        </div>
                        <div className="3 step-container">
                            <div className="step">3</div>
                            <p>Successful</p>
                        </div>
                        <div className="progress-bar">
                            <div className="progressing"></div>
                        </div>
                    </div>
                )}
                <div className="form-register">
                    <img src={Logo} alt="" className="logo-img" />
                    <p className="title-cr">Create Your Account to Ignite Your Learning Journey!</p>
                    {step === null && (
                        <Box
                            component="form"
                            sx={{
                                '& > :not(style)': { m: 1, width: '25ch' },
                            }}
                            noValidate
                            autoComplete="off"
                        >
                            <TextField id="outlined-basic" label="Email" variant="outlined" />
                        </Box>
                    )}
                </div>
            </div>
        </div>
    )
}