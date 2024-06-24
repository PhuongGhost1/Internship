import React, { useEffect } from "react";
import './SliderCards.css';
import Card from "../Card/Card";

export default function SliderCards({ items }) {
    const datas = [
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/5e360aa2986a2a96295b34d639919836c323cbb6-1200x900.jpg?w=3840&q=100&fit=clip&auto=format",
            name: "Blockchain Developer",
            ratingAVG: 4.5,
            ratingCount: 2003,
            timeLearing: "7 hours 43 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/b122bbb8302858740db71ef43ad17f7097ec7b63-1200x900.jpg?w=3840&q=100&fit=clip&auto=format",
            name: "Blockchain With Solidity",
            ratingAVG: 4.5,
            ratingCount: 2003,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/180434427a41505e6661e4bee15580f296730630-1200x900.jpg?w=3840&q=100&fit=clip&auto=format",
            name: "Blockchain Fundamental",
            ratingAVG: 4.5,
            ratingCount: 279,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/ef515d443ec26be717422a866678c42947db8bfa-1200x750.jpg?w=3840&q=100&fit=clip&auto=format",
            name: "Introducing With AWS",
            ratingAVG: 4.5,
            ratingCount: 4567,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/a532bde0528c319357e09cd65ea0fbd0e956e1ab-1200x900.jpg?w=3840&q=100&fit=clip&auto=format",
            name: "Generative AI",
            ratingAVG: 4.5,
            ratingCount: 9567,
            timeLearing: "8 hours 45 minutes"
        },
    ]
    return (
        <div id="slider-cards">
            {datas.map((data, index) => (
                <Card data={data} key={index} />
            ))}
        </div>
    )
}