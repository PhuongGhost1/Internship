import React from "react";
import "./InfoFollow.css";
import IntructorIMG2 from "../../../../../assets/IntructorIMG2.png";
import PropTypes from "prop-types";

export default function InfoFollow({ user }) {
  if (!user || !user.followFollowers) return null;

  const { followFollowers } = user;

  return (
    <div id="InfoFollow">
      <div className="followinfo-container">
        <h3>Followers</h3>
        {followFollowers.length > 0 ? (
          followFollowers.map((follower, index) => (
            <div key={index} className="follow">
              <img
                src={
                  follower.images.find((img) => img.type === "Avatar")?.url ||
                  IntructorIMG2
                }
                alt={`${follower.username}'s avatar`}
                className="avatar"
              />
              <div className="info">
                <span className="name">
                  {follower.username === null
                    ? follower.email
                    : follower.username}
                </span>
                <span className="role">
                  {follower.description || "Not provided"}
                </span>
              </div>
            </div>
          ))
        ) : (
          <p>No followers found</p>
        )}
      </div>
    </div>
  );
}

InfoFollow.propTypes = {
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
