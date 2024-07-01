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
            <a href="/admin/dashboard"><LuBarChart3 className="LuBarChart" /> &nbsp;Dashboard</a>
          </span>
        </li>
        <li className="menu-item">
          <span>
            <a href="/admin/instructor"><FaChalkboardTeacher className="instructor" /> &nbsp;Instructor</a>
          </span>
        </li>
        <div>
          <li className="menu-item">
            <span>
              <a href="/admin/student"><PiStudentBold className="Student" /> &nbsp;Sutdent</a>
            </span>
          </li>
          <li className="menu-item">
            <span>
            <a href="/admin/course"><SiCoursera className="course" /> &nbsp;Course management</a>
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
