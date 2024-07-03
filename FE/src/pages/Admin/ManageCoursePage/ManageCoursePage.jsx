import React from "react";
import "./ManageCoursePage.css";
import ManageCourse from "../../../components/Admin/ManageCourse/ManageCourse";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";

export default function ManageCoursePage() {
  return (
    <div id="ManageCoursePage">
      <div className="Header-Admin">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type= 'course'/>
        </div>
        <div className="Layout-container">
          <div className="ManageCourse-container">
            <ManageCourse />
          </div>
        </div>
      </div>
    </div>
  );
}
