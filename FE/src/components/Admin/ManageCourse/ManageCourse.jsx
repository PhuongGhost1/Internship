import React, { useState } from "react";
import './ManageCourse.css';
import { Table, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'react-bootstrap';
import ReactPaginate from 'react-paginate';
import { CiCircleMore } from "react-icons/ci";
import { MdDeleteOutline } from "react-icons/md";
import Angular_logo from "../../../assets/Angular_logo.png";
import { FaSearch } from "react-icons/fa";

const data = [
    { id: 1, company: "Klein Inc", owner: "Oscar Martinez", status: "Active", contacts: [Angular_logo] },
    { id: 2, company: "Weissnat - Schultz", owner: "Phyllis Smith", status: "Cancel", contacts: [Angular_logo, Angular_logo, Angular_logo] },
    { id: 3, company: "McClure, Hills and Bahringer", owner: "Meredith Palmer", status: "Active", contacts: [Angular_logo, Angular_logo, Angular_logo] },
    { id: 4, company: "Thompson - Zieme", owner: "Angela Martin", status: "Active", contacts: [Angular_logo, Angular_logo] },
    { id: 5, company: "Batz - Greenholt", owner: "Meredith Palmer", status: "Waiting", contacts: [Angular_logo, Angular_logo] },
    { id: 6, company: "Bruen, Willms and Marquardt", owner: "Pam Beesly", status: "Waiting", contacts: [Angular_logo] },
    { id: 7, company: "Botsford - Dach", owner: "Stanley Hudson", status: "Cancel", contacts: [Angular_logo] },
    { id: 8, company: "O'Connell - Lind", owner: "Michael Scott", status: "Active", contacts: [Angular_logo, Angular_logo] },
    { id: 9, company: "Crona - Donnelly", owner: "Stanley Hudson", status: "Active", contacts: [Angular_logo] },
    { id: 10, company: "Stoltenberg Group", owner: "Dwight Schrute", status: "Waiting", contacts: [Angular_logo] },
    { id: 11, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 12, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Cancel", contacts: [Angular_logo] },
    { id: 13, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 14, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 15, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 16, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 17, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 18, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 19, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 20, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 21, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Waiting", contacts: [Angular_logo] },
    { id: 22, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 23, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 24, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 25, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Active", contacts: [Angular_logo] },
    { id: 26, company: "Steuber, Yundt and Torp", owner: "Creed Bratton", status: "Cancel", contacts: [Angular_logo] },
    { id: 27, company: "Weimann - Shanahan", owner: "Ryan Howard", status: "Active", contacts: [Angular_logo] }

];

const ITEMS_PER_PAGE = 11;

const DataTable = () => {
    const [courses, setCourses] = useState(data);
    const [dropdownOpen, setDropdownOpen] = useState(null);
    const [currentPage, setCurrentPage] = useState(0);
    const [searchTerm, setSearchTerm] = useState('');
    const [statusFilter, setStatusFilter] = useState('');

    const handleSearchChange = (event) => {
        setSearchTerm(event.target.value);
    };


    const handlePageClick = (event) => {
        setCurrentPage(event.selected);
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



    const offset = currentPage * ITEMS_PER_PAGE;
    const currentPageData = courses.slice(offset, offset + ITEMS_PER_PAGE);

    const handleStatusFilterChange = (status) => {
        setStatusFilter(status);
    };

    const filteredData = currentPageData.filter(course =>
        statusFilter ? course.status === statusFilter : true &&
            (course.company.toLowerCase().includes(searchTerm.toLowerCase()) ||
                course.owner.toLowerCase().includes(searchTerm.toLowerCase()))
    );

    return (
        <div id="management-course">
            <div className="table-info">
                <div className="table-header">
                    <Dropdown
                        isOpen={dropdownOpen === 'filter'}
                        toggle={() => toggleDropdown('filter')}
                        className="dropdown-filter"
                    >
                        <DropdownToggle caret className="filter-toggle">
                            {statusFilter || 'Filter by Status'}
                        </DropdownToggle>
                        <DropdownMenu className="filter-menu">
                            <DropdownItem onClick={() => handleStatusFilterChange('')}>
                                All
                            </DropdownItem>
                            <DropdownItem onClick={() => handleStatusFilterChange('Active')}>
                                Active
                            </DropdownItem>
                            <DropdownItem onClick={() => handleStatusFilterChange('Cancel')}>
                                Cancel
                            </DropdownItem>
                            <DropdownItem onClick={() => handleStatusFilterChange('Waiting')}>
                                Waiting
                            </DropdownItem>
                        </DropdownMenu>
                    </Dropdown>
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
                <Table>
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
                        {filteredData.map((course, index) => (
                            <tr key={index}>
                                <td className="company">{course.company}</td>
                                <td className="image">
                                    {course.contacts.map((contact, i) => (
                                        <img
                                            key={i}
                                            src={contact}
                                            alt="contact"
                                            style={{ width: '30px', height: '30px', borderRadius: '50%', margin: '0 5px' }}
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
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </div>

            <div className="Pagination">
                <ReactPaginate
                    previousLabel={'Previous'}
                    nextLabel={'Next'}
                    breakLabel={'...'}
                    pageCount={Math.ceil(data.length / ITEMS_PER_PAGE)}
                    marginPagesDisplayed={2}
                    pageRangeDisplayed={2}
                    onPageChange={handlePageClick}
                    containerClassName={'pagination'}
                    activeClassName={'active'}
                />
            </div>
        </div>
    );
};

export default DataTable;
