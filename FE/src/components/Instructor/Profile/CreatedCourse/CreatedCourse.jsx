import React, { useEffect, useState } from "react";
import "./CreatedCourse.css";
import { IoMdMore } from "react-icons/io";
import { GrUpdate } from "react-icons/gr";
import { FaRegStopCircle } from "react-icons/fa";
import { MdDeleteOutline } from "react-icons/md";
import ApiService from "../../../../api/ApiService";

export default function CreatedCourse() {
  const [instructorProfile, setInstructorProfile] = useState(null); // Initialize with null
  const [openDropdownIndex, setOpenDropdownIndex] = useState(null);

  useEffect(() => {
    const fetchInstructorProfileData = async () => {
      try {
        const data = await ApiService.getInstructorProfile("user_400182aadc");
        setInstructorProfile(data);
      } catch (error) {
        console.log("Error fetching instructor profile data: ", error);
      }
    };

    fetchInstructorProfileData();
  }, []);

  const handleDropdownClick = (index) => {
    setOpenDropdownIndex(index === openDropdownIndex ? null : index);
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
        {instructorProfile ? (
          instructorProfile.courses.map((course, index) => (
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
                <div className="course-actions">
                  <IoMdMore
                    className="more-icon"
                    onClick={() => handleDropdownClick(index)}
                  />
                  <div
                    className="more-dropdown"
                    style={{
                      display: openDropdownIndex === index ? "block" : "none",
                    }}
                  >
                    <div className="update btnz">
                      <GrUpdate />
                      &nbsp;&nbsp;Update
                    </div>
                    <div className="stop btnz">
                      <FaRegStopCircle />
                      &nbsp;&nbsp;Stop
                    </div>
                    <div className="delete btnz">
                      <MdDeleteOutline />
                      &nbsp;&nbsp;Delete
                    </div>
                  </div>
                </div>
              </div>
            </div>
          ))
        ) : (
          <p>No created courses available.</p>
        )}
      </div>
    </div>
  );
}
