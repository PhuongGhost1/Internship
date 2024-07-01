import React from "react";
import "./Header.css";
import Logo from "../../../assets/Logo.png";
import { FiBell } from "react-icons/fi";
import { RxAvatar } from "react-icons/rx";

export default function Header() {
  return (
    <div id="Header-Admin">
      <div className="header-container">
        <div className="logo">
          <span className="icon">
            <img src={Logo} alt="" />
          </span>{" "}
          <span className="logo-text">CodeCourse</span>
        </div>
        <div className="search-bar">
          <input type="text" placeholder="Search projects" />
        </div>
        <div className="user-info">
          <span>
            <FiBell className="Bell" />
          </span>
          <div className="avatar-user">
            <RxAvatar className="avatar" />
            <div className="user-name">GUN</div>
          </div>
        </div>
      </div>
    </div>
  );
}
