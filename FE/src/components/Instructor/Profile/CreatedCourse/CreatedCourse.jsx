import React, { useState } from "react";
import './CreatedCourse.css'
import CNXlogo from '../../../../assets/CNX.png';
import Mlogo from '../../../../assets/M.png';
import MMlogo from '../../../../assets/MM.png';
import CUlogo from '../../../../assets/CU.png';
import SYSNEYlogo from '../../../../assets/SYSNEY.png';
import { IoMdMore } from "react-icons/io";
import { GrUpdate } from "react-icons/gr";
import { FaRegStopCircle } from "react-icons/fa";
import { MdDeleteOutline } from "react-icons/md";




export default function CreatedCourse() {

    const createdCourse = [
        {
            title: "CertNexus CertNexus Certified Ethical Emerging Technologist Professional Certificate",
            courseLink: "#",
            imageSrc: CNXlogo,
        },
        {
            title: "Software Development Lifecycle Specialization (University of Minnesota)",
            courseLink: "#",
            imageSrc: Mlogo,
        },
        {
            title: "Web Design for Everybody: Basics of Web Development & Coding Specialization (University of Michigan)",
            courseLink: "#",
            imageSrc: MMlogo,
        },
        {
            title: "Computer Communications Specialization (University of Colorado System)",
            courseLink: "#",
            imageSrc: CUlogo,
        },
        {
            title: "Academic Skills for University Success Specialization (The University of Sydney)",
            courseLink: "#",
            imageSrc: SYSNEYlogo,
        },
    ]

    const [openDropdownIndex, setOpenDropdownIndex] = useState(null);

    const handleDropdownClick = (index) => {
        setOpenDropdownIndex(index === openDropdownIndex ? null : index);
    };

    return (
        <div id="created-course">
            <div className="created-title">
                <h3 className="created-course-title">Created course</h3>
            </div>
            <div id="created">
                {createdCourse.map((cert, index) => (
                    <div key={index} className="created-course-item" id={`created-course-title-${index}`}>
                        <div className="created-course-header">
                            <div className="created-course-image">
                                <img src={cert.imageSrc} alt={cert.title} />
                            </div>
                            <div className="created-course-details">
                                <h4 id={`course-title-${index}`}>{cert.title}</h4>
                                <a href={cert.courseLink} className="view-course-detail" id={`view-course-detail-${index}`}>View course detail</a>
                            </div>
                            <div className="course-actions">
                                <IoMdMore className="more-icon" onClick={() => handleDropdownClick(index)} />
                                <div className="more-dropdown" style={{ display: openDropdownIndex === index ? 'block' : 'none' }}>
                                    <div className="update btnz" ><GrUpdate />&nbsp;&nbsp;Update</div>
                                    <div className="stop btnz" ><FaRegStopCircle />&nbsp;&nbsp;Stop</div>
                                    <div className="delete btnz" ><MdDeleteOutline />&nbsp;&nbsp;Delete</div>
                                </div>
                            </div>

                        </div>
                    </div>

                ))}
            </div>
        </div>

    )
}