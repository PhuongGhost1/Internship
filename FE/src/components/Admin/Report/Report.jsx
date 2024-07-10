import React, { useState } from "react";
import './Report.css';
import { Pagination, PaginationItem, PaginationLink, Table } from "reactstrap";
import { FaInfoCircle, FaSearch, FaCalendarDay, FaPhoneAlt, FaUserCheck, FaCheckCircle, FaUsers } from "react-icons/fa";
import { FaRegStarHalfStroke } from "react-icons/fa6";
import { RxCross2 } from "react-icons/rx";
import { GoDotFill } from "react-icons/go";
import { MdEmail } from "react-icons/md";
import { GrTransaction } from "react-icons/gr";
import { SiGmail } from "react-icons/si";
import IntructorIMG from "../../../assets/IntructorIMG.png";
import IntructorIMG2 from "../../../assets/IntructorIMG2.png";
import IntructorIMG3 from "../../../assets/IntructorIMG3.png";
import CNXlogo from '../../../assets/CNX.png';
import Mlogo from '../../../assets/M.png';
import CUlogo from '../../../assets/CU.png';

const initialStudents = [
     {
          id: 1,
          email: "bapcon@example.com",
          name: "Bap",
          course: "Blockchain Developer",
          title: "Course error cannot load video",
          status: "New",
          img: IntructorIMG,
          phone: "0353747221",
          calender: "Joined May 2020",
          age: "22",
          role: "Student",
          country: "USA",
          attended: "Attended 7 days ago",
          activities: [
               {
                    name: 'Enrolled in CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                    datetime: '9:00 AM, May 5 2020',
                    type: "checked"
               },
               {
                    name: 'Completed module 1 of Web Design for Everybody',
                    datetime: '9:00 AM, Apr 8 2022',
                    type: "checked"
               },
               {
                    name: 'Payment of $99.00 made for Software Development Lifecycle Specialization',
                    datetime: '4:50 PM, Mar 30 2022',
                    type: "payment"
               },
               {
                    name: 'Received email about new course recommendations',
                    datetime: '10:33 AM, Mar 25 2022',
                    type: "emaill"
               },
               {
                    name: 'Submitted assignment for Web Design course',
                    datetime: '11:00 AM, Mar 23 2022',
                    type: "checked"
               }
          ],
          courses: [
               {
                    logo: CNXlogo,
                    name: 'CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                    detailLink: '#',
                    rating: '4.5',
                    progress: '60%'
               },
               {
                    logo: Mlogo,
                    name: 'Software Development Lifecycle Specialization',
                    detailLink: '#',
                    rating: '4.8',
                    progress: '30%'
               },
               {
                    logo: CUlogo,
                    name: 'Web Design for Everybody: Basics of Web Development & Coding Specialization',
                    detailLink: '#',
                    rating: '4.7',
                    progress: '80%'
               }
          ],
          payments: [
               {
                    course: 'CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                    amount: '$500'
               },
               {
                    course: 'Software Development Lifecycle Specialization',
                    amount: '$300'
               },
               {
                    course: 'Web Design for Everybody: Basics of Web Development & Coding Specialization',
                    amount: '$450'
               }
          ]
     },
     {
          id: 2,
          email: "jerome@example.com",
          name: "Jerome Reichert",
          course: "Blockchain Developer",
          title: "Course error cannot load video",
          status: "New",
          img: IntructorIMG3,
          phone: "0353747222",
          calender: "Joined June 2020",
          age: "24",
          role: "Student",
          country: "Canada",
          attended: "Attended 5 days ago",
          activities: [
               {
                    name: 'Enrolled in Software Development Lifecycle Specialization',
                    datetime: '10:00 AM, June 10 2020',
                    type: "checked"
               },
               {
                    name: 'Completed final project for Web Design course',
                    datetime: '2:00 PM, May 15 2022',
                    type: "checked"
               },
               {
                    name: 'Payment of $150.00 made for CertNexus Certificate',
                    datetime: '11:30 AM, May 1 2022',
                    type: "payment"
               }
          ],
          courses: [
               {
                    logo: Mlogo,
                    name: 'Software Development Lifecycle Specialization',
                    detailLink: '#',
                    rating: '4.6',
                    progress: '45%'
               },
               {
                    logo: CUlogo,
                    name: 'Web Design for Everybody: Basics of Web Development & Coding Specialization',
                    detailLink: '#',
                    rating: '4.9',
                    progress: '100%'
               }
          ],
          payments: [
               {
                    course: 'Software Development Lifecycle Specialization',
                    amount: '$350'
               },
               {
                    course: 'Web Design for Everybody: Basics of Web Development & Coding Specialization',
                    amount: '$400'
               }
          ]
     },
     {
          id: 3,
          email: "oscar@example.com",
          name: "Oscar Witting",
          status: "New",
          course: "Blockchain Developer",
          title: "Course error cannot load video",
          img: IntructorIMG2,
          phone: "0353747223",
          calender: "Joined July 2020",
          age: "26",
          role: "Student",
          country: "UK",
          attended: "Attended 3 days ago",
          activities: [
               {
                    name: 'Enrolled in Web Design for Everybody',
                    datetime: '3:00 PM, July 20 2020',
                    type: "checked"
               },
               {
                    name: 'Completed module 3 of Software Development Lifecycle',
                    datetime: '1:00 PM, June 5 2022',
                    type: "checked"
               },
               {
                    name: 'Payment of $200.00 made for advanced courses',
                    datetime: '9:45 AM, May 28 2022',
                    type: "payment"
               }
          ],
          courses: [
               {
                    logo: CUlogo,
                    name: 'Web Design for Everybody: Basics of Web Development & Coding Specialization',
                    detailLink: '#',
                    rating: '4.7',
                    progress: '70%'
               },
               {
                    logo: Mlogo,
                    name: 'Software Development Lifecycle Specialization',
                    detailLink: '#',
                    rating: '4.5',
                    progress: '50%'
               }
          ],
          payments: [
               {
                    course: 'Web Design for Everybody: Basics of Web Development & Coding Specialization',
                    amount: '$400'
               },
               {
                    course: 'Software Development Lifecycle Specialization',
                    amount: '$350'
               }
          ]
     }
];

