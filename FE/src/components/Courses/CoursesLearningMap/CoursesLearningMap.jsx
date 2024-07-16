import React, { useEffect, useState } from "react";
import './CoursesLearningMap.css';

import CurriculumCourse from "../../Items/CurriculumCourse/CurriculumCourse";
import ApiService from "../../../api/ApiService";

export default function CoursesLearningMap({ courseData }) {
    const [datas, setDatas] = useState([])
    const [dropdown, setDropdown] = useState(null)
    useEffect(() => {
        if (courseData?.id) {
            fetchingLearningMap(courseData.id)
        }
    }, [courseData])

    const fetchingLearningMap = async (courseId) => {
        const fetchData = await ApiService.getCourseContent(courseId)
        console.log(fetchData)
        setDatas(fetchData?.chapters)
    }

    return (
        <div id="courses-learning-map">
            <p className="title">Course Content</p>
            <div className="course-content-container">
                {datas.map((data, index) => {
                    return (
                        <CurriculumCourse data={data} key={data.id} setDropdown={setDropdown} dropdown={dropdown} />
                    )
                })}
            </div>
        </div>
    )
}