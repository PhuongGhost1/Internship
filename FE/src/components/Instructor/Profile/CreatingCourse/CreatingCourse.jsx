import React from "react";
import './CreatingCourse.css'
import HTMLlogo from '../../../../assets/Html-Title.png';
import Clogo from '../../../../assets/C++-Title.png';
import ITlogo from '../../../../assets/IT-Title.png';
import JavaScriptlogo from '../../../../assets/JavaScript-Title.png';
import { FaArrowRight } from "react-icons/fa";

const creatingCourse = [
    {
        title: "HTML CSS từ Zero đến Hero",
        certificateLink: "#",
        imageSrc: HTMLlogo,
    },
    {
        title: "Lập trình C++ cơ bản, nâng cao",
        certificateLink: "#",
        imageSrc: Clogo,
    },
    {
        title: "Kiến Thức Nhập Môn IT",
        certificateLink: "#",
        imageSrc: ITlogo,
    },
    {
        title: "Lập Trình JavaScript Cơ Bản",
        certificateLink: "#",
        imageSrc: JavaScriptlogo,
    },
]

export default function CreatingCourse() {

    return (
        <div id="creating-course">
            <div className="creating-titile">
                <h3 className="creating-course-title">Draft</h3>
            </div>
            <div id="creating">
                {creatingCourse.map((cert, index) => (
                    <div key={index} className="creating-course-item" id={`creating-course-title-${index}`}>
                        <div className="creating-course-header">
                            <div className="creating-course-image">
                                <img src={cert.imageSrc} alt={cert.title} />
                            </div>
                            <div className="creating-course-details">
                                <h4 id={`course-title-${index}`}>{cert.title}</h4>
                                <a href={cert.courseLink} className="view-course-detail" id={`view-course-detail-${index}`}>View course detail</a>
                            </div>
                            <div class="creating-course-button">
                                <a href="#">Continue <FaArrowRight /></a>
                            </div>
                        </div>
                    </div>

                ))}
            </div>
        </div>

    )
}