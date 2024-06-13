import React from "react";
import './Home.css';
import slide from '../../assets/Slide.svg'

import Header from "../../components/Header/Header";
import Footer from "../../components/Footer/Footer";
import SliderCards from "../../components/SliderCards/SliderCards";

import Angular_logo from '../../assets/Angular_logo.png'
import Django_logo from '../../assets/Django_logo.webp'
import Dotnet_logo from '../../assets/Dotnet_logo.png'
import React_logo from '../../assets/React_logo.png'
import JavaScript_logo from '../../assets/JavaScript_logo.png'
import AI_logo from '../../assets/AI_logo.png'
import AWS_logo from '../../assets/AWS_logo.webp'
import CS_logo from '../../assets/CS_logo.png'
import Python_logo from '../../assets/Python_logo.png'


import slide_img from '../../assets/slide_img.webp'

export default function Home() {
    return (
        <div id="home">
            <Header />
            <div className="slide-show">
                <img className="slide" src={slide} alt="" />
                <div className="blur-block">
                    <div className="slide-content">
                        <p className="course-name">Code Course for learing</p>
                        <p className="introduce">Master the technology skills to drive your career</p>
                        <p className="description">Looking to get certified in cloud, land a role in cybersecurity, or pave a new career path with AI? Pluralsight Skills can get you there—whether you’re just starting out or a seasoned pro.</p>
                        <a href="/" className="start-btn">Start your trip</a>
                    </div>
                    <div className="slide-image-container">
                        <img src={slide_img} alt="" className="slide-img" />
                    </div>
                </div>
                <div className="topic">
                    <div className="topic-title">Popular topics to learn now</div>
                    <div className="categories">
                        <a href="/" className="python category">
                            <img src={Python_logo} alt="" className="icon" />
                        </a>
                        <a href="/" className="cs category">
                            <img src={CS_logo} alt="" className="icon" />
                        </a>
                        <a href="/" className="aws category">
                            <img src={AWS_logo} alt="" className="icon" />
                        </a>
                        <a href="/" className="ai category">
                            <img src={AI_logo} alt="" className="icon" />
                        </a>
                        <a href="/" className="js category">
                            <img src={JavaScript_logo} alt="" className="icon" />
                        </a>
                        <a href="/" className="react category">
                            <img src={React_logo} alt="" className="icon" />
                        </a>
                        <a href="/" className="dotnet category">
                            <img src={Dotnet_logo} alt="" className="icon" />
                        </a>
                        <a href="/" className="django category">
                            <img src={Django_logo} alt="" className="icon" />
                        </a>
                        <a href="/" className="angular category">
                            <img src={Angular_logo} alt="" className="icon" />
                        </a>
                    </div>
                </div>
            </div>
            <div className="courses-container">
                <div className="new courses">
                    <p className="courses-title">New Release</p>
                    <SliderCards />
                </div>
                <div className="most-popular courses">
                    <p className="courses-title">Most Popular Courses</p>
                    <SliderCards />
                </div>
                <div className="free courses">
                    <p className="courses-title">Top Free Courses</p>
                    <SliderCards />
                </div>
            </div>
            <Footer />
        </div>
    )
}