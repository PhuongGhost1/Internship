import React, { useEffect } from "react";
import './CourseQuizContent.css';
import { LuHome } from "react-icons/lu";
import { SlArrowRight, SlArrowLeft } from "react-icons/sl";
import { FaListCheck } from "react-icons/fa6";
import { WiTime8 } from "react-icons/wi";
import { PiGraduationCapLight } from "react-icons/pi";

export default function CourseQuizContent({ quizData, quizName }) {
    useEffect(() => {
        console.log(quizData)
    }, [])
    const getLetterForIndex = (index) => {
        const letters = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I'];
        return letters[index];
    };
    return (
        <div id="course-quiz-content">
            <div className="action-btn">
                <div className="path">
                    <LuHome className="home-icon redict" />
                    <SlArrowRight className="arrow" />
                    <span className="course redict">Course</span>
                    <SlArrowRight className="arrow" />
                    <span className="lecture-name redict">Quiz: {quizName}</span>
                </div>
                <div className="prev-next">
                    <div className="prev btn">
                        <SlArrowLeft className="arrow left" />
                        Prev
                    </div>
                    <div className="next btn">
                        Next
                        <SlArrowRight className="arrow right" />
                    </div>
                </div>
            </div>
            <div className="quiz-container">
                <div className="quiz-info">
                    <p className="title">Quiz info</p>
                    <div className="info-board board">
                        <div className="question info">
                            <div>
                                <FaListCheck />
                                <span>Questions</span>
                            </div>
                            <span>10</span>
                        </div>
                        <div className="time info">
                            <div>
                                <WiTime8 />
                                <span>Time</span>
                            </div>
                            <span>30m</span>
                        </div>
                        <div className="level info">
                            <div>
                                <PiGraduationCapLight />
                                <span>Level</span>
                            </div>
                            <span>Beginner</span>
                        </div>
                    </div>
                    <p className="title">Time</p>
                    <div className="time-board board">
                        <div className="hours time-block">
                            <span className="time">
                                18
                            </span>
                            <p>Minutes</p>
                        </div>
                        <div className="minutes time-block">
                            <span className="time">
                                30
                            </span>
                            <p>Seconds</p>
                        </div>
                    </div>
                </div>
                <div className="questions-container">
                    <p className="title">Questions</p>
                    <div className="questions">
                        {quizData.map((question, index) => {
                            return (
                                <div className="question">
                                    <div className="question-text">
                                        <div className="index">
                                            {index + 1}
                                        </div>
                                        <p className="text">{question.text}</p>
                                    </div>
                                    <div className="answers">
                                        {question.answer.map((answer, index) => {
                                            return (
                                                <div className="answer">
                                                    <div className="letter-answer">
                                                        <div className="border-letter">
                                                            {getLetterForIndex(index)}
                                                        </div>
                                                    </div>
                                                    <p>{answer.text}</p>
                                                </div>
                                            )
                                        })}
                                    </div>
                                </div>
                            )
                        })}
                    </div>
                </div>
            </div>
        </div>
    )
}