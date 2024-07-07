import React, { useEffect } from "react";
import './CoursesDetail.css';

import Box from '@mui/material/Box';
import Rating from '@mui/material/Rating';

export default function CoursesDetail({ courseData }) {
    return (
        <div id="courses-detail">
            <p className="courses-title">{courseData?.name}</p>
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
            <p className="introduction">{courseData?.description}</p>
            <div className="enroll-btn">Enroll</div>
        </div>
    )
}