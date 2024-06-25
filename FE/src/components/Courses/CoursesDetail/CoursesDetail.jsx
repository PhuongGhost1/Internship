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
        </div>
    )
}