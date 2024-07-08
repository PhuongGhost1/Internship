import React from "react";
import './FeedBackAdminPage.css';
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import FeedBackAdmin from "../../../components/Admin/FeedBackAdmin/FeedBackAdmin";

export default function FeedBackAdminPage(){
     return(
          <div id="FeedBack">
               <div className="Header-Admin">
                    <Header />
               </div>
               <div className="Layout">
                    <div className="SideBar-container">
                         <SideBar type='feedback' />
                    </div>
                    <div className="FeedBack-container">
                         <div className="FeedBack-container">
                              <FeedBackAdmin />
                         </div>
                    </div>
               </div>
          </div>
     );
}
