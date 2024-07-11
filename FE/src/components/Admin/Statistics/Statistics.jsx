import React, { useState, useEffect } from "react";
import ApiService from "../../../api/ApiService";

export default function Statistics() {
  const [courseData, setCourseData] = useState([]);

  useEffect(() => {
    const fetchMostPurchasedCourses = async () => {
      try {
        const mostPurchasedCourses = await ApiService.getMostPurchasedCourses();
        setCourseData(mostPurchasedCourses);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchMostPurchasedCourses();
  }, []);

  return (
    <div id="Statistics">
      <h2>Most Purchased Courses</h2>
      {courseData.length === 0 ? (
        <div className="course-item">Chưa có thông tin nào hiện có.</div>
      ) : (
        courseData.map((course, index) => (
          <div key={index} className="course-item">
            <div>
              <h4>{course.title}</h4>
              <p>{course.date}</p>
            </div>
            <div className={`course-status ${course.status.toLowerCase()}`}>
              <p>{course.status}</p>
              <p>{course.id}</p>
            </div>
          </div>
        ))
      )}
    </div>
  );
}
