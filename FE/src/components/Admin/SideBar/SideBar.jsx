import React from "react";
import './SideBar.css';

export default function Sidebar() {
    return (
        <div id="sidebar">

            <div className="sidebar-item">
                <a className="sidebar-text">Dasboard</a>
            </div>

            <div className="sidebar-item">
                <a className="sidebar-text">Account Management</a>

                <div className="sidebar-container">
                    <a>Student List</a>
                    <a>Instructor List</a>
                </div>

            </div>

            <div className="sidebar-item">
                <a className="sidebar-text">Course Management</a>

                <div className="sidebar-container">
                    <a>Request Management</a>
                    <a>Course List</a>
                </div>

            </div>

            <div className="sidebar-item">
                <a className="sidebar-text">Feedback Management</a>

                <div className="sidebar-container">
                    <a>Request Management</a>
                    <a>Feedback List</a>
                    <a>Report Request</a>
                </div>

            </div>

        </div>
    )
}