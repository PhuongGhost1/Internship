import { useState } from "react";
import './PostedCourse.css';
import { Table, Dropdown, DropdownToggle, DropdownMenu, DropdownItem, Modal, ModalHeader, ModalBody, ModalFooter, Button } from 'react-bootstrap';
import { FaSearch, FaInfoCircle } from "react-icons/fa";
import { Pagination, PaginationItem, PaginationLink } from "reactstrap";
import { MdOutlineStarPurple500 } from "react-icons/md";

const DataTableWaiting = ({ data }) => {
     const pageSize = 10;
     const [currentPage, setCurrentPage] = useState(1);
     const [courses, setCourses] = useState(data);
     const [dropdownOpen, setDropdownOpen] = useState(null);
     const [searchTerm, setSearchTerm] = useState('');
     const [modal, setModal] = useState(false);
     const [selectedCourse, setSelectedCourse] = useState(null);

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

     const handleOpenPopUpClick = (index) => {
          setSelectedCourse(currentCourses[index]);
          setModal(true);
     };

     const toggleModal = () => {
          setModal(!modal);
     };

     const indexOfLastCourse = currentPage * pageSize;
     const indexOfFirstCourse = indexOfLastCourse - pageSize;

     const filteredCourses = courses.filter(course =>
          course.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
          course.owner.toLowerCase().includes(searchTerm.toLowerCase())
     );

     const waitingCourses = filteredCourses.filter(course => course.status === "Waiting");
     const currentCourses = waitingCourses.slice(indexOfFirstCourse, indexOfLastCourse);
     const totalPages = Math.ceil(waitingCourses.length / pageSize);

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
                                        <tr key={index}>
                                             <td className="name">{course.name}</td>
                                             <td className="image">
                                                  {course.contacts.map((contact, i) => (
                                                       <img
                                                            key={i}
                                                            src={contact}
                                                            alt="contact"
                                                            style={{ width: '70px', height: '70px', borderRadius: '50%', margin: '0 5px' }}
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
                                                            </DropdownItem>
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
                                        </tr>
                                   ))}
                              </tbody>
                         </Table>
                    </div>
                    <Pagination>
                         <PaginationItem disabled={currentPage <= 1}>
                              <PaginationLink previous onClick={(e) => handleClick(e, currentPage - 1)} />
                         </PaginationItem>
                         {[...Array(totalPages)].map((_, page) => (
                              <PaginationItem key={page + 1} active={page + 1 === currentPage}>
                                   <PaginationLink onClick={(e) => handleClick(e, page + 1)}>
                                        {page + 1}
                                   </PaginationLink>
                              </PaginationItem>
                         ))}
                         <PaginationItem disabled={currentPage >= totalPages}>
                              <PaginationLink next onClick={(e) => handleClick(e, currentPage + 1)} />
                         </PaginationItem>
                    </Pagination>
               </div>

               {selectedCourse && (
                    <Modal show={modal} onHide={toggleModal} centered>
                         <div className="courseName">
                              <ModalHeader toggle={toggleModal}>{selectedCourse.name}</ModalHeader>
                         </div>
                         <div className="content-popup">
                              <ModalBody>
                                   <img src={selectedCourse.contacts[0]} alt="course" style={{ width: '100%' }} />
                                   <p><strong>Instructor:</strong> {selectedCourse.owner}</p>
                                   <div>
                                        <span><strong>Status: </strong></span>
                                        <span className={`course-status-${selectedCourse.status.toLowerCase()}`}>{selectedCourse.status}</span>
                                   </div>
                                   <p><strong>Piece:</strong> {selectedCourse.price} $</p>
                                   <p><strong>Rating:</strong> {selectedCourse.rating}<MdOutlineStarPurple500 /></p>
                                   <p className="des"><strong>Discription:</strong> <i>{selectedCourse.description}</i></p>
                              </ModalBody>
                              <ModalFooter>
                                   <Button color="secondary" onClick={toggleModal}>Close</Button>
                              </ModalFooter>
                         </div>
                    </Modal>
               )}
          </div>
     );
};

export default DataTableWaiting;
