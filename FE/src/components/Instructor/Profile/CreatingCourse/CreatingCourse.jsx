import React, { useEffect, useState } from "react";
import "./CreatingCourse.css";

import { FaArrowRight } from "react-icons/fa";
import ApiService from "../../../../api/ApiService";

export default function CreatingCourse() {
  const [userData, setUserData] = useState([]);

  useEffect(() => {
    const fetchCreatingCoursesData = async () => {
      try {
        const data = await ApiService.getWaitingCourses("user_400182aadc");
        setUserData(data);
      } catch (error) {
        console.log("Error fetching creating courses: ", error);
      }
    };

    fetchCreatingCoursesData();
  }, []);

  if (!userData) {
    return <div>Loading...</div>;
  }

  if (!userData.courses || !Array.isArray(userData.courses)) {
    return <div>Loading...</div>;
  }

  return (
    <div id="creating-course">
      <div className="creating-title">
        <h3 className="creating-course-title">Draft</h3>
      </div>
      <div id="creating">
        {userData ? (
          userData.courses.map((course, index) => (
            <div
              key={index}
              className="creating-course-item"
              id={`creating-course-title-${index}`}
            >
              <div className="creating-course-header">
                <div className="creating-course-image">
                  {course.images && course.images.length > 0 && (
                    <img src={course.images[0].url} alt={course.name} />
                  )}
                </div>
                <div className="creating-course-details">
                  <h4 id={`course-title-${index}`}>{course.name}</h4>{" "}
                  <a
                    href={`/courses/${course.name}`}
                    className="view-course-detail"
                    id={`view-course-detail-${index}`}
                  >
                    View course detail
                  </a>
                </div>
                <div className="creating-course-button">
                  <a href="#">
                    Continue <FaArrowRight />
                  </a>
                </div>
              </div>
            </div>
          ))
        ) : (
          <p>No draft courses available.</p>
        )}
      </div>
    </div>
  );
}
