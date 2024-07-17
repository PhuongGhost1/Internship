import React, { useEffect, useState } from "react";
import "./Home.css";
import slide from "../../assets/Slide.svg";

import Header from "../../components/Items/Header/Header";
import Footer from "../../components/Items/Footer/Footer";
import SliderCards from "../../components/Items/SliderCards/SliderCards";

import Angular_logo from "../../assets/Angular_logo.png";
import Django_logo from "../../assets/Django_logo.webp";
import Dotnet_logo from "../../assets/Dotnet_logo.png";
import React_logo from "../../assets/React_logo.png";
import JavaScript_logo from "../../assets/JavaScript_logo.png";
import AI_logo from "../../assets/AI_logo.png";
import AWS_logo from "../../assets/AWS_logo.webp";
import CS_logo from "../../assets/CS_logo.png";
import Python_logo from "../../assets/Python_logo.png";

import slide_img from "../../assets/slide_img.webp";
import ApiService from "../../api/ApiService";

export default function Home() {
  const [newReleaseCoursesData, setNewReleaseCoursesData] = useState(null);
  const [mostPopularCourses, setMostPopularCoursesData] = useState(null);

  useEffect(() => {
    const fetchNewReleaseCourses = async () => {
      try {
        const data = await ApiService.getNewReleaseCourses();
        setNewReleaseCoursesData(data);
      } catch (error) {
        console.log("Error fetching new release courses: ", error);
      }
    };
    fetchNewReleaseCourses();
  }, []);

  useEffect(() => {
    const fetchMostPopularCourses = async () => {
      try {
        const data = await ApiService.getMostPurchasedCourses();
        setMostPopularCoursesData(data);
      } catch (error) {
        console.log("Error fetching new release courses: ", error);
      }
    };
    fetchMostPopularCourses();
  }, []);

  return (
    <div id="home">
      <Header />
      <div className="slide-show">
        <img className="slide" src={slide} alt="" />
        <div className="blur-block">
          <div className="slide-content">
            <p className="course-name">Code Course for learing</p>
            <p className="introduce">
              Master the technology skills to drive your career
            </p>
            <p className="description">
              Looking to get certified in cloud, land a role in cybersecurity,
              or pave a new career path with AI? Pluralsight Skills can get you
              there—whether you’re just starting out or a seasoned pro.
            </p>
            <a href="/" className="start-btn">
              Start your trip
            </a>
          </div>
          <div className="slide-image-container">
            <img src={slide_img} alt="" className="slide-img" />
          </div>
        </div>
        <div className="topic">
          <div className="topic-title">Popular topics to learn now</div>
          <div className="categories">
            {newReleaseCoursesData &&
              newReleaseCoursesData.map((course, index) => (
                <a
                  key={index}
                  href="/"
                  className={`${course.name.toLowerCase()} category`}
                >
                  <img src={course.image[0].url} alt="" className="icon" />
                </a>
              ))}
          </div>
        </div>
      </div>
      <div className="courses-container">
        <div className="new courses">
          <p className="courses-title">New Release</p>
          <SliderCards datas={newReleaseCoursesData} />
        </div>
        <div className="most-popular courses">
          <p className="courses-title">Most Popular Courses</p>
          <SliderCards datas={mostPopularCourses} />
        </div>
        <div className="free courses">
          <p className="courses-title">Top Free Courses</p>
          <SliderCards />
        </div>
      </div>
      <Footer />
    </div>
  );
}
