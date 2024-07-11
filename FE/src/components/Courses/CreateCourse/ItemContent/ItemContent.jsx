import React, { useEffect, useState } from "react";
import './ItemContent.css';
import { GoDeviceCameraVideo } from "react-icons/go";
import { HiOutlineClipboardDocumentList } from "react-icons/hi2";
import { FaPlus } from "react-icons/fa";
import { RxCrossCircled } from "react-icons/rx";
import { PiSealQuestionFill } from "react-icons/pi";
import { FaRegTrashCan } from "react-icons/fa6";
import { FaRegCheckSquare } from "react-icons/fa";
import { IoIosArrowDown } from "react-icons/io";
import Checkbox from '@mui/material/Checkbox';

export default function ItemContent({ data, itemSelected, handleUpdateNameChapter, resetWhenSave, hanldeUpdateLessonType }) {
    const [chapterInput, setChapterInput] = useState('')
    const [itemInput, setItemInput] = useState('')
    const [selectedType, setSelectedType] = useState('')
    const [selectedFile, setSelectedFile] = useState(null);
    const [quizInput, setQuizInput] = useState([])
    const [openDropdownType, setOpenDropdownType] = useState(null)
    const [openDropdownQuestion, setOpenDropdownQuestion] = useState({})
    useEffect(() => {
        setChapterInput(data[itemSelected.chapterIndex - 1]?.name)
    }, [itemSelected.chapterIndex])

    useEffect(() => {
        setItemInput(data[itemSelected.chapterIndex - 1]?.items[itemSelected.itemIndex - 1]?.name)
    }, [itemSelected])

    const hanldeSaveChapter = () => {
        handleUpdateNameChapter(chapterInput, itemSelected.chapterIndex - 1);
        resetWhenSave();
    }

    const hanldeSaveLessonType = () => {
        hanldeUpdateLessonType(
            selectedType,
            itemSelected.chapterIndex - 1,
            itemSelected.itemIndex - 1
        )
    }

    const handleFileChange = (event) => {
        const file = event.target.files[0];
        setSelectedFile(file);
    };

    const handleAddQuestionClick = () => {
        const question = {
            index: quizInput.length + 1,
            text: 'Question',
            type: 'Single',
            answers: [
                {
                    text: 'Choice A',
                    status: true,
                },
                {
                    text: 'Choice B',
                    status: false,
                }
            ]
        }
        setQuizInput(prev => [...prev, question])
        setOpenDropdownQuestion(prev => ({
            ...prev,
            [quizInput.length]: false
        }))
    }
    const handleChangleQuestionType = (index, type) => {
        setQuizInput(prev => prev.map((question, indexQuestion) => {
            if (indexQuestion === index) {
                return {
                    ...question,
                    type: type
                }
            }
            return question
        }))
        setOpenDropdownType(null)
    }
    const handleDropdownQuestion = (index) => {
        setOpenDropdownQuestion(prev => (
            {
                ...prev,
                [index]: !prev[index]
            }
        ))
    }

    const handleStatusAnswer = (indexQuestion, indexAnswer) => {
        setQuizInput(prev => prev.map((question, iQ) => {
            if (indexQuestion === iQ) {
                return {
                    ...question,
                    answers: question.answers.map((answer, iA) => {
                        if (indexAnswer === iA) {
                            return {
                                ...answer,
                                status: !answer.status
                            }
                        }
                        return answer
                    })
                }
            }
            return question
        }))
    }
    const handleTextAnswer = (indexQuestion, indexAnswer, newText) => {
        setQuizInput(prev => prev.map((question, iQ) => {
            if (indexQuestion === iQ) {
                return {
                    ...question,
                    answers: question.answers.map((answer, iA) => {
                        if (indexAnswer === iA) {
                            return {
                                ...answer,
                                text: newText
                            }
                        }
                        return answer
                    })
                }
            }
            return question
        }))
    }
    const hanldeTextQuestion = (indexQuestion, newText) => {
        setQuizInput(prev => prev.map((question, iQ) => {
            if (indexQuestion === iQ) {
                return {
                    ...question,
                    text: newText
                }
            }
            return question
        }))
    }
    return (
        <div id="item-content">
            {itemSelected.chapterIndex !== 0 ? (
                itemSelected.itemIndex !== 0 ? (
                    <>
                        {data[itemSelected.chapterIndex - 1].items[itemSelected.itemIndex - 1].type === 'lecture' && (
                            <div className="lecture">
                                <div className="form">
                                    <div className="title-btn">
                                        <p>Edit: {data[itemSelected.chapterIndex - 1].items[itemSelected.itemIndex - 1].type}: {data[itemSelected.chapterIndex - 1].items[itemSelected.itemIndex - 1].name}</p>
                                        <div className="save-btn">
                                            SAVE
                                        </div>
                                    </div>
                                    <div className="title-upload">
                                        <div className="title-edit">
                                            <p className="title-lecture">
                                                <strong>Title</strong> - choose a title for your lessons
                                            </p>
                                            <input type="text" value={itemInput} className="title-input" onChange={(e) => { setItemInput(e.target.value) }} />
                                        </div>
                                        <div className="upload-edit">
                                            <p className="title">Upload a video file</p>
                                            <div className="button-container">
                                                <input type="file" className="input-video" multiple={false} onChange={handleFileChange} />
                                                {selectedFile ? (
                                                    <>
                                                        <span>1 File Uploaded</span>
                                                        <RxCrossCircled className="cross" onClick={() => { setSelectedFile(null) }} />
                                                    </>
                                                ) : (
                                                    <>
                                                        <FaPlus className="plus" />
                                                        <span>Upload a file</span>
                                                    </>
                                                )}
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        )}
                        {data[itemSelected.chapterIndex - 1].items[itemSelected.itemIndex - 1].type === 'quiz' && (
                            <div className="quiz">
                                <div className="form">
                                    <div className="title-btn">
                                        <p>Edit: {data[itemSelected.chapterIndex - 1].items[itemSelected.itemIndex - 1].type}: {data[itemSelected.chapterIndex - 1].items[itemSelected.itemIndex - 1].name}</p>
                                        <div className="save-btn">
                                            SAVE
                                        </div>
                                    </div>
                                    <div className="title-upload">
                                        <div className="title-edit">
                                            <p className="title-lecture">
                                                <strong>Title</strong> - choose a title for your lessons
                                            </p>
                                            <input type="text" value={itemInput} className="title-input" onChange={(e) => { setItemInput(e.target.value) }} />
                                        </div>
                                        <div className="quiz-add">
                                            <p className="title">Quiz Content</p>
                                            <div className="questions">
                                                {quizInput.map((question, index) => {
                                                    return (
                                                        <div className="question">
                                                            <div className="introduce-bar">
                                                                <div className="name-icon">
                                                                    <div className="title-question">
                                                                        <PiSealQuestionFill />
                                                                        <span>Question {question.index}</span>
                                                                    </div>
                                                                    <div className="type-Selection">
                                                                        <div className="visible-select" onClick={() => { (index === openDropdownType) ? setOpenDropdownType(null) : setOpenDropdownType(index) }}>
                                                                            <FaRegCheckSquare />
                                                                            <span>{question.type} Choice</span>
                                                                            <IoIosArrowDown className="arrow" />
                                                                        </div>
                                                                        <div className="selection-dropdown" style={index === openDropdownType ? {} : { display: 'none' }}>
                                                                            <p>Question type</p>
                                                                            <div className={`selection ${question.type === 'Single' ? 'active' : ''}`} onClick={() => { handleChangleQuestionType(index, 'Single') }}>
                                                                                Single Choice
                                                                            </div>
                                                                            <div className={`selection ${question.type === 'Multiple' ? 'active' : ''}`} onClick={() => { handleChangleQuestionType(index, 'Multiple') }}>
                                                                                Multiple Choice
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div className="action-btn">
                                                                    <div className="edit-btn" onClick={() => { handleDropdownQuestion(index) }}>
                                                                        {openDropdownQuestion[index] ? 'Close' : 'Edit'}
                                                                    </div>
                                                                    <FaRegTrashCan />
                                                                </div>
                                                            </div>
                                                            {openDropdownQuestion[index] && (
                                                                <div className="dropdown-question">
                                                                    <div className="input-container">
                                                                        <p>Question</p>
                                                                        <textarea type="text" placeholder="type here" value={question.text} onChange={(e) => { hanldeTextQuestion(index, e.target.value) }} />
                                                                    </div>
                                                                    <div className="input-container">
                                                                        <p>Answers</p>
                                                                        <div className="answers">
                                                                            {question.answers.map((answer, indexAnswer) => {
                                                                                return (
                                                                                    <div className="answer">
                                                                                        <Checkbox
                                                                                            checked={answer.status}
                                                                                            onChange={() => { handleStatusAnswer(index, indexAnswer) }}
                                                                                            inputProps={{ 'aria-label': 'controlled' }}
                                                                                        />
                                                                                        <input type="text" value={answer.text} onChange={(e) => { handleTextAnswer(index, indexAnswer, e.target.value) }} />
                                                                                    </div>
                                                                                )
                                                                            })}
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            )}
                                                        </div>
                                                    )
                                                })}
                                            </div>
                                            <div className="add-question-btn" onClick={handleAddQuestionClick}>
                                                <FaPlus />
                                                <span>Add New Question</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        )}
                        {data[itemSelected.chapterIndex - 1].items[itemSelected.itemIndex - 1].type === '' && (
                            <div className="lesson">
                                <div className="title-btn">
                                    <p>Lessons</p>
                                    <div className="save-btn" onClick={hanldeSaveLessonType}>
                                        SAVE
                                    </div>
                                </div>
                                <p className="assess">Assess your students</p>
                                <div className="selection">
                                    <div className={`lecture-selection block ${selectedType === 'lecture' ? 'active' : ''}`} onClick={() => { setSelectedType('lecture') }}>
                                        <div className="icon-container">
                                            <GoDeviceCameraVideo />
                                        </div>
                                        <div className="content">
                                            <p className="title">Lecture</p>
                                            <p className="description">Easily upload and display your video content</p>
                                        </div>
                                    </div>
                                    <div className={`quiz-selection block ${selectedType === 'quiz' ? 'active' : ''}`} onClick={() => { setSelectedType('quiz') }}>
                                        <div className="icon-container">
                                            <HiOutlineClipboardDocumentList />
                                        </div>
                                        <div className="content">
                                            <p className="title">Quiz</p>
                                            <p className="description">Allow students to interact with material that was just taught or presented</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        )}
                    </>
                ) : (
                    <div className="chapter-edit">
                        <div className="action-btn">
                            <div className="title">
                                Edit Chapter {itemSelected.chapterIndex}:
                            </div>
                            <div className="btn-contain">
                                <div className="discard button">
                                    DISCARD CHANGES
                                </div>
                                <div className="save button" onClick={hanldeSaveChapter}>
                                    SAVE
                                </div>
                            </div>
                        </div>
                        <div className="chapter-title">
                            <p>Chapter Title</p>
                            <input type="text" value={chapterInput} onChange={(e) => { setChapterInput(e.target.value) }} />
                        </div>
                    </div>
                )
            ) : (
                <></>
            )}
        </div>
    )
}