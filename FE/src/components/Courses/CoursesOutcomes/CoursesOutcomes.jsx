import React from "react";
import './CoursesOutcomes.css';

import { GoDotFill } from "react-icons/go";

import outcome from '../../../assets/outcome-background.avif';

export default function CoursesOutcomes() {
    return (
        <div id="courses-outcomes">
            <div className="content">
                <div className="introduce">
                    <p className="outcome-title">Build your subject-matter expertise</p>
                    <p className="description">This course is available as part of <span>multiple programs</span></p>
                    <p className="description">When you enroll in this course, you'll also be asked to select a specific program.</p>
                </div>
                <div className="target-collect">
                    <div>
                        <GoDotFill /><p>Learn new concepts from industry experts </p>
                    </div>
                    <div>
                        <GoDotFill /><p>Gain a foundational understanding of a subject or tool</p>
                    </div>
                    <div>
                        <GoDotFill /><p>Develop job-relevant skills with hands-on projects </p>
                    </div>
                    <div>
                        <GoDotFill /><p>Earn a shareable career certificate </p>
                    </div>
                </div>
            </div>
            <div className="image-container">
                <img src={outcome} alt="" />
            </div>
        </div>
    )
}
