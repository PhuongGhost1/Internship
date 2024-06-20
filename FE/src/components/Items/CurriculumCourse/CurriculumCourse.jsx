import React from "react";
import './CurriculumCourse.css'

import { FaDiamond } from "react-icons/fa6";
import { IoIosArrowDown } from "react-icons/io";


export default function CurriculumCourse(props) {
    return (
        <div id="curriculum-course">
            <div className="chapter-content">
                <div className="chapter-container">
                    <p className="chapter-title">Overview Of Data Science Tools</p>
                    <div className="detail">
                        <span className="lecture">8 lectures</span>
                        <FaDiamond />
                        <span className="quiz">3 quizzes</span>
                        <FaDiamond />
                        <span className="time">2h18m</span>
                    </div>
                </div>
                <div className="more-detail">
                    <div className="more-btn">
                        <span>More Detail</span>
                        <IoIosArrowDown />
                    </div>
                </div>
            </div>
        </div>
    )
}