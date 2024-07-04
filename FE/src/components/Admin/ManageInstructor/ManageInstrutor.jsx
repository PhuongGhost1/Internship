import React, { useState } from "react";
import './ManageInstructor.css';
import { Pagination, PaginationItem, PaginationLink, Table } from "reactstrap";
import { FaInfoCircle } from "react-icons/fa";
import { FaSearch } from "react-icons/fa";
import { RxCross2 } from "react-icons/rx";
import IntructorIMG from "../../../assets/IntructorIMG.png"
import IntructorIMG2 from "../../../assets/IntructorIMG2.png"
import IntructorIMG3 from "../../../assets/IntructorIMG3.png"
import { FaCalendarDay } from "react-icons/fa6";
import { GoDotFill } from "react-icons/go";
import { IoIosMail } from "react-icons/io";
import { FaPhoneAlt } from "react-icons/fa";
import { FaUserCheck } from "react-icons/fa6";
import { FaCheckCircle } from "react-icons/fa";
import { MdEmail } from "react-icons/md";
import { GrTransaction } from "react-icons/gr";
import CNXlogo from '../../../assets/CNX.png';
import Mlogo from '../../../assets/M.png';
import MMlogo from '../../../assets/MM.png';
import CUlogo from '../../../assets/CU.png';
import SYSNEYlogo from '../../../assets/SYSNEY.png';
import { FaUsers } from "react-icons/fa";
import { FaRegStarHalfStroke } from "react-icons/fa6";


