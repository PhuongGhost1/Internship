import React, { useEffect, useState } from "react";
import "./CoursesDetail.css";

import Box from "@mui/material/Box";
import Rating from "@mui/material/Rating";
import ApiService from "../../../api/ApiService";
import PropTypes from "prop-types";

function CoursesDetail({ courseData, onStatusUpdate }) {
  const [isSaved, setIsSaved] = useState(false);
  const [isFollowing, setIsFollowing] = useState(false);

  useEffect(() => {
    if (courseData) {
      setIsSaved(courseData.saveCourses.some((sc) => sc.statusSaveCourse));

      const isFollowingInstructor = courseData.user?.followFolloweds?.some(
        (follower) =>
          follower.id === "user_00ebd16723" && follower.statusFollowing
      );

      setIsFollowing(isFollowingInstructor ?? false);
    }
  }, [courseData]);

  const handleStatusChangeForFollowing = async (
    FollowerId,
    FollowedId,
    status
  ) => {
    try {
      if (status) {
        await ApiService.removeFollowing(FollowerId, FollowedId);
      } else {
        await ApiService.createFollowing(FollowerId, FollowedId);
      }
      onStatusUpdate();
      setIsFollowing(!status);
    } catch (error) {
      console.error("Error creating following: ", error);
      throw error;
    }
  };

  const handleStatusChangeForSaveCourse = async (CourseId, UserId) => {
    try {
      const saveCourse = courseData?.saveCourses?.find(
        (sc) => sc.course.id === CourseId
      );
      if (isSaved) {
        await ApiService.removeSaveCourse(saveCourse?.id);
      } else {
        await ApiService.createSaveCourse(CourseId, UserId);
      }
      onStatusUpdate();
      setIsSaved(!isSaved);
    } catch (error) {
      console.error("Error saving course: ", error);
      throw error;
    }
  };

  return (
    <div id="courses-detail">
      <p className="courses-title">{courseData?.name}</p>
      <button
        onClick={() =>
          handleStatusChangeForSaveCourse(courseData?.id, "user_00ebd16723")
        }
      >
        {isSaved ? "Already Saved" : "Save Course"}
      </button>
      <div className="courses-categories">
        {courseData?.cateCoruse?.map((categoryCourse, index) => (
          <a href="" key={index} className="category">
            {categoryCourse.category.names}
          </a>
        ))}
      </div>
      <div className="rating-author">
        <Box sx={{ "& > legend": { mt: 2 } }}>
          <Rating name="read-only" value={courseData?.rating} readOnly />
        </Box>
        <span className="by">By</span>
        <a href="" className="author">
          {courseData?.user?.name}
        </a>
        <button
          onClick={() =>
            handleStatusChangeForFollowing(
              "user_00ebd16723",
              courseData?.user?.id,
              courseData?.user?.statusFollowing
            )
          }
        >
          {courseData?.user?.statusFollowing
            ? "Already Following"
            : "Follow Instructor"}
        </button>
      </div>
      <p className="introduction">{courseData?.description}</p>
      <div className="enroll-btn">Enroll</div>
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
    })
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
    })
  ),
  statusFollowing: PropTypes.bool,
});

CoursesDetail.propTypes = {
  courseData: PropTypes.shape({
    id: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired,
    rating: PropTypes.number,
    description: PropTypes.string,
    cateCoruse: PropTypes.arrayOf(
      PropTypes.shape({
        id: PropTypes.string.isRequired,
        createdAt: PropTypes.string,
        category: PropTypes.shape({
          id: PropTypes.string.isRequired,
          name: PropTypes.string.isRequired,
          names: PropTypes.arrayOf(PropTypes.string),
        }),
      })
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
      })
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
};

export default CoursesDetail;
