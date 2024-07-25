import React from "react";
import "./UserInfoPage.css";
import Header from "../../../components/Items/Header/Header";
import InfoStudent from "../../../components/User/Search/UserInfo/InfoStudent/InfoStudent";
import InfoFollow from "../../../components/User/Search/UserInfo/InfoFollow/InfoFollow";
import InfoRate from "../../../components/User/Search/UserInfo/InfoRate/InfoRate";
import InfoSlider from "../../../components/User/Search/UserInfo/InfoSlider/InfoSlider"
import Footer from "../../../components/Items/Footer/Footer";

export default function UserInfoPage() {
     return (
          <div id="UserInfoPage">
               <Header />
               <div className="infoStudent">
                    <InfoStudent />
               </div>
               <div className="FL-Rate">
                    <div className="Userfollow">
                         <InfoFollow />
                    </div>
                    <div className="Userrate">
                         <InfoRate />
                         <InfoSlider />

                    </div>
               </div>
               <Footer />
          </div>
     )
}