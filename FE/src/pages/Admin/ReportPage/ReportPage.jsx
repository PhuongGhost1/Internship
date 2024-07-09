import React from "react";
import './ReportPage.css';
import Report from "../../../components/Admin/Report/Report";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";

export default function ReportPage() {
     return (
          <div id="ReportPage">
               <div className="Header-Admin">
                    <Header />
               </div>
               <div className="Layout">
                    <div className="SideBar-container">
                         <SideBar type='report' />
                    </div>
                    <div className="Layout-container">
                         <div className="Report-container">
                              <Report />
                         </div>
                    </div>
               </div>
          </div>
     );
}
