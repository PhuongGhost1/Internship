import React, { useState } from "react";
import "./Saved.css";
import Logo from "../../../../../assets/Angular_logo.png";

const data = [
  {
    name: "JavaScript for Beginners",
    price: "$49.99",
    image: Logo,
    instructor: "John Doe",
    action: "Remove",
  },
  {
    name: "Advanced CSS and Sass",
    price: "$29.99",
    image: Logo,
    instructor: "Jane Smith",
    action: "Remove",
  },
  {
    name: "React - The Complete Guide",
    price: "$59.99",
    image: Logo,
    instructor: "Maximilian Schwarzmüller",
    action: "Remove",
  },
  {
    name: "Node.js, Express, MongoDB & More: The Complete Bootcamp",
    price: "$79.99",
    image: Logo,
    instructor: "Jonas Schmedtmann",
    action: "Remove",
  },
  {
    name: "Python for Data Science and Machine Learning Bootcamp",
    price: "$99.99",
    image: Logo,
    instructor: "Jose Portilla",
    action: "Remove",
  },
  {
    name: "The Complete Web Developer in 2024: Zero to Mastery",
    price: "$49.99",
    image: Logo,
    instructor: "Andrei Neagoie",
    action: "Remove",
  },
  {
    name: "The Complete JavaScript Course 2024: From Zero to Expert!",
    price: "$39.99",
    image: Logo,
    instructor: "Jonas Schmedtmann",
    action: "Remove",
  },
  {
    name: "Complete Python Bootcamp: Go from zero to hero in Python 3",
    price: "$69.99",
    image: Logo,
    instructor: "Jose Portilla",
    action: "Remove",
  },
  {
    name: "The Ultimate MySQL Bootcamp: Go from SQL Beginner to Expert",
    price: "$59.99",
    image: Logo,
    instructor: "Colt Steele",
    action: "Remove",
  },
  {
    name: "Understanding TypeScript - 2024 Edition",
    price: "$19.99",
    image: Logo,
    instructor: "Maximilian Schwarzmüller",
    action: "Remove",
  },
  {
    name: "Docker and Kubernetes: The Complete Guide",
    price: "$49.99",
    image: Logo,
    instructor: "Stephen Grider",
    action: "Remove",
  },
  {
    name: "Complete React Developer in 2024 (w/ Redux, Hooks, GraphQL)",
    price: "$59.99",
    image: Logo,
    instructor: "Andrei Neagoie",
    action: "Remove",
  },
  {
    name: "Build Responsive Real World Websites with HTML5 and CSS3",
    price: "$29.99",
    image: Logo,
    instructor: "Jonas Schmedtmann",
    action: "Remove",
  },
  {
    name: "The Complete Guide to Angular 12 (formerly Angular 2)",
    price: "$49.99",
    image: Logo,
    instructor: "Maximilian Schwarzmüller",
    action: "Remove",
  },
  {
    name: "Machine Learning A-Z: Hands-On Python & R In Data Science",
    price: "$99.99",
    image: Logo,
    instructor: "Kirill Eremenko",
    action: "Remove",
  },
  {
    name: "AWS Certified Solutions Architect - Associate 2024",
    price: "$89.99",
    image: Logo,
    instructor: "Ryan Kroonenburg",
    action: "Remove",
  },
];

const Saved = () => {
  const [currentPage, setCurrentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");
  const tutorsPerPage = 10;

  // Logic for filtering tutors based on search term
  const filteredData = data.filter(
    (tutor) =>
      tutor.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
      tutor.price.toLowerCase().includes(searchTerm.toLowerCase()) ||
      tutor.instructor.toLowerCase().includes(searchTerm.toLowerCase())
  );

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
              <img src={tutor.image} alt={`${tutor.name}'s logo`} />
            </div>
            <h3>{tutor.name}</h3>
            <p>{tutor.price}</p>
            <p>{tutor.instructor}</p>
            <button className="button-remove">{tutor.action}</button>
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
