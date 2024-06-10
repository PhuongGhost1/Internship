import React from "react";
import './Header.css';

import { IoSearchOutline } from "react-icons/io5";

export default function Header() {
    return (
        <div id="header">
            <div className="logo-title">
                <a href="/" className="logo-link">
                    <img src="" alt="" className="logo" />
                </a>
                <span className="title">Rác rưỡi vãi cả lồn</span>
            </div>
            <div className="action-bar">
                <div className="search-bar">
                    <IoSearchOutline />
                    <input type="text" placeholder="Searching for course" />
                </div>
                <div className="action-button">
                    <a href="" className="login">Log in</a>
                    <a href="" className="signup">Sign Up</a>
                </div>
            </div>
        </div>
    )
}