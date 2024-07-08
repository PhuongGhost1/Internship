import React from "react";
import "./ManageCoursePage.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import PostedCourse from "../../../components/Admin/ManageCourse/PostedCourse/PostedCourse";
import CourseStatus from "../../../components/Admin/ManageCourse/CourseStatus/CourseStatus";
import Angular_logo from "../../..//assets/Angular_logo.png";

export default function ManageCoursePage() {
  const data = [
    { id: 1, name: "Klein Inc", owner: "Oscar Martinez", status: "Active", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "100", rating: "4.5" },
    { id: 2, name: "Weissnat - Schultz", owner: "Phyllis Smith", status: "Cancel", contacts: [Angular_logo, Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "200", rating: "4.0" },
    { id: 3, name: "McClure, Hills and Bahringer", owner: "Meredith Palmer", status: "Active", contacts: [Angular_logo, Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "$150", rating: "4.8" },
    { id: 4, name: "Thompson - Zieme", owner: "Angela Martin", status: "Active", contacts: [Angular_logo, Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "120", rating: "4.2" },
    { id: 5, name: "Batz - Greenholt", owner: "Meredith Palmer", status: "Waiting", contacts: [Angular_logo, Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "130", rating: "4.1" },
    { id: 6, name: "Bruen, Willms and Marquardt", owner: "Pam Beesly", status: "Waiting", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "170", rating: "4.6" },
    { id: 7, name: "Botsford - Dach", owner: "Stanley Hudson", status: "Cancel", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "160", rating: "3.9" },
    { id: 8, name: "O'Connell - Lind", owner: "Michael Scott", status: "Waiting", contacts: [Angular_logo, Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "110", rating: "4.3" },
    { id: 9, name: "Crona - Donnelly", owner: "Stanley Hudson", status: "Active", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "180", rating: "4.7" },
    { id: 10, name: "Stoltenberg Group", owner: "Dwight Schrute", status: "Waiting", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "140", rating: "4.4" },
    { id: 11, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "190", rating: "4.9" },
    { id: 12, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Cancel", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "200", rating: "4.0" },
    { id: 13, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "210", rating: "3.8" },
    { id: 14, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "220", rating: "4.1" },
    { id: 15, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "230", rating: "4.2" },
    { id: 16, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "240", rating: "4.3" },
    { id: 17, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "250", rating: "4.4" },
    { id: 18, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "260", rating: "4.5" },
    { id: 19, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "270", rating: "4.6" },
    { id: 20, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "280", rating: "4.7" },
    { id: 21, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "290", rating: "4.8" },
    { id: 22, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "300", rating: "4.9" },
    { id: 23, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "310", rating: "5.0" },
    { id: 24, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "320", rating: "4.5" },
    { id: 25, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "330", rating: "4.6" },
    { id: 26, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Cancel", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "340", rating: "4.7" },
    { id: 27, name: "Weimann - Shanahan", owner: "Ryan Howard", status: "Active", contacts: [Angular_logo], description: "AngularJS is a powerful web application framework. It is a very useful tool for web developers who want to use web applications in a variety of scenarios. AngularJS can also be used to create HTML pages in different ways. I just wanted to eat some fish. ", price: "350", rating: "4.8" }
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