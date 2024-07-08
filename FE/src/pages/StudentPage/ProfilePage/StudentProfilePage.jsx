import React from "react";
import './StudentProfilePage.css'

import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";
import PersonalDetail from "../../../components/Student/Profile/PersonalDetail/PersonalDetail";
import LearningCourses from "../../../components/Student/Profile/LearningCourses/LearningCourses";
import CertificationProfile from "../../../components/Student/Profile/CertificationProfile/CertificationProfile";
import Timeline from "../../../components/Student/Profile/Timeline/Timeline";

export default function StudentProfilePage() {
    return (
        <div id="student-profile-page">
            <Header />
            <div className="student-profile-container">
                <div className="personal-detail-container">
                    <PersonalDetail />
                    <Timeline />
                </div>
                <div className="courses-certification">
                    <LearningCourses />
                    <CertificationProfile />
                </div>
            </div>
            <Footer />

        </div>
    )
}

