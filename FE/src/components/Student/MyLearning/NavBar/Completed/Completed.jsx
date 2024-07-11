import React, { useState } from "react";
import './Completed.css';

import CNXLogo from '../../../../../assets/CNX.png';
import DotnetLogo from '../../../../../assets/Dotnet_logo.png';

import { IoInformationCircleOutline } from "react-icons/io5";
import { IoIosArrowDown, IoIosArrowUp } from "react-icons/io";

const courses = [
    {
        title: "React Development Specialization",
        institution: "CertNexus",
        fields: ["Leadership and Management", "Strategy and Operations", "Critical Thinking", "Human Learning"],
        duration: "8 month program",
        completionDate: "Completed November 2023",
        certificateLink: "#",
        imageSrc: CNXLogo,
        progress: 100,
    },
    {
        title: "React Development Specialization",
        institution: "React",
        fields: ["React", "JavaScript", "Front-end Development"],
        duration: "6 month program",
        completionDate: "Completed May 2024",
        certificateLink: "#",
        imageSrc: CNXLogo,
        progress: 100,
    },
    {
        title: "Java Enterprise Edition Specialization",
        institution: "LearnQuest",
        fields: ["Java Programming", "Full-Stack Web Development", "Programming Principles", "Leadership and Management"],
        duration: "3 month program",
        completionDate: "Completed January 2024",
        certificateLink: "#",
        imageSrc: CNXLogo,
        progress: 100,
    },
    {
        title: "Java Enterprise Edition Specialization",
        institution: "LearnQuest",
        fields: ["Java Programming", "Full-Stack Web Development", "Programming Principles", "Leadership and Management"],
        duration: "3 month program",
        completionDate: "Completed January 2024",
        certificateLink: "#",
        imageSrc: CNXLogo,
        progress: 1,
    },
    {
        title: "Python for Everybody Specialization",
        institution: "University of Michigan",
        fields: ["Python Programming", "Data Analysis", "Web Development", "Programming Principles"],
        duration: "4 month program",
        completionDate: "Completed February 2024",
        certificateLink: "#",
        imageSrc: DotnetLogo,
        progress: 1,
    },
    {
        title: "Full-Stack Web Development with React",
        institution: "The Hong Kong University of Science and Technology",
        fields: ["Web Development", "React.js", "JavaScript", "Front-End Development"],
        duration: "5 month program",
        completionDate: "Completed March 2024",
        certificateLink: "#",
        imageSrc: DotnetLogo,
        progress: 1,
    },
    {
        title: "Data Science Specialization",
        institution: "Johns Hopkins University",
        fields: ["Data Science", "R Programming", "Machine Learning", "Data Visualization"],
        duration: "6 month program",
        completionDate: "Completed April 2024",
        certificateLink: "#",
        imageSrc: DotnetLogo,
        progress: 1,
    },
    {
        title: "Machine Learning",
        institution: "Stanford University",
        fields: ["Machine Learning", "Artificial Intelligence", "Data Science", "Algorithms"],
        duration: "3 month program",
        completionDate: "Completed May 2024",
        certificateLink: "#",
        imageSrc: DotnetLogo,
        progress: 1,
    },
    {
        title: "Cloud Computing Specialization",
        institution: "University of Illinois at Urbana-Champaign",
        fields: ["Cloud Computing", "Networking", "Security", "Systems Administration"],
        duration: "4 month program",
        completionDate: "Completed June 2024",
        certificateLink: "#",
        imageSrc: DotnetLogo,
        progress: 1,
    }

];

export default function Completed() {
    const [showAll, setShowAll] = useState(false);
    const [itemShow, setItemShow] = useState(3);
    const [searchTerm, setSearchTerm] = useState("");

    const handleShowMore = () => {
        if (itemShow === 3) {
            setItemShow(courses.length);
            setShowAll(true);
        } else {
            setItemShow(3);
            setShowAll(false);
        }
    };

    const filteredCourses = courses.filter(course =>
        course.title.toLowerCase().includes(searchTerm.toLowerCase())
    );

    return (
        <div id="Completed">

            <div className="courses-title">
                <h3 className="education-title">Courses Completed</h3>
                <IoInformationCircleOutline className="info-icon" />
            </div>

            <div id="search-bar">
                <input
                    type="text"
                    placeholder="Search Courses..."
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                />
            </div>

            <div id="courses">
                <div className="courses-container">
                    {filteredCourses.map((course, index) => (
                        <div key={index} className="course-item" id={`course-item-${index}`} style={index < itemShow ? {} : { display: 'none' }}>
                            <div className="course-header">
                                <div className="course-image">
                                    <img src={course.imageSrc} alt={course.title} />
                                </div>
                                <div className="course-details">
                                    <h3 id={`course-title-${index}`}>{course.title}</h3>
                                    <p id={`institution-${index}`}>{course.institution}</p>
                                    <div className="fields" id={`fields-${index}`}>
                                        {course.fields.map((field, i) => (
                                            <span key={i} className="field-tag" id={`field-tag-${index}-${i}`}>{field}</span>
                                        ))}
                                    </div>

                                    {/* Line Progressing */}
                                    {/* <div className="progress-bar">
                                        <div className="progress" style={{ width: `${course.progress}%` }}></div>
                                    </div> */}

                                    {/* <a href={course.certificateLink} className="view-certificate" id={`view-certificate-${index}`}>
                                        {course.progress === 100 ? "Review" : "Resume"}
                                    </a> */}
                                </div>

                                <div className="bt-view-ceritifcated">
                                    <a href={course.certificateLink} className="view-review" >
                                        Review
                                    </a>
                                    <a href={course.certificateLink} className="view-certificate" id={`view-certificate-${index}`}>
                                        Certificated
                                    </a>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
                <div className="show-more">
                    <button className="show-all" onClick={handleShowMore}>
                        {showAll ? <IoIosArrowUp className="arrow" /> : <IoIosArrowDown className="arrow" />}
                        {showAll ? "Show less" : "Show more"}
                    </button>
                </div>
            </div>
        </div>
    );
}