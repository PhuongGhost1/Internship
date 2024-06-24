import React from "react";
import './CourseLearning.css'

import Header from "../../../components/Items/Header/Header";
import CourseSlideBar from "../../../components/Courses/CourseLearning/CourseSlideBar/CourseSlideBar";

export default function CourseLearning() {
    const data = [
        {
            name: 'Modern Data Ecosystem and the Role of Data Analytics',
            items: [
                {

                    type: 'lecture',
                    name: 'Modern Data Ecosystem',
                    time: '10m'
                },
                {

                    type: 'quiz',
                    name: 'Graded Quiz',
                    time: '30m'
                },
                {

                    type: 'lecture',
                    name: 'Key Players in the Data Ecosystem',
                    time: '10m'
                },
                {

                    type: 'lecture',
                    name: 'Defining Data Analysis',
                    time: '10m'
                }
            ]
        },
        {
            name: 'The Data Analyst Role',
            items: [
                {

                    type: 'lecture',
                    name: 'Responsibilities of a Data Analyst',
                    time: '10m'
                },
                {

                    type: 'quiz',
                    name: 'Graded Quiz',
                    time: '30m'
                },
                {

                    type: 'lecture',
                    name: 'Viewpoints: Qualities and Skills to be a Data Analyst',
                    time: '10m'
                },
                {

                    type: 'lecture',
                    name: 'A Day in the Life of a Data Analyst',
                    time: '10m'
                },
                {

                    type: 'quiz',
                    name: 'Graded Quiz',
                    time: '30m'
                },
            ]
        },
        {
            name: 'The Data Ecosystem and Languages for Data Professionals',
            items: [
                {

                    type: 'lecture',
                    name: 'Understanding Different Types of File Formats',
                    time: '10m'
                },
                {

                    type: 'quiz',
                    name: 'Graded Quiz',
                    time: '30m'
                },
                {

                    type: 'lecture',
                    name: 'Languages for Data Professionals',
                    time: '10m'
                }
            ]
        },
        {
            name: 'Understanding Data Repositories and Big Data Platforms',
            items: [
                {
                    type: 'lecture',
                    name: 'Data Marts, Data Lakes, ETL, and Data Pipelines',
                    time: '10m'
                },
                {
                    type: 'quiz',
                    name: 'Graded Quiz',
                    time: '30m'
                },
                {
                    type: 'lecture',
                    name: 'Big Data Processing Tools',
                    time: '10m'
                }
            ]
        },

    ]

    return (
        <div id="course-learning">
            <Header />
            <div className="body-container">
                <div className="course-slide-bar-container">
                    <CourseSlideBar data={data} />
                </div>
                <div className="content-container">
                </div>
            </div>
        </div>
    )
}