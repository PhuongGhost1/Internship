import React from "react";
import './ManageInstructorPage.css';
import ManageInstructor from "../../../components/Admin/ManageInstructor/ManageInstrutor";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";



export default function ManageInstructorPage(){
    return(
        <div id="ManageInstructorPage">
      <div className="Header-Admin">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type = 'instructor' />
        </div>
        <div className="Layout-container">
          <div className="ManageInstructor-container">
            <ManageInstructor />
          </div>
        </div>
      </div>
    </div>
  );
}