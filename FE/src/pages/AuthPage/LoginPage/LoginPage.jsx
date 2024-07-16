import React, { useContext, useEffect, useState } from "react";
import './LoginPage.css';
import Header from "../../../components/Items/Header/Header";

import Logo_White from "../../../assets/Logo_White.png";
import { FaUser } from "react-icons/fa";
import { RiLockPasswordFill } from "react-icons/ri";
import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import { TiSocialFacebook } from "react-icons/ti";
import { FaGoogle } from "react-icons/fa";
import { AuthContext } from "../../Context/AuthContext";
import Cookies from 'js-cookie';


export default function LoginPage() {
    const { checkLogin } = useContext(AuthContext)
    const [emai, setEmail] = useState('')
    const [password, setPassword] = useState('')
    useEffect(() => {
        document.body.classList.add('no-scroll');
    }, [])
    const hanldeLogInBtn = async () => {
        const response = await checkLogin(emai, password)
        if (response.token) {
            Cookies.set('token', response.token, { expires: 1, sameSite: 'None', secure: true });
            window.location.href = '/'
        } else {

        }
    }
    return (
        <div id="log-in">
            <Header />
            <div className="log-in-container">
                <img src={Logo_White} alt="" className="logo" />
                <p className="title">Account Login</p>
                <div className="login-form">
                    <div className="email bar">
                        <div className="logo-container">
                            <FaUser />
                        </div>
                        <input type="text" value={emai} placeholder="Username or Email address" onChange={(e) => { setEmail(e.target.value) }} />
                    </div>
                    <div className="password bar">
                        <div className="logo-container">
                            <RiLockPasswordFill />
                        </div>
                        <input type="password" value={password} placeholder="Password" onChange={(e) => { setPassword(e.target.value) }} />
                    </div>
                    <div className="action-btn">
                        <FormGroup>
                            <FormControlLabel control={<Checkbox defaultChecked />} label="Remember me?" />
                        </FormGroup>
                        <div className="forgot-password-container">
                            <span>Forgot password?</span>
                        </div>
                    </div>
                    <div className="login-btn" onClick={hanldeLogInBtn}>
                        Log In
                    </div>
                    <div className="or-title">
                        <span>or</span>
                    </div>
                    <div className="facebook-google">
                        <div className="google btn">
                            <FaGoogle />
                        </div>
                        <div className="facebook btn">
                            <TiSocialFacebook />
                        </div>
                    </div>
                    <div className="ask-cr">
                        <span className="title-ask">Don't have account?</span>
                        <span className="sign-up-btn">Sign Up</span>
                    </div>
                </div>
            </div>
        </div>
    )
}