import React, { useEffect, useState } from "react";
import "./FeedBackAdmin.css";
import { Pagination, PaginationItem, PaginationLink, Table } from "reactstrap";
import { FaSearch } from "react-icons/fa";
import ApiService from "../../../api/ApiService";

const pageSize = 12;

export default function FeedBackAdmin() {
  const [feedbackData, setFeedbackData] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");

  useEffect(() => {
    const fetchFeedbackData = async () => {
      try {
        const feedbacks =
          await ApiService.getRequestBecomeInstructorManagementByAdmin();
        setFeedbackData(feedbacks);
      } catch (error) {
        console.log("Error fetching feedback data: ", error);
      }
    };

    fetchFeedbackData();
  }, []);

  const handleClick = (event, page) => {
    event.preventDefault();
    setCurrentPage(page);
  };

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const filteredFeedbacks = feedbackData.filter(
    (feedback) =>
      feedback.userRequest.username
        .toLowerCase()
        .includes(searchTerm.toLowerCase()) ||
      feedback.userRequest.email
        .toLowerCase()
        .includes(searchTerm.toLowerCase())
  );

  const indexOfLastFeedback = currentPage * pageSize;
  const indexOfFirstFeedback = indexOfLastFeedback - pageSize;
  const currentFeedbacks = filteredFeedbacks.slice(
    indexOfFirstFeedback,
    indexOfLastFeedback
  );
  const totalPages = Math.ceil(filteredFeedbacks.length / pageSize);

  return (
    <div id="FeedBackAdmin">
      <div className="ManageFeedback-top">
        <div className="management-feedback-pagination">
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
      <Table className="feedback-list">
        <thead>
          <tr>
            <th>No</th>
            <th>Email</th>
            <th>Name</th>
            <th>Title</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {currentFeedbacks.map((feedback, index) => (
            <tr key={feedback.id}>
              <td className="no" scope="row">
                {indexOfFirstFeedback + index + 1}
              </td>
              <td className="email">{feedback.userRequest.email}</td>
              <td className="name">{feedback.userRequest.username}</td>
              <td className="title">{feedback.title}</td>
              <td className="description">{feedback.description}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
}
