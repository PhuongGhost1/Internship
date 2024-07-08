import React, { useRef, useState, useEffect } from "react";
import './CourseDetailPage.css'

import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";
import CoursesDetail from "../../../components/Courses/CoursesDetail/CoursesDetail";
import CoursesLearningMap from "../../../components/Courses/CoursesLearningMap/CoursesLearningMap";
import CoursesInfo from "../../../components/Courses/CoursesInfo/CoursesInfo";
import CoursesDetailBar from "../../../components/Courses/CoursesDetailBar/CoursesDetailBar";
import CoursesAbout from "../../../components/Courses/CoursesAbout/CoursesAbout";
import CoursesOutcomes from "../../../components/Courses/CoursesOutcomes/CoursesOutcomes";
import SliderCards from "../../../components/Items/SliderCards/SliderCards";
import CoursesReview from "../../../components/Courses/CoursesReview/CoursesReview";

export default function CourseDetailPage() {
    const [isIn, setIsIn] = useState('about')
    const [isOpenHeader, setIsOpenHeader] = useState(false)
    const aboutRef = useRef(null);
    const outcomesRef = useRef(null);
    const contentsRef = useRef(null)
    const recommendRef = useRef(null);
    const reviewRef = useRef(null);

    const scrollToSection = (sectionRef) => {
        const yOffset = -60;
        const yPosition = sectionRef.current.getBoundingClientRect().top + window.pageYOffset + yOffset;
        window.scrollTo({ top: yPosition, behavior: 'smooth' });
    };

    useEffect(() => {
        const options = {
            root: null, // root là viewport của trình duyệt
            rootMargin: '0px 0px -850px 0px', // Điều chỉnh rootMargin để phần tử chạm vào đầu viewport
            threshold: 0, // Kích hoạt ngay khi phần tử chạm vào viewport
        };

        let isAboveAboutRef = false;

        const handleIntersection = (entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    switch (entry.target) {
                        case aboutRef.current:
                            setIsIn('about');
                            setIsOpenHeader(prev => !prev);
                            break;
                        case outcomesRef.current:
                            setIsIn('outcomes');
                            setIsOpenHeader(true);
                            break;
                        case contentsRef.current:
                            setIsIn('contents');
                            setIsOpenHeader(true);
                            break;
                        case recommendRef.current:
                            setIsIn('recommend');
                            setIsOpenHeader(true);
                            break;
                        case reviewRef.current:
                            setIsIn('review');
                            setIsOpenHeader(true);
                            break;
                        default:
                            break;
                    }
                }
            });
        };

        const observer = new IntersectionObserver(handleIntersection, options);

        if (aboutRef.current) observer.observe(aboutRef.current);
        if (outcomesRef.current) observer.observe(outcomesRef.current);
        if (contentsRef.current) observer.observe(contentsRef.current);
        if (recommendRef.current) observer.observe(recommendRef.current);
        if (reviewRef.current) observer.observe(reviewRef.current);


        return () => {
            if (aboutRef.current) observer.unobserve(aboutRef.current);
            if (outcomesRef.current) observer.unobserve(outcomesRef.current);
            if (contentsRef.current) observer.unobserve(contentsRef.current);
            if (recommendRef.current) observer.unobserve(recommendRef.current);
            if (reviewRef.current) observer.unobserve(reviewRef.current);
        };
    }, []);

    useEffect(() => {
        console.log(isIn)
    }, [isIn])

    return (
        <div id="course-detail-page">
            <Header />
            <div className="courser-detail-container">
                <div className="flex-container">
                    <div className="course-detail-learning-map-container">
                        <CoursesDetail />
                        <CoursesDetailBar
                            onAboutClick={() => { scrollToSection(aboutRef) }}
                            onOutcomesClick={() => { scrollToSection(outcomesRef) }}
                            onContentsClick={() => { scrollToSection(contentsRef) }}
                            onRecommendClick={() => { scrollToSection(recommendRef) }}
                            onReviewClick={() => { scrollToSection(reviewRef) }}
                            isIn={isIn}
                            isOpenHeader={isOpenHeader} />
                        <div ref={aboutRef}>
                        </div>
                        <CoursesAbout />
                    </div>
                    <div className="course-info-container">
                        <CoursesInfo />
                    </div>
                </div>
                <div ref={outcomesRef}>
                </div>
                <CoursesOutcomes />
                <div ref={contentsRef}>
                </div>
                <CoursesLearningMap />
                <div ref={recommendRef}>
                </div>
                <p className="recommend-title">Recommended</p>
                <div className="slider-card-recommend">
                    <SliderCards />
                </div>
                <div ref={reviewRef}>
                </div>
                <CoursesReview />
            </div>
            <Footer />
        </div>
    )
}