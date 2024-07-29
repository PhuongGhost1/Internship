import React, { useContext, useEffect, useState } from "react";
import "./SettingPage.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import Setting from "../../../components/Admin/Setting/Setting";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function SettingPage() {
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

  return (
    <>
      {userId ? (
        <div id="SettingPage">
          <div className="Header-Admin">
            <Header />
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
      ) : (
        <p>No user</p>
      )}
    </>
  );
}