const initialInstructors = [
    {
        id: 1,
        email: "NHCanh@gmail.com",
        name: "Nguyễn Hửu Cảnh",
        status: "Active",
        img: IntructorIMG,
        phone: "(+84)353747221",
        calender: "Joined May 2020",
        age: "22",
        role: "Instructor",
        country: "Vietnam",
        attended: "Attended 7 day ago",
        activities: [
            {
                name: 'Successfully submitted course posting request',
                datetime: '9:00 AM, May 5 2020',
                type: "checked"
            },
            {
                name: 'Checked in to Little Tigers Karate class',
                datetime: '9:00 AM, Apr 8 2022',
                type: "checked"
            },
            {
                name: 'Payment of $99.00 made towards Little Tigers Karate program',
                datetime: '4:50 PM, Mar 30 2022',
                type: "payment"
            },
            {
                name: 'Email sent about new updated Pricing for Swimming Dolphin',
                datetime: '10:33 AM, Mar 25 2022',
                type: "emaill"
            },
            {
                name: 'Checked in to Swimming Dolphin class',
                datetime: '11:00 AM, Mar 23 2022',
                type: "checked"
            },
            {
                name: 'Successfully submitted course posting request',
                datetime: '9:00 AM, May 5 2020',
                type: "checked"
            },
            {
                name: 'Checked in to Little Tigers Karate class',
                datetime: '9:00 AM, Apr 8 2022',
                type: "checked"
            }
        ],
        courses: [
            {
                logo: CNXlogo,
                name: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                detailLink: '#',
                rating: '4.5',
                enroll: '200'
            },
            {
                logo: Mlogo,
                name: 'Software Development Lifecycle Specialization (University of Minnesota)',
                detailLink: '#',
                rating: '4.8',
                enroll: '150'
            },
            {
                logo: CUlogo,
                name: 'Web Design for Everybody: Basics of Web Development & Coding Specialization (University of Michigan)',
                detailLink: '#',
                rating: '4.7',
                enroll: '180'
            }
        ],
        payments: [
            {
                course: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                amount: '$500'
            },
            {
                course: 'Software Development Lifecycle Specialization (University of Minnesota)',
                amount: '$300'
            },
            {
                course: 'Web Design for Everybody: Basics of Web Development & Coding Specialization (University of Michigan)',
                amount: '$450'
            },
            {
                course: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                amount: '$200'
            },
            {
                course: 'Software Development Lifecycle Specialization (University of Minnesota)',
                amount: '$600'
            },
            {
                course: 'Web Design for Everybody: Basics of Web Development & Coding Specialization (University of Michigan)',
                amount: '$700'
            },
            {
                course: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                amount: '$900'
            }
        ]
    },
    {
        id: 2,
        email: "NCHai@gmail.com",
        name: "Nguyễn Chí Hải",
        status: "Active",
        img: IntructorIMG3,
        phone: "(+84)353747221",
        calender: "Joined May 2020",
        age: "22",
        role: "Instructor",
        country: "Vietnam",
        attended: "Attended 5 day ago",
        activities: [
            {
                name: 'Successfully submitted course posting request',
                datetime: '9:00 AM, May 5 2020',
                type: "checked"
            },
            {
                name: 'Checked in to Little Tigers Karate class',
                datetime: '9:00 AM, Apr 8 2022',
                type: "checked"
            },
            {
                name: 'Payment of $99.00 made towards Little Tigers Karate program',
                datetime: '4:50 PM, Mar 30 2022',
                type: "payment"
            },
            {
                name: 'Email sent about new updated Pricing for Swimming Dolphin',
                datetime: '10:33 AM, Mar 25 2022',
                type: "emaill"
            },
            {
                name: 'Checked in to Swimming Dolphin class',
                datetime: '11:00 AM, Mar 23 2022',
                type: "checked"
            },
            {
                name: 'Successfully submitted course posting request',
                datetime: '9:00 AM, May 5 2020',
                type: "checked"
            },
            {
                name: 'Checked in to Little Tigers Karate class',
                datetime: '9:00 AM, Apr 8 2022',
                type: "checked"
            }
        ],
        courses: [
            {
                logo: CNXlogo,
                name: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                detailLink: '#',
                rating: '4.5',
                enroll: '220'
            },
            {
                logo: CUlogo,
                name: 'Web Design for Everybody: Basics of Web Development & Coding Specialization (University of Michigan)',
                detailLink: '#',
                rating: '4.6',
                enroll: '180'
            }
        ],
        payments: [
            {
                course: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                amount: '$200'
            },
            {
                course: 'Web Design for Everybody: Basics of Web Development & Coding Specialization (University of Michigan)',
                amount: '$250'
            },
            {
                course: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                amount: '$300'
            },
            {
                course: 'Web Design for Everybody: Basics of Web Development & Coding Specialization (University of Michigan)',
                amount: '$400'
            },
            {
                course: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                amount: '$500'
            },
            {
                course: 'Web Design for Everybody: Basics of Web Development & Coding Specialization (University of Michigan)',
                amount: '$600'
            },
            {
                course: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                amount: '$700'
            }
        ]
    },
    {
        id: 3,
        email: "NMQuan@gmail.com",
        name: "Nguyễn Minh Quân",
        status: "Active",
        img: IntructorIMG2,
        phone: "(+84)353747221",
        calender: "Joined May 2020",
        age: "22",
        role: "Instructor",
        country: "Vietnam",
        attended: "Attended 7 day ago",
        activities: [
            {
                name: 'Successfully submitted course posting request',
                datetime: '9:00 AM, May 5 2020',
                type: "checked"
            },
            {
                name: 'Checked in to Little Tigers Karate class',
                datetime: '9:00 AM, Apr 8 2022',
                type: "checked"
            },
            {
                name: 'Payment of $99.00 made towards Little Tigers Karate program',
                datetime: '4:50 PM, Mar 30 2022',
                type: "payment"
            },
            {
                name: 'Email sent about new updated Pricing for Swimming Dolphin',
                datetime: '10:33 AM, Mar 25 2022',
                type: "emaill"
            },
            {
                name: 'Checked in to Swimming Dolphin class',
                datetime: '11:00 AM, Mar 23 2022',
                type: "checked"
            },
            {
                name: 'Successfully submitted course posting request',
                datetime: '9:00 AM, May 5 2020',
                type: "checked"
            },
            {
                name: 'Checked in to Little Tigers Karate class',
                datetime: '9:00 AM, Apr 8 2022',
                type: "checked"
            }
        ],
        courses: [
            {
                logo: CNXlogo,
                name: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                detailLink: '#',
                rating: '4.8',
                enroll: '200'
            },
            {
                logo: Mlogo,
                name: 'Software Development Lifecycle Specialization (University of Minnesota)',
                detailLink: '#',
                rating: '4.7',
                enroll: '200'
            },
            {
                logo: CUlogo,
                name: 'Web Design for Everybody: Basics of Web Development & Coding Specialization (University of Michigan)',
                detailLink: '#',
                rating: '4.2',
                enroll: '200'
            },
            {
                logo: CNXlogo,
                name: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                detailLink: '#',
                rating: '4.6',
                enroll: '200'
            },
            {
                logo: Mlogo,
                name: 'Software Development Lifecycle Specialization (University of Minnesota)',
                detailLink: '#',
                rating: '4.3',
                enroll: '200'
            },
            {
                logo: CUlogo,
                name: 'Web Design for Everybody: Basics of Web Development & Coding Specialization (University of Michigan)',
                detailLink: '#',
                rating: '4.1',
                enroll: '200'
            }
        ],
        payments: [
            {
                course: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                amount: '$600'
            },
            {
                course: 'Software Development Lifecycle Specialization (University of Minnesota)',
                amount: '$700'
            },
            {
                course: 'Web Design for Everybody: Basics of Web Development & Coding Specialization (University of Michigan)',
                amount: '$500'
            },
            {
                course: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                amount: '$300'
            },
            {
                course: 'Software Development Lifecycle Specialization (University of Minnesota)',
                amount: '$400'
            },
            {
                course: 'Web Design for Everybody: Basics of Web Development & Coding Specialization (University of Michigan)',
                amount: '$600'
            },
            {
                course: 'CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate',
                amount: '$700'
            }
        ]
    }
];

