import React from "react";
import './Header.css';

export default function Header() {
    return (
        <div id="Header">
            <div className="header-container">
                <div className="logo">
                    <span className="icon">📦</span> <span className="logo-text">CodeCourse</span>
                </div>
                <div className="search-bar">
                    <input type="text" placeholder="Search projects" />
                </div>
                <div className="user-info">
                    <div className="user-name">David Greymaax</div>
                    <div className="icons">
                        <span className="icon">🔔</span>
                        <span className="icon">📧</span>
                        <span className="icon">⏻</span>
                    </div>
                </div>
            </div>
        </div>
    );
}
