import React from "react";
import './Statistics.css';

const courseData = [
    {
        title: "Introduction to C++",
        date: "Start Date: Jul 18th 2022",
        status: "Ongoing",
        id: "C1"
    },
    {
        title: "Advanced PHP Programming",
        date: "Start Date: Jul 20th 2022",
        status: "Upcoming",
        id: "C2"
    },
    {
        title: "Object-Oriented Programming with Ruby",
        date: "Start Date: Jul 19th 2022",
        status: "Ongoing",
        id: "C3"
    },
    {
        title: "Redis for Beginners",
        date: "Start Date: Jul 18th 2022",
        status: "Completed",
        id: "C4"
    },
    {
        title: "Ruby on Rails Bootcamp",
        date: "Start Date: Jul 15th 2022",
        status: "Upcoming",
        id: "C5"
    },
    {
        title: "Full-Stack Development with JavaScript",
        date: "Start Date: Jul 18th 2022",
        status: "Ongoing",
        id: "C6"
    },
    {
        title: "Data Structures and Algorithms in Python",
        date: "Start Date: Jul 18th 2022",
        status: "Completed",
        id: "C7"
    }
];

export default function Statistics(){
    return(
        <div id="Statistics">
          <h2>Transactions</h2>
            {courseData.map((course, index) => (
                <div key={index} className="course-item">
                    <div>
                        <h4>{course.title}</h4>
                        <p>{course.date}</p>
                    </div>
                    <div className={`course-status ${course.status.toLowerCase()}`}>
                        <p>{course.status}</p>
                        <p>{course.id}</p>
                    </div>
                </div>
            ))}
        </div>
    );
}