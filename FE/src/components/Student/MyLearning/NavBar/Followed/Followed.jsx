import React, { useEffect, useState } from "react";
import './Followed.css';
import add from '../../../../../assets/add_profile.png';
import ApiService from "../../../../../api/ApiService";

const tutorsData = [
     // { name: "John Doe", title: "Wordpress & Plugin Tutor", students: "100K Students", courses: "15 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Kerstin Cable", title: "Language Learning Coach, Writer, Online Tutor", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 3", title: "Title 3", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 4", title: "Title 4", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 5", title: "Title 5", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 6", title: "Title 6", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 7", title: "Title 7", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 8", title: "Title 8", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 9", title: "Title 9", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 10", title: "Title 10", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 11", title: "Title 11", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 12", title: "Title 12", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 13", title: "Title 13", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 14", title: "Title 14", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 15", title: "Title 15", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
     // { name: "Tutor 16", title: "Title 16", students: "14K Students", courses: "11 Courses", social: ["facebook", "twitter", "linkedin", "youtube"], avatar: add },
];

const Followed = () => {
     const [currentPage, setCurrentPage] = useState(1);
     const [searchTerm, setSearchTerm] = useState("");
     const [tutors, setTutors] = useState(tutorsData);
     const [data, setData] = useState(null);
     const tutorsPerPage = 15;

     useEffect(() => {
          fetchFollowing("user_8c0c22c265")
     }, [])

     const fetchFollowing = async (userId) => {
          const response = await ApiService.getFollowing(userId);
          setData(response)
     }
     useEffect(() => {
          console.log(data)
     }, [data])
     // Logic for filtering tutors based on search term
     const filteredTutors = tutors.filter(tutor =>
          tutor.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
          tutor.students.toLowerCase().includes(searchTerm.toLowerCase()) ||
          tutor.courses.toLowerCase().includes(searchTerm.toLowerCase())
     );

     // Logic for displaying current tutors
     const indexOfLastTutor = currentPage * tutorsPerPage;
     const indexOfFirstTutor = indexOfLastTutor - tutorsPerPage;
     const currentTutors = filteredTutors.slice(indexOfFirstTutor, indexOfLastTutor);

     // Logic for handling page numbers
     const pageNumbers = [];
     for (let i = 1; i <= Math.ceil(filteredTutors.length / tutorsPerPage); i++) {
          pageNumbers.push(i);
     }

     // Handle Unfollow button click
     const handleUnfollow = (name) => {
          if (window.confirm(`Are you sure you want to unfollow ${name}?`)) {
               setTutors(tutors.filter(tutor => tutor.name !== name));
          }
     };

     return (
          <div id="Followed">

               <div id="search-bar">
                    <input
                         type="text"
                         placeholder="Search Tutors..."
                         value={searchTerm}
                         onChange={(e) => setSearchTerm(e.target.value)}
                    />
               </div>

               <div id="tutors-grid">
                    {data?.map((tutor, index) => (
                         <div className="tutor-card" key={index}>
                              <div className="avatar">
                                   <img src={tutor.listImage[0]} alt={`avatar`} />
                              </div>
                              <h3>{tutor.name}</h3>
                              <div className="social-links">
                                   {tutor.social?.map((platform, idx) => (
                                        <a key={idx} href={`#${platform}`} className={`icon-${platform}`}></a>
                                   ))}
                              </div>
                              <p>{tutor.follower} Follower</p>
                              <p>{tutor.course} Courses</p>
                              <button onClick={() => handleUnfollow(tutor.name)}>Unfollow</button>
                         </div>
                    ))}
               </div>

               {pageNumbers.length > 1 && ( // Only show pagination if there is more than 1 page
                    <div className="pagination">
                         <button onClick={() => setCurrentPage(currentPage - 1)} disabled={currentPage === 1}>
                              Previous
                         </button>
                         {pageNumbers.map(number => (
                              <button
                                   key={number}
                                   onClick={() => setCurrentPage(number)}
                                   className={currentPage === number ? 'active' : ''}
                                   disabled={currentPage === number}
                              >
                                   {number}
                              </button>
                         ))}
                         <button onClick={() => setCurrentPage(currentPage + 1)} disabled={currentPage === pageNumbers.length}>
                              Next
                         </button>
                    </div>
               )}
          </div>
     );
};

export default Followed;
