import React from "react";
import "./ManageStudentPage.css";
import Header from "../../../components/Admin/Header/Header";
import ManageStudent from "../../../components/Admin/ManageStudent/ManageStudebt";
import SideBar from "../../../components/Admin/SideBar/SideBar";

export default function ManageStudentPage() {
  return (
    <div id="ManageStudentPage">
      <div className="Header">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar />
        </div>
        <div className="Layout-container">
          <div className="ManageStudent-container">
            <ManageStudent />
          </div>
        </div>
      </div>
    </div>
  );
}
