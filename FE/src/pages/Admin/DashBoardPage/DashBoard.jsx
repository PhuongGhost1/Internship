import React from "react";
import "./DashBoard.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import Weekly from "../../../components/Admin/Weekly/Weekly";
import Statistics from "../../../components/Admin/Statistics/Statistics";
import Analytics from "../../../components/Admin/Analytics/Analytics";
import Order from "../../../components/Admin/Order/Order";

export default function DashBoard() {
  return (
    <div id="DashBoard">
      <div className="Header">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar />
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
              <Analytics/>
              <Order />
              </div>
            
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
