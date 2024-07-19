import React, { useEffect } from "react";
import './CoursesDetail.css';

import Box from '@mui/material/Box';
import Rating from '@mui/material/Rating';

export default function CoursesDetail({ courseData }) {
    return (
        <div id="courses-detail">
            <p className="courses-title">{courseData?.name}</p>
            <div className="courses-categories">
                {courseData?.categoryCourses?.map((categoryCourse, index) => {
                    return (
                        <a href="" className="category">{categoryCourse.category.name}</a>
                    )
                })}
            </div>
            <div className="rating-author">
                <Box
                    sx={{
                        '& > legend': { mt: 2 },
                    }}
                >
                    <Rating name="read-only" value={courseData?.rating} readOnly />
                </Box>
                <span className="by">By</span>
                <a href="" className="author">{courseData?.user?.username}</a>
            </div>
            <p className="introduction">{courseData?.description}</p>
            <div className="enroll-btn">Enroll</div>
        </div>
    )
}