import React from "react";
import './FollowingPage.css'

import Header from "../../../../components/Items/Header/Header";
import Footer from "../../../../components/Items/Footer/Footer";
import NavBar from "../../../../components/Student/MyLearning/NavBar/NavBar";


export default function FollowingPage() {
    return (
        <div id="following-page">
            <Header />
            <NavBar type='following' />
            <Footer />
        </div>
    )
}