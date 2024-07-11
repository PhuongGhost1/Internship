import React, { useState } from "react";
import './SidebarCreateCourse.css'
import { IoMdMore } from "react-icons/io";
import { MdOutlineKeyboardArrowDown } from "react-icons/md";
import { RxDragHandleDots2 } from "react-icons/rx";
import { MdOutlineSlowMotionVideo } from "react-icons/md";
import { GoQuestion } from "react-icons/go";
import { MdOutlinePlayLesson } from "react-icons/md";

export default function SidebarCreateCourse({ data, addChapter, addLession, handleItemClick }) {
    const [selectedchapter, setSelectedChapter] = useState()
    const handedropdownClick = (index) => {
        if (selectedchapter === index) {
            setSelectedChapter(null)
        } else {
            setSelectedChapter(index)
        }
    }
    return (
        <div id="sidebar-create-course">
            <div className="action-btn">
                <div className="Add-chapter-btn" onClick={addChapter}>
                    Add Chapter
                </div>
                <div className="more-btn">
                    <IoMdMore />
                </div>
            </div>
            <div className="chapters">
                {data.map((chapter, index) => {
                    return (
                        <div className="chapter" key={index}>
                            <div className="title" onClick={() => { handleItemClick(index + 1, 0) }}>
                                Chapter {chapter.index}: {chapter.name}
                                <MdOutlineKeyboardArrowDown onClick={() => { handedropdownClick(index) }} />
                            </div>
                            {selectedchapter === index && (

                                <div className="dropdown">
                                    <div className="items">
                                        {chapter.items.map((item, indexItem) => {
                                            return (
                                                <div className="item" key={indexItem} onClick={() => { handleItemClick(index + 1, indexItem + 1) }}>
                                                    <div className="icon">
                                                        <RxDragHandleDots2 />
                                                    </div>
                                                    <div className="item-info">
                                                        <p><span>{item.type === 'lecture' && 'Video'}
                                                            {item.type === 'quiz' && 'Quiz'}
                                                            {item.type === '' && 'Lesson'}</span> : {item.name}
                                                        </p>
                                                        {item.type === 'lecture' && (
                                                            <MdOutlineSlowMotionVideo />
                                                        )}
                                                        {item.type === 'quiz' && (
                                                            <GoQuestion />
                                                        )}
                                                        {item.type === '' && (
                                                            <MdOutlinePlayLesson />
                                                        )}
                                                    </div>
                                                </div>
                                            )
                                        })}
                                    </div>
                                    <div className="add-lession" onClick={() => { addLession(index) }}>
                                        Add Lession
                                    </div>
                                </div>
                            )}
                        </div>
                    )
                })}
            </div>
        </div>
    )
}