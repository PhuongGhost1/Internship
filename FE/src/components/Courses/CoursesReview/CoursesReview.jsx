import React, { useEffect } from "react";
import './CoursesReview.css';
import { formatNumber } from "../../../utils/Validation";
import { IoStar } from "react-icons/io5";

export default function CoursesReview() {
    return (
        <div id="courses-review">
            <div className="rating-container">
                <p className="title">Learner reviews</p>
                <div className="rating-overview">
                    <div className="star-avg">
                        <IoStar />
                        <span className="avg">4.5</span>
                    </div>
                    <span className="total-reviews">{formatNumber(200000)} reviews</span>
                </div>
                <div className="rating-statistical">

                </div>
            </div>
            <div className="comment-container">

            </div>
        </div>
    )
}