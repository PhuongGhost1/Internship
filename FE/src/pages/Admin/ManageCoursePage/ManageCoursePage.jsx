import React from "react";
import "./ManageCoursePage.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import PostedCourse from "../../../components/Admin/ManageCourse/PostedCourse/PostedCourse";
import CourseStatus from "../../../components/Admin/ManageCourse/CourseStatus/CourseStatus";
import Angular_logo from "../../..//assets/Angular_logo.png";

export default function ManageCoursePage() {
  const data = [
    { id: 1, name: "Klein Inc", owner: "Oscar Martinez", status: "Active", contacts: [Angular_logo] },
    { id: 2, name: "Weissnat - Schultz", owner: "Phyllis Smith", status: "Cancel", contacts: [Angular_logo, Angular_logo] },
    { id: 3, name: "McClure, Hills and Bahringer", owner: "Meredith Palmer", status: "Active", contacts: [Angular_logo, Angular_logo] },
    { id: 4, name: "Thompson - Zieme", owner: "Angela Martin", status: "Active", contacts: [Angular_logo, Angular_logo] },
    { id: 5, name: "Batz - Greenholt", owner: "Meredith Palmer", status: "Waiting", contacts: [Angular_logo, Angular_logo] },
    { id: 6, name: "Bruen, Willms and Marquardt", owner: "Pam Beesly", status: "Waiting", contacts: [Angular_logo] },
    { id: 7, name: "Botsford - Dach", owner: "Stanley Hudson", status: "Cancel", contacts: [Angular_logo] },
    { id: 8, name: "O'Connell - Lind", owner: "Michael Scott", status: "Active", contacts: [Angular_logo, Angular_logo] },
    { id: 9, name: "Crona - Donnelly", owner: "Stanley Hudson", status: "Active", contacts: [Angular_logo] },
    { id: 10, name: "Stoltenberg Group", owner: "Dwight Schrute", status: "Waiting", contacts: [Angular_logo] },
    { id: 11, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 12, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Cancel", contacts: [Angular_logo] },
    { id: 13, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 14, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 15, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 16, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 17, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 18, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 19, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 20, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 21, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 22, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 23, name: "Steuber, Yundt and Torp", owner: "Creed BrAatton", status: "Active", contacts: [Angular_logo] },
    { id: 24, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 25, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 26, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Cancel", contacts: [Angular_logo] },
    { id: 27, name: "Weimann - Shanahan", owner: "Ryan Howard", status: "Active", contacts: [Angular_logo] }
  ];



  return (
    <div id="ManageCoursePage">
      <div className="Header-Admin">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type='managecourse' />
        </div>

        <div className="Layout_Status_Posted">
          <div className="CourseStatus">
            <CourseStatus data={data} />
          </div>
          <div className="PostedCourse">
            <PostedCourse data={data} />
          </div>
        </div>
      </div>
    </div>
  );
}