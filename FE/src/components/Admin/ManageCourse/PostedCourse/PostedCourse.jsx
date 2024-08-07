import React, { useEffect, useState } from "react";
import {
  Table,
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
} from "react-bootstrap";
import { FaSearch, FaInfoCircle } from "react-icons/fa";
import { Pagination, PaginationItem, PaginationLink } from "reactstrap";
import PropTypes from "prop-types";
import "./PostedCourse.css";
import ApiService from "../../../../api/ApiService";
import { RxCross2 } from "react-icons/rx";
import { GoDotFill } from "react-icons/go";
import { FaCalendarDay } from "react-icons/fa6";
import { FaUserCheck } from "react-icons/fa6";
import { SiGmail } from "react-icons/si";
import { FaPhoneAlt } from "react-icons/fa";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const DataTable = ({ data, onStatusUpdate }) => {
  const pageSize = 6;
  const [currentPage, setCurrentPage] = useState(1);
  const [courses, setCourses] = useState(data || []);
  const [dropdownOpen, setDropdownOpen] = useState(null);
  const [searchTerm, setSearchTerm] = useState("");
  const [updateInProgress, setUpdateInProgress] = useState(false);
  const [currentNum, setCurrentNum] = useState(0);
  const [isVisiblePopUp, setIsVisiblePopUp] = useState(false);

  useEffect(() => {
    setCourses(data);
  }, [data]);

  const handleClick = (event, page) => {
    event.preventDefault();
    setCurrentPage(page);
  };

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const toggleDropdown = (id) => {
    setDropdownOpen((prev) => (prev === id ? null : id));
  };

  const handleStatusChange = async (courseId, newStatus) => {
    try {
      setUpdateInProgress(true);
      const updatedStatus = await ApiService.updateCourseByAdmin(
        courseId,
        newStatus,
      );

      if (updatedStatus) {
        setCourses((prevCourses) =>
          prevCourses.map((course) =>
            course.id === courseId ? { ...course, status: newStatus } : course,
          ),
        );
        onStatusUpdate();
      } else {
        console.log("Update status failed or no update needed.");
      }
      toast.success(`Updated successfully!`);
    } catch (error) {
      console.error("Error updating status:", error);
      toast.error("Error updating status. Please try again.");
    } finally {
      setUpdateInProgress(false);
      setDropdownOpen(null);
    }
  };

  const statusToString = (status) => {
    if (status === 0) return "Active";
    if (status === 1) return "Cancel";
    if (status === 2) return "Waiting";
    return "Unknown";
  };

  const stringToStatus = (statusString) => {
    if (statusString === "Active") return 0;
    if (statusString === "Cancel") return 1;
    if (statusString === "Waiting") return 2;
    return -1;
  };

  const indexOfLastCourse = currentPage * pageSize;
  const indexOfFirstCourse = indexOfLastCourse - pageSize;

  const filteredCourses = courses.filter(
    (course) =>
      course.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
      course.username.toLowerCase().includes(searchTerm.toLowerCase()),
  );

  const currentCourses = filteredCourses.slice(
    indexOfFirstCourse,
    indexOfLastCourse,
  );
  const totalPages = Math.ceil(filteredCourses.length / pageSize);

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

  return (
    <div id="management-course">
      <div className="table-info">
        <div className="table-header">
          <h3>Waiting Courses</h3>
          <div className="search-bar">
            <FaSearch />
            <input
              type="text"
              placeholder="Search by Name or Instructor"
              value={searchTerm}
              onChange={handleSearchChange}
            />
          </div>
        </div>
        <div>
          <Table className="course-active">
            <thead>
              <tr>
                <th>Course Name</th>
                <th>Image</th>
                <th>Instructor</th>
                <th className="status-heading">Status</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody>
              {currentCourses.map((course, index) => (
                <tr key={course.id}>
                  <td className="name">{course.name}</td>
                  <td className="image">
                    {course.images.map((image, i) => (
                      <img
                        key={i}
                        src={image.url}
                        alt="contact"
                        style={{
                          width: "70px",
                          height: "70px",
                          borderRadius: "50%",
                          margin: "0 5px",
                        }}
                      />
                    ))}
                  </td>
                  <td className="owner">{course.username}</td>
                  <td className="status">
                    <Dropdown
                      isOpen={dropdownOpen === course.id}
                      toggle={() => toggleDropdown(course.id)}
                      className="dropdown-status"
                    >
                      <DropdownToggle
                        caret
                        className={`status-toggle status-${statusToString(
                          course.status,
                        ).toLowerCase()}`}
                      >
                        {statusToString(course.status)}
                      </DropdownToggle>
                      <DropdownMenu className="menu">
                        <DropdownItem
                          className="item"
                          onClick={() =>
                            handleStatusChange(
                              course.id,
                              stringToStatus("Active"),
                            )
                          }
                        >
                          Active
                        </DropdownItem>
                        <DropdownItem
                          className="item"
                          onClick={() =>
                            handleStatusChange(
                              course.id,
                              stringToStatus("Cancel"),
                            )
                          }
                        >
                          Cancel
                        </DropdownItem>
                        <DropdownItem
                          className="item"
                          onClick={() =>
                            handleStatusChange(
                              course.id,
                              stringToStatus("Waiting"),
                            )
                          }
                        >
                          Waiting
                        </DropdownItem>
                      </DropdownMenu>
                    </Dropdown>
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
        </div>
        <Pagination className="pagination-left">
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
                    src={currentCourses[currentNum].images[0]?.url || ""}
                    alt={currentCourses[currentNum].images[0]?.url || ""}
                  />
                </div>
                <div className="popup-info-title">
                  <h2>{currentCourses[currentNum].name}</h2>
                  <div className="popup-info-title2">
                    <p>Age 21</p> <GoDotFill />
                    <p>{currentCourses[currentNum].username}</p>
                    <GoDotFill />
                    <p>Viet Nam</p>
                  </div>
                </div>
              </div>
              <div className="popup-status">
                <div className="popup-statuss">
                  <FaCalendarDay />
                  <p>{currentCourses[currentNum].createAt}</p>
                </div>
                <div className="popup-statuss">
                  <FaUserCheck />
                  {currentCourses[currentNum].updateAt === null ? (
                    <p>Chua co thong tin</p>
                  ) : (
                    currentCourses[currentNum].updateAt
                  )}
                </div>
              </div>
              <div className="popup-contact">
                <div className="popup-card">
                  <SiGmail />
                  <p>{currentCourses[currentNum].email}</p>
                </div>
                <div className="popup-card">
                  <FaPhoneAlt />
                  <p>{currentCourses[currentNum].phone}</p>
                </div>
              </div>
              <div className="details">
                <h3>Details</h3>
                <div className="content" style={{ whiteSpace: "pre-line" }}>
                  {currentCourses[currentNum].whatLearn
                    .split(" + ")
                    .map((item, index) => (
                      <div key={index}>{item}</div>
                    ))}
                </div>
              </div>
            </div>
          </div>
        )}
      </div>
    </div>
  );
};

DataTable.propTypes = {
  data: PropTypes.array.isRequired,
  onStatusUpdate: PropTypes.func.isRequired,
};

export default DataTable;
