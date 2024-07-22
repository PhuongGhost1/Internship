import React, { useEffect, useState } from "react";
import "./ManageCoursePage.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import PostedCourse from "../../../components/Admin/ManageCourse/PostedCourse/PostedCourse";
import CourseStatus from "../../../components/Admin/ManageCourse/CourseStatus/CourseStatus";
import LoadingOverlay from "../../../components/LoadingOverlay";
import ApiService from "../../../api/ApiService";

export default function ManageCoursePage() {
  const [loading, setLoading] = useState(true);
  const [courseData, setCourseData] = useState([]);
  const [courseWaitingData, setCourseWaitingData] = useState([]);

  useEffect(() => {
    const fetchCourseData = async () => {
      try {
        const courseManaData = await ApiService.getCourseManagementByAdmin();
        setCourseData(courseManaData);
      } catch (error) {
        console.log("Error fetching course data: ", error);
      }
    };

    fetchCourseData();
  }, []);

  useEffect(() => {
    const fetchWaitingCourseData = async () => {
      try {
        const courseWaData =
          await ApiService.getCourseManagementForWaitingByAdmin();
        setCourseWaitingData(courseWaData);
      } catch (error) {
        console.log("Error fetching waiting course data: ", error);
      }
    };

    fetchWaitingCourseData();
  }, []);

  useEffect(() => {
    const timeLoading = () => {
      setTimeout(() => {
        setLoading(false);
      }, 3000);
    };
    timeLoading();
  }, []);

  const handleStatusUpdate = async () => {
    try {
      const updatedCourseData = await ApiService.getCourseManagementByAdmin();
      const courseWaData =
        await ApiService.getCourseManagementForWaitingByAdmin();
      setCourseData(updatedCourseData);
      setCourseWaitingData(courseWaData);
    } catch (error) {
      console.log("Error fetching updated course data: ", error);
    }
  };

  return (
    <div id="ManageCoursePage">
      <LoadingOverlay loading={loading} />
      <div className="Header-Admin">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type="managecourse" />
        </div>

        <div className="Layout_Status_Posted">
          <div className="CourseStatus">
            <CourseStatus
              data={courseData}
              onStatusUpdate={handleStatusUpdate}
            />
          </div>
          <div className="PostedCourse">
            <PostedCourse
              data={courseWaitingData}
              onStatusUpdate={handleStatusUpdate}
            />
          </div>
        </div>
      </div>
    </div>
  );
}
