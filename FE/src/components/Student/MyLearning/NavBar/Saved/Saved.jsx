import React, { useEffect, useState } from "react";
import "./Saved.css";
import { ImBooks } from "react-icons/im";
import { FaChalkboardTeacher } from "react-icons/fa";
import ApiService from "../../../../../api/ApiService";
import Box from '@mui/material/Box';
import Rating from '@mui/material/Rating';
// const data = [
//   {
//     name: "JavaScript for Beginners",
//     price: "$49.99",
//     categories: ["abcbbbbbbbbbbbb", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "John Doe",
//     level: "Beginner",
//     ratingAvg: 4.5,
//     ratingCount: 1200,
//   },
//   {
//     name: "Advanced CSS and Sass",
//     price: "$29.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Jane Smith",
//     level: "Intermediate",
//     ratingAvg: 4.6,
//     ratingCount: 1100,
//   },
//   {
//     name: "React - The Complete Guide",
//     price: "$59.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Maximilian Schwarzmüller",
//     level: "Advanced",
//     ratingAvg: 4.7,
//     ratingCount: 1300,
//   },
//   {
//     name: "Node.js, Express, MongoDB & More: The Complete Bootcamp",
//     price: "$79.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Jonas Schmedtmann",
//     level: "Advanced",
//     ratingAvg: 4.8,
//     ratingCount: 1400,
//   },
//   {
//     name: "Python for Data Science and Machine Learning Bootcamp",
//     price: "$99.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Jose Portilla",
//     level: "Intermediate",
//     ratingAvg: 4.9,
//     ratingCount: 1500,
//   },
//   {
//     name: "The Complete Web Developer in 2024: Zero to Mastery",
//     price: "$49.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Andrei Neagoie",
//     level: "Beginner",
//     ratingAvg: 4.6,
//     ratingCount: 1100,
//   },
//   {
//     name: "The Complete JavaScript Course 2024: From Zero to Expert!",
//     price: "$39.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Jonas Schmedtmann",
//     level: "Beginner",
//     ratingAvg: 4.8,
//     ratingCount: 1600,
//   },
//   {
//     name: "Complete Python Bootcamp: Go from zero to hero in Python 3",
//     price: "$69.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Jose Portilla",
//     level: "Beginner",
//     ratingAvg: 4.9,
//     ratingCount: 1700,
//   },
//   {
//     name: "The Ultimate MySQL Bootcamp: Go from SQL Beginner to Expert",
//     price: "$59.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Colt Steele",
//     level: "Intermediate",
//     ratingAvg: 4.7,
//     ratingCount: 1400,
//   },
//   {
//     name: "Understanding TypeScript - 2024 Edition",
//     price: "$19.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Maximilian Schwarzmüller",
//     level: "Intermediate",
//     ratingAvg: 4.5,
//     ratingCount: 1000,
//   },
//   {
//     name: "Docker and Kubernetes: The Complete Guide",
//     price: "$49.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Stephen Grider",
//     level: "Intermediate",
//     ratingAvg: 4.6,
//     ratingCount: 1100,
//   },
//   {
//     name: "Complete React Developer in 2024 (w/ Redux, Hooks, GraphQL)",
//     price: "$59.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Andrei Neagoie",
//     level: "Advanced",
//     ratingAvg: 4.7,
//     ratingCount: 1300,
//   },
//   {
//     name: "Build Responsive Real World Websites with HTML5 and CSS3",
//     price: "$29.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Jonas Schmedtmann",
//     level: "Beginner",
//     ratingAvg: 4.8,
//     ratingCount: 1200,
//   },
//   {
//     name: "The Complete Guide to Angular 12 (formerly Angular 2)",
//     price: "$49.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Maximilian Schwarzmüller",
//     level: "Advanced",
//     ratingAvg: 4.9,
//     ratingCount: 1400,
//   },
//   {
//     name: "Machine Learning A-Z: Hands-On Python & R In Data Science",
//     price: "$99.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Kirill Eremenko",
//     level: "Advanced",
//     ratingAvg: 4.7,
//     ratingCount: 1500,
//   },
//   {
//     name: "AWS Certified Solutions Architect - Associate 2024",
//     price: "$89.99",
//     categories: ["abc", "def", "ghi"],
//     countLecture: "19",
//     imgUrl: Logo,
//     instructor: "Ryan Kroonenburg",
//     level: "Advanced",
//     ratingAvg: 4.8,
//     ratingCount: 1600,
//   },
// ];

const Saved = () => {
  const [currentPage, setCurrentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");
  const [dataReturn, setDataReturn] = useState([]);
  const tutorsPerPage = 8;

  useEffect(() => {
    fetchSavedCourse("user_00ebd16723")
  }, [])

  useEffect(() => {
    console.log(dataReturn)
  }, [dataReturn])
  // Logic for filtering tutors based on search term
  const filteredData = dataReturn.filter(
    (tutor) =>
      tutor.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
      tutor.level.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const fetchSavedCourse = async (userId) => {
    const fetchData = await ApiService.getSavedCourse(userId);
    setDataReturn(fetchData);
  }

  // Logic for displaying current tutors
  const indexOfLastTutor = currentPage * tutorsPerPage;
  const indexOfFirstTutor = indexOfLastTutor - tutorsPerPage;
  const currentTutors = filteredData.slice(indexOfFirstTutor, indexOfLastTutor);

  // Logic for handling page numbers
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
        {currentTutors.map((tutor, index) => (
          <div className="wishlist-item" key={index}>
            <div className="logo">
              <img src={tutor.imgUrl} alt={`${tutor.name}'s logo`} />
            </div>
            <div className="category">
              <span className="cate-detail">{tutor?.categories[0].name}</span>
              <span className="cate-detail">+{tutor.categories.length - 1}</span>
            </div>
            <h3>{tutor.name}</h3>
            <div className="info-course">
              <p><ImBooks /> : {tutor.countLecture}</p>
              <p><FaChalkboardTeacher /> : {tutor.level}</p>
            </div>
            <div className="rating-action">
              <div className="rating">
                <Box
                  sx={{
                    '& > legend': { mt: 2 },
                  }}
                >
                  <Rating name="read-only" value={tutor.ratingAvg} readOnly />
                </Box>
                <span> {tutor.ratingCount}</span>
              </div>
              <button className="button-remove">Unsave</button>
            </div>
          </div>
        ))}
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
