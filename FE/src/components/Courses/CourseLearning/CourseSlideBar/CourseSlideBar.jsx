import React, { useEffect, useState } from "react";
import './CourseSlideBar.css'

import ChapterDetailSB from "../../../Items/ChapterDetailSB/ChapterDetailSB";
import { FaListUl } from "react-icons/fa";
import { MdMoreVert } from "react-icons/md";

export default function CourseSlideBar({ data, courseName, itemName }) {
    const [isOpenSlideBar, setIsOpenSlideBar] = useState(true)
    const [isContentVisible, setIsContentVisible] = useState(true);

    const handleHideMenuClick = () => {
        setIsOpenSlideBar(false)
        setTimeout(() => {
            setIsContentVisible(false);
        }, 500);
    }

    const handleMoreClick = () => {
        setIsOpenSlideBar(true)
        setIsContentVisible(true)
    }

    return (
        <div id="course-slidebar" className={isOpenSlideBar ? '' : 'hide'}>
            {!isOpenSlideBar && (
                <div className="more-icon" onClick={handleMoreClick}>
                    <MdMoreVert />
                </div>
            )}
            {isContentVisible && (
                <div className="slide-bar-content">
                    <div className="menu" onClick={handleHideMenuClick}>
                        <FaListUl />
                        <p>Hide Menu</p>
                    </div>
                    {data.map((chapter, index) => (
                        <ChapterDetailSB
                            key={index}
                            chapter={chapter}
                            index={index}
                            courseName={courseName}
                            itemName={itemName} />
                    ))}
                </div>
            )}
        </div>
    )
}