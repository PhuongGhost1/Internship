import React, { useEffect, useState, useRef } from "react";
import "./CreatedCourse.css";
import { IoMdMore } from "react-icons/io";
import ApiService from "../../../../api/ApiService";

export default function CreatedCourse({ user }) {
  const [instructorProfile, setInstructorProfile] = useState(null);
  const [openDropdownIndex, setOpenDropdownIndex] = useState(null);
  const [isOpenVisible, setIsOpenVisible] = useState(false);
  const [currentCourse, setCurrentCourse] = useState(null);
  const dropdownRef = useRef(null);

  useEffect(() => {
    const fetchInstructorProfileData = async () => {
      try {
        const data = await ApiService.getInstructorProfile(user.id);
        setInstructorProfile(data);
      } catch (error) {
        console.log("Error fetching instructor profile data: ", error);
      }
    };

    fetchInstructorProfileData();
  }, [user.id]);

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
        setIsOpenVisible(false);
        setOpenDropdownIndex(null);
      }
    };

    document.addEventListener("mousedown", handleClickOutside);
    return () => {
      document.removeEventListener("mousedown", handleClickOutside);
    };
  }, []);

  const handleDropdownClick = (index, course) => {
    setOpenDropdownIndex(index === openDropdownIndex ? null : index);
    setCurrentCourse(course);
  };

  if (!instructorProfile) {
    return <div>Loading...</div>;
  }

  if (!instructorProfile.courses || !Array.isArray(instructorProfile.courses)) {
    return <div>Loading...</div>;
  }

  return (
    <div id="created-course">
      <div className="created-title">
        <h3 className="created-course-title">Created Courses</h3>
      </div>
      <div id="created">
        {instructorProfile.courses.map((course, index) => (
          <div
            key={course.id}
            className="created-course-item"
            id={`created-course-title-${index}`}
          >
            <div className="created-course-header">
              <div className="created-course-image">
                <img src={course.images[0]?.url} alt={course.name} />
              </div>
              <div className="created-course-details">
                <h4 id={`course-title-${index}`}>{course.name}</h4>
                <a
                  href={`/courses/${course.name}`}
                  className="view-course-detail"
                  id={`view-course-detail-${index}`}
                >
                  View course detail
                </a>
              </div>
              <div className="course-actions"
                onClick={() => {
                  handleDropdownClick(index, course); // Show the dropdown
                  setIsOpenVisible(true); // Show the popup
                }}
              >
                <IoMdMore
                  className="more-icon"
                  onClick={() => {
                    handleDropdownClick(index, course); // Show the dropdown
                    setIsOpenVisible(true); // Show the popup
                  }}
                />
              </div>


              {currentCourse && openDropdownIndex === index && (
                <div
                  className="popup-update"
                  style={
                    isOpenVisible ? { display: "block" } : { display: "none" }
                  }
                >
                  <div className="popup-update-buttonclose-container">
                    <div
                      className="popup-update-buttonclose"
                      onClick={() => {
                        setIsOpenVisible(false);
                        setCurrentCourse(null); // Clear current course on close
                      }}
                      title="Close Popup"
                    >
                      Close X
                    </div>
                  </div>

                  <div className="popup-row">
                    <div className="popup-row-title">
                      <p>Select The Section To Edit</p>
                    </div>

                    <div className="popup-row-text">
                      <p>You can edit your course title and description</p>
                      <p><strong>Course ID:</strong> {currentCourse.id}</p>
                      <p><strong>Course Name:</strong> {currentCourse.name}</p>
                      <p><strong>Description:</strong> {currentCourse.description}</p>
                      {/* Display other course details as needed */}
                    </div>
                  </div>
                </div>
              )}

              <div
                className="overlay1"
                style={
                  isOpenVisible ? { display: "block" } : { display: "none" }
                }
                onClick={() => {
                  setIsOpenVisible(false);
                  setCurrentCourse(null); // Clear current course on overlay click
                }}
              ></div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
