import React from "react";
import "./Header.css";
import Logo from "../../../assets/Logo.png";
import { FiBell } from "react-icons/fi";
import { RxAvatar } from "react-icons/rx";
import PropTypes from "prop-types";

function Header({ user }) {
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
          <div className="avatar-user">
            <RxAvatar className="avatar" />
            <div className="user-name">{user.username}</div>
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
