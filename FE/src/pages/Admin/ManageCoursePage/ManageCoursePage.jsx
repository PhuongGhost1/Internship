import React from "react";
import "./ManageCoursePage.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import PostedCourse from "../../../components/Admin/ManageCourse/PostedCourse/PostedCourse";
import CourseSold from "../../../components/Admin/ManageCourse/CourseSold/CourseSold";
import CourseStatus from "../../../components/Admin/ManageCourse/CourseStatus/CourseStatus";

export default function ManageCoursePage() {
  return (
    <div id="ManageCoursePage">
      <div className="Header-Admin">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type = 'managecourse'/>
        </div>

        <div className="Layout_Status_Posted">
          <div className="CourseStatus">
               <CourseStatus/>
          </div>
          <div className="PostedCourse">
               <PostedCourse/>
               <CourseSold/>
          </div>
        </div>
   



      </div>
    </div>
  );
}