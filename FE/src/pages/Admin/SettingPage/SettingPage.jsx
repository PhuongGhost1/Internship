import React, { useContext, useEffect } from "react";
import "./SettingPage.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import Setting from "../../../components/Admin/Setting/Setting";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function SettingPage() {
  const { user, roles } = useContext(AuthContext);
  const nav = useNavigate();

  useEffect(() => {
    if (!user) {
      nav("/login");
    } else if (!roles.includes("Admin")) {
      nav("/error");
    }
  }, [user, roles, nav]);

  return (
    <div id="SettingPage">
      <div className="Header-Admin">
        <Header user={user} />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type="setting" />
        </div>
        <div className="Layout-container">
          <div className="Setting-container">
            <Setting />
          </div>
        </div>
      </div>
    </div>
  );
}
