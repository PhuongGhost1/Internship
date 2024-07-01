import React from "react";
import './Header.css';
import Logo from '../../../assets/Logo.png';
import { FiBell } from "react-icons/fi";

export default function Header() {
    return (
        <div id="Header">
            <div className="header-container">
                <div className="logo">
                    <span className="icon"><img src={Logo} alt="" /></span> <span className="logo-text">CodeCourse</span>
                </div>
                <div className="search-bar">
                    <input type="text" placeholder="Search projects" />
                    <span><FiBell className="Bell" /></span>
                </div>
                <div className="user-info">
                    <div className="user-name">David Greymaax</div>
                    <div className="icons">


                    </div>
                </div>
            </div>
        </div>
    );
}
