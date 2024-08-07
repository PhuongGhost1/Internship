import React, { useEffect, useState } from "react";
import "./Category.css";
import {
  Table,
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  Modal,
  Button,
  Form,
} from "react-bootstrap";
import { FaSearch } from "react-icons/fa";
import { Pagination, PaginationItem, PaginationLink } from "reactstrap";
import ApiService from "../../../api/ApiService";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const getIsInvisibleString = (isVisible) => {
  return isVisible ? "Active" : "Inactive";
};

const DataTable = () => {
  const pageSize = 8;
  const [currentPage, setCurrentPage] = useState(1);
  const [courses, setCourses] = useState([]);
  const [dropdownOpen, setDropdownOpen] = useState(null);
  const [searchTerm, setSearchTerm] = useState("");
  const [showModal, setShowModal] = useState(false);
  const [newCategory, setNewCategory] = useState({
    name: "",
    isVisible: "Active",
  });

  useEffect(() => {
    const fetchCategoryData = async () => {
      try {
        const categoryData =
          await ApiService.getAllCategoriesManagementByAdmin();
        setCourses(categoryData);
      } catch (error) {
        console.log("Error fetching categories data: ", error);
      }
    };

    fetchCategoryData();
  }, []);

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

  const handleStatusChange = async (id, status) => {
    try {
      const updateStatus =
        await ApiService.updateStatusCategoriesManagementByAdmin(id);
      if (updateStatus) {
        setCourses((prevCourses) =>
          prevCourses.map((course) =>
            course.id === id
              ? { ...course, isVisible: status === "Active" }
              : course,
          ),
        );
        setDropdownOpen(null);
        toast.success(`Updated successfully!`);
      } else {
        console.log("Update status failed or no update needed.");
      }
    } catch (error) {
      console.error("Error updating status:", error);
      toast.error("Error updating category. Please try again.");
    }
  };

  const handleCreateCategory = async () => {
    try {
      if (!newCategory.name) {
        toast.error("Category name is required");
        return;
      }

      const newCategoryData =
        await ApiService.createNewCategoryManagementByAdmin(
          newCategory.name,
          newCategory.isVisible,
        );
      setCourses([...courses, newCategoryData]);
      setShowModal(false);
      setNewCategory({ name: "", isVisible: "Active" });

      toast.success(`Category "${newCategoryData.name}" created successfully!`);
    } catch (error) {
      console.error("Error creating category:", error);
      toast.error("Error creating category. Please try again.");
    }
  };

  const indexOfLastCourse = currentPage * pageSize;
  const indexOfFirstCourse = indexOfLastCourse - pageSize;

  const filteredCourses = courses.filter((course) => {
    const name = course.name ?? "";
    return name.toLowerCase().includes(searchTerm.toLowerCase());
  });

  const currentCourses = filteredCourses.slice(
    indexOfFirstCourse,
    indexOfLastCourse,
  );
  const totalPages = Math.ceil(filteredCourses.length / pageSize);

  return (
    <div id="management-category">
      <ToastContainer
        style={{ position: "fixed", top: 60, right: 20, zIndex: 9999 }}
      />
      <div className="table-info">
        <div className="table-header">
          <button className="create-cate" onClick={() => setShowModal(true)}>
            Create a new Category
          </button>
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
                      <DropdownToggle
                        caret
                        className={`status-toggle status-${getIsInvisibleString(
                          course.isVisible,
                        ).toLowerCase()}`}
                      >
                        {getIsInvisibleString(course.isVisible)}
                      </DropdownToggle>
                      <DropdownMenu className="menu">
                        <DropdownItem
                          className="item"
                          onClick={() =>
                            handleStatusChange(course.id, "Active")
                          }
                        >
                          Active
                        </DropdownItem>
                        <DropdownItem
                          className="item"
                          onClick={() =>
                            handleStatusChange(course.id, "Inactive")
                          }
                        >
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
                  onChange={(e) =>
                    setNewCategory({ ...newCategory, name: e.target.value })
                  }
                />
              </Form.Group>
            </div>
            <div className="cate-status">
              <Form.Group controlId="formCategoryStatus">
                <Form.Label>Status</Form.Label>
                <Form.Control
                  className="control"
                  as="select"
                  value={newCategory.isVisible}
                  onChange={(e) =>
                    setNewCategory({
                      ...newCategory,
                      isVisible: e.target.value,
                    })
                  }
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
          <Button
            className="btn-save"
            variant="primary"
            onClick={handleCreateCategory}
          >
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default DataTable;
