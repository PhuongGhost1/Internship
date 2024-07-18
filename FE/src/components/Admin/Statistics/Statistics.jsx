import React, { useState, useEffect } from "react";
import './Statistics.css';
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
        <div className="Ranking">
          <div id="leaderboard">
            <div className="ribbon"></div>
            <table>
              <tbody>
                {courseData.map((course, index) => (
                  <tr key={index}>
                    <td className="number">{index + 1}</td>
                    <td className="name">{course.name}</td>
                    <td className="points">
                      {course.points}
                      {index === 0 && (
                        <img
                          className="gold-medal"
                          src="https://github.com/malunaridev/Challenges-iCodeThis/blob/master/4-leaderboard/assets/gold-medal.png?raw=true"
                          alt="gold medal"
                        />
                      )}
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      )}
    </div>
  );
}
