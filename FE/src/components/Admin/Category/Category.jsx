import { useState } from "react";
import './Category.css';
import { Table, Dropdown, DropdownToggle, DropdownMenu, DropdownItem, Modal, Button, Form } from 'react-bootstrap';
import { FaSearch } from "react-icons/fa";
import {
     Pagination,
     PaginationItem,
     PaginationLink,
} from "reactstrap";

const data = [
     { id: 1, name: "Technology", status: "Active" },
     { id: 2, name: "Finance", status: "Inactive" },
     { id: 3, name: "Healthcare", status: "Active" },
     { id: 4, name: "Education", status: "Active" },
     { id: 5, name: "Retail", status: "Active" },
     { id: 6, name: "Transportation", status: "Inactive" },
     { id: 7, name: "Manufacturing", status: "Inactive" },
     { id: 8, name: "Real Estate", status: "Active" },
     { id: 9, name: "Consulting", status: "Active" },
     { id: 10, name: "Legal", status: "Inactive" },
     { id: 11, name: "Energy", status: "Active" },
     { id: 12, name: "Agriculture", status: "Inactive" },
     { id: 13, name: "Construction", status: "Active" },
     { id: 14, name: "Hospitality", status: "Active" },
     { id: 15, name: "Entertainment", status: "Active" },
     { id: 16, name: "Media", status: "Active" },
     { id: 17, name: "Telecommunications", status: "Active" },
     { id: 18, name: "Non-profit", status: "Active" },
     { id: 19, name: "Government", status: "Active" },
     { id: 20, name: "Insurance", status: "Active" },
     { id: 21, name: "Aerospace", status: "Active" },
     { id: 22, name: "Defense", status: "Active" },
     { id: 23, name: "Pharmaceutical", status: "Active" },
     { id: 24, name: "Biotechnology", status: "Active" },
     { id: 25, name: "Advertising", status: "Active" },
     { id: 26, name: "Human Resources", status: "Inactive" },
     { id: 27, name: "Marketing", status: "Active" }
];

const DataTable = () => {
     const pageSize = 8;
     const [currentPage, setCurrentPage] = useState(1);
     const [courses, setCourses] = useState(data);
     const [dropdownOpen, setDropdownOpen] = useState(null);
     const [searchTerm, setSearchTerm] = useState('');
     const [showModal, setShowModal] = useState(false);
     const [newCategory, setNewCategory] = useState({ name: '', status: 'Active' });

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

     const handleCreateCategory = () => {
          setCourses([...courses, { ...newCategory, id: courses.length + 1 }]);
          setShowModal(false);
          setNewCategory({ name: '', status: 'Active' });
     };

     const indexOfLastCourse = currentPage * pageSize;
     const indexOfFirstCourse = indexOfLastCourse - pageSize;

     const filteredCourses = courses.filter(course =>
          course.name.toLowerCase().includes(searchTerm.toLowerCase())
     );

     const currentCourses = filteredCourses.slice(indexOfFirstCourse, indexOfLastCourse);
     const totalPages = Math.ceil(filteredCourses.length / pageSize);

     return (
          <div id="management-category">
               <div className="table-info">
                    <div className="table-header">
                         <button className="create-cate" onClick={() => setShowModal(true)}>Create a new Category</button>
                         <h3>List of Categories</h3>
                         <div className="search-bar">
                              <FaSearch />
                              <input
                                   type="text"
                                   placeholder="Search by category name"
                                   value={searchTerm}
                                   onChange={handleSearchChange}
                              />
                         </div>
                    </div>
                    <div className="cate-info">
                         <Table className="course-active">
                              <thead>
                                   <tr>
                                        <th>Category Name</th>
                                        <th className="status-heading">Status</th>
                                   </tr>
                              </thead>
                              <tbody>
                                   {currentCourses.map((course, index) => (
                                        <tr key={index}>
                                             <td className="name">{course.name}</td>
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
                                                            <DropdownItem className="item" onClick={() => handleStatusChange(course.id, "Inactive")}>
                                                                 Inactive
                                                            </DropdownItem>
                                                       </DropdownMenu>
                                                  </Dropdown>
                                             </td>
                                        </tr>
                                   ))}
                              </tbody>
                         </Table>
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

               <Modal show={showModal} onHide={() => setShowModal(false)}>
                    <Modal.Header closeButton>
                         <Modal.Title>Create a New Category</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                         <Form className="form-Create">
                              <div className="cate-name">
                                   <Form.Group controlId="formCategoryName">
                                        <div className="title">
                                             <Form.Label>Add a New Category</Form.Label>
                                        </div>
                                        <Form.Label>Category Name</Form.Label>
                                        <Form.Control
                                             className="control"
                                             type="text"
                                             placeholder="Enter category name"
                                             value={newCategory.name}
                                             onChange={(e) => setNewCategory({ ...newCategory, name: e.target.value })}
                                        />
                                   </Form.Group>
                              </div>
                              <div className="cate-status">
                                   <Form.Group controlId="formCategoryStatus">
                                        <Form.Label>Status</Form.Label>
                                        <Form.Control
                                             className="control"
                                             as="select"
                                             value={newCategory.status}
                                             onChange={(e) => setNewCategory({ ...newCategory, status: e.target.value })}
                                        >
                                             <option>Active</option>
                                             <option>Inactive</option>
                                        </Form.Control>
                                   </Form.Group>
                              </div>
                         </Form>
                    </Modal.Body>
                    <Modal.Footer>
                         <Button variant="secondary" onClick={() => setShowModal(false)}>
                              Close
                         </Button>
                         <Button className="btn-save" variant="primary" onClick={handleCreateCategory}>
                              Save Changes
                         </Button>
                    </Modal.Footer>
               </Modal>
          </div>
     );
};

export default DataTable;
