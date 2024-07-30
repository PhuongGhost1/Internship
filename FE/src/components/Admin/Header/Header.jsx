import React, { useState } from "react";
import "./Header.css";
import Logo from "../../../assets/Logo.png";
import { FiBell } from "react-icons/fi";
import { RxAvatar } from "react-icons/rx";
import PropTypes from "prop-types";
import { LuBarChartBig } from "react-icons/lu";
import { BiLogOut } from "react-icons/bi";
import Cookies from "js-cookie";

function Header({ user }) {
  const [isDropDownUser, setIsDropDownUser] = useState(false);

  const handleLogOut = () => {
    Cookies.remove("token");
    window.location.href = "/";
  };

  return (
    <div id="Header-Admin">
      <div className="header-container">
        <div className="logo">
          <span className="icon">
            <a href="https://groupcooked.web.app/admin/dashboard">
              <img src={Logo} alt="" />
            </a>
          </span>{" "}
          <span className="logo-text">CodeCourse</span>
        </div>
        {/* <div className="search-bar">
          <input type="text" placeholder="Search projects" />
        </div> */}
        <div className="user-info">
          <span>
            <FiBell className="Bell" />
          </span>
          <div
            className="user-action"
            onClick={() => {
              setIsDropDownUser((prev) => !prev);
            }}
          >
            <RxAvatar className="avatar" />
            <div className="user-name">{user.username}</div>
            <div className={`user-dropdown ${isDropDownUser ? "active" : ""}`}>
              <div className="dropdown-container">
                <div className="arrow"></div>
                <a href="/admin/dashboard" className="selection-block">
                  <LuBarChartBig />
                  Dashboard
                </a>
                <div className="logout special-block" onClick={handleLogOut}>
                  <BiLogOut />
                  Log Out
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

Header.propTypes = {
  user: PropTypes.shape({
    username: PropTypes.string.isRequired,
  }).isRequired,
};

export default Header;