const pageSize = 12;

export default function ManageInstructor() {
    const [instructors, setInstructors] = useState(initialInstructors);
    const [currentPage, setCurrentPage] = useState(1);
    const [searchTerm, setSearchTerm] = useState("");
    const [tagActive, setTagActive] = useState("Activity");
    const [isVisiblePopUp, setIsVisiblePopUp] = useState(false);
    const [currentNum, setCurrentNum] = useState(0);

    const handleStatusChange = (id) => {
        setInstructors(prevInstructors => prevInstructors.map(
            instructor => instructor.id === id ? { ...instructor, status: instructor.status === "Active" ? "Block" : "Active" } : instructor
        ));
    };

    const handleClick = (event, page) => {
        event.preventDefault();
        setCurrentPage(page);
    };

    const handleSearchChange = (event) => {
        setSearchTerm(event.target.value);
    };

    const filteredInstructors = instructors.filter(instructor =>
        instructor.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
        instructor.email.toLowerCase().includes(searchTerm.toLowerCase())
    );

    const indexOfLastInstructor = currentPage * pageSize;
    const indexOfFirstInstructor = indexOfLastInstructor - pageSize;
    const currentInstructors = filteredInstructors.slice(indexOfFirstInstructor, indexOfLastInstructor);
    const totalPages = Math.ceil(filteredInstructors.length / pageSize);

    const handleOpenPopUpClick = (num) => {
        setIsVisiblePopUp(true)
        try {
            setTimeout(() => {
                let progress = document.querySelector('.popup');
                progress.classList.add('open');
            }, 200);
        } catch (error) {
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

    const renderContent = () => {
        switch (tagActive) {
            case 'Activity':
                return (
                    <div className="popup-activity">
                        <div className="activity-card">
                            <div className="activity-content">
                                {initialInstructors[currentNum].activities.map((activity, index) => (
                                    <div key={index} className={`activity-item ${activity.type}`}>
                                        <div className="activity-icon">
                                            {(activity.type === 'payment') && <GrTransaction />}
                                            {(activity.type === 'emaill') && <MdEmail />}
                                            {(activity.type === 'checked') && <FaCheckCircle />}
                                        </div>
                                        <div>
                                            <p>{activity.datetime}</p>
                                            <p>{activity.name}</p>
                                        </div>
                                    </div>
                                ))}
                            </div>
                        </div>
                    </div>
                );
            case 'Course':
                return (
                    <div className="popup-course">
                        {initialInstructors[currentNum].courses.map((course, index) => (
                            <div key={index} className="course-card">
                                <img src={course.logo} alt={`${course.name} logo`} className="course-logo" />
                                <div className="course-details">
                                    <h3>{course.name}</h3>
                                    <div className="course-icon">
                                        <div className="course-icon-item">
                                            <FaRegStarHalfStroke />
                                            <p>{course.rating}</p>
                                        </div>
                                        <div className="course-icon-item">
                                            <FaUsers />
                                            <p>{course.enroll}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        ))}
                    </div>
                );
            case 'Payment-History':
                return (
                    <div className="popup-payment">
                        <div className="payment-history">
                            {initialInstructors[currentNum].payments.map((payment, index) => (
                                <div key={index} className="payment-item">
                                    <p><strong>Course:</strong> {payment.course}</p>
                                    <p><strong>Amount: </strong><span>+{payment.amount}</span> </p>
                                </div>
                            ))}
                        </div>
                    </div>
                );
            default:
                return null;
        }
    };

    return (
        <div id="ManageInstructor">
            <div className="ManageInstructor-top">
                <div className="management-instructor-pagination">
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
            <Table className="instructor-list">
                <thead>
                    <tr>
                        <th>No</th>
                        <th>Email</th>
                        <th>Name</th>
                        <th>Status</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {currentInstructors.map((instructor, index) => (
                        <tr key={instructor.id}>
                            <th className="no" scope="row">{indexOfFirstInstructor + index + 1}</th>
                            <td className="email">{instructor.email}</td>
                            <td className="name">{instructor.name}</td>
                            <td className="status">
                                <button
                                    className={`status-toggle status-${instructor.status.toLowerCase()}`}
                                    onClick={() => handleStatusChange(instructor.id)}
                                >
                                    {instructor.status}
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
                                <img src={initialInstructors[currentNum].img} alt={initialInstructors[currentNum].img} />
                            </div>
                            <div className="popup-info-title">
                                <h2>{initialInstructors[currentNum].name}</h2>
                                <div className="popup-info-title2">
                                    <p>Age {initialInstructors[currentNum].age}</p> <GoDotFill />
                                    <p>{initialInstructors[currentNum].role}</p> <GoDotFill />
                                    <p>{initialInstructors[currentNum].country}</p>
                                </div>
                            </div>
                        </div>
                        <div className="popup-status">
                            <div className="popup-statuss">
                                <FaCalendarDay />
                                <p>{initialInstructors[currentNum].calender}</p>
                            </div>
                            <div className="popup-statuss">
                                <FaUserCheck />
                                <p>{initialInstructors[currentNum].attended}</p>
                            </div>
                        </div>
                        <div className="popup-contact">
                            <div className="popup-card">
                                <IoIosMail />
                                <p>{initialInstructors[currentNum].email}</p>
                            </div>
                            <div className="popup-card">
                                <FaPhoneAlt />
                                <p>{initialInstructors[currentNum].phone}</p>
                            </div>
                        </div>
                        <div className="details">
                            <h3>Details</h3>
                            <div className="nav-bar">
                                <div className={`activity tag ${tagActive === 'Activity' ? 'active' : ''}`} onClick={() => { setTagActive('Activity') }}>
                                    Activity
                                </div>
                                <div className={`course tag ${tagActive === 'Course' ? 'active' : ''}`} onClick={() => { setTagActive('Course') }}>
                                    Course
                                </div>
                                <div className={`payment-history tag ${tagActive === 'Payment-History' ? 'active' : ''}`} onClick={() => { setTagActive('Payment-History') }}>
                                    Payment History
                                </div>
                            </div>
                            <div className="content">
                                {renderContent()}
                            </div>
                        </div>
                    </div>
                </div>
                <div className="blur-popup"></div>
            </div>
        </div>
    );
}