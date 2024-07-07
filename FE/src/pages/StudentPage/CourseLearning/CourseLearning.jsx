import React, { useEffect } from "react";
import { useParams } from 'react-router-dom';
import './CourseLearning.css'

import Header from "../../../components/Items/Header/Header";
import CourseSlideBar from "../../../components/Courses/CourseLearning/CourseSlideBar/CourseSlideBar";
import CourseVideoContent from "../../../components/Courses/CourseLearning/CourseVideoContent/CourseVideoContent";
import CourseQuizContent from "../../../components/Courses/CourseLearning/CourseQuizContent/CourseQuizContent";

export default function CourseLearning() {
    const { courseType, itemName } = useParams();
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

    const quizData = [
        {
            index: 1,
            text: `Which of the following commands would you use to retrieve the concise summary of a dataset loaded as pandas data frame ?`,
            mark: 1,
            type: '',
            answer: [
                {
                    text: 'df.describe(include=’all’)',
                    status: true,
                },
                {
                    text: 'df. dtypes',
                    status: false,
                },
                {
                    text: 'df.info()',
                    status: false,
                },
                {
                    text: 'df. describe()',
                    status: false,
                }
            ]
        },
        {
            index: 2,
            text: 'What description best describes the library, Numpy?',
            mark: 1,
            type: '',
            answer: [
                {
                    text: 'Includes functions for some advanced math problems and scientific processes.',
                    status: true,
                },
                {
                    text: 'A highly efficient array processing library capable of quickly performing mathematical transformation functions on single or multi-dimensional arrays.',
                    status: false,
                },
                {
                    text: 'Includes functions for creating various plots that can be used to create different visualizations for the dataset.',
                    status: false,
                },
                {
                    text: 'Offers data structure and tools for effective data manipulation and analysis. It provides fast access to structured data:',
                    status: false,
                }
            ]
        },
        {
            index: 3,
            text: '',
            mark: 1,
            type: '',
            answer: [
                {
                    text: '',
                    status: true,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                }
            ]
        },
        {
            index: 4,
            text: '',
            mark: 1,
            type: '',
            answer: [
                {
                    text: '',
                    status: true,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                }
            ]
        },
        {
            index: 5,
            text: '',
            mark: 1,
            type: '',
            answer: [
                {
                    text: '',
                    status: true,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                }
            ]
        },
        {
            index: 6,
            text: '',
            mark: 1,
            type: '',
            answer: [
                {
                    text: '',
                    status: true,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                }
            ]
        },
        {
            index: 7,
            text: '',
            mark: 1,
            type: '',
            answer: [
                {
                    text: '',
                    status: true,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                }
            ]
        },
        {
            index: 8,
            text: '',
            mark: 1,
            type: '',
            answer: [
                {
                    text: '',
                    status: true,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                }
            ]
        },
        {
            index: 9,
            text: '',
            mark: 1,
            type: '',
            answer: [
                {
                    text: '',
                    status: true,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                }
            ]
        },
        {
            index: 10,
            text: '',
            mark: 1,
            type: '',
            answer: [
                {
                    text: '',
                    status: true,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
                },
                {
                    text: '',
                    status: false,
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
                    {courseType === 'lecture' && (
                        <CourseVideoContent lectureName={itemName} />
                    )}
                    {courseType === 'quiz' && (
                        <CourseQuizContent quizData={quizData} quizName={itemName} />
                    )}
                </div>
            </div>
        </div>
    )
}