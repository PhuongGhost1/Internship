import React, { useEffect } from "react";
import './CoursesDetailBar.css'

export default function CoursesDetailBar({ onAboutClick, onOutcomesClick, onContentsClick, onRecommendClick, onReviewClick, isIn, isOpenHeader, courseData }) {

    useEffect(() => {
        try {
            let progress1 = document.querySelector('.active')
            progress1.classList.remove('active')
        } catch (error) {

        }
        try {
            let progress2 = document.querySelector('.' + isIn)
            progress2.classList.add('active')
        } catch (error) {

        }
    }, [isIn, isOpenHeader])

    return (
        <div id="courses-detail-bar">
            <div className="tab" onClick={onAboutClick}>About</div>
            <div className="tab" onClick={onOutcomesClick}>Outcomes</div>
            <div className="tab" onClick={onContentsClick}>Contents</div>
            <div className="tab" onClick={onRecommendClick}>Recommendations</div>
            <div className="tab" onClick={onReviewClick}>Reviews</div>
            <div className="header-courses-bar" style={isOpenHeader ? { height: '143px' } : { height: '0px' }}>
                <div className="name-btn">
                    <p>{courseData?.name}</p>
                    <div className="btn-contain">
                        <div className="enroll-btn">Enroll</div>
                    </div>
                </div>
                <div className="tab-container">
                    <div className="about tab" onClick={onAboutClick}>About</div>
                    <div className="outcomes tab" onClick={onOutcomesClick}>Outcomes</div>
                    <div className="contents tab" onClick={onContentsClick}>Contents</div>
                    <div className="recommend tab" onClick={onRecommendClick}>Recommendations</div>
                    <div className="review tab" onClick={onReviewClick}>Reviews</div>
                </div>
            </div>
        </div>
    )
}