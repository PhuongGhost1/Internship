import React, { useContext, useEffect, useRef, useState } from "react";
import './Header.css';

import Logo from '../../../assets/Logo.png'

import { IoSearchOutline } from "react-icons/io5";
import SliderCards from "../SliderCards/SliderCards";
import { AuthContext } from "../../../pages/Context/AuthContext";
import { HiOutlineUserCircle } from "react-icons/hi2";
import { FaBell } from "react-icons/fa";

export default function Header() {
  const [isDropDown, setIsDropDown] = useState(false);
  const [height, setHeight] = useState('0px');
  const contentDropdownRef = useRef(null);
  const { user } = useContext(AuthContext);
  const [imgUser, setImgUser] = useState(null)

  useEffect(() => {
    if (isDropDown) {
      let process = document.querySelector('.search-result-container');
      process.classList.add("show");
      let process1 = document.querySelector('.search-bar');
      process1.classList.add("slide");
      setHeight(`376px`);
    } else {
      let process = document.querySelector('.search-result-container');
      process.classList.remove("show");
      let process1 = document.querySelector('.search-bar');
      process1.classList.remove("slide");
      setHeight('0px');
    }
  }, [isDropDown]);


  const handleSearchFocus = () => {
    setIsDropDown(true);
  }


  const handleCancelBtn = () => {
    setIsDropDown(false);
  }

  return (
    <div id="header">
      <div className="header-shown">
        <div className="logo-title">
          <a href="/" className="logo-link">
            <img src={Logo} alt="" className="logo" />
          </a>
          <span className="title">CodeCourse</span>
        </div>
        <div className="search-container">
          <div className="search-bar">
            <IoSearchOutline />
            <input
              type="text"
              placeholder="Searching for course"
              onFocus={handleSearchFocus}
            />
          </div>
        </div>

        <div className="action-button">
          {isDropDown ? (
            <div className="cancel-btn" onClick={handleCancelBtn}>CANCEL</div>
          ) : (
            user ? (
              <div className="user-action">
                <div className="user-logo">
                  {imgUser ?
                    <img src={imgUser} alt="" />
                    :
                    <HiOutlineUserCircle />
                  }
                </div>
                <div className="notification">
                  <FaBell />
                </div>
              </div>
            ) : (<React.Fragment>
              <a href="/login" className="login">Log in</a>
              <a href="/signup" className="signup">Sign Up</a>
            </React.Fragment>
            ))}
        </div>
      </div>
      <div
        ref={contentDropdownRef}
        className="search-result-container"
        style={{ height: height }}
      >
        <p className="title">Recommend</p>
        <div className="slider-container">
          <SliderCards items='1' />
        </div>
      </div>
    </div >
  );
}