import React from "react";
import "./StockMarket.css";


const Portfolio = () => {
     const portfolioItems = [
          { name: 'Days', value: '$13,546', change: '+1.41%', bgColor: '#f5f5f5' },
          { name: 'Months', value: '$1,643', change: '+1.53%', bgColor: '#e8f0fe' },
          { name: 'Years', value: '$2,987', change: '+2.01%', bgColor: '#e6ffed' },
     ];

     return (
          <div id="portfolio">
               <h2><strong>My Revenue Average</strong></h2>
               <div className="portfolio-items">
                    {portfolioItems.map((item, index) => (
                         <div key={index} className="portfolio-item" style={{ backgroundColor: item.bgColor }}>
                              <h3>{item.name}</h3>
                              <p className="value">{item.value}</p>
                              <p className="change">{item.change}</p>
                         </div>
                    ))}
               </div>
          </div>
     );
};

export default Portfolio;