import React from "react";
import "./ExploreNow.css";
import { GrTransaction } from "react-icons/gr";
export default function ExploreNow() {
     return (
          <div id="ad-banner">
               <div className="ad-content">
                    <h1>My Transaction <GrTransaction /> </h1>
                    <p>Everything from revenue, fluctuations in account information...</p>
                    <button className="explore-button" ><a href="/instructor/profile"><strong>My Information</strong></a></button>
               </div>
          </div>
     );
}