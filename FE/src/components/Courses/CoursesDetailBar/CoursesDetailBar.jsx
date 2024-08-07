import React, { useEffect, useState } from "react";
import "./CoursesDetailBar.css";
import ApiService from "../../../api/ApiService";
import { useNavigate } from "react-router-dom";

export default function CoursesDetailBar({
  onAboutClick,
  onOutcomesClick,
  onContentsClick,
  onRecommendClick,
  onReviewClick,
  isIn,
  isOpenHeader,
  courseData,
  user,
}) {
  const [isEnrolled, setIsEnrolled] = useState(false);
  const [isInCartUser, setIsInCartUser] = useState(false);
  const nav = useNavigate();

  useEffect(() => {
    const checkCourseStatus = async () => {
      if (courseData) {
        setIsEnrolled(courseData.isEnrolled || false);
        setIsInCartUser(courseData.isInCart || false);
      }
    };

    checkCourseStatus();
  }, [courseData]);

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

  useEffect(() => {
    try {
      let progress1 = document.querySelector(".active");
      progress1.classList.remove("active");
    } catch (error) {}
    try {
      let progress2 = document.querySelector("." + isIn);
      progress2.classList.add("active");
    } catch (error) {}
  }, [isIn, isOpenHeader]);

  return (
    <div id="courses-detail-bar">
      <div className="tab" onClick={onAboutClick}>
        About
      </div>
      <div className="tab" onClick={onOutcomesClick}>
        Outcomes
      </div>
      <div className="tab" onClick={onContentsClick}>
        Contents
      </div>
      <div className="tab" onClick={onRecommendClick}>
        Recommendations
      </div>
      <div className="tab" onClick={onReviewClick}>
        Reviews
      </div>
      <div
        className="header-courses-bar"
        style={isOpenHeader ? { height: "143px" } : { height: "0px" }}
      >
        <div className="name-btn">
          <p>{courseData?.name}</p>
          <div className="btn-contain">
            <div className="enroll-btn">
              <div className="text" onClick={handleEnrollButtonClick}>
                <h10>
                  {isEnrolled
                    ? "Enroll"
                    : isInCartUser
                    ? "Already In Cart"
                    : "Buy"}
                </h10>
              </div>
            </div>
          </div>
        </div>
        <div className="tab-container">
          <div className="about tab" onClick={onAboutClick}>
            About
          </div>
          <div className="outcomes tab" onClick={onOutcomesClick}>
            Outcomes
          </div>
          <div className="contents tab" onClick={onContentsClick}>
            Contents
          </div>
          <div className="recommend tab" onClick={onRecommendClick}>
            Recommendations
          </div>
          <div className="review tab" onClick={onReviewClick}>
            Reviews
          </div>
        </div>
      </div>
    </div>
  );
}
