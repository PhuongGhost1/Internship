import React from "react";
import "./InfoStudent.css";
import user_background from "../../../../../assets/Infobackground.jpg";
import { IoLogoFacebook } from "react-icons/io5";
import { FaGithub } from "react-icons/fa6";
import { FaSquareInstagram } from "react-icons/fa6";
import PropTypes from "prop-types";

export default function InfoStudent({ user }) {
  if (!user) return null;

  const { images, email, phone, description, username, dob } = user;
  const avatarUrl = images.find((img) => img.type === "Avatar")?.url || "";

  return (
    <div id="InfoStudent">
      <div className="container-img">
        <img src={user_background} alt="Background" />
      </div>
      <div className="info-container">
        <div className="profile">
          <img src={avatarUrl} alt="User Avatar" />
          <div className="info">
            <div className="name">{username || "No name available"}</div>
            <div className="title">
              {description || "No description available"}
            </div>
            <div className="iconinfo">
              <IoLogoFacebook />
              <FaGithub />
              <FaSquareInstagram />
            </div>
          </div>
        </div>
        <div className="details">
          <div className="detail-item">
            <div className="label">EMAIL</div>
            <div className="value">{email || "Not provided"}</div>
          </div>
          <div className="detail-item">
            <div className="label">BIRTHDAY</div>
            <div className="value">{dob || "Not provided"}</div>
          </div>
          <div className="detail-item">
            <div className="label">PHONE</div>
            <div className="value">{phone || "Not provided"}</div>
          </div>
          <div className="detail-item">
            <div className="label">LOCATION</div>
            <div className="value">New York, NY</div>
          </div>
        </div>
      </div>
    </div>
  );
}

InfoStudent.propTypes = {
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
