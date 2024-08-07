import React, { useState } from "react";
import "./InfoSlider.css";
import Background from "../../../../../assets/background-user1.jpg";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

export default function InfoSlider({ user }) {
  const [currentIndex, setCurrentIndex] = useState(0);
  const maxVisibleCards = 4;
  if (!user || !user.courses) return null;
  const { courses } = user;

  const handlePrevClick = () => {
    if (currentIndex > 0) {
      setCurrentIndex(currentIndex - 1);
    }
  };

  const handleNextClick = () => {
    if (currentIndex < courses.length - maxVisibleCards) {
      setCurrentIndex(currentIndex + 1);
    }
  };

  return (
    <div id="InfoSlider">
      <button onClick={handlePrevClick} className="slider-arrow left-arrow">
        &#8592;
      </button>
      <div className="card-container">
        {courses.length > 0 &&
          courses
            .slice(currentIndex, currentIndex + maxVisibleCards)
            .map((card, index) => (
              <Link to={`/courses/${card.name}`} key={card.id || index}>
                <div className="card">
                  <img
                    src={
                      card.images.find((img) => img.type === "Background")
                        ?.url || Background
                    }
                    alt={card.name}
                    className="card-img"
                  />
                  <div className="card-content">
                    <div className="card-category">
                      {card.cateCoruse[0]?.category?.names.join(", ") ||
                        "No Category"}
                    </div>
                    <div className="card-title">{card.name}</div>
                    <div className="card-details">
                      <span>{card.processings} Lessons</span>
                      <span>{card.estimatedLearningTime} mins</span>
                    </div>
                  </div>
                </div>
              </Link>
            ))}
      </div>
      <button onClick={handleNextClick} className="slider-arrow right-arrow">
        &#8594;
      </button>
    </div>
  );
}

InfoSlider.propTypes = {
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
      }),
    ),
    courses: PropTypes.arrayOf(
      PropTypes.shape({
        id: PropTypes.string.isRequired,
        name: PropTypes.string.isRequired,
        processings: PropTypes.number,
        estimatedLearningTime: PropTypes.number,
        images: PropTypes.arrayOf(
          PropTypes.shape({
            id: PropTypes.string,
            url: PropTypes.string,
            type: PropTypes.string,
            lastUpdated: PropTypes.string,
          }),
        ),
        cateCoruse: PropTypes.arrayOf(
          PropTypes.shape({
            id: PropTypes.string,
            category: PropTypes.shape({
              names: PropTypes.arrayOf(PropTypes.string),
              cateId: PropTypes.string,
              name: PropTypes.string,
              isVisible: PropTypes.bool,
            }),
            course: PropTypes.object,
            createdAt: PropTypes.string,
          }),
        ),
      }),
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
          }),
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
              }),
            ),
          }),
        ),
        followFollowers: PropTypes.array,
      }),
    ),
  }),
};
