import React, { useState } from "react";
import "./LearningCourses.css";
import CNXLogo from "../../../../assets/CNX.png";
import { IoInformationCircleOutline } from "react-icons/io5";
import { IoIosArrowDown } from "react-icons/io";
import { IoIosArrowUp } from "react-icons/io";

const courses = [
  {
    title: "React Development Specialization",
    institution: "CertNexus",
    fields: [
      "Leadership and Management",
      "Strategy and Operations",
      "Critical Thinking",
      "Human Learning",
    ],
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
    fields: [
      "Java Programming",
      "Full-Stack Web Development",
      "Programming Principles",
      "Leadership and Management",
    ],
    duration: "3 month program",
    completionDate: "Completed January 2024",
    certificateLink: "#",
    imageSrc: CNXLogo,
    progress: 30,
  },
  {
    title: "Java Enterprise Edition Specialization",
    institution: "LearnQuest",
    fields: [
      "Java Programming",
      "Full-Stack Web Development",
      "Programming Principles",
      "Leadership and Management",
    ],
    duration: "3 month program",
    completionDate: "Completed January 2024",
    certificateLink: "#",
    imageSrc: CNXLogo,
    progress: 100,
  },
  {
    title: "Java Enterprise Edition Specialization",
    institution: "LearnQuest",
    fields: [
      "Java Programming",
      "Full-Stack Web Development",
      "Programming Principles",
      "Leadership and Management",
    ],
    duration: "3 month program",
    completionDate: "Completed January 2024",
    certificateLink: "#",
    imageSrc: CNXLogo,
    progress: 55,
  },
  {
    title: "Java Enterprise Edition Specialization",
    institution: "LearnQuest",
    fields: [
      "Java Programming",
      "Full-Stack Web Development",
      "Programming Principles",
      "Leadership and Management",
    ],
    duration: "3 month program",
    completionDate: "Completed January 2024",
    certificateLink: "#",
    imageSrc: CNXLogo,
    progress: 95,
  },
  {
    title: "Java Enterprise Edition Specialization",
    institution: "LearnQuest",
    fields: [
      "Java Programming",
      "Full-Stack Web Development",
      "Programming Principles",
      "Leadership and Management",
    ],
    duration: "3 month program",
    completionDate: "Completed January 2024",
    certificateLink: "#",
    imageSrc: CNXLogo,
    progress: 65,
  },
  {
    title: "Java Enterprise Edition Specialization",
    institution: "LearnQuest",
    fields: [
      "Java Programming",
      "Full-Stack Web Development",
      "Programming Principles",
      "Leadership and Management",
    ],
    duration: "3 month program",
    completionDate: "Completed January 2024",
    certificateLink: "#",
    imageSrc: CNXLogo,
    progress: 0,
  },
];

export default function LearningCourses() {
  const [showAll, setShowAll] = useState(false);
  const [itemShow, setItemShow] = useState(3);

  const handleShowMore = () => {
    if (itemShow === 3) {
      setItemShow(courses.length);
      setShowAll(true);
    } else {
      setItemShow(3);
      setShowAll(false);
    }
  };

  return (
    <div id="learning-courses">
      <div className="courses-title">
        <h3 className="education-title">Learning Courses</h3>
        <IoInformationCircleOutline className="info-icon" />
      </div>
      <div id="courses">
        <div className="courses-container">
          {courses.map((course, index) => (
            <div
              key={index}
              className="course-item"
              id={`course-item-${index}`}
              style={index < itemShow ? {} : { display: "none" }}
            >
              <div className="course-header">
                <div className="course-image">
                  <img src={course.imageSrc} alt={course.title} />
                </div>
                <div className="course-details">
                  <h3 id={`course-title-${index}`}>{course.title}</h3>
                  <p id={`institution-${index}`}>{course.institution}</p>
                  <div className="fields" id={`fields-${index}`}>
                    {course.fields.map((field, i) => (
                      <span
                        key={i}
                        className="field-tag"
                        id={`field-tag-${index}-${i}`}
                      >
                        {field}
                      </span>
                    ))}
                  </div>
                  <div className="progress-bar">
                    <div
                      className="progress"
                      style={{ width: `${course.progress}%` }}
                    ></div>
                  </div>
                  <a
                    href={course.certificateLink}
                    className="view-certificate"
                    id={`view-certificate-${index}`}
                  >
                    Resume
                  </a>
                </div>
              </div>
            </div>
          ))}
        </div>
        <div className="show-more">
          <button className="show-all" onClick={handleShowMore}>
            {showAll ? (
              <IoIosArrowUp className="arrow" />
            ) : (
              <IoIosArrowDown className="arrow" />
            )}
            {showAll ? "Show less" : "Show more"}
          </button>
        </div>
      </div>
    </div>
  );
}
