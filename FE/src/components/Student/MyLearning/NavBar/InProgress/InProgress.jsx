import React, { useState, useEffect } from "react";
import "./InProgress.css";
import ApiService from "../../../../../api/ApiService";
import PropTypes from "prop-types";

import { IoInformationCircleOutline } from "react-icons/io5";
import { IoIosArrowDown, IoIosArrowUp } from "react-icons/io";
import { Link } from "react-router-dom";

function InProgress({ user }) {
  const [showAll, setShowAll] = useState(false);
  const [itemShow, setItemShow] = useState(3);
  const [searchTerm, setSearchTerm] = useState("");
  const [courses, setCourses] = useState([]);

  useEffect(() => {
    const fetchInProgressData = async () => {
      try {
        const certificationData =
          await ApiService.ViewUserPurchasedCoursesWithDetails(user.id);

        setCourses(
          certificationData.map((cert) => ({
            title: cert.courseName,
            institution: cert.user.name,
            fields: cert.cateCoruse.map((cat) => cat.category.name),
            imageSrc: cert.images[0]?.url || "",
            certificateLink: `/courses/learning/${cert.courseName}/:courseType/:itemName`,
            courseName: cert.courseName,
            userId: cert.userId,
            progress: calculateCourseProgress(cert.userProgress),
          })),
        );
      } catch (error) {
        console.log("Error fetching in-progress courses: ", error);
      }
    };

    fetchInProgressData();
  }, [user.id]);

  const calculateCourseProgress = (chapters) => {
    const totalLectures = chapters.reduce(
      (acc, chapter) => acc + chapter.lectureCount,
      0,
    );
    const totalQuizzes = chapters.reduce(
      (acc, chapter) => acc + chapter.quizCount,
      0,
    );

    const completedLectures = chapters.reduce(
      (acc, chapter) => acc + chapter.completedLectures,
      0,
    );
    const completedQuizzes = chapters.reduce(
      (acc, chapter) => acc + chapter.completedQuizzes,
      0,
    );

    const totalItems = totalLectures + totalQuizzes;
    const completedItems = completedLectures + completedQuizzes;

    return totalItems === 0 ? 0 : (completedItems / totalItems) * 100;
  };

  const handleShowMore = () => {
    if (itemShow === 3) {
      setItemShow(courses.length);
      setShowAll(true);
    } else {
      setItemShow(3);
      setShowAll(false);
    }
  };

  const filteredCourses = courses.filter((course) =>
    course.title.toLowerCase().includes(searchTerm.toLowerCase()),
  );

  return (
    <div id="InProgress">
      <div className="courses-title">
        <h3 className="education-title">Learning Courses</h3>
        <IoInformationCircleOutline className="info-icon" />
      </div>

      <div id="search-bar">
        <input
          type="text"
          placeholder="Search Courses..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
      </div>

      <div id="courses">
        <div className="courses-container">
          {filteredCourses.map((course, index) => (
            <div
              key={index}
              className="course-item"
              id={`course-item-${index}`}
              style={index < itemShow ? {} : { display: "none" }}
            >
              <div className="course-header">
                <div className="course-image">
                  <img src={course.imageSrc} alt={course.title} />
                </div>
                <div className="course-details">
                  <h3 id={`course-title-${index}`}>{course.title}</h3>
                  <p id={`institution-${index}`}>{course.institution}</p>
                  <div className="fields" id={`fields-${index}`}>
                    {course.fields.map((field, i) => (
                      <span
                        key={i}
                        className="field-tag"
                        id={`field-tag-${index}-${i}`}
                      >
                        {field}
                      </span>
                    ))}
                  </div>
                  <div className="progress-bar">
                    <div
                      className="progress"
                      style={{ width: `${course.progress}%` }}
                    ></div>
                  </div>
                  {/* <a href={course.certificateLink} className="view-certificate" id={`view-certificate-${index}`}>
                                        Resume
                                    </a> */}
                </div>

                <div>
                  <Link to={course.certificateLink}>
                    <button
                      className="view-certificate"
                      id={`view-certificate-${index}`}
                    >
                      Resume
                    </button>
                  </Link>
                </div>
              </div>
            </div>
          ))}
        </div>
        <div className="show-more">
          <button className="show-all" onClick={handleShowMore}>
            {showAll ? (
              <IoIosArrowUp className="arrow" />
            ) : (
              <IoIosArrowDown className="arrow" />
            )}
            {showAll ? "Show less" : "Show more"}
          </button>
        </div>
      </div>
    </div>
  );
}

InProgress.propTypes = {
  user: PropTypes.shape({
    id: PropTypes.string.isRequired,
    username: PropTypes.string.isRequired,
  }).isRequired,
};

export default InProgress;
