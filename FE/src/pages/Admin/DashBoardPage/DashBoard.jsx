import React, { useState, useEffect } from "react";
import "./DashBoard.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import Weekly from "../../../components/Admin/Weekly/Weekly";
import Statistics from "../../../components/Admin/Statistics/Statistics";
import Analytics from "../../../components/Admin/Analytics/Analytics";
import Appointment from "../../../components/Admin/Appointment/Appointment";
import LoadingOverlay from "../../../components/LoadingOverlay";

export default function DashBoard() {
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const simulateLoading = () => {
      setTimeout(() => {
        setLoading(false);
      }, 3000);
    };

    simulateLoading();
  }, []);

  return (
    <div id="DashBoard">
      <LoadingOverlay loading={loading} />
      <div className="Header-Admin">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type="dashboard" />
        </div>
        <div className="Layout-container">
          <div className="Weekly-container">
            <Weekly />
          </div>

          <div className="Sta-Chart">
            <div className="Statistics">
              <Statistics />
            </div>
            <div className="Chart">
              <div className="">
                <Analytics />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
