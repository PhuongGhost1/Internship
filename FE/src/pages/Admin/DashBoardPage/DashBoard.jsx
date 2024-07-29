import React, { useState, useEffect, useContext } from "react";
import "./DashBoard.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import Weekly from "../../../components/Admin/Weekly/Weekly";
import Statistics from "../../../components/Admin/Statistics/Statistics";
import Analytics from "../../../components/Admin/Analytics/Analytics";
import Appointment from "../../../components/Admin/Appointment/Appointment";
import LoadingOverlay from "../../../components/LoadingOverlay";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function DashBoard() {
  const [loading, setLoading] = useState(true);
  const [userId, setUserId] = useState(null);
  const { user } = useContext(AuthContext);
  const nav = useNavigate();

  useEffect(() => {
    if (user) {
      setUserId(user.id);
    } else {
      nav("/login");
    }
  }, [user]);

  useEffect(() => {
    const simulateLoading = () => {
      setTimeout(() => {
        setLoading(false);
      }, 3000);
    };

    simulateLoading();
  }, []);

  return (
    <>
      {userId ? (
        <div id="DashBoard">
          <LoadingOverlay loading={loading} />
          <div className="Header-Admin">
            <Header user={user} />
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
      ) : (
        <p>No user</p>
      )}
    </>
  );
}
