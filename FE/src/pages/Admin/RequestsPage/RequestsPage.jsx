import React, { useEffect, useState } from "react";
import "./RequestsPage.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import Requests from "../../../components/Admin/Requests/Requests";
import LoadingOverlay from "../../../components/LoadingOverlay";

export default function RequestsPage() {
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
    <div id="RequestsPage">
      <LoadingOverlay loading={loading} />
      <div className="Header-Admin">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type="requests" />
        </div>
        <div className="Layout-container">
          <div className="Requests-container">
            <Requests />
          </div>
        </div>
      </div>
    </div>
  );
}