const pageSize = 12;

export default function Report() {
     const [students, setStudents] = useState(initialStudents);
     const [currentPage, setCurrentPage] = useState(1);
     const [searchTerm, setSearchTerm] = useState("");
     const [tagActive, setTagActive] = useState("Activity");
     const [isVisiblePopUp, setIsVisiblePopUp] = useState(false);
     const [currentNum, setCurrentNum] = useState(0);

     const handleStatusChange = (id) => {
          setStudents(prevStudents => prevStudents.map(
               student => student.id === id ? { ...student, status: student.status === "New" ? "Fixed" : "New" } : student
          ));
     };

     const handleClick = (event, page) => {
          event.preventDefault();
          setCurrentPage(page);
     };

     const handleSearchChange = (event) => {
          setSearchTerm(event.target.value);
     };

     const filteredStudents = students.filter(student =>
          student.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
          student.email.toLowerCase().includes(searchTerm.toLowerCase())
     );

     const indexOfLastStudent = currentPage * pageSize;
     const indexOfFirstStudent = indexOfLastStudent - pageSize;
     const currentStudents = filteredStudents.slice(indexOfFirstStudent, indexOfLastStudent);
     const totalPages = Math.ceil(filteredStudents.length / pageSize);

     const handleOpenPopUpClick = (num) => {
          setIsVisiblePopUp(true)
          try {
               setTimeout(() => {
                    let progress = document.querySelector('.popup');
                    progress.classList.add('open');
               }, 200);
          } catch (error) {
               <h2>Error Search</h2>
          }
          setCurrentNum(num);
     }

     const handleCrossClick = () => {
          let progress = document.querySelector('.popup');
          progress.classList.remove('open');
          setTimeout(() => {
               setIsVisiblePopUp(false)
          }, 500);
     }

     return (
          <div id="Report">
               <div className="ManageStudent-top">
                    <div className="management-student-pagination">
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
               <Table className="student-list">
                    <thead>
                         <tr>
                              <th>No</th>
                              <th>Email</th>
                              <th>Course</th>
                              <th>Title</th>
                              <th>Status</th>
                              <th>Action</th>
                         </tr>
                    </thead>
                    <tbody>
                         {currentStudents.map((student, index) => (
                              <tr key={student.id}>
                                   <td className="no" scope="row">{indexOfFirstStudent + index + 1}</td>
                                   <td className="email">{student.email}</td>
                                   <td className="course">{student.course}</td>
                                   <td className="title">{student.title}</td>
                                   <td className="status">
                                        <button
                                             className={`status-toggle status-${student.status.toLowerCase()}`}
                                             onClick={() => handleStatusChange(student.id)}
                                        >
                                             {student.status}
                                        </button>
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
               <div style={isVisiblePopUp ? {} : { display: 'none' }}>
                    <div className="popup">
                         <div className="cross"> <RxCross2 onClick={handleCrossClick} /></div>
                         <div className="popup-container">
                              <div className="popup-info">
                                   <div className="popup-info-image">
                                        <img src={initialStudents[currentNum].img} alt={initialStudents[currentNum].name} />
                                   </div>
                                   <div className="popup-info-title">
                                        <h2>{initialStudents[currentNum].name}</h2>
                                        <div className="popup-info-title2">
                                             <p>Age {initialStudents[currentNum].age}</p> <GoDotFill />
                                             <p>{initialStudents[currentNum].role}</p> <GoDotFill />
                                             <p>{initialStudents[currentNum].country}</p>
                                        </div>
                                   </div>
                              </div>
                              <div className="popup-status">
                                   <div className="popup-statuss">
                                        <FaCalendarDay />
                                        <p>{initialStudents[currentNum].calender}</p>
                                   </div>
                                   <div className="popup-statuss">
                                        <FaUserCheck />
                                        <p>{initialStudents[currentNum].attended}</p>
                                   </div>
                              </div>
                              <div className="popup-contact">
                                   <div className="popup-card">
                                        <SiGmail />
                                        <p>{initialStudents[currentNum].email}</p>
                                   </div>
                                   <div className="popup-card">
                                        <FaPhoneAlt />
                                        <p>{initialStudents[currentNum].phone}</p>
                                   </div>
                              </div>
                              <div className="details">
                                   <h3>Description</h3>
                                   <div className="nav-bar">
                                        <h4>Chapter 1</h4>
                                        <p>The video cannot load, please fix</p>
                                        <img src="https://gcs.tripi.vn/public-tripi/tripi-feed/img/473935Fys/5-cach-sua-loi-this-video-file-cannot-be-played-error-code-thumb-1.jpg" alt="Video error" />
                                   </div>
                              </div>
                         </div>
                    </div>
                    <div className="blur-popup"></div>
               </div>
          </div>
     );
}
