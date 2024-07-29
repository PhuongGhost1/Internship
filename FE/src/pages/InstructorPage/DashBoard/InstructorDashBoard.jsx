import React, { useContext, useEffect } from "react";
import "./InstructorDashBoard.css";
import Header from "../../../components/Items/Header/Header";
import ExploreNow from "../../../components/Instructor/InstructorDashboard/ExploreNow/ExploreNow";
import MyProtfolio from "../../../components/Instructor/InstructorDashboard/MyProtfolio/MyProtfolio";
import ProfileStatus from "../../../components/Instructor/InstructorDashboard/ProfileStatus/ProfileStatus";
import RecentActivities from "../../../components/Instructor/InstructorDashboard/RecentActivities/RecentActivities";
import StockMarket from "../../../components/Instructor/InstructorDashboard/StockMarket/StockMarket";
import Transaction from "../../../components/Instructor/InstructorDashboard/Transaction/Transaction";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function InstructorDashBoard() {
  const { user } = useContext(AuthContext);
  const nav = useNavigate();

  useEffect(() => {
    if (user) {
      console.log(user);
    } else {
      nav("/login");
    }
  }, []);
  return (
    <div id="InstructorDashBoard">
      <Header />
      <div className="Container">
        <div className="Container-One">
          <ExploreNow />
          <MyProtfolio />
          <ProfileStatus />
        </div>

        <div className="Container-Two">
          <RecentActivities />
          <StockMarket />
          <Transaction />
        </div>
      </div>
    </div>
  );
}
