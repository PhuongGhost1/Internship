import React, { useEffect, useState } from "react";
import './InstructorProfilePage.css'

import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";
import PersonalDetail from "../../../components/Student/Profile/PersonalDetail/PersonalDetail";
import CertificationProfile from "../../../components/Student/Profile/CertificationProfile/CertificationProfile";
import Timeline from "../../../components/Student/Profile/Timeline/Timeline";
import CreatedCourse from "../../../components/Instructor/Profile/CreatedCourse/CreatedCourse";
import CreatingCourse from "../../../components/Instructor/Profile/CreatingCourse/CreatingCourse";

export default function InstructorProfilePage() {
    const [pageShow, setPageShow] = useState('process')

    useEffect(() => {
        try {
            let process1 = document.querySelector('.activeSB')
            process1.classList.remove('activeSB')
        } catch (error) {

        }
        if (pageShow === 'process') {
            let process2 = document.querySelector('.process')
            process2.classList.add('activeSB')
        } else if (pageShow === 'management') {
            let process2 = document.querySelector('.management')
            process2.classList.add('activeSB')
        }
    }, [pageShow])

    const handleProcessClick = () => {
        setPageShow('process')
    }

    const handleManagementClick = () => {
        setPageShow('management')
    }

    return (
        <div id="instructor-profile-page">
            <Header />
            <div className="instructor-profile-container">
                <div className="personal-detail-container">
                    <PersonalDetail />
                    <Timeline />
                </div>
                <div className="courses-certification">
                    <div className="switch-bar">
                        <div className="process bar" onClick={handleProcessClick}>
                            Process
                        </div>
                        <div className="management bar" onClick={handleManagementClick}>
                            Management
                        </div>
                    </div>
                    {pageShow === 'process' && (
                        <React.Fragment>
                            <CertificationProfile />
                        </React.Fragment>
                    )}
                    {pageShow === 'management' && (
                        <React.Fragment>
                            <CreatedCourse />
                            <CreatingCourse />
                        </React.Fragment>
                    )}
                </div>
            </div>
            <Footer />
        </div>
    )
}