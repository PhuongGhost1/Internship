import React, { useEffect, useState } from "react";
import "./Card.css";

import Rating from "@mui/material/Rating";
import Stack from "@mui/material/Stack";

import CircularProgress from "@mui/material/CircularProgress";
import Box from "@mui/material/Box";

import { CoverMinutesToHours, nameNavigation } from "../../../utils/Validation";
import ImgReplacement from "../../../assets/background_forest.png";

const Card = ({ data }) => {
  const handleOnClickCard = (courseName) => {
    window.location.href = `courses/${nameNavigation(courseName)}`;
  };

  return (
    <div
      id="card"
      onClick={() => {
        handleOnClickCard(data.name);
      }}
    >
      <div className="card-container">
        {data ? (
          <>
            <img
              src={data.image !== null ? data.image[0].url : ImgReplacement}
              className="background"
              alt="Course"
            />
            <div className="card-content">
              <p className="course-name">{data.name}</p>
              <div className="rating-container">
                <Stack spacing={1}>
                  <Rating
                    className="rating"
                    value={data.ratingAvg}
                    precision={0.5}
                    readOnly
                  />
                </Stack>
                <span className="total-rating">
                  &#40;{data.ratingCount}&#41;
                </span>
              </div>
              <p className="course-time">
                {CoverMinutesToHours(data.timeLearning)}
              </p>
            </div>
          </>
        ) : (
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
              justifyContent: "center",
              width: "100%",
              height: "100%",
              position: "absolute",
            }}
          >
            <CircularProgress />
          </Box>
        )}
      </div>
    </div>
  );
};

export default Card;
