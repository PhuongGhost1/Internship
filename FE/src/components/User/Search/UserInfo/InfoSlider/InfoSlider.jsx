import React from "react";
import "./InfoSlider.css";

const cardData = [
     {
          category: "Adventure Sports",
          title: "Fear Of Driving And Automatic Negative Thoughts",
          lessons: 12,
          duration: "3 hr 30 min",
          imageUrl: "/path/to/image1.jpg", // Update with actual image paths
     },
     {
          category: "Sales and Operations",
          title: "Work more, Earn more while sitting at your home",
          lessons: 23,
          duration: "1 hr 30 min",
          imageUrl: "/path/to/image2.jpg", // Update with actual image paths
     },
     {
          category: "Marketing",
          title: "Foundation course to understand about Software",
          lessons: 23,
          duration: "1 hr 30 min",
          imageUrl: "/path/to/image3.jpg", // Update with actual image paths
          isNew: true,
     },
];

export default function InfoSlider() {
     return (
          <div id="InfoSlider">
               {cardData.map((card, index) => (
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
     );
}
