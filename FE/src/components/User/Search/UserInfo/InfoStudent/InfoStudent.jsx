import React from "react";
import "./InfoStudent.css";
import user_background from '../../../../../assets/Infobackground.jpg';
import IntructorIMG2 from '../../../../../assets/IntructorIMG2.png';
import { IoLogoFacebook } from "react-icons/io5";
import { FaGithub } from "react-icons/fa6";
import { FaSquareInstagram } from "react-icons/fa6";

export default function InfoStudent() {
     return (
          <div id="InfoStudent">
               <div className="container-img">
                    <img src={user_background} alt="Background" />
               </div>
               <div className="info-container">
                    <div className="profile">
                         <img src={IntructorIMG2} alt="User Avatar" />
                         <div className="info">
                              <div className="name">Ronald Robertson</div>
                              <div className="title">Creative Director</div>
                              <div className="iconinfo">
                                   <IoLogoFacebook />
                                   <FaGithub />
                                   <FaSquareInstagram />
                              </div>
                         </div>
                    </div>
                    <div className="details">
                         <div className="detail-item">
                              <div className="label">EMAIL</div>
                              <div className="value">robe@example.com</div>
                         </div>
                         <div className="detail-item">
                              <div className="label">BIRTHDAY</div>
                              <div className="value">17 March, 1995</div>
                         </div>
                         <div className="detail-item">
                              <div className="label">PHONE</div>
                              <div className="value">+1 (070) 123-8459</div>
                         </div>
                         <div className="detail-item">
                              <div className="label">LOCATION</div>
                              <div className="value">New York, NY</div>
                         </div>
                    </div>
               </div>
          </div>
     );
}
