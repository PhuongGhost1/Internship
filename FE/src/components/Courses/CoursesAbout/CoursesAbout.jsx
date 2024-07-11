import React, { useState } from "react";
import './CoursesAbout.css';

export default function CoursesAbout() {
    const [isMore, setIsMore] = useState(false);
    const handleAboutClick = () => {
        let progress = document.querySelector('.about-container');
        progress.classList.toggle('more');
        setIsMore(prev => !prev)
    }
    return (
        <div id="courses-about">
            <div className="about-container">
                <p className="wul">What you'll learn</p>
                <p className="wul-p">Python has exploded in popularity in recent years and has emerged as the technology of choice for data analysts and data scientists.<br />

                    In this course, Python for Data Analysts, you will gain the ability to write Python programs and utilize fundamental building blocks of programming and data analysis. First, you will learn how programming languages such as Python, spreadsheets such as Microsoft Excel, and SQL-based technologies such as databases differ from each other, and also how they inter-operate.<br />

                    Next, you will plunge into Python programming, installing Python and getting started with simple programs. You will then understand the ways in which variables are used to hold data, and how simple and complex data types in Python differ in their semantics.<br />

                    Finally, you will round out your knowledge by working with conditional evaluation using if statements, loops and functions. You will learn how Python treats functions as first-class entities, a key enabler of functional programming.<br />

                    When you’re finished with this course, you will have the skills and knowledge to identify situations when Python is the right choice for you, and to implement simple but solid programs using Python.</p>
            </div>
            <div className="more-detail" onClick={handleAboutClick}>
                {isMore ? 'Less Detail' : 'More Detail'}
            </div>
        </div>
    )
}