import React, { useState } from "react";
import "./ManageStudent.css";
import {
  Pagination,
  PaginationItem,
  PaginationLink,
  Table,
  Button,
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
} from "reactstrap";
import { CiCircleMore } from "react-icons/ci";
import { MdDeleteOutline } from "react-icons/md";
import { FaSearch } from "react-icons/fa";

const initialStudents = [
  {
    id: 1,
    email: "marcus-krajcik-sr.@lueilwitz-kiehn.net",
    name: "Marcus Krajcik Sr.",
    status: "Active",
    role: "Instructor",
  },
  {
    id: 2,
    email: "jerome-reichert-gutmann-iv@rowe-kassulke-and-olson.net",
    name: "Jerome Reichert-Gutmann IV",
    status: "Active",
    role: "Instructor",
  },
  {
    id: 3,
    email: "oscar-witting@morar-llc.io",
    name: "Oscar Witting",
    status: "Active",
    role: "Instructor",
  },
  {
    id: 4,
    email: "dorothy-o'reilly@runte-schneider-and-hoppe.co",
    name: "Dorothy O'Reilly",
    status: "Active",
    role: "Instructor",
  },
  {
    id: 5,
    email: "edna-flatley@upton-group.dev",
    name: "Edna Flatley",
    status: "Active",
    role: "Instructor",
  },
  {
    id: 6,
    email: "johnathan-morar@farrell-inc.co",
    name: "Johnathan Morar",
    status: "Active",
    role: "Instructor",
  },
  {
    id: 7,
    email: "dr.-orville-grady@abernathy-jakubowski.io",
    name: "Dr. Orville Grady",
    status: "Active",
    role: "Instructor",
  },
  {
    id: 8,
    email: "frances-hilll@vandervort-blick-and-breitenberg.com",
    name: "Frances Hilll",
    status: "Active",
    role: "Student",
  },
  {
    id: 9,
    email: "jared-hand@walter-inc.com",
    name: "Jared Hand",
    status: "Active",
    role: "Student",
  },
  {
    id: 10,
    email: "olga-stiedemann@upton-group.dev",
    name: "Olga Stiedemann",
    status: "Active",
    role: "Student",
  },
  {
    id: 11,
    email: "monica-cronin@abernathy-jakubowski.io",
    name: "Monica Cronin",
    status: "Active",
    role: "Student",
  },
  {
    id: 12,
    email: "nicole-hodkiewicz-md@rowe-kassulke-and-olson.net",
    name: "Nicole Hodkiewicz MD",
    status: "Active",
    role: "Student",
  },
  {
    id: 13,
    email: "frances-hilll@vandervort-blick-and-breitenberg.com",
    name: "Frances Hilll",
    status: "Active",
    role: "Student",
  },
  {
    id: 14,
    email: "jared-hand@walter-inc.com",
    name: "Jared Hand",
    status: "Active",
    role: "Student",
  },
  {
    id: 15,
    email: "olga-stiedemann@upton-group.dev",
    name: "Olga Stiedemann",
    status: "Active",
    role: "Student",
  },
  {
    id: 16,
    email: "monica-cronin@abernathy-jakubowski.io",
    name: "Monica Cronin",
    status: "Active",
    role: "Student",
  },
  {
    id: 17,
    email: "nicole-hodkiewicz-md@rowe-kassulke-and-olson.net",
    name: "Nicole Hodkiewicz MD",
    status: "Active",
    role: "Student",
  },
  {
    id: 18,
    email: "frances-hilll@vandervort-blick-and-breitenberg.com",
    name: "Frances Hilll",
    status: "Active",
    role: "Student",
  },
  {
    id: 19,
    email: "jared-hand@walter-inc.com",
    name: "Jared Hand",
    status: "Active",
    role: "Student",
  },
  {
    id: 20,
    email: "olga-stiedemann@upton-group.dev",
    name: "Olga Stiedemann",
    status: "Active",
    role: "Student",
  },
  {
    id: 21,
    email: "monica-cronin@abernathy-jakubowski.io",
    name: "Monica Cronin",
    status: "Active",
    role: "Student",
  },
  {
    id: 22,
    email: "nicole-hodkiewicz-md@rowe-kassulke-and-olson.net",
    name: "Nicole Hodkiewicz MD",
    status: "Active",
    role: "Student",
  },
];

const pageSize = 12;

export default function ManageStudent() {
  const [students, setStudents] = useState(initialStudents);
  const [currentPage, setCurrentPage] = useState(1);
  const [dropdownOpen, setDropdownOpen] = useState(null);
  const [searchTerm, setSearchTerm] = useState("");

  const toggleDropdown = (id) => {
    setDropdownOpen((prev) => (prev === id ? null : id));
  };

  const handleStatusChange = (id, status) => {
    setStudents((prevStudents) =>
      prevStudents.map((student) =>
        student.id === id ? { ...student, status } : student
      )
    );
    setDropdownOpen(null);
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

  return (
    <div id="ManageStudent">
      <div className="ManageStudent-top">
        <div className="management-student-pagination">
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
          <div>
            <FaSearch />
            <input
              type="text"
              placeholder="Search by name or email"
              value={searchTerm}
              onChange={handleSearchChange}
            />
          </div>
        </div>
      </div>
      <Table className="student-list">
        <thead>
          <tr>
            <th>No</th>
            <th>Email</th>
            <th>Name</th>
            <th>Role</th>
            <th>Status</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {currentStudents.map((student, index) => (
            <tr key={student.id}>
              <th className="no" scope="row">
                {indexOfFirstStudent + index + 1}
              </th>
              <td className="email">{student.email}</td>
              <td className="name">{student.name}</td>
              <td className="role">{student.role}</td>
              <td className="status">
                <Dropdown
                  isOpen={dropdownOpen === student.id}
                  toggle={() => toggleDropdown(student.id)}
                  className="dropdown-status"
                >
                  <DropdownToggle
                    caret
                    className={`status-toggle status-${student.status.toLowerCase()}`}
                  >
                    {student.status}
                  </DropdownToggle>
                  <DropdownMenu>
                    <DropdownItem
                      onClick={() => handleStatusChange(student.id, "Active")}
                    >
                      Active
                    </DropdownItem>
                    <DropdownItem
                      onClick={() => handleStatusChange(student.id, "Ban")}
                    >
                      Ban
                    </DropdownItem>
                  </DropdownMenu>
                </Dropdown>
              </td>
              <td className="action">
                <span className="button-view">
                  <CiCircleMore
                    onClick={() => {
                      window.location.href = "#";
                    }}
                  />
                </span>
                <span className="button-delete">
                  <MdDeleteOutline
                    onClick={() => {
                      window.location.href = "#";
                    }}
                  />
                </span>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
      
    </div>
  );
}
