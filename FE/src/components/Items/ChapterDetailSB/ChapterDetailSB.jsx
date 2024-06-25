import React, { useEffect } from "react";
import './ChapterDetailSB.css'

import ItemChapterSB from "../ItemChapterSB/ItemChapterSB";

export default function ChapterDetailSB({chapter}, {index}){
    return(
        <div id="chapter-detail-sb" key={index}>
            <div className="title-chaper">
                <p>{chapter.name}</p>
            </div>
            <div className="items-dropdown">
                {chapter.items.map((item, index)=>{
                    return(
                    <ItemChapterSB item = {item} index = {index}/>
                )})}
            </div>
        </div>
    )
}