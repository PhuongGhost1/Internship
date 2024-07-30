import React, { useContext, useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import "./CourseLearning.css";

import Header from "../../../components/Items/Header/Header";
import CourseSlideBar from "../../../components/Courses/CourseLearning/CourseSlideBar/CourseSlideBar";
import CourseVideoContent from "../../../components/Courses/CourseLearning/CourseVideoContent/CourseVideoContent";
import CourseQuizContent from "../../../components/Courses/CourseLearning/CourseQuizContent/CourseQuizContent";
import ApiService from "../../../api/ApiService";
import { AuthContext } from "../../Context/AuthContext";

export default function CourseLearning() {
  const { courseName, courseType, itemName } = useParams();
  const [courseId, setCourseId] = useState(null);
  const [courseContent, setCourseContent] = useState([]);
  const { user, roles } = useContext(AuthContext);
  const nav = useNavigate();

  useEffect(() => {
    if (!user) {
      nav("/login");
    } else if (
      !roles.some((role) => ["Instructor", "Student"].includes(role))
    ) {
      nav("/login");
    }
  }, [user, roles, nav]);

  useEffect(() => {
    fetchCourseData(courseName);
  }, []);

  useEffect(() => {
    fetchCourseContent(courseId);
  }, [courseId]);

  const fetchCourseData = async (courseName) => {
    const data = await ApiService.getCourseByName(courseName);
    setCourseId(data.id);
  };

  const fetchCourseContent = async (courseId) => {
    const data = await ApiService.getCourseContent(courseId);
    setCourseContent(data.chapters);
  };

  return (
    <div id="course-learning">
      <Header />
      <div className="body-container">
        <div className="course-slide-bar-container">
          <CourseSlideBar
            data={courseContent}
            courseName={courseName}
            itemName={itemName}
          />
        </div>
        <div className="content-container">
          {courseType === "lecture" && (
            <CourseVideoContent lectureName={itemName} />
          )}
          {courseType === "quiz" && <CourseQuizContent hashCode={itemName} />}
        </div>
      </div>
    </div>
  );
}
