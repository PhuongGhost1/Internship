import React from "react";
import './CourseCompletedPage.css'

import Header from "../../../../components/Items/Header/Header";
import Footer from "../../../../components/Items/Footer/Footer";
import NavBar from "../../../../components/Student/MyLearning/NavBar/NavBar";

export default function CourseCompletedPage() {
    return (
        <div id="course-completed-page">
            <Header />
            <NavBar type='completed' />
            <Footer />
        </div>
    )
}