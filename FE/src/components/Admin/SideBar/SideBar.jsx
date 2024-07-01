import React, { useState, useEffect } from "react";
import "./SideBar.css";
import { LuBarChart3 } from "react-icons/lu";
import { FaChalkboardTeacher } from "react-icons/fa";
import { PiStudentBold } from "react-icons/pi";
import { SiCoursera } from "react-icons/si";

export default function SideBar() {
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
        <li className={`menu-item ${activeItem === "instructor" ? "active" : ""}`}>
          <span onClick={() => handleItemClick("instructor")}>
            <a href="/admin/instructor">
              <FaChalkboardTeacher className="instructor" /> &nbsp;Instructor
            </a>
          </span>
        </li>
        <li className={`menu-item ${activeItem === "student" ? "active" : ""}`}>
          <span onClick={() => handleItemClick("student")}>
            <a href="/admin/student">
              <PiStudentBold className="Student" /> &nbsp;Student
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
      </ul>
      <div className="sidebar-settings">
        <div className="settings-header">Settings</div>
        <ul>
          <li className="settings-item">Roles</li>
          <li className="settings-item">Requests</li>
          <li className="settings-item">Preferences</li>
        </ul>
      </div>
    </div>
  );
}
