import React from "react";
import './FollowingPage.css'
import Header from "../../../../components/Items/Header/Header";
import Footer from "../../../../components/Items/Footer/Footer";
import NavBar from "../../../../components/Student/MyLearning/NavBar/NavBar";
import Followed from "../../../../components/Student/MyLearning/NavBar/Followed/Followed";


export default function FollowingPage() {
    return (
        <div id="following-page">
            <Header />
            <NavBar type='following' />
            <Followed/>
            <Footer />
        </div>
    )
}