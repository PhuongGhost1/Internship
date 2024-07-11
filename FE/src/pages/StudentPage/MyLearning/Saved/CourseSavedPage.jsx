import React from "react";
import './CourseSavedPage.css'

import Header from "../../../../components/Items/Header/Header";
import Footer from "../../../../components/Items/Footer/Footer";
import NavBar from "../../../../components/Student/MyLearning/NavBar/NavBar";
import Saved from "../../../../components/Student/MyLearning/NavBar/Saved/Saved";


export default function CourseSavedPage() {
    return (
        <div id="course-saved-page">
            <Header />
            <NavBar type='saved' />
            <Saved />
            
            <Footer />
        </div>
    )
}