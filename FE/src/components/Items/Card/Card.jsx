import React, { useEffect, useState } from "react";
import './Card.css';

import Rating from '@mui/material/Rating';
import Stack from '@mui/material/Stack';
import { formatTime } from "../../../utils/Validation";
import ApiService from "../../../api/ApiService";

import CircularProgress from '@mui/material/CircularProgress';
import Box from '@mui/material/Box';


export default function Card({ data }) {
    const [imgUrl, setImgUrl] = useState('');
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        let isMounted = true;
        const fetchImg = async () => {
            try {
                const response = await ApiService.fetchImage(data.imgUrl);
                if (isMounted) {
                    setImgUrl(response);
                    setIsLoading(false);
                }
            } catch (error) {
                console.error('Error fetching image:', error);
            }
        };
        fetchImg();

        // Cleanup to revoke the object URL and prevent memory leaks
        return () => {
            isMounted = false;
            if (imgUrl) {
                URL.revokeObjectURL(imgUrl);
            }
        };
    }, [data.imgUrl]);

    return (
        <div id="card">
            <div className="card-container">
                {isLoading ? (
                    <Box sx={{
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'center',
                        width: '100%',
                        height: '100%',
                        position: 'absolute'
                    }}>
                        <CircularProgress />
                    </Box>
                ) : (
                    <img src={imgUrl} className="background" alt="Course" />
                )}
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