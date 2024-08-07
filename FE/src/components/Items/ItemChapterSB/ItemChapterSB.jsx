import React, { useEffect, useState } from "react";
import './ItemChapterSB.css'

import { MdOutlineSlowMotionVideo } from "react-icons/md";
import { GoQuestion } from "react-icons/go";
import { useNavigate } from "react-router-dom";
import { convertTimeString } from "../../../utils/Validation";
import { FaCircleCheck } from "react-icons/fa6";

export default function ItemChapterSB({ item, index, courseName, itemName, courseProcessing }) {
    const [isDone, setIsDone] = useState(false)
    const navigate = useNavigate()
    const handleItemClick = (type) => {
        if (type === 'Lecture') {
            navigate(`/courses/learning/${courseName}/lecture/${item.hashCode}`)
        } else if (type === 'Quiz') {
            navigate(`/courses/learning/${courseName}/quiz/${item.hashCode}`)
        }
    }
    useEffect(() => {
        if (courseProcessing.includes(item.hashCode)) {
            setIsDone(true);
        }
    }, [courseProcessing])
    return (
        <div id="item-chapter-sb" className={itemName === item.hashCode ? 'active' : ''} key={index} onClick={() => { handleItemClick(item.type) }} >
            <div className="logo-item">
                {!isDone ? (
                    <>
                        {item.type === 'Lecture' && (
                            <MdOutlineSlowMotionVideo />
                        )}

                        {item.type === 'Quiz' && (
                            <GoQuestion />
                        )}
                    </>
                ) : (
                    <FaCircleCheck className="check" />
                )}
            </div>
            <div className="item-content">
                <p className="title">
                    <strong className="type">
                        {item.type === 'Lecture' && (
                            'Video:'
                        )}
                        {item.type === 'Quiz' && (
                            'Quiz:'
                        )}
                    </strong> {item.name}
                </p>
                <p className="time">{convertTimeString(item.time)}</p>
            </div>
        </div>
    )
}