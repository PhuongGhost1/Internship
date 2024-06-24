import React from "react";
import './CoursesDetail.css';

import Box from '@mui/material/Box';
import Rating from '@mui/material/Rating';

export default function CoursesDetail() {
    return (
        <div id="courses-detail">
            <p className="courses-title">Python for Data Analysis</p>
            <div className="courses-categories">
                <a href="" className="category">Python</a>
                <a href="" className="category">Data Science</a>
                <a href="" className="category">Data Analysis</a>
                <a href="" className="category">Microsoft Excel</a>
            </div>
            <div className="rating-author">
                <Box
                    sx={{
                        '& > legend': { mt: 2 },
                    }}
                >
                    <Rating name="read-only" value={4} readOnly />
                </Box>
                <span className="by">By</span>
                <a href="" className="author">Nguyễn Mạnh Duy</a>
            </div>
            <p className="introduction">Python is one of the most popular and powerful programming languages data analysts use to process, analyze, and visualize data efficiently. Data analysts leverage Python's extensive libraries such as pandas for data manipulation, NumPy for numerical operations, and Matplotlib for creating charts. These tools enable analysts to clean data, perform exploratory data analysis, and generate actionable insights, making Python an essential skill in data-driven industries to support analytics and inform business decisions.</p>
            <div className="enroll-btn">Enroll</div>
            <p className="wul">What you'll learn</p>
            <p className="wul-p">Python has exploded in popularity in recent years and has emerged as the technology of choice for data analysts and data scientists.<br />

                In this course, Python for Data Analysts, you will gain the ability to write Python programs and utilize fundamental building blocks of programming and data analysis. First, you will learn how programming languages such as Python, spreadsheets such as Microsoft Excel, and SQL-based technologies such as databases differ from each other, and also how they inter-operate.<br />

                Next, you will plunge into Python programming, installing Python and getting started with simple programs. You will then understand the ways in which variables are used to hold data, and how simple and complex data types in Python differ in their semantics.<br />

                Finally, you will round out your knowledge by working with conditional evaluation using if statements, loops and functions. You will learn how Python treats functions as first-class entities, a key enabler of functional programming.<br />

                When you’re finished with this course, you will have the skills and knowledge to identify situations when Python is the right choice for you, and to implement simple but solid programs using Python.</p>
        </div>
    )
}