import React, { useEffect } from "react";
import './ItemChapterSB.css'

import { MdOutlineSlowMotionVideo } from "react-icons/md";
import { GoQuestion } from "react-icons/go";

export default function ItemChapterSB({ item }, { index }) {

    return (
        <div id="item-chapter-sb" key={index} >
            <div className="logo-item">
                {item.type === 'lecture' && (
                    <MdOutlineSlowMotionVideo />
                )}

                {item.type === 'quiz' && (
                    <GoQuestion />
                )}
            </div>
            <div className="item-content">
                <p className="title">
                    <strong className="type">
                        {item.type === 'lecture' && (
                            'Video:'
                        )}
                        {item.type === 'quiz' && (
                            'Quiz:'
                        )}
                    </strong> {item.name}
                </p>
                <p className="time">{item.time}</p>
            </div>
        </div>
    )
}