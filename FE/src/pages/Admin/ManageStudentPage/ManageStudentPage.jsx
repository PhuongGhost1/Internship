import React, { useEffect, useState } from "react";
import "./ManageStudentPage.css";
import Header from "../../../components/Admin/Header/Header";
import ManageStudent from "../../../components/Admin/ManageStudent/ManageStudent";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import LoadingOverlay from "../../../components/LoadingOverlay";

export default function ManageStudentPage() {
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const timeLoading = () => {
      setTimeout(() => {
        setLoading(false);
      }, 3000);
    };
    timeLoading();
  }, []);

  return (
    <div id="ManageStudentPage">
      <LoadingOverlay loading={loading} />
      <div className="Header-Admin">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type="student" />
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
