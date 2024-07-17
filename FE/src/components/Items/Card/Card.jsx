import React, { useEffect, useState } from "react";
import PropTypes from "prop-types";
import "./Card.css";

import Rating from "@mui/material/Rating";
import Stack from "@mui/material/Stack";

import CircularProgress from "@mui/material/CircularProgress";
import Box from "@mui/material/Box";

const Card = ({ data }) => {
  const [newReleaseCourses, setNewReleaseCourses] = useState(null);

  useEffect(() => {
    setNewReleaseCourses(data);
  }, [data]);

  if (!newReleaseCourses) {
    <p>Loading...</p>;
  }

  return (
    <div id="card">
      <div className="card-container">
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
        <img
          src={data.image == null ? "" : data.image[0].url}
          className="background"
          alt="Course"
        />
        <div className="card-content">
          <a href={`/courses/${data.name}`} className="card-link">
            <p className="course-name">{data.name}</p>
          </a>
          <div className="rating-container">
            <Stack spacing={1}>
              <Rating
                className="rating"
                value={data.ratingAvg}
                precision={0.5}
                readOnly
              />
            </Stack>
            <span className="total-rating">&#40;{data.ratingCount}&#41;</span>
          </div>
          <p className="course-time">{data.timeLearning} Minutes</p>
        </div>
      </div>
    </div>
  );
};

Card.propTypes = {
  data: PropTypes.shape({
    name: PropTypes.string.isRequired,
    image: PropTypes.arrayOf(
      PropTypes.shape({
        id: PropTypes.string.isRequired,
        url: PropTypes.string.isRequired,
        type: PropTypes.string.isRequired,
        lastUpdated: PropTypes.string.isRequired,
      })
    ).isRequired,
    ratingAvg: PropTypes.number.isRequired,
    ratingCount: PropTypes.number.isRequired,
    timeLearning: PropTypes.number.isRequired,
  }).isRequired,
};

export default Card;
