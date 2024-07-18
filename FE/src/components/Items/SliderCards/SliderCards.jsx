import React, { useEffect } from "react";
import PropTypes from "prop-types";
import "./SliderCards.css";
import Card from "../Card/Card";

export default function SliderCards({ datas }) {
  useEffect(() => {
    console.log(datas);
  }, [datas]);

  return (
    <div id="slider-cards">
      {datas?.map((data, index) => (
        <Card data={data} key={index} />
      ))}
    </div>
  );
}

SliderCards.propTypes = {
  datas: PropTypes.array.isRequired,
};
