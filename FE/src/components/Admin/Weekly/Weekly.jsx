import React from "react";
import './Weekly.css';

const weeklyData = [
    { title: "Net Revenue", value: "$123,000", subtext: "5% vs last month" },
    { title: "Weekly Sales", value: "$24,000", subtext: "71% of total goals" },
    { title: "Page Visits", value: "423", subtext: "22% higher" },
    { title: "New Customers", value: "150", subtext: "10% increase" }
];

export default function Weekly() {
    return (
        <div id="Weekly">
            {weeklyData.map((item, index) => (
                <div className="weekly-item" key={index}>
                    <div className="weekly-title">{item.title}</div>
                    <div className="weekly-value">{item.value}</div>
                    <div className="weekly-subtext">{item.subtext}</div>
                </div>
            ))}
        </div>
    );
}
