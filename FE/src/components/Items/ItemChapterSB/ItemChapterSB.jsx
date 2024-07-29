import React, { useEffect } from "react";
import './ItemChapterSB.css'

import { MdOutlineSlowMotionVideo } from "react-icons/md";
import { GoQuestion } from "react-icons/go";
import { useNavigate } from "react-router-dom";
import { convertTimeString } from "../../../utils/Validation";

export default function ItemChapterSB({ item, index, courseName, itemName }) {
    const navigate = useNavigate()
    const handleItemClick = (type) => {
        if (type === 'Lecture') {
            navigate(`/courses/learning/${courseName}/lecture/${item.hashCode}`)
        } else if (type === 'Quiz') {
            navigate(`/courses/learning/${courseName}/quiz/${item.hashCode}`)
        }
    }
    return (
        <div id="item-chapter-sb" className={itemName === item.hashCode ? 'active' : ''} key={index} onClick={() => { handleItemClick(item.type) }} >
            <div className="logo-item">
                {item.type === 'Lecture' && (
                    <MdOutlineSlowMotionVideo />
                )}

                {item.type === 'Quiz' && (
                    <GoQuestion />
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