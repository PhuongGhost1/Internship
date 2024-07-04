import React, { useRef, useState, useEffect } from "react";
import axios from "axios";

export default function CourseDetailPage() {
    const [isIn, setIsIn] = useState('about');
    const [isOpenHeader, setIsOpenHeader] = useState(false);
    const aboutRef = useRef(null);
    const outcomesRef = useRef(null);
    const contentsRef = useRef(null);
    const recommendRef = useRef(null);
    const reviewRef = useRef(null);

    useEffect(() => {
        fetchAPI('prompt-engineering-specialization');
    }, []);

    const scrollToSection = (sectionRef) => {
        const yOffset = -60;
        const yPosition = sectionRef.current.getBoundingClientRect().top + window.pageYOffset + yOffset;
        window.scrollTo({ top: yPosition, behavior: 'smooth' });
    };

    async function fetchAPI(courseName) {
        // Convert data to URL-encoded format
        const params = new URLSearchParams();
        params.append('courseName', courseName);

        try {
            const response = await axios.post('http://localhost:5144/api/v1/web/course/find-course', { courseName: 'prompt-engineering-specialization' }, {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                },
            });
            console.log(response.data);
        } catch (error) {
            console.error('There was an error!', error);
        }
    }

    useEffect(() => {
        const options = {
            root: null,
            rootMargin: '0px 0px -850px 0px',
            threshold: 0,
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
        console.log(isIn);
    }, [isIn]);

    return (
        <div id="course-detail-page">
            {/* Your components here */}
        </div>
    );
}
