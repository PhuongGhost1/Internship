import React from "react";
import "./SideBar.css";
import { LuBarChart3 } from "react-icons/lu";
import { FaChalkboardTeacher } from "react-icons/fa";
import { PiStudentBold } from "react-icons/pi";
import { SiCoursera } from "react-icons/si";

export default function SideBar() {
  return (
    <div id="SideBar">
      <div className="sidebar-header">
        <h5>Administrator</h5>
      </div>
      <ul className="sidebar-menu">
        <li className="menu-item active">
          <span>
            <LuBarChart3 className="LuBarChart" />
            &nbsp;Dashboard
          </span>
        </li>
        <li className="menu-item">
          <span>
            <FaChalkboardTeacher className="instructor" />
            &nbsp;Instructor
          </span>
        </li>
        <div>
          <li className="menu-item">
            <span>
              {" "}
              <PiStudentBold className="Student" />
              &nbsp;Sutdent
            </span>
          </li>
          <li className="menu-item">
            <span>
              <SiCoursera className="course" />
              &nbsp;Course management
            </span>
          </li>
        </div>
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
