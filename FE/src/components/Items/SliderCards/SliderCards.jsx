import React, { useEffect } from "react";
import './SliderCards.css';
import Card from "../Card/Card";

export default function SliderCards({ datas }) {
    useEffect(() => {
        console.log(datas)
    }, [datas])
    return (
        <div id="slider-cards">
            {datas?.map((data, index) => (
                <Card data={data} key={index} />
            ))}
        </div>
    )
}