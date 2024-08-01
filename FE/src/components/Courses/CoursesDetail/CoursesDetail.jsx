import React, { useEffect, useState } from "react";
import "./CoursesDetail.css";
import { FaHeart, FaRegHeart } from "react-icons/fa";
import { SlUserFollow, SlUserFollowing } from "react-icons/sl";
import Box from "@mui/material/Box";
import Rating from "@mui/material/Rating";
import ApiService from "../../../api/ApiService";
import PropTypes from "prop-types";
import { useNavigate } from "react-router-dom";

function CoursesDetail({ courseData, onStatusUpdate, user }) {
  const [isFollowing, setIsFollowing] = useState(false);
  const [isSaved, setIsSaved] = useState(false);
  const [isEnrolled, setIsEnrolled] = useState(false);
  const [isInCartUser, setIsInCartUser] = useState(false);
  const nav = useNavigate();

  useEffect(() => {
    const checkCourseStatus = async () => {
      if (courseData) {
        setIsFollowing(courseData.user?.statusFollowing || false);
        setIsSaved(courseData.saveCourses?.[0]?.statusSaveCourse || false);
        setIsEnrolled(courseData.isEnrolled || false);
        setIsInCartUser(courseData.isInCart || false);
      }
    };

    checkCourseStatus();
  }, [courseData]);

  const handleStatusChangeForFollowing = async (FollowerId, FollowedId) => {
    if (user) {
      try {
        if (isFollowing) {
          await ApiService.removeFollowing(FollowerId, FollowedId);
        } else {
          await ApiService.createFollowing(FollowerId, FollowedId);
        }
        setIsFollowing(!isFollowing);
        onStatusUpdate();
      } catch (error) {
        console.error("Error updating following status:", error);
      }
    } else {
      nav("/login");
    }
  };

  const handleStatusChangeForSaveCourse = async (CourseId, UserId) => {
    if (user) {
      try {
        if (isSaved) {
          await ApiService.removeSaveCourse(courseData.saveCourses[0].id);
        } else {
          await ApiService.createSaveCourse(CourseId, UserId);
        }
        setIsSaved(!isSaved);
        onStatusUpdate();
      } catch (error) {
        console.error("Error updating save course status:", error);
      }
    } else {
      nav("/login");
    }
  };

  const handleEnrollButtonClick = async () => {
    if (user) {
      if (isEnrolled) {
        nav(`/courses/learning/${courseData?.name}/:courseType/:itemName`);
      } else {
        try {
          const response = await ApiService.getCart(user?.id);

          if (response && response.carts && response.carts.length > 0) {
            const cart = response.carts[0];

            if (!cart.id) {
              console.error("No cart ID found for user.");
              return;
            }

            const isInCart = await ApiService.checkCourseInCart(
              cart.id,
              courseData?.id,
            );

            if (isInCart) {
              alert("The course is already in the cart.");
              return;
            }
          }

          await ApiService.addCourseToCart(courseData?.id, user?.id);
          nav("/student/cart");
        } catch (error) {
          console.error("Error adding course to cart:", error);
        }
      }
    } else {
      nav("/login");
    }
  };

  return (
    <div id="courses-detail">
      <p className="courses-title">{courseData?.name}</p>
      <button
        onClick={() =>
          handleStatusChangeForSaveCourse(courseData?.id, user?.id)
        }
        className="heart-button"
      >
        {isSaved ? <FaHeart /> : <FaRegHeart />}
      </button>
      <div className="courses-categories">
        {courseData?.cateCoruse?.map((categoryCourse, index) => (
          <a href="#" key={index} className="category">
            {categoryCourse?.category?.names}
          </a>
        ))}
      </div>
      <div className="star-ins-sub">
        <div className="rating-author">
          <Box sx={{ "& > legend": { mt: 2 } }}>
            <Rating name="read-only" value={courseData?.rating} readOnly />
          </Box>
          <span className="by">By</span>
          <a href={`/user/${courseData?.user?.id}`} className="author">
            {courseData?.user?.name}
          </a>
          <div className="Subscribe">
            <button
              onClick={() =>
                handleStatusChangeForFollowing(user?.id, courseData?.user?.id)
              }
              className={`follow-button ${
                isFollowing ? "following" : "not-following"
              }`}
            >
              {isFollowing ? (
                <>
                  <SlUserFollow className="icon" />
                  Unsubscribe
                </>
              ) : (
                <>
                  <SlUserFollowing className="icon" />
                  Subscribe
                </>
              )}
            </button>
          </div>
        </div>
      </div>
      <p className="introduction">{courseData?.description}</p>
      <div className="enroll-btn">
        <div className="text" onClick={handleEnrollButtonClick}>
          <h10>
            {isEnrolled ? "Enroll" : isInCartUser ? "Already In Cart" : "Buy"}
          </h10>
        </div>
      </div>
    </div>
  );
}

