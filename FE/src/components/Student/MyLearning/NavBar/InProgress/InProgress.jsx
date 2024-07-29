import React, { useState, useEffect } from "react";
import "./InProgress.css";
import ApiService from "../../../../../api/ApiService";

import CNXLogo from "../../../../../assets/CNX.png";
import CSLogo from "../../../../../assets/CS_logo.png";
import ReactJSLogo from "../../../../../assets/React_logo.png";

import { IoInformationCircleOutline } from "react-icons/io5";
import { IoIosArrowDown, IoIosArrowUp } from "react-icons/io";

export default function InProgress({ user }) {
  const [showAll, setShowAll] = useState(false);
  const [itemShow, setItemShow] = useState(3);
  const [searchTerm, setSearchTerm] = useState("");
  const [courses, setCourses] = useState([]);

  useEffect(() => {
    const fetchInProgressData = async () => {
      try {
        const certificationData = await ApiService.getCredentials(user.id);
        setCourses(
          certificationData.map((cert) => ({
            title: cert.certification.course.name,
            institution: cert.certification.course.user.name,
            fields: cert.certification.course.cateCoruse.map(
              (cat) => cat.category.name,
            ),
            imageSrc: cert.certification.course.images[0].url,
            certificateLink: cert.certification.course.id,
            courseName: cert.certification.course.name,
            userId: cert.user.id, // Include user ID here
            progress: cert.certification.course.processings,
          })),
        );
      } catch (error) {
        console.log("Error fetching get credentials list: ", error);
      }
    };

    fetchInProgressData();
  }, []);

  const handleShowMore = () => {
    if (itemShow === 3) {
      setItemShow(courses.length);
      setShowAll(true);
    } else {
      setItemShow(3);
      setShowAll(false);
    }
  };

  const filteredCourses = courses.filter((course) =>
    course.title.toLowerCase().includes(searchTerm.toLowerCase()),
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
                  {/* <a href={course.certificateLink} className="view-certificate" id={`view-certificate-${index}`}>
                                        Resume
                                    </a> */}
                </div>

                <div>
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
