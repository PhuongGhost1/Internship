import React from "react";
import './SettingPage.css';
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import Setting from "../../../components/Admin/Setting/Setting";

export default function SettingPage(){
     return (
          <div id="SettingPage">
         <div className="Header-Admin">
                    <Header />
               </div>
               <div className="Layout">
                    <div className="SideBar-container">
                         <SideBar type='setting' />
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
