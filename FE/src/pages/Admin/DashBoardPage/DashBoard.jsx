import React from "react";
import './DashBoard.css';
import Header from "../../../components/Admin/Header/Header";
import SlideBar from "../../../components/Admin/SideBar/SlideBar";
import Weekly from "../../../components/Admin/Weekly/Weekly";
import Statistics from "../../../components/Admin/Statistics/Statistics";


export default function DashBoard() {
    return (
        <div id="DashBoard">
            <div className="Header">
                <Header />
            </div>
            <div className="Layout">
                <div className="SlideBar-container">
                    <SlideBar />
                </div>
                <div className="Weekly-container">
                    <Weekly />
                    <Statistics />
                </div>
            </div>
        </div>
    );
}