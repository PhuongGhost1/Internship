import React, { useEffect, useState } from "react";
import './CourseQuizContent.css';
import { LuHome } from "react-icons/lu";
import { SlArrowRight, SlArrowLeft } from "react-icons/sl";
import { FaListCheck } from "react-icons/fa6";
import { WiTime8 } from "react-icons/wi";
import { PiGraduationCapLight } from "react-icons/pi";
import ApiService from "../../../../api/ApiService";

export default function CourseQuizContent({ hashCode }) {
    const [isOpenQuiz, setIsOpenQuiz] = useState(false)
    const [quizData, setQuizData] = useState([])
    const [quizName, setQuizName] = useState('')
    const [time, setTime] = useState(null);
    const [minutes, setMinutes] = useState(0);
    const [seconds, setSeconds] = useState(0);
    const [selectedAnswers, setSelectedAnswers] = useState({});

    useEffect(() => {
        if (time <= 0) return;

        const timer = setInterval(() => {
            setTime(prevTime => prevTime - 1);
        }, 1000);
        formatTime(time);
        return () => clearInterval(timer);
    }, [time]);

    useEffect(() => {
        fetchQuiz(hashCode)
        setIsOpenQuiz(false)
    }, [hashCode])

    const fetchQuiz = async (hashCode) => {
        const data = await ApiService.GetQuiz(hashCode);
        setQuizData(data.questions)
        setQuizName(data.name)
    }

    const formatTime = (seconds) => {
        const minutes = Math.floor(seconds / 60);
        const secs = seconds % 60;
        setMinutes(minutes);
        setSeconds(secs);
    };

    const getLetterForIndex = (index) => {
        const letters = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I'];
        return letters[index];
    };

    const handleAnswerClick = (questionIndex, answerIndex) => {
        setSelectedAnswers(prevState => ({
            ...prevState,
            [questionIndex]: answerIndex
        }));
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
            {isOpenQuiz ? (
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
                                    {minutes}
                                </span>
                                <p>Minutes</p>
                            </div>
                            <div className="minutes time-block">
                                <span className="time">
                                    {seconds}
                                </span>
                                <p>Seconds</p>
                            </div>
                        </div>
                        <div className="submit-cancle">
                            <div className="submit-btn button">Submit</div>
                            <div className="back-btn button">Back</div>
                        </div>
                    </div>
                    <div className="questions-container">
                        <p className="title">Questions</p>
                        <div className="questions">
                            {quizData.map((question, questionIndex) => {
                                return (
                                    <div className="question">
                                        <div className="question-text">
                                            <div className="index">
                                                {questionIndex + 1}
                                            </div>
                                            <p className="text">{question.text}</p>
                                        </div>
                                        <div className="answers">
                                            {question.answers.map((answer, answerIndex) => {
                                                return (
                                                    <div className="answer">
                                                        <div className="letter-answer">
                                                            <div
                                                                className={`border-letter ${selectedAnswers[questionIndex] === answerIndex ? 'selected' : ''}`}
                                                                onClick={() => handleAnswerClick(questionIndex, answerIndex)}
                                                            >
                                                                {getLetterForIndex(answerIndex)}
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
            ) : (
                <div className="start-quiz-container">
                    <p className="title">Graded Quiz: {quizName}</p>
                    <div className="grade-start">
                        <div className="grade">
                            <p className="grade-title">Your grade</p>
                            <p className="grade-description">You haven’t submitted this yet</p>
                            <p className="score">0%</p>
                        </div>
                        <div className="start-btn-container">
                            <div className="start-btn" onClick={() => { setIsOpenQuiz(true); setTime(1800) }}>
                                Start Quiz
                            </div>
                        </div>
                    </div>
                </div>
            )}
        </div>
    )
}