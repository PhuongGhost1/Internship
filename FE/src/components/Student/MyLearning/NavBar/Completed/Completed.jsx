import React, { useState, useEffect, useContext } from "react";
import "./Completed.css";
import ApiService from "../../../../../api/ApiService";

import { IoInformationCircleOutline } from "react-icons/io5";
import { IoIosArrowDown, IoIosArrowUp } from "react-icons/io";

export default function Completed({ user }) {
  const [showAll, setShowAll] = useState(false);
  const [itemShow, setItemShow] = useState(3);
  const [searchTerm, setSearchTerm] = useState("");
  const [courses, setCourses] = useState([]);

  useEffect(() => {
    const fetchCompletedData = async () => {
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
          })),
        );
      } catch (error) {
        console.log("Error fetching get credentials list: ", error);
      }
    };

    fetchCompletedData();
  }, []);

  const handleShowMore = () => {
    setShowAll((prevShowAll) => !prevShowAll);
    setItemShow((prevItemShow) => (prevItemShow === 3 ? courses.length : 3));
  };

  const filteredCourses = courses.filter((course) =>
    course.title.toLowerCase().includes(searchTerm.toLowerCase()),
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
          {filteredCourses.slice(0, itemShow).map((course, index) => (
            <div key={index} className="course-item">
              <div className="course-header">
                <div className="course-image">
                  <img src={course.imageSrc} alt={course.title} />
                </div>
                <div className="course-details">
                  <h3>{course.title}</h3>
                  <p>{course.institution}</p>
                  <div className="fields">
                    {course.fields.map((field, i) => (
                      <span key={i} className="field-tag">
                        {field}
                      </span>
                    ))}
                  </div>
                </div>
                <div className="bt-view-ceritifcated">
                  <a
                    href={`/courses/${course.courseName}`}
                    className="view-review"
                  >
                    Review
                  </a>
                  <a
                    href={`/student/certification/${course.userId}`}
                    className="view-certificate"
                  >
                    Certificated
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
