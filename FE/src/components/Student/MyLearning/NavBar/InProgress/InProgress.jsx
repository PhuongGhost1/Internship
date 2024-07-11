import React, { useState } from "react";
import './InProgress.css';

import CNXLogo from '../../../../../assets/CNX.png';
import CSLogo from '../../../../../assets/CS_logo.png';
import ReactJSLogo from '../../../../../assets/React_logo.png';

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
        progress: 75,
    },
    {
        title: "React Development Specialization",
        institution: "React",
        fields: ["React", "JavaScript", "Front-end Development"],
        duration: "6 month program",
        completionDate: "Completed May 2024",
        certificateLink: "#",
        imageSrc: CNXLogo,
        progress: 10,
    },
    {
        title: "Java Enterprise Edition Specialization",
        institution: "LearnQuest",
        fields: ["Java Programming", "Full-Stack Web Development", "Programming Principles", "Leadership and Management"],
        duration: "3 month program",
        completionDate: "Completed January 2024",
        certificateLink: "#",
        imageSrc: CNXLogo,
        progress: 30,
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
        progress: 55,
    },
    {
        title: "Java Enterprise Edition Specialization",
        institution: "LearnQuest",
        fields: ["Java Programming", "Full-Stack Web Development", "Programming Principles", "Leadership and Management"],
        duration: "3 month program",
        completionDate: "Completed January 2024",
        certificateLink: "#",
        imageSrc: CNXLogo,
        progress: 95,
    },
    {
        title: "Java Enterprise Edition Specialization",
        institution: "LearnQuest",
        fields: ["Java Programming", "Full-Stack Web Development", "Programming Principles", "Leadership and Management"],
        duration: "3 month program",
        completionDate: "Completed January 2024",
        certificateLink: "#",
        imageSrc: CNXLogo,
        progress: 65,
    },
    {
        title: "Java Enterprise Edition Specialization",
        institution: "LearnQuest",
        fields: ["Java Programming", "Full-Stack Web Development", "Programming Principles", "Leadership and Management"],
        duration: "3 month program",
        completionDate: "Completed January 2024",
        certificateLink: "#",
        imageSrc: CNXLogo,
        progress: 0,
    },
    {
        title: "Advanced C# Programming",
        institution: "University of California, San Diego",
        fields: ["Advanced C# Programming", "LINQ", "Asynchronous Programming", "Design Patterns"],
        duration: "5 month program",
        completionDate: "Completed July 2024",
        certificateLink: "#",
        imageSrc: CSLogo,
        progress: 10,
    },
    {
        title: "C# and .NET Development",
        institution: "Microsoft",
        fields: ["C# Programming", ".NET Framework", "Web Development", "Software Engineering"],
        duration: "6 month program",
        completionDate: "Completed August 2024",
        certificateLink: "#",
        imageSrc: CSLogo,
        progress: 35,
    },
    {
        title: "C# for Beginners",
        institution: "Coursera",
        fields: ["C# Basics", "Programming Fundamentals", "Debugging", "Problem Solving"],
        duration: "3 month program",
        completionDate: "Completed September 2024",
        certificateLink: "#",
        imageSrc: CSLogo,
        progress: 45,
    },
    {
        title: "Building Web Applications with C# and ASP.NET",
        institution: "Harvard University",
        fields: ["C# Programming", "ASP.NET", "Web Development", "MVC Framework"],
        duration: "4 month program",
        completionDate: "Completed October 2024",
        certificateLink: "#",
        imageSrc: CSLogo,
        progress: 55,
    },
    {
        title: "Object-Oriented Programming in C#",
        institution: "University of Washington",
        fields: ["Object-Oriented Programming", "C# Programming", "Software Design", "Principles of OOP"],
        duration: "3 month program",
        completionDate: "Completed November 2024",
        certificateLink: "#",
        imageSrc: CSLogo,
        progress: 89,
    },
    {
        title: "C# Data Structures and Algorithms",
        institution: "MIT",
        fields: ["C# Programming", "Data Structures", "Algorithms", "Performance Optimization"],
        duration: "4 month program",
        completionDate: "Completed December 2024",
        certificateLink: "#",
        imageSrc: CSLogo,
        progress: 77.77,
    },
    {
        title: "React Front-End Development",
        institution: "Udacity",
        fields: ["React.js", "JavaScript ES6+", "Redux", "Front-End Development"],
        duration: "3 month program",
        completionDate: "Completed January 2024",
        certificateLink: "#",
        imageSrc: ReactJSLogo,
        progress: 97,
    },
    {
        title: "Advanced React and Redux",
        institution: "Pluralsight",
        fields: ["Advanced React Concepts", "State Management", "Hooks", "Performance Optimization"],
        duration: "2 month program",
        completionDate: "Completed February 2024",
        certificateLink: "#",
        imageSrc: ReactJSLogo,
        progress: 66.89,
    },
    {
        title: "Full-Stack Web Development with MERN",
        institution: "Coursera",
        fields: ["MongoDB", "Express.js", "React.js", "Node.js"],
        duration: "4 month program",
        completionDate: "Completed March 2024",
        certificateLink: "#",
        imageSrc: ReactJSLogo,
        progress: 33.33,
    },
    {
        title: "React Native Mobile Development",
        institution: "LinkedIn Learning",
        fields: ["React Native", "Mobile App Development", "Cross-Platform Development", "UI Design"],
        duration: "3 month program",
        completionDate: "Completed April 2024",
        certificateLink: "#",
        imageSrc: ReactJSLogo,
        progress: 45.96,
    },
    {
        title: "Server-Side Rendering with React",
        institution: "Frontend Masters",
        fields: ["Next.js", "Server-Side Rendering", "SEO Optimization", "Performance"],
        duration: "2 month program",
        completionDate: "Completed May 2024",
        certificateLink: "#",
        imageSrc: ReactJSLogo,
        progress: 16.66,
    },
    {
        title: "React and GraphQL",
        institution: "Udemy",
        fields: ["React.js", "GraphQL", "API Integration", "Data Fetching"],
        duration: "3 month program",
        completionDate: "Completed June 2024",
        certificateLink: "#",
        imageSrc: ReactJSLogo,
        progress: 10,
    },
];

export default function InProgress() {
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
        <div id="InProgress">

            <div className="courses-title">
                <h3 className="education-title">Learning Courses</h3>
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
                                    <div className="progress-bar">
                                        <div className="progress" style={{ width: `${course.progress}%` }}></div>
                                    </div>
                                    {/* <a href={course.certificateLink} className="view-certificate" id={`view-certificate-${index}`}>
                                        Resume
                                    </a> */}
                                </div>

                                <div>
                                    <a href={course.certificateLink} className="view-certificate" id={`view-certificate-${index}`}>
                                        Resume
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
