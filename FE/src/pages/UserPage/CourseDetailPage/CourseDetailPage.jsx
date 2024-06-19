import React from "react";
import './CourseDetailPage.css'

import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";
import CoursesDetail from "../../../components/Courses/CoursesDetail/CoursesDetail";
import CoursesLearningMap from "../../../components/Courses/CoursesLearningMap/CoursesLearningMap";
import CoursesInfo from "../../../components/Courses/CoursesInfo/CoursesInfo";

export default function CourseDetailPage() {

    return (
        <div id="course-detail-page">
            <Header />
            <div className="courser-detail-container">
                <div className="course-detail-learning-map-container">
                    <CoursesDetail />
                    <CoursesLearningMap />
                </div>
                <div className="course-info-container">
                    <CoursesInfo />
                </div>
            </div>
            <Footer />
        </div>
    )
}