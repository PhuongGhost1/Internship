import React from 'react';
import './InfoRate.css';
import { PiStudentBold } from "react-icons/pi";
import { SiCoursera } from "react-icons/si";
import { MdOutlineStar } from "react-icons/md";
import { FaLongArrowAltUp, FaLongArrowAltDown } from "react-icons/fa";

export default function InfoRate() {
     const totalStudents = 150;
     const totalCourses = 35;
     const averageRating = 4.5;

     const studentChange = 5;
     const courseChange = -3;
     const ratingChange = 1.2;

     const getArrowAndColor = (value) => {
          const color = value > 0 ? 'green' : 'red';
          const arrow = value > 0 ? <FaLongArrowAltUp style={{ color }} /> : <FaLongArrowAltDown style={{ color }} />;
          return { arrow, color };
     };

     const { arrow: studentArrow, color: studentColor } = getArrowAndColor(studentChange);
     const { arrow: courseArrow, color: courseColor } = getArrowAndColor(courseChange);
     const { arrow: ratingArrow, color: ratingColor } = getArrowAndColor(ratingChange);

     return (
          <div id="InfoRate">
               <div className="rateinfo-container">
                    <div className="stat">
                         <div className='stat-icon'>
                              <p><PiStudentBold /></p>
                         </div>
                         <div className='stat-value'>
                              <span>{totalStudents}</span>
                              <span className='stat-change' style={{ color: studentColor }}>
                                   {studentArrow} {Math.abs(studentChange)}%
                              </span>
                         </div>
                         <div className='stat-title'>
                              <p>Total Students</p>
                         </div>
                    </div>

                    <div className="stat">
                         <div className='stat-icon'>
                              <p><SiCoursera /></p>
                         </div>
                         <div className='stat-value'>
                              <span>{totalCourses}</span>
                              <span className='stat-change' style={{ color: courseColor }}>
                                   {courseArrow} {Math.abs(courseChange)}%
                              </span>
                         </div>
                         <div className='stat-title'>
                              <p>Total Courses</p>
                         </div>
                    </div>

                    <div className="stat">
                         <div className='stat-icon'>
                              <p><MdOutlineStar /></p>
                         </div>
                         <div className='stat-value'>
                              <span>{averageRating}</span>
                              <span className='stat-change' style={{ color: ratingColor }}>
                                   {ratingArrow} {Math.abs(ratingChange)}%
                              </span>
                         </div>
                         <div className='stat-title'>
                              <p>Average Rating</p>
                         </div>
                    </div>
               </div>
          </div>
     );
}
