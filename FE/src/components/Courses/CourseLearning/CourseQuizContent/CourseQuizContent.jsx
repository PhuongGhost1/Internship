import React, { useEffect, useState } from "react";
import './CourseQuizContent.css';
import { LuHome } from "react-icons/lu";
import { SlArrowRight, SlArrowLeft } from "react-icons/sl";
import { FaListCheck } from "react-icons/fa6";
import { WiTime8 } from "react-icons/wi";
import { PiGraduationCapLight } from "react-icons/pi";
import ApiService from "../../../../api/ApiService";

export default function CourseQuizContent({ hashCode, setIsFetchingProcessing, user }) {
    const [isOpenQuiz, setIsOpenQuiz] = useState(false)
    const [quizId, setQuizId] = useState('')
    const [quizData, setQuizData] = useState([])
    const [quizName, setQuizName] = useState('')
    const [time, setTime] = useState(null);
    const [minutes, setMinutes] = useState(0);
    const [seconds, setSeconds] = useState(0);
    const [selectedAnswers, setSelectedAnswers] = useState({});
    const [grade, setGrade] = useState(null);
    const [isSubmit, setIsSubmit] = useState(false);
    const [isPass, setIsPass] = useState(false);

    useEffect(() => {
        if (user) {
            fetchSubmission(hashCode, user.id);
        }
    }, [user, hashCode])

    useEffect(() => {
        if (isSubmit) {
            fetchSubmission(hashCode, user.id);
            setIsSubmit(false)
        }
    }, [isSubmit])


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
        setQuizId(data.id)
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
    const fetchSubmission = async (hashCodeQuiz, userId) => {
        const data = await ApiService.GetSubmission(hashCodeQuiz, userId)
        setGrade(data.grade)
        setIsPass(data.isPass)
    }
    const fetchMarkQuiz = async (answers, hashCodeQuiz, userId) => {
        const data = await ApiService.MarkQuiz(answers, hashCodeQuiz, userId)
    }
    const handleSubmitClick = async () => {
        console.log(Object.values(selectedAnswers));
        await fetchMarkQuiz(Object.values(selectedAnswers), hashCode, user.id).then(
            () => {
                setGrade(0)
                setIsOpenQuiz(false)
                setIsSubmit(true)
                setSelectedAnswers({})
            }
        )
    }

    useEffect(() => {
        if (isPass) {
            hanldePass(quizId, user.id)
        }
        setIsFetchingProcessing(true)
    }, [isPass])

    const hanldePass = async (itemId, userId) => {
        const data = await ApiService.CreateProcessing(itemId, userId);
    }
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
                            <div className="submit-btn button" onClick={handleSubmitClick}>Submit</div>
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
                                                                className={`border-letter ${selectedAnswers[questionIndex] === answer.id ? 'selected' : ''}`}
                                                                onClick={() => handleAnswerClick(questionIndex, answer.id)}
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
                            <p className="grade-description">{!grade ? 'You haven’t submitted this yet' : 'Get your highest score'}</p>
                            <p className="score">{grade ? grade : 0}%</p>
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