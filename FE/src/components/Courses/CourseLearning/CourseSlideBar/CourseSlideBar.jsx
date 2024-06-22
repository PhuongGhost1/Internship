import React, { useEffect } from "react";
import './CourseSlideBar.css'

import ChapterDetailSB from "../../../Items/ChapterDetailSB/ChapterDetailSB";
import { FaListUl } from "react-icons/fa";

export default function CourseSlideBar({data}){
    return (
        <div id="course-slidebar">
            <div className="menu">
            <FaListUl />
            <p>Hide Menu</p>
            </div>
            {data.map((chapter, index)=>{
                return(
                    <ChapterDetailSB chapter = {chapter} index={index}/>
                )
            })
            }
        </div>
    )
}