import React, { useState } from "react";
import './ManageCourse.css';
import { Table, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'react-bootstrap';
import ReactPaginate from 'react-paginate';
import { CiCircleMore } from "react-icons/ci";
import { MdDeleteOutline } from "react-icons/md";
import Angular_logo from "../../../assets/Angular_logo.png";
import { FaSearch } from "react-icons/fa";

const data = [
    { id: 1, name: "Klein Inc", owner: "Oscar Martinez", status: "Active", contacts: [Angular_logo] },
    { id: 2, name: "Weissnat - Schultz", owner: "Phyllis Smith", status: "Cancel", contacts: [Angular_logo, Angular_logo, Angular_logo] },
    { id: 3, name: "McClure, Hills and Bahringer", owner: "Meredith Palmer", status: "Active", contacts: [Angular_logo, Angular_logo, Angular_logo] },
    { id: 4, name: "Thompson - Zieme", owner: "Angela Martin", status: "Active", contacts: [Angular_logo, Angular_logo] },
    { id: 5, name: "Batz - Greenholt", owner: "Meredith Palmer", status: "Waiting", contacts: [Angular_logo, Angular_logo] },
    { id: 6, name: "Bruen, Willms and Marquardt", owner: "Pam Beesly", status: "Waiting", contacts: [Angular_logo] },
    { id: 7, name: "Botsford - Dach", owner: "Stanley Hudson", status: "Cancel", contacts: [Angular_logo] },
    { id: 8, name: "O'Connell - Lind", owner: "Michael Scott", status: "Active", contacts: [Angular_logo, Angular_logo] },
    { id: 9, name: "Crona - Donnelly", owner: "Stanley Hudson", status: "Active", contacts: [Angular_logo] },
    { id: 10, name: "Stoltenberg Group", owner: "Dwight Schrute", status: "Waiting", contacts: [Angular_logo] },
    { id: 11, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 12, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Cancel", contacts: [Angular_logo] },
    { id: 13, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 14, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 15, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 16, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 17, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 18, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 19, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 20, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 21, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 22, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 23, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 24, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 25, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 26, name: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Cancel", contacts: [Angular_logo] },
    { id: 27, name: "Weimann - Shanahan", owner: "Ryan Howard", status: "Active", contacts: [Angular_logo] }

];

const DataTable = () => {
    const [courses, setCourses] = useState(data);
    const [dropdownOpen, setDropdownOpen] = useState(null);
    const [searchTerm, setSearchTerm] = useState('');

    const handleSearchChange = (event) => {
        setSearchTerm(event.target.value);
    };

    const toggleDropdown = (id) => {
        setDropdownOpen(prev => (prev === id ? null : id));
    };

    const handleStatusChange = (id, status) => {
        setCourses(prevCourses => prevCourses.map(
            course => course.id === id ? { ...course, status } : course
        ));
        setDropdownOpen(null);
    };

    const filteredCourses = courses.filter(course =>
        course.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
        course.owner.toLowerCase().includes(searchTerm.toLowerCase())
    );
    return (
        <div id="management-course">
            <div className="table-info">
                <div className="table-header">
                    <div className="search-bar">
                        <FaSearch />
                        <input
                            type="text"
                            placeholder="Search by Name or Instrucor"
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
                            {filteredCourses.map((course, index) => (
                                <tr key={index}>
                                    {course.status === "Active" &&
                                        <>
                                            <td className="name">{course.name}</td>
                                            <td className="image">
                                                {course.contacts.map((contact, i) => (
                                                    <img
                                                        key={i}
                                                        src={contact}
                                                        alt="contact"
                                                        style={{ width: '50px', height: '5  0px', borderRadius: '50%', margin: '0 5px' }}
                                                    />
                                                ))}
                                            </td>
                                            <td className="owner">{course.owner}</td>
                                            <td className="status">
                                                <Dropdown
                                                    isOpen={dropdownOpen === course.id}
                                                    toggle={() => toggleDropdown(course.id)}
                                                    className="dropdown-status"
                                                >
                                                    <DropdownToggle caret className={`status-toggle status-${course.status.toLowerCase()}`}>
                                                        {course.status}
                                                    </DropdownToggle>
                                                    <DropdownMenu className="menu">
                                                        <DropdownItem className="item" onClick={() => handleStatusChange(course.id, "Active")}>
                                                            Active
                                                        </DropdownItem >
                                                        <DropdownItem className="item" onClick={() => handleStatusChange(course.id, "Cancel")}>
                                                            Cancel
                                                        </DropdownItem>
                                                        <DropdownItem className="item" onClick={() => handleStatusChange(course.id, "Waiting")}>
                                                            Waiting
                                                        </DropdownItem>
                                                    </DropdownMenu>
                                                </Dropdown>
                                            </td>
                                            <td className="action">
                                                <span className="button-view">
                                                    <CiCircleMore onClick={() => { window.location.href = "#" }} />
                                                </span>
                                                <span className="button-delete">
                                                    <MdDeleteOutline onClick={() => { window.location.href = "#" }} />
                                                </span>
                                            </td>
                                        </>
                                    }
                                </tr>
                            ))}
                        </tbody>
                    </Table>
                </div>
            </div>
        </div>
    );
};

export default DataTable;
