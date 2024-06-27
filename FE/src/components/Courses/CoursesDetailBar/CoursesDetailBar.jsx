import React from "react";
import './CoursesDetailBar.css'

export default function CoursesDetailBar() {
    return (
        <div id="courses-detail-bar">
            <div className="about tab">About</div>
            <div className="outcome tab">Outcomes</div>
            <div className="content tab">Contents</div>
            <div className="recommend tab">Recommendations</div>
            <div className="review tab">Reviews</div>
        </div>
    )
}