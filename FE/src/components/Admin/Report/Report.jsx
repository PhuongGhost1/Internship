import React, { useState } from "react";
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
import IntructorIMG from "../../../assets/IntructorIMG.png";
import IntructorIMG2 from "../../../assets/IntructorIMG2.png";
import IntructorIMG3 from "../../../assets/IntructorIMG3.png";
import Error from "../../../assets/error.png";

const initialError = [
  {
    id: 1,
    email: "bapcon@example.com",
    name: "Bap",
    course: "Python",
    title: "Course error cannot load video",
    status: "New",
    img: IntructorIMG,
    phone: "0353747221",
    calender: "Joined May 2020",
    age: "22",
    role: "Student",
    country: "USA",
    attended: "Attended 7 days ago",
    chapter: "1",
    description: "The video cannot load",
    image: Error,
  },
  {
    id: 2,
    email: "jerome@example.com",
    name: "Jerome Reichert",
    course: "C#",
    title: "Course error cannot load video",
    status: "New",
    img: IntructorIMG3,
    phone: "0353747222",
    calender: "Joined June 2020",
    age: "24",
    role: "Student",
    country: "Canada",
    attended: "Attended 5 days ago",
    chapter: "3",
    description: "The video cannot load",
    image: Error,
  },
  {
    id: 3,
    email: "oscar@example.com",
    name: "Oscar Witting",
    course: "NodeJS",
    title: "Course error cannot load video",
    status: "New",
    img: IntructorIMG2,
    phone: "0353747223",
    calender: "Joined July 2020",
    age: "26",
    role: "Student",
    country: "UK",
    attended: "Attended 3 days ago",
    chapter: "2",
    description: "The video cannot load",
    image: Error,
  },
];

const pageSize = 12;

export default function Report() {
  const [students, setStudents] = useState(initialError);
  const [currentPage, setCurrentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");
  const [isVisiblePopUp, setIsVisiblePopUp] = useState(false);
  const [currentNum, setCurrentNum] = useState(0);

  const handleStatusChange = (id) => {
    setStudents((prevStudents) =>
      prevStudents.map((student) =>
        student.id === id
          ? { ...student, status: student.status === "New" ? "Fixed" : "New" }
          : student
      )
    );
  };

  const handleClick = (event, page) => {
    event.preventDefault();
    setCurrentPage(page);
  };

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const filteredStudents = students.filter(
    (student) =>
      student.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
      student.email.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const indexOfLastStudent = currentPage * pageSize;
  const indexOfFirstStudent = indexOfLastStudent - pageSize;
  const currentStudents = filteredStudents.slice(
    indexOfFirstStudent,
    indexOfLastStudent
  );
  const totalPages = Math.ceil(filteredStudents.length / pageSize);

  const handleOpenPopUpClick = (num) => {
    setIsVisiblePopUp(true);
    setCurrentNum(num);
    setTimeout(() => {
      let progress = document.querySelector(".popup");
      if (progress) {
        progress.classList.add("open");
      }
    }, 200);
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
            <th>Email</th>
            <th>Course</th>
            <th>Title</th>
            <th>Status</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {currentStudents.map((student, index) => (
            <tr key={student.id}>
              <td className="no" scope="row">
                {indexOfFirstStudent + index + 1}
              </td>
              <td className="email">{student.email}</td>
              <td className="course">{student.course}</td>
              <td className="title">{student.title}</td>
              <td className="status">
                <button
                  className={`status-toggle status-${student.status.toLowerCase()}`}
                  onClick={() => handleStatusChange(student.id)}
                >
                  {student.status}
                </button>
              </td>
              <td className="action">
                <span className="button-view">
                  <FaInfoCircle onClick={() => handleOpenPopUpClick(index)} />
                </span>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
      {isVisiblePopUp && (
        <div>
          <div className="popup">
            <div className="cross">
              <RxCross2 onClick={handleCrossClick} />
            </div>
            <div className="popup-container">
              <div className="popup-info">
                <div className="popup-info-image">
                  <img
                    src={initialError[currentNum].img}
                    alt={initialError[currentNum].name}
                  />
                </div>
                <div className="popup-info-title">
                  <h2>{initialError[currentNum].name}</h2>
                  <div className="popup-info-title2">
                    <p>Age {initialError[currentNum].age}</p> <GoDotFill />
                    <p>{initialError[currentNum].role}</p> <GoDotFill />
                    <p>{initialError[currentNum].country}</p>
                  </div>
                </div>
              </div>
              <div className="popup-status">
                <div className="popup-statuss">
                  <FaCalendarDay />
                  <p>{initialError[currentNum].calender}</p>
                </div>
                <div className="popup-statuss">
                  <FaUserCheck />
                  <p>{initialError[currentNum].attended}</p>
                </div>
              </div>
              <div className="popup-contact">
                <div className="popup-card">
                  <SiGmail />
                  <p>{initialError[currentNum].email}</p>
                </div>
                <div className="popup-card">
                  <FaPhoneAlt />
                  <p>{initialError[currentNum].phone}</p>
                </div>
              </div>
              <div className="details">
                <h3>Detail</h3>
                <div className="nav-bar">
                  <p>
                    <strong>Subject: </strong>
                    {initialError[currentNum].course}
                  </p>
                  <p>
                    <strong>Chapter: </strong>
                    {initialError[currentNum].chapter}
                  </p>
                  <p>
                    <strong>Description: </strong>
                    {initialError[currentNum].description}
                  </p>
                  <img src={initialError[currentNum].image} />
                </div>
              </div>
            </div>
          </div>
          <div className="blur-popup"></div>
        </div>
      )}
    </div>
  );
}
