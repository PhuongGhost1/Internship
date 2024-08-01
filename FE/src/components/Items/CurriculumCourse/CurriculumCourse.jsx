import React, { useState } from "react";
import "./CurriculumCourse.css";

import { FaDiamond } from "react-icons/fa6";
import { IoIosArrowDown } from "react-icons/io";
import { IoIosVideocam } from "react-icons/io";
import { IoDocumentText } from "react-icons/io5";

export default function CurriculumCourse({ data, key, dropdown, setDropdown }) {
  return (
    <div id="curriculum-course">
      <div className="chapter-content">
        <div className="chapter-show">
          <div className="chapter-container">
            <p className="chapter-title">{data.name}</p>
            <div className="detail">
              <span className="lecture">{data.lectureCount} lectures</span>
              <FaDiamond />
              <span className="quiz">{data.quizCount} quizzes</span>
              <FaDiamond />
              <span className="time">{data.totalTime}m</span>
            </div>
          </div>
          <div className="more-detail">
            <div
              className="more-btn"
              onClick={() =>
                dropdown === data.id ? setDropdown(null) : setDropdown(data.id)
              }
            >
              <span>
                {dropdown === data.id ? "Less Details" : "More Details"}
              </span>
              <IoIosArrowDown
                className={`arrow ${dropdown === data.id ? "active" : ""}`}
              />
            </div>
          </div>
        </div>
        <div
          className={`chapter-dropdown ${dropdown === data.id ? "active" : ""}`}
        >
          {data.items.map((item, index) => {
            return (
              <>
                <div
                  className={`item ${
                    index === data.items.length - 1 ? `bottom` : ``
                  }`}
                  key={index}
                >
                  {item.type === "Lecture" && <IoIosVideocam />}
                  {item.type === "Quiz" && <IoDocumentText />}
                  <p className="item-name">{item.name}</p>
                </div>
              </>
            );
          })}
        </div>
      </div>
    </div>
  );
}
