import React from "react";
import './CoursesLearningMap.css';

import CurriculumCourse from "../../Items/CurriculumCourse/CurriculumCourse";

export default function CoursesLearningMap() {
    const datas = [
        {

        },
        {

        },
        {

        },
        {

        },
        {

        },
    ]

    return (
        <div id="courses-learning-map">
            <p className="title">Course Content</p>
            <div className="course-content-container">
                {datas.map((data, index) => {
                    return (
                        <CurriculumCourse />
                    )
                })}
            </div>
        </div>
    )
}