import React from "react";
import "./InfoRate.css";
import { PiStudentBold } from "react-icons/pi";
import { SiCoursera } from "react-icons/si";
import { MdOutlineStar } from "react-icons/md";
import { FaLongArrowAltUp, FaLongArrowAltDown } from "react-icons/fa";
import PropTypes from "prop-types";

export default function InfoRate({ user }) {
  if (!user) return null;

  const { totalStudents, totalCourses, averageRatingForCourses } = user;

  const studentChange = 5;
  const courseChange = -3;
  const ratingChange = 1.2;

  const getArrowAndColor = (value) => {
    const color = value > 0 ? "green" : "red";
    const arrow =
      value > 0 ? (
        <FaLongArrowAltUp style={{ color }} />
      ) : (
        <FaLongArrowAltDown style={{ color }} />
      );
    return { arrow, color };
  };

  const { arrow: studentArrow, color: studentColor } =
    getArrowAndColor(studentChange);
  const { arrow: courseArrow, color: courseColor } =
    getArrowAndColor(courseChange);
  const { arrow: ratingArrow, color: ratingColor } =
    getArrowAndColor(ratingChange);

  return (
    <div id="InfoRate">
      <div className="rateinfo-container">
        <div className="stat">
          <div className="stat-icon">
            <p>
              <PiStudentBold />
            </p>
          </div>
          <div className="stat-value">
            <span>{totalStudents}</span>
            <span className="stat-change" style={{ color: studentColor }}>
              {studentArrow} {Math.abs(studentChange)}%
            </span>
          </div>
          <div className="stat-title">
            <p>Total Students</p>
          </div>
        </div>

        <div className="stat">
          <div className="stat-icon">
            <p>
              <SiCoursera />
            </p>
          </div>
          <div className="stat-value">
            <span>{totalCourses}</span>
            <span className="stat-change" style={{ color: courseColor }}>
              {courseArrow} {Math.abs(courseChange)}%
            </span>
          </div>
          <div className="stat-title">
            <p>Total Courses</p>
          </div>
        </div>

        <div className="stat">
          <div className="stat-icon">
            <p>
              <MdOutlineStar />
            </p>
          </div>
          <div className="stat-value">
            <span>{averageRatingForCourses}</span>
            <span className="stat-change" style={{ color: ratingColor }}>
              {ratingArrow} {Math.abs(ratingChange)}%
            </span>
          </div>
          <div className="stat-title">
            <p>Average Rating</p>
          </div>
        </div>
      </div>
    </div>
  );
}

InfoRate.propTypes = {
  user: PropTypes.shape({
    id: PropTypes.string,
    username: PropTypes.string,
    description: PropTypes.string,
    email: PropTypes.string,
    dob: PropTypes.string,
    phone: PropTypes.string,
    totalStudents: PropTypes.number,
    totalCourses: PropTypes.number,
    averageRatingForCourses: PropTypes.number,
    images: PropTypes.arrayOf(
      PropTypes.shape({
        id: PropTypes.string,
        url: PropTypes.string,
        type: PropTypes.string,
        lastUpdated: PropTypes.string,
      })
    ),
    courses: PropTypes.arrayOf(
      PropTypes.shape({
        id: PropTypes.string,
        name: PropTypes.string,
        processings: PropTypes.number,
        estimatedLearningTime: PropTypes.number,
        images: PropTypes.arrayOf(
          PropTypes.shape({
            id: PropTypes.string,
            url: PropTypes.string,
            type: PropTypes.string,
            lastUpdated: PropTypes.string,
          })
        ),
      })
    ),
    followFollowers: PropTypes.arrayOf(
      PropTypes.shape({
        id: PropTypes.string,
        username: PropTypes.string,
        description: PropTypes.string,
        email: PropTypes.string,
        dob: PropTypes.string,
        phone: PropTypes.string,
        totalStudents: PropTypes.number,
        totalCourses: PropTypes.number,
        averageRatingForCourses: PropTypes.number,
        images: PropTypes.arrayOf(
          PropTypes.shape({
            id: PropTypes.string,
            url: PropTypes.string,
            type: PropTypes.string,
            lastUpdated: PropTypes.string,
          })
        ),
        courses: PropTypes.arrayOf(
          PropTypes.shape({
            id: PropTypes.string,
            name: PropTypes.string,
            processings: PropTypes.number,
            estimatedLearningTime: PropTypes.number,
            images: PropTypes.arrayOf(
              PropTypes.shape({
                id: PropTypes.string,
                url: PropTypes.string,
                type: PropTypes.string,
                lastUpdated: PropTypes.string,
              })
            ),
          })
        ),
        followFollowers: PropTypes.array,
      })
    ),
  }),
};
