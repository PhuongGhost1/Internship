import React, { useContext, useEffect, useState } from "react";
import "./ReportPage.css";
import Report from "../../../components/Admin/Report/Report";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import LoadingOverlay from "../../../components/LoadingOverlay";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function ReportPage() {
  const [loading, setLoading] = useState(true);
  const { user, roles } = useContext(AuthContext);
  const nav = useNavigate();

  useEffect(() => {
    if (!user) {
      nav("/login");
    } else if (!roles.includes("Admin")) {
      nav("/error");
    }
  }, [user, roles, nav]);

  useEffect(() => {
    const timeLoading = () => {
      setTimeout(() => {
        setLoading(false);
      }, 1500);
    };
    timeLoading();
  }, []);

  return (
    <div id="ReportPage">
      <LoadingOverlay loading={loading} />
      <div className="Header-Admin">
        <Header user={user} />
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
