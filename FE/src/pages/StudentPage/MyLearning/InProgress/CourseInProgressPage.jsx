import React from "react";
import './CourseInProgressPage.css';

import Header from "../../../../components/Items/Header/Header";
import Footer from "../../../../components/Items/Footer/Footer";
import NavBar from "../../../../components/Student/MyLearning/NavBar/NavBar";


export default function CourseInProgressPage() {
    return (
        <div id="course-in-progress-page">
            <Header />
            <NavBar type='in-progress' />
            <Footer />
        </div>
    )
}