import React from "react";
import "./RequestsPage.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import Requests from "../../../components/Admin/Requests/Requests";


export default function RequestsPage() {
     return (
          <div id="RequestsPage">
               <div className="Header-Admin">
                    <Header />
               </div>
               <div className="Layout">
                    <div className="SideBar-container">
                         <SideBar type='requests' />
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
