import React from "react";
import './Footer.css'

import Logo from '../../assets/Logo.png'

import { FaYoutube } from "react-icons/fa";
import { IoLogoFacebook } from "react-icons/io";
import { AiFillTikTok } from "react-icons/ai";
import { IoLogoGithub } from "react-icons/io";

export default function Footer() {
    return (
        <div id="footer">
            <div className="footer-content">
                <div className="logo-contact">
                    <div className="logo-title">
                        <img src={Logo} alt="" className="logo" />
                        <span>CodeCourse</span>
                    </div>
                    <div className="description">
                        <span>Phone: 0981041426</span>
                        <span>Email: duynmse173649@fpt.edu.vn</span>
                        <span>Address: 6th Floor, OneHub Saigon, High-Tech Park, Tan Phu Ward, District 9, Ho Chi Minh City</span>
                    </div>
                </div>
                <div className="about block">
                    <p className="title">About CodeCourse</p>
                    <div className="description">
                        <p>About Us</p>
                        <p>Privacy Policy</p>
                        <p>Terms of Use</p>
                        <p>Cookie Policy</p>
                    </div>
                </div>
                <div className="product block">
                    <p className="title">Product</p>
                    <div className="description">
                        <p>Course Learning</p>
                        <p>Gaming Learning</p>
                        <p>Teach To Be Wibu Lỏd</p>
                    </div>
                </div>
                <div className="community block">
                    <p className="title">Community</p>
                    <div className="description">
                        <a href="https://www.youtube.com/channel/UCGJ6ICSmHN_vr1XJ4KrVY1g" target="_blank" rel="noopener noreferrer">
                            <FaYoutube />
                            <span>Youtube</span>
                        </a>
                        <a href="https://www.facebook.com/profile.php?id=100073611805031" target="_blank" rel="noopener noreferrer">
                            <IoLogoFacebook />
                            <span>Facebook</span>
                        </a>
                        <a href="https://www.youtube.com/watch?v=dQw4w9WgXcQ&autoplay=1" target="_blank" rel="noopener noreferrer">
                            <AiFillTikTok />
                            <span>Tiktok</span>
                        </a>
                        <a href="https://github.com/OtakuIsMe" target="_blank" rel="noopener noreferrer">
                            <IoLogoGithub />
                            <span>GitHub</span>
                        </a>
                    </div>
                </div>
                <div className="account block">
                    <p className="title">Account</p>
                    <div className="description">
                        <p>Create Account?</p>
                        <p>Log In</p>
                    </div>
                </div>
            </div>
            <div className="slogan">Education: The Cool Pathway to Success</div>
        </div>
    )
}