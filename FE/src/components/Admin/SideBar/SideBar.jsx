import React, { useState, useEffect } from "react";
import "./SideBar.css";
import { LuBarChart3 } from "react-icons/lu";
import { FaChalkboardTeacher } from "react-icons/fa";
import { PiStudentBold } from "react-icons/pi";
import { SiCoursera } from "react-icons/si";
import { MdOutlineManageAccounts } from "react-icons/md";
import { IoGitPullRequestSharp } from "react-icons/io5";
import { IoSettingsSharp } from "react-icons/io5";
import { TbReportAnalytics } from "react-icons/tb";
import { VscFeedback } from "react-icons/vsc";
import { BiCategory } from "react-icons/bi";

export default function SideBar({ type }) {
     const [activeItem, setActiveItem] = useState(localStorage.getItem("activeItem") || "dashboard");

     const handleItemClick = (item) => {
          setActiveItem(item);
          localStorage.setItem("activeItem", item);
     };

     useEffect(() => {
          const storedActiveItem = localStorage.getItem("activeItem");
          if (storedActiveItem) {
               setActiveItem(storedActiveItem);
          }
     }, []);

     const dropdownManagemnet = () => {
          handleItemClick("manage");
          const dropdown = document.querySelector('.dropdown');
          dropdown.classList.toggle('active');
     };

     useEffect(() => {
          if (type === 'student' || type === 'instructor') {
               setTimeout(() => {
                    const progress = document.querySelector('.dropdown');
                    progress.classList.add('nav');
               }, 100);
          }
     }, [type]);

     return (
          <div id="SideBar">
               <div className="sidebar-header">
                    <h5>Administrator</h5>
               </div>
               <ul className="sidebar-menu">
                    <li className={`menu-item ${activeItem === "dashboard" ? "active" : ""}`}>
                         <span onClick={() => handleItemClick("dashboard")}>
                              <a href="/admin/dashboard">
                                   <LuBarChart3 className="LuBarChart" /> &nbsp;Dashboard
                              </a>
                         </span>
                    </li>
                    <li className={`menu-item ${activeItem === "manage" ? "active" : ""}`} onClick={dropdownManagemnet}>
                         <MdOutlineManageAccounts className="Manage" /> &nbsp;Managemnt
                    </li>
                    <div className={`dropdown ${activeItem === "manage" ? "active" : ""}`}>
                         <div className={`menu-item ${activeItem === "instructor" ? "active" : ""}`}>
                              <a href="/admin/instructor">
                                   <FaChalkboardTeacher className="instructor" /> &nbsp;Instructor
                              </a>
                         </div>
                         <div className={`menu-item ${activeItem === "student" ? "active" : ""}`}>
                              <a href="/admin/student">
                                   <PiStudentBold className="Student" /> &nbsp;Student
                              </a>
                         </div>
                    </div>

                    <li className={`menu-item ${activeItem === "category" ? "active" : ""}`}>
                         <span onClick={() => handleItemClick("category")}>
                              <a href="/admin/category">
                                   <BiCategory  className="category" /> &nbsp;Category
                              </a>
                         </span>
                    </li>
                    <li className={`menu-item ${activeItem === "course" ? "active" : ""}`}>
                         <span onClick={() => handleItemClick("course")}>
                              <a href="/admin/course">
                                   <SiCoursera className="course" /> &nbsp;Course management
                              </a>
                         </span>
                    </li>
                    <li className={`menu-item ${activeItem === "requests" ? "active" : ""}`}>
                         <span onClick={() => handleItemClick("requests")}>
                              <a href="/admin/requests">
                                   <IoGitPullRequestSharp className="requests" /> &nbsp;Requests
                              </a>
                         </span>
                    </li>
                    <li className={`menu-item ${activeItem === "report" ? "active" : ""}`}>
                         <span onClick={() => handleItemClick("report")}>
                              <a href="/admin/report">
                                   <TbReportAnalytics  className="report" /> &nbsp;Report
                              </a>
                         </span>
                    </li>
                    <li className={`menu-item ${activeItem === "feedback" ? "active" : ""}`}>
                         <span onClick={() => handleItemClick("feedback")}>
                              <a href="/admin/feedback">
                                   <VscFeedback  className="feedback" /> &nbsp;Feedback
                              </a>
                         </span>
                    </li>
                    <li className={`menu-item ${activeItem === "setting" ? "active" : ""}`}>
                         <span onClick={() => handleItemClick("setting")}>
                              <a href="/admin/setting">
                                   <IoSettingsSharp className="setting" /> &nbsp;Setting
                              </a>
                         </span>
                    </li>
               </ul>
          </div>
     );
}
