import { useState } from "react";
import './PostedCourse.css';
import { Table, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'react-bootstrap';
import { CiCircleMore } from "react-icons/ci";
import { MdDeleteOutline } from "react-icons/md";
import { FaSearch } from "react-icons/fa";
import { FaInfoCircle } from "react-icons/fa";
import {
     Pagination,
     PaginationItem,
     PaginationLink,
} from "reactstrap";

const DataTable = ({ data }) => {
     const pageSize = 8;
     const [currentPage, setCurrentPage] = useState(1);
     const [courses, setCourses] = useState(data);
     const [dropdownOpen, setDropdownOpen] = useState(null);
     const [searchTerm, setSearchTerm] = useState('');

     const handleClick = (event, page) => {
          event.preventDefault();
          setCurrentPage(page);
     };

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

     const indexOfLastCourse = currentPage * pageSize;
     const indexOfFirstCourse = indexOfLastCourse - pageSize;

     const filteredCourses = courses.filter(course =>
          course.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
          course.owner.toLowerCase().includes(searchTerm.toLowerCase())
     );

     const currentCourses = filteredCourses.slice(indexOfFirstCourse, indexOfLastCourse);
     const totalPages = Math.ceil(filteredCourses.length / pageSize);

     return (
          <div id="management-course">
               <div className="table-info">
                    <div className="table-header">
                         <h3>Active & Cancel Courses</h3>
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
                                        <tr key={index}>
                                             {(course.status === "Waiting") &&
                                                  <>
                                                       <td className="name">{course.name}</td>
                                                       <td className="image">
                                                            {course.contacts.map((contact, i) => (
                                                                 <img
                                                                      key={i}
                                                                      src={contact}
                                                                      alt="contact"
                                                                      style={{ width: '50px', height: '50px', borderRadius: '50%', margin: '0 5px' }}
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
                                                                 <FaInfoCircle onClick={() => { handleOpenPopUpClick(index) }} />
                                                            </span>
                                                       </td>
                                                  </>
                                             }
                                        </tr>
                                   ))}
                              </tbody>
                         </Table>
                    </div>
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
          </div>
     );
};

export default DataTable;
