import React, { useEffect, useState } from "react";
import "./ReportPage.css";
import Report from "../../../components/Admin/Report/Report";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import LoadingOverlay from "../../../components/LoadingOverlay";

export default function ReportPage() {
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
    <div id="ReportPage">
      <LoadingOverlay loading={loading} />
      <div className="Header-Admin">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type="report" />
        </div>
        <div className="Layout-container">
          <div className="Report-container">
            <Report />
          </div>
        </div>
      </div>
    </div>
  );
}
