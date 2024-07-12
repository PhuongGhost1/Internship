import React, { useEffect, useState } from "react";
import "./Report.css";
import { Pagination, PaginationItem, PaginationLink, Table } from "reactstrap";
import {
  FaInfoCircle,
  FaSearch,
  FaCalendarDay,
  FaPhoneAlt,
  FaUserCheck,
} from "react-icons/fa";
import { RxCross2 } from "react-icons/rx";
import { GoDotFill } from "react-icons/go";
import { SiGmail } from "react-icons/si";
import IntructorIMG from "../../../assets/Collection-Avatar/1.png";
import Error from "../../../assets/error.png";
import ApiService from "../../../api/ApiService";
import { FaUsers } from "react-icons/fa";
import { FaRegStarHalfStroke } from "react-icons/fa6";

const pageSize = 12;

const getStatusString = (status) => {
  return status === 0 ? "New" : "Checked";
};

const getIsInvisibleString = (invisible) => {
  return invisible ? "Opened" : "Blocked";
};

export default function Report() {
  const [reportData, setReportData] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");
  const [isVisiblePopUp, setIsVisiblePopUp] = useState(false);
  const [currentReport, setCurrentReport] = useState(null);

  useEffect(() => {
    const fetchApiReportsData = async () => {
      try {
        const reportsData = await ApiService.getReportsManagementByAdmin();
        setReportData(reportsData);
      } catch (error) {
        console.log("Error fetching reports data: ", error);
      }
    };

    fetchApiReportsData();
  }, []);

  const handleStatusChange = async (report) => {
    try {
      const userId = report.reportedUser ? report.reportedUser.id : null;
      const reportId = report.id;
      const commentId = report.comments ? report.comments.id : null;
      const courseId = report.courses.id;

      const updatedStatus = await ApiService.updateReportManagementByAdmin(
        userId,
        reportId,
        commentId,
        courseId
      );

      if (updatedStatus) {
        console.log("Reported user isVisible:", report.reportedUser.isVisible);
        setReportData((prevReports) =>
          prevReports.map((r) =>
            r.id === reportId
              ? {
                  ...r,
                  status: r.status === 1,
                  comments: r.comments ? null : r.comments,
                  courses: {
                    ...r.courses,
                    status: r.status,
                  },
                  reportedUser: {
                    ...r.reportedUser,
                    isVisible: r.isVisible,
                  },
                }
              : r
          )
        );
      } else {
        console.log("Update status failed or no update needed.");
      }
    } catch (error) {
      console.error("Error updating status:", error);
    }
  };

  const handleClick = (event, page) => {
    event.preventDefault();
    setCurrentPage(page);
  };

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const filteredReports = reportData.filter(
    (report) =>
      report.courses.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
      report.reporter.email.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const indexOfLastReport = currentPage * pageSize;
  const indexOfFirstReport = indexOfLastReport - pageSize;
  const currentReports = filteredReports.slice(
    indexOfFirstReport,
    indexOfLastReport
  );
  const totalPages = Math.ceil(filteredReports.length / pageSize);

  const handleOpenPopUpClick = (report) => {
    setIsVisiblePopUp(true);
    setCurrentReport({ ...report });
    try {
      setTimeout(() => {
        let progress = document.querySelector(".popup");
        progress.classList.add("open");
      }, 200);
    } catch (error) {
      <h2>Error Search</h2>;
    }
  };

  const handleCrossClick = () => {
    let progress = document.querySelector(".popup");
    if (progress) {
      progress.classList.remove("open");
    }
    setTimeout(() => {
      setIsVisiblePopUp(false);
    }, 500);
  };

  return (
    <div id="Report">
      <div className="ManageReport-top">
        <div className="management-report-pagination">
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
      <Table className="report-list">
        <thead>
          <tr>
            <th>No</th>
            <th>Reporter</th>
            <th>Course</th>
            <th>Title</th>
            <th>Status</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {currentReports.map((report, index) => (
            <tr key={report.id}>
              <td className="no" scope="row">
                {indexOfFirstReport + index + 1}
              </td>
              <td className="email">{report.reporter.email}</td>
              <td className="course">{report.courses.name}</td>
              <td className="title">{report.title}</td>
              <td className="status">
                <button
                  className={`status-toggle status-${getStatusString(
                    report.status
                  ).toLowerCase()}`}
                  onClick={() => handleStatusChange(report)}
                >
                  {getStatusString(report.status)}
                </button>
              </td>
              <td className="action">
                <span className="button-view">
                  <FaInfoCircle onClick={() => handleOpenPopUpClick(report)} />
                </span>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
      {isVisiblePopUp && currentReport && (
        <div>
          <div className="popup">
            <div className="cross">
              <RxCross2 onClick={handleCrossClick} />
            </div>
            <div className="popup-container">
              {currentReport.comments ? (
                <>
                  <div className="popup-info">
                    <div
                      className={`popup-invisible-${getIsInvisibleString(
                        currentReport.reportedUser.isVisible
                      ).toLowerCase()}`}
                    >
                      {getIsInvisibleString(
                        currentReport.reportedUser.isVisible
                      )}
                    </div>

                    <div className="popup-info-image">
                      <img
                        src={
                          currentReport.reportedUser.images
                            ? currentReport.reportedUser.images[0]?.url
                            : IntructorIMG
                        }
                        alt={currentReport.reportedUser.name}
                      />
                    </div>
                    <div className="popup-info-title">
                      <h2>{currentReport.reportedUser.name}</h2>
                      <div className="popup-info-title2">
                        <p>Age 21</p> <GoDotFill />
                        <p>
                          {
                            currentReport.reportedUser.roleUsers[0].roles[0]
                              .name
                          }
                        </p>{" "}
                        <GoDotFill />
                        <p>Viet Nam</p>
                      </div>
                    </div>
                  </div>
                  <div className="popup-status">
                    <div className="popup-statuss">
                      <FaCalendarDay />
                      <p>{currentReport.reportedUser.createAt}</p>
                    </div>
                    <div className="popup-statuss">
                      <FaUserCheck />
                      <p>{currentReport.reportedUser.createAt}</p>
                    </div>
                  </div>
                  <div className="popup-contact">
                    <div className="popup-card">
                      <SiGmail />
                      <p>{currentReport.reportedUser.email}</p>
                    </div>
                    <div className="popup-card">
                      <FaPhoneAlt />
                      <p>{currentReport.reportedUser.phone}</p>
                    </div>
                  </div>
                  <div className="details">
                    <div className="nav-bar">
                      <div className="popup-course">
                        <div className="course-card">
                          <img
                            src={currentReport.comments.courses.images[0]?.url}
                            alt={`${currentReport.comments.courses.name} logo`}
                            className="course-logo"
                          />
                          <div className="course-details">
                            <h3>{currentReport.comments.courses.name}</h3>
                            <div className="course-icon">
                              <div className="course-icon-item">
                                <FaRegStarHalfStroke />
                                <p>{currentReport.comments.courses.rating}</p>
                              </div>
                              <div className="course-icon-item">
                                <FaUsers />
                                <p>{currentReport.comments.courses.price}</p>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                      <p>
                        <strong>Description: </strong>
                        {currentReport.comments.comment1}
                      </p>
                    </div>
                  </div>
                </>
              ) : (
                <>
                  <div className="popup-info">
                    <div className="popup-info-image">
                      <img
                        src={
                          currentReport.courses.images
                            ? currentReport.courses.images[0]?.url
                            : IntructorIMG
                        }
                        alt={currentReport.courses.name}
                      />
                    </div>
                    <div className="popup-info-title">
                      <h2>{currentReport.courses.name}</h2>
                      <div className="popup-info-title2">
                        <p>Rating: {currentReport.courses.rating}</p>{" "}
                        <GoDotFill />
                        <p>Price: {currentReport.courses.price}</p>
                        <GoDotFill />
                        <p>Author: {currentReport.courses.user.name}</p>
                      </div>
                    </div>
                  </div>
                  <div className="popup-status">
                    <div className="popup-statuss">
                      <FaCalendarDay />
                      <p>{currentReport.courses.createdAt}</p>
                    </div>
                    <div className="popup-statuss">
                      <FaUserCheck />
                      <p>
                        {currentReport.courses.updatedAt !== null
                          ? currentReport.courses.updatedAt
                          : "Chua co thong tin"}
                      </p>
                    </div>
                  </div>
                  <div className="popup-contact">
                    <div className="popup-card">
                      <SiGmail />
                      <p>{currentReport.courses.user.email}</p>
                    </div>
                    <div className="popup-card">
                      <FaPhoneAlt />
                      <p>{currentReport.courses.user.phone}</p>
                    </div>
                  </div>
                  <div className="details">
                    <h3>Detail</h3>
                    <div className="nav-bar">
                      <p>
                        <strong>Subject: </strong>
                        {currentReport.title}
                      </p>
                      <p>
                        <strong>Description: </strong>
                        {currentReport.message}
                      </p>
                      <img src={Error} alt="Error" />
                    </div>
                  </div>
                </>
              )}
            </div>
          </div>
          <div className="blur-popup"></div>
        </div>
      )}
    </div>
  );
}
