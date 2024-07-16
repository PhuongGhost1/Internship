import React, { useEffect, useState } from "react";
import "./FeedBackAdminPage.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import FeedBackAdmin from "../../../components/Admin/FeedBackAdmin/FeedBackAdmin";
import LoadingOverlay from "../../../components/LoadingOverlay";

export default function FeedBackAdminPage() {
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const timeLoading = () => {
      setTimeout(() => {
        setLoading(false);
      }, 2500);
    };

    timeLoading();
  }, []);
  return (
    <div id="FeedBack">
      <LoadingOverlay loading={loading} />
      <div className="Header-Admin">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type="feedback" />
        </div>
        <div className="Layout-container">
          <div className="FeedBack-container">
            <FeedBackAdmin />
          </div>
        </div>
      </div>
    </div>
  );
}
