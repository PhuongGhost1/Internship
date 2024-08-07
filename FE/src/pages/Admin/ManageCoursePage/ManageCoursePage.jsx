import React, { useContext, useEffect, useState } from "react";
import "./ManageCoursePage.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import PostedCourse from "../../../components/Admin/ManageCourse/PostedCourse/PostedCourse";
import CourseStatus from "../../../components/Admin/ManageCourse/CourseStatus/CourseStatus";
import LoadingOverlay from "../../../components/LoadingOverlay";
import ApiService from "../../../api/ApiService";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

export default function ManageCoursePage() {
  const [loading, setLoading] = useState(true);
  const [courseData, setCourseData] = useState([]);
  const [courseWaitingData, setCourseWaitingData] = useState([]);
  const { user, roles } = useContext(AuthContext);
  const nav = useNavigate();

  useEffect(() => {
    if (!user) {
      nav("/login");
    } else if (!roles.includes("Admin")) {
      nav("/error");
    }
  }, [user, roles, nav]);

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
      }, 2000);
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
      <ToastContainer
        style={{ position: "fixed", top: 60, right: 20, zIndex: 9999 }}
      />
      <LoadingOverlay loading={loading} />
      <div className="Header-Admin">
        <Header user={user} />
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