const FollowInfoPropType = PropTypes.shape({
  id: PropTypes.string.isRequired,
  email: PropTypes.string,
  name: PropTypes.string,
  images: PropTypes.arrayOf(PropTypes.string),
  coursesCount: PropTypes.number,
  followerCount: PropTypes.number,
  followedCount: PropTypes.number,
  courses: PropTypes.arrayOf(PropTypes.object),
  followFolloweds: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.string.isRequired,
      email: PropTypes.string,
      name: PropTypes.string,
      images: PropTypes.arrayOf(PropTypes.string),
      coursesCount: PropTypes.number,
      followerCount: PropTypes.number,
      followedCount: PropTypes.number,
      courses: PropTypes.arrayOf(PropTypes.object),
      followFolloweds: PropTypes.arrayOf(PropTypes.object),
      followFollowers: PropTypes.arrayOf(PropTypes.object),
      statusFollowing: PropTypes.bool,
    }),
  ),
  followFollowers: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.string.isRequired,
      email: PropTypes.string,
      name: PropTypes.string,
      images: PropTypes.arrayOf(PropTypes.string),
      coursesCount: PropTypes.number,
      followerCount: PropTypes.number,
      followedCount: PropTypes.number,
      courses: PropTypes.arrayOf(PropTypes.object),
      followFolloweds: PropTypes.arrayOf(PropTypes.object),
      followFollowers: PropTypes.arrayOf(PropTypes.object),
      statusFollowing: PropTypes.bool,
    }),
  ),
  statusFollowing: PropTypes.bool,
});

CoursesDetail.propTypes = {
  courseData: PropTypes.shape({
    id: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired,
    rating: PropTypes.number,
    description: PropTypes.string,
    isEnrolled: PropTypes.bool,
    isInCart: PropTypes.bool,
    cateCoruse: PropTypes.arrayOf(
      PropTypes.shape({
        id: PropTypes.string.isRequired,
        createdAt: PropTypes.string,
        category: PropTypes.shape({
          id: PropTypes.string.isRequired,
          name: PropTypes.string.isRequired,
          names: PropTypes.arrayOf(PropTypes.string),
        }),
      }),
    ),
    saveCourses: PropTypes.arrayOf(
      PropTypes.shape({
        id: PropTypes.string.isRequired,
        statusSaveCourse: PropTypes.bool,
        course: PropTypes.shape({
          id: PropTypes.string.isRequired,
          name: PropTypes.string.isRequired,
          rating: PropTypes.number,
          price: PropTypes.number,
        }),
        user: PropTypes.shape({
          id: PropTypes.string.isRequired,
          name: PropTypes.string,
          email: PropTypes.string,
        }),
      }),
    ),
    user: PropTypes.shape({
      id: PropTypes.string.isRequired,
      name: PropTypes.string.isRequired,
      email: PropTypes.string,
      images: PropTypes.arrayOf(PropTypes.string),
      coursesCount: PropTypes.number,
      followerCount: PropTypes.number,
      followedCount: PropTypes.number,
      courses: PropTypes.arrayOf(PropTypes.object),
      followFolloweds: PropTypes.arrayOf(FollowInfoPropType),
      followFollowers: PropTypes.arrayOf(FollowInfoPropType),
      statusFollowing: PropTypes.bool,
    }),
  }),
  onStatusUpdate: PropTypes.func.isRequired,
  user: PropTypes.shape({
    id: PropTypes.string.isRequired,
    username: PropTypes.string.isRequired,
  }).isRequired,
};

export default CoursesDetail;
