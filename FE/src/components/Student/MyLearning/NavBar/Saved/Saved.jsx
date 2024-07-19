import React, { useEffect, useState } from "react";
import "./Saved.css";
import { ImBooks } from "react-icons/im";
import { FaChalkboardTeacher } from "react-icons/fa";
import ApiService from "../../../../../api/ApiService";
import Box from "@mui/material/Box";
import Rating from "@mui/material/Rating";

const Saved = () => {
  const [currentPage, setCurrentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");
  const [dataReturn, setDataReturn] = useState([]);
  const [loading, setLoading] = useState(true);
  const tutorsPerPage = 4;

  useEffect(() => {
    fetchSavedCourse("user_00ebd16723");
  }, []);

  const fetchSavedCourse = async (userId) => {
    setLoading(true);
    try {
      const fetchData = await ApiService.getSavedCourse(userId);
      setDataReturn(fetchData);
    } catch (error) {
      console.error("Error fetching saved courses: ", error);
    } finally {
      setLoading(false);
    }
  };

  const removeSaveCourse = async (saveCourseId) => {
    try {
      await ApiService.removeSaveCourse(saveCourseId);
      fetchSavedCourse("user_00ebd16723");
    } catch (error) {
      console.error("Error removing saved course: ", error);
    }
  };

  const filteredData = dataReturn.filter(
    (tutor) =>
      tutor.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
      tutor.level.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const indexOfLastTutor = currentPage * tutorsPerPage;
  const indexOfFirstTutor = indexOfLastTutor - tutorsPerPage;
  const currentTutors = filteredData.slice(indexOfFirstTutor, indexOfLastTutor);

  const pageNumbers = [];
  for (let i = 1; i <= Math.ceil(filteredData.length / tutorsPerPage); i++) {
    pageNumbers.push(i);
  }

  return (
    <div id="Saved">
      <div id="search-bar">
        <input
          type="text"
          placeholder="Search Course..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
      </div>
      <div id="wishlist-course">
        {loading ? (
          <p>Loading...</p>
        ) : filteredData.length > 0 ? (
          currentTutors.length > 0 ? (
            currentTutors.map((tutor, index) => (
              <div className="wishlist-item" key={index}>
                <div className="logo">
                  <img src={tutor.imgUrl} alt={`${tutor.name}'s logo`} />
                </div>
                <div className="category">
                  <span className="cate-detail">
                    {tutor?.categories[0].name}
                  </span>
                  <span className="cate-detail">
                    +{tutor.categories.length - 1}
                  </span>
                </div>
                <h3>{tutor.name}</h3>
                <div className="info-course">
                  <p>
                    <ImBooks /> : {tutor.countLecture}
                  </p>
                  <p>
                    <FaChalkboardTeacher /> : {tutor.level}
                  </p>
                </div>
                <div className="rating-action">
                  <div className="rating">
                    <Box sx={{ "& > legend": { mt: 2 } }}>
                      <Rating
                        name="read-only"
                        value={tutor.ratingAvg}
                        readOnly
                      />
                    </Box>
                    <span> {tutor.ratingCount}</span>
                  </div>
                  <button
                    className="button-remove"
                    onClick={() => removeSaveCourse(tutor.saveCourseId)}
                  >
                    Unsave
                  </button>
                </div>
              </div>
            ))
          ) : (
            <p>No saved courses available</p>
          )
        ) : (
          <p>No results found</p>
        )}
      </div>
      {pageNumbers.length > 1 && (
        <div className="pagination">
          <button
            onClick={() => setCurrentPage(currentPage - 1)}
            disabled={currentPage === 1}
          >
            Previous
          </button>
          {pageNumbers.map((number) => (
            <button
              key={number}
              onClick={() => setCurrentPage(number)}
              className={currentPage === number ? "active" : ""}
              disabled={currentPage === number}
            >
              {number}
            </button>
          ))}
          <button
            onClick={() => setCurrentPage(currentPage + 1)}
            disabled={currentPage === pageNumbers.length}
          >
            Next
          </button>
        </div>
      )}
    </div>
  );
};

export default Saved;
