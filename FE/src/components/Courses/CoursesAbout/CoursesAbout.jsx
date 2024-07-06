import React, { useState } from "react";
import './CoursesAbout.css';

export default function CoursesAbout({ courseData }) {
    const [isMore, setIsMore] = useState(false);
    const handleAboutClick = () => {
        let progress = document.querySelector('.about-container');
        progress.classList.toggle('more');
        setIsMore(prev => !prev)
    }
    return (
        <div id="courses-about">
            <div className="about-container">
                <p className="wul">What you'll learn</p>
                <p className="wul-p">{courseData?.whatLearn}</p>
            </div>
            <div className="more-detail" onClick={handleAboutClick}>
                {isMore ? 'Less Detail' : 'More Detail'}
            </div>
        </div>
    )
}