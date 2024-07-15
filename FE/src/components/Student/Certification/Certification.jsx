import React, { useState, useEffect } from "react";
import './Certification.css';

import Pic1 from '../../../assets/Collection-Avatar/1.png'
import M from '../../../assets/M.png'
import Certificate from '../../../assets/Certification.png'

import Box from '@mui/material/Box';
import Rating from '@mui/material/Rating';

import { IoCheckmarkOutline } from "react-icons/io5";
import { SlShareAlt } from "react-icons/sl";
import { BsDownload } from "react-icons/bs";
import ApiService from '../../../api/ApiService';
import { useParams } from 'react-router-dom';
import LoadingOverlay from "../../LoadingOverlay";

export default function Certification() {
     const { userId } = useParams();
     const [userData, setUserData] = useState([]);
     const [loading, setLoading] = useState(true);

     useEffect(() => {
          const fetchUserData = async () => {
               try {
                    const data = await ApiService.getCredentials(userId);
                    setUserData(data);
               } catch (error) {
                    console.log("Error fetching user data: ", error);
               }
          };

          fetchUserData();
     }, []);

     useEffect(() => {
          const timeLoading = () => {
               setTimeout(() => {
                    setLoading(false);
               }, 3000);
          };

          timeLoading();
     }, []);

     const certificationData = userData[0];

     if (!certificationData || !certificationData.certification || !certificationData.certification.course) {
          return <div><LoadingOverlay loading={loading} /></div>;
     }

     const datePass = certificationData.datePass;

     const dateObj = new Date(datePass);

     const formattedDate = `${dateObj.getFullYear()}-${(dateObj.getMonth() + 1).toString().padStart(2, '0')}-${dateObj.getDate().toString().padStart(2, '0')}`;

     return (
          <div id="Certification">
               <div className="container">
                    <div className="container1">
                         <h5>{certificationData.certification.course.name}</h5>

                         <div className="container1-column">
                              <div className="container-column1">
                                   <div className="complete-avatar">
                                        <img src={certificationData.user.images[0].url} alt="Avatar" className="avatar" />
                                   </div>

                                   <div className="complete-container">
                                        <div className="column-by">
                                             <h2>Completed by</h2>
                                             <h2>{certificationData.user.name}</h2>
                                        </div>

                                        <div className="column-date">
                                             <h2>{formattedDate}</h2>
                                        </div>

                                        <div className="column-title">
                                             <div className="column-by">
                                                  <p>{certificationData.user.name}</p>
                                                  <p>account is verified.</p>
                                             </div>
                                             <p>Coursera certifies their successful completion of University of Minnesota Software Development Lifecycle Specialization.</p>
                                        </div>

                                        <div className="column-chapter">
                                             <h2> Chapter Completed</h2>
                                             <p>Chapter 1: Importing Data Sets</p>
                                             <p>Chapter 2: Data Wrangling</p>
                                             <p>Chapter 3: Exploratory Data Analysis</p>
                                             <p>Chapter 4: Model Development</p>
                                        </div>
                                   </div>
                              </div>

                              <div className="container2-column">
                                   <div className="container-column2">
                                        <div className="icon-course">
                                             <img src={M} alt="Avatar" className="avatar" />
                                        </div>

                                        <div className="course-container">
                                             <div className="course-title">
                                                  <h2>Data structures and algorithms Practice with LeetCode</h2>
                                             </div>

                                             <div className="course-of-instructor">
                                                  <h2>Nguyen Manh Duy</h2>
                                             </div>

                                             <Box
                                                  sx={{
                                                       '& > legend': { mt: 2 },
                                                  }}
                                             >
                                                  <Rating name="read-only" value={3} readOnly />
                                             </Box>

                                        </div>
                                   </div>
                              </div>

                              <div className="container-column3">

                                   <div className="column3-title1">
                                        <h4>WHAT YOU WILL LEARN</h4>

                                   </div>

                                   <div className="container-you-learn">

                                        <div className="column3-column">
                                             <div className="column3-row">
                                                  <div className="column-learn">
                                                       <div className="row-learn">
                                                            <IoCheckmarkOutline style={{ height: '20px', width: '50px' }} />
                                                            <h2>Get familiar with BASIC and ADVANCED algorithmic data structures.</h2>
                                                       </div>
                                                       <div className="row-learn">
                                                            <IoCheckmarkOutline style={{ height: '20px', width: '50px' }} />
                                                            <h2>Can install data structures and algorithms yourself.</h2>
                                                       </div>
                                                  </div>
                                             </div>
                                        </div>

                                        <div className="column3-column">
                                             <div className="column3-row">
                                                  <div className="column-learn">
                                                       <div className="row-learn">
                                                            <IoCheckmarkOutline style={{ height: '20px', width: '50px' }} />
                                                            <h2>Know how to use the library corresponding to those CTDLs and GTs.</h2>                                            </div>
                                                       <div className="row-learn">
                                                            <IoCheckmarkOutline style={{ height: '20px', width: '50px' }} />
                                                            <h2>Practice with real exercises on LeetCode and HackerRank</h2>                                            </div>
                                                  </div>
                                             </div>
                                        </div>

                                   </div>
                              </div>
                         </div>
                    </div>

                    <div className="container2">
                         <div className="container-certification">

                              <div className="certification-img">
                                   <img src={Certificate} alt="Avatar" className="avatar" />
                              </div>

                              <div className="certification-bt">
                                   <div className="certification-bt-share">
                                        <div className="icon">
                                             <SlShareAlt size={15} />
                                        </div>
                                        <div className="text">
                                             <h2>Share Certificate</h2>
                                        </div>
                                   </div>

                                   <div className="certification-bt-dowwnload">
                                        <div className="icon">
                                             <BsDownload size={15} />
                                        </div>
                                        <div className="text">
                                             <h2>Download Cetificate</h2>
                                        </div>
                                   </div>
                              </div>
                         </div>
                    </div>

               </div>
          </div>
     );
}