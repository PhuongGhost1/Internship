import React, { useState, useEffect } from "react";
import "./ManageInstructor.css";
import { Pagination, PaginationItem, PaginationLink, Table } from "reactstrap";
import { FaInfoCircle } from "react-icons/fa";
import { FaSearch } from "react-icons/fa";
import { RxCross2 } from "react-icons/rx";
import { FaCalendarDay } from "react-icons/fa6";
import { GoDotFill } from "react-icons/go";
import { FaUserCheck } from "react-icons/fa6";
import { FaCheckCircle } from "react-icons/fa";
import { MdEmail } from "react-icons/md";
import { GrTransaction } from "react-icons/gr";
import { FaUsers } from "react-icons/fa";
import { FaRegStarHalfStroke } from "react-icons/fa6";
import ApiService from "../../../api/ApiService";
import { FaPhoneAlt } from "react-icons/fa";
import { SiGmail } from "react-icons/si";
import IntructorIMG2 from "../../../assets/IntructorIMG2.png";

const pageSize = 12;

const ManageInstructor = () => {
  const [instructors, setInstructors] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");
  const [tagActive, setTagActive] = useState("Activity");
  const [isVisiblePopUp, setIsVisiblePopUp] = useState(false);
  const [currentNum, setCurrentNum] = useState(0);
  const [updateInProgress, setUpdateInProgress] = useState(false);

  useEffect(() => {
    const fetchInstructors = async () => {
      try {
        const instructorsData = await ApiService.getInstructors();
        setInstructors(instructorsData);
      } catch (error) {
        console.error("Error fetching instructors:", error);
      }
    };

    fetchInstructors();
  }, []);

  const handleStatusChange = async (id) => {
    try {
      setUpdateInProgress(true);
      const updatedStatus = await ApiService.updateStatusInstructors(id);

      if (updatedStatus) {
        setInstructors((prevInstructors) =>
          prevInstructors.map((instructor) =>
            instructor.id === id
              ? { ...instructor, isVisible: !instructor.isVisible }
              : instructor,
          ),
        );
      } else {
        console.log("Update status failed or no update needed.");
      }
    } catch (error) {
      console.error("Error updating status:", error);
    } finally {
      setUpdateInProgress(false);
    }
  };

  const handleClick = (event, page) => {
    event.preventDefault();
    setCurrentPage(page);
  };

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const filteredInstructors = instructors.filter((instructor) => {
    const name = instructor.name ? instructor.name.toLowerCase() : "";
    const email = instructor.email ? instructor.email.toLowerCase() : "";
    const search = searchTerm.toLowerCase();

    return name.includes(search) || email.includes(search);
  });

  const indexOfLastInstructor = currentPage * pageSize;
  const indexOfFirstInstructor = indexOfLastInstructor - pageSize;
  const currentInstructors = filteredInstructors.slice(
    indexOfFirstInstructor,
    indexOfLastInstructor,
  );
  const totalPages = Math.ceil(filteredInstructors.length / pageSize);

  const handleOpenPopUpClick = (num) => {
    setIsVisiblePopUp(true);
    try {
      setTimeout(() => {
        let progress = document.querySelector(".popup");
        progress.classList.add("open");
      }, 200);
    } catch (error) {
      <h2>Error Search</h2>;
    }
    setCurrentNum(num);
  };

  const handleCrossClick = () => {
    let progress = document.querySelector(".popup");
    progress.classList.remove("open");
    setTimeout(() => {
      setIsVisiblePopUp(false);
    }, 500);
  };

  const renderContent = () => {
    if (!instructors[currentNum]) return null;

    switch (tagActive) {
      case "Activity":
        return (
          <div className="popup-activity">
            <div className="activity-card">
              <div className="activity-content">
                {(instructors[currentNum].notifications || []).map(
                  (activity, index) => (
                    <div
                      key={index}
                      className={`activity-item ${activity.type}`}
                    >
                      <div className="activity-icon">
                        {activity.type === "payment" && <GrTransaction />}
                        {activity.type === "email" && <MdEmail />}
                        {activity.type === "checked" && <FaCheckCircle />}
                      </div>
                      <div>
                        <p>{activity.datetime}</p>
                        <p>{activity.name}</p>
                      </div>
                    </div>
                  ),
                )}
              </div>
            </div>
          </div>
        );
      case "Course":
        return (
          <div className="popup-course">
            {(instructors[currentNum].courses || []).map((course, index) => (
              <div key={index} className="course-card">
                <img
                  src={course.images[0].url}
                  alt={`${course.name} logo`}
                  className="course-logo"
                />
                <div className="course-details">
                  <h3>{course.name}</h3>
                  <div className="course-icon">
                    <div className="course-icon-item">
                      <FaRegStarHalfStroke />
                      <p>{course.rating}</p>
                    </div>
                    <div className="course-icon-item">
                      <FaUsers />
                      <p>{course.price}</p>
                    </div>
                  </div>
                </div>
              </div>
            ))}
          </div>
        );
      case "Payment-History":
        return (
          <div className="popup-payment">
            <div className="payment-history">
              {(instructors[currentNum].payments || []).map(
                (payment, index) => (
                  <div key={index} className="payment-item">
                    {payment.paymentCourses &&
                    payment.paymentCourses.length > 0 ? (
                      payment.paymentCourses.map(
                        (paymentCourse, courseIndex) => (
                          <div key={courseIndex}>
                            <p>
                              <strong>Course:</strong>{" "}
                              {paymentCourse.cartCourseDto.courseForAdminDto
                                .name || "Unknown Course"}
                            </p>
                            <p>
                              <strong>Amount: </strong>
                              <span>+{payment.total}</span>{" "}
                            </p>
                          </div>
                        ),
                      )
                    ) : (
                      <div>
                        <p>Not paying yet</p>
                        <p>
                          <strong>Amount: </strong>
                          <span>+{payment.total}</span>{" "}
                        </p>
                      </div>
                    )}
                  </div>
                ),
              )}
            </div>
          </div>
        );
      default:
        return null;
    }
  };

  return (
    <div id="ManageInstructor">
      <div className="ManageInstructor-top">
        <div className="management-instructor-pagination">
          <Pagination>
            <PaginationItem disabled={currentPage <= 1}>
              <PaginationLink
                previous
                onClick={(e) => handleClick(e, currentPage - 1)}
              />
            </PaginationItem>
            {[...Array(totalPages)].map((_, page) => (
              <PaginationItem key={page + 1} active={page + 1 === currentPage}>
                <PaginationLink onClick={(e) => handleClick(e, page + 1)}>
                  {page + 1}
                </PaginationLink>
              </PaginationItem>
            ))}
            <PaginationItem disabled={currentPage >= totalPages}>
              <PaginationLink
                next
                onClick={(e) => handleClick(e, currentPage + 1)}
              />
            </PaginationItem>
          </Pagination>
        </div>
        <div className="search-bar">
          <FaSearch />
          <input
            type="text"
            placeholder="Search by name or email"
            value={searchTerm}
            onChange={handleSearchChange}
          />
        </div>
      </div>
      <Table className="instructor-list">
        <thead>
          <tr>
            <th>No</th>
            <th>Email</th>
            <th>Name</th>
            <th>Status</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {currentInstructors.map((instructor, index) => (
            <tr key={instructor.id}>
              <td className="no" scope="row">
                {indexOfFirstInstructor + index + 1}
              </td>
              <td className="email">{instructor.email}</td>
              <td className="name">
                {instructor.name === null ? "Not Provided" : instructor.name}
              </td>
              <td className="status">
                <button
                  className={`status-toggle status-${instructor.isVisible}`}
                  onClick={() => handleStatusChange(instructor.id)}
                  disabled={updateInProgress}
                >
                  {instructor.isVisible === true ? <p>Block</p> : <p>Active</p>}
                </button>
              </td>
              <td className="action">
                <span className="button-view">
                  <FaInfoCircle
                    onClick={() => {
                      handleOpenPopUpClick(index);
                    }}
                  />
                </span>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
      <div style={isVisiblePopUp ? {} : { display: "none" }}>
        {isVisiblePopUp && (
          <div className="popup">
            <div className="cross">
              <RxCross2 onClick={handleCrossClick} />
            </div>
            <div className="popup-container">
              <div className="popup-info">
                <div className="popup-info-image">
                  <img
                    src={
                      currentInstructors[currentNum].images[0]?.url ||
                      IntructorIMG2
                    }
                    alt={currentInstructors[currentNum].images[0]?.url || ""}
                  />
                </div>
                <div className="popup-info-title">
                  <h2>{currentInstructors[currentNum].name}</h2>
                  <div className="popup-info-title2">
                    <p>Age 21</p> <GoDotFill />
                    <p>
                      {
                        currentInstructors[currentNum].roleUsers[0].roles[0]
                          .name
                      }
                    </p>
                    <GoDotFill />
                    <p>Viet Nam</p>
                  </div>
                </div>
              </div>
              <div className="popup-status">
                <div className="popup-statuss">
                  <FaCalendarDay />
                  <p>{currentInstructors[currentNum].createAt}</p>
                </div>
                <div className="popup-statuss">
                  <FaUserCheck />
                  <p>{currentInstructors[currentNum].createAt}</p>
                </div>
              </div>
              <div className="popup-contact">
                <div className="popup-card">
                  <SiGmail />
                  <p>{currentInstructors[currentNum].email}</p>
                </div>
                <div className="popup-card">
                  <FaPhoneAlt />
                  <p>{currentInstructors[currentNum].phone}</p>
                </div>
              </div>
              <div className="details">
                <h3>Details</h3>
                <div className="nav-bar">
                  <div
                    className={`activity tag ${
                      tagActive === "Activity" ? "active" : ""
                    }`}
                    onClick={() => {
                      setTagActive("Activity");
                    }}
                  >
                    Activity
                  </div>
                  <div
                    className={`course tag ${
                      tagActive === "Course" ? "active" : ""
                    }`}
                    onClick={() => {
                      setTagActive("Course");
                    }}
                  >
                    Course
                  </div>
                  <div
                    className={`payment-history tag ${
                      tagActive === "Payment-History" ? "active" : ""
                    }`}
                    onClick={() => {
                      setTagActive("Payment-History");
                    }}
                  >
                    Payment History
                  </div>
                </div>
                <div className="content">{renderContent()}</div>
              </div>
            </div>
          </div>
        )}
      </div>
    </div>
  );
};

export default ManageInstructor;
