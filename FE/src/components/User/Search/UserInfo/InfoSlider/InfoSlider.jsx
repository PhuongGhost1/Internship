import React, { useState } from "react";
import "./InfoSlider.css";
import Background from '../../../../../assets/background-user1.jpg';

const cardData = [
     {
          category: "Adventure Sports",
          title: "Fear Of Driving And Automatic Negative Thoughts",
          lessons: 12,
          duration: "3 hr 30 min",
          imageUrl: Background,
     },
     {
          category: "Sales and Operations",
          title: "Work more, Earn more while sitting at your home",
          lessons: 23,
          duration: "1 hr 30 min",
          imageUrl: Background,
     },
     {
          category: "Marketing",
          title: "Foundation course to understand about Software",
          lessons: 23,
          duration: "1 hr 30 min",
          imageUrl: Background,
          isNew: true,
     },
     {
          category: "Marketing",
          title: "Foundation course to understand about Software",
          lessons: 23,
          duration: "1 hr 30 min",
          imageUrl: Background,
          isNew: true,
     },
     {
          category: "Tech",
          title: "Learn about React in depth",
          lessons: 10,
          duration: "2 hr 15 min",
          imageUrl: Background,
          isNew: true,
     }
];

export default function InfoSlider() {
     const [currentIndex, setCurrentIndex] = useState(0);
     const maxVisibleCards = 4;

     const handlePrevClick = () => {
          if (currentIndex > 0) {
               setCurrentIndex(currentIndex - 1);
          }
     };

     const handleNextClick = () => {
          if (currentIndex < cardData.length - maxVisibleCards) {
               setCurrentIndex(currentIndex + 1);
          }
     };

     return (
          <div id="InfoSlider">
               <button onClick={handlePrevClick} className="slider-arrow left-arrow">&#8592;</button>
               <div className="card-container">
                    {cardData.slice(currentIndex, currentIndex + maxVisibleCards).map((card, index) => (
                         <div key={index} className="card">
                              <img src={card.imageUrl} alt={card.title} className="card-img" />
                              <div className="card-content">
                                   <div className="card-category">{card.category}</div>
                                   <div className="card-title">{card.title}</div>
                                   <div className="card-details">
                                        <span>{card.lessons} Lessons</span>
                                        <span>{card.duration}</span>
                                   </div>
                                   {card.isNew && <div className="card-new">New</div>}
                              </div>
                         </div>
                    ))}
               </div>
               <button onClick={handleNextClick} className="slider-arrow right-arrow">&#8594;</button>
          </div>
     );
}
