import React from "react";
import './Card.css';

import Rating from '@mui/material/Rating';
import Stack from '@mui/material/Stack';
import { formatTime } from "../../../utils/Validation";

export default function Card({ data }) {
    return (
        <div id="card">
            <div className="card-container">
                <img src={data.imgUrl} className="background" alt="" />
                <div className="card-content">
                    <p className="course-name">{data.name}</p>
                    <div className="rating-container">
                        <Stack spacing={1}>
                            <Rating className="rating" value={data.ratingAVG} precision={0.5} readOnly />
                        </Stack>
                        <span className="total-rating">&#40;{data.ratingCount}&#41;</span>
                    </div>
                    <p className="course-time">{formatTime(data.timeLearning)}</p>
                </div>
            </div>
        </div>
    )
}