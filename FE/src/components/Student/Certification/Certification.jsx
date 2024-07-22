import React, { useState, useEffect, useRef } from "react";
import "./Certification.css";

import Box from "@mui/material/Box";
import Rating from "@mui/material/Rating";

import { IoCheckmarkOutline } from "react-icons/io5";
import { SlShareAlt } from "react-icons/sl";
import { BsDownload } from "react-icons/bs";
import ApiService from "../../../api/ApiService";
import { useParams } from "react-router-dom";
import LoadingOverlay from "../../LoadingOverlay";
import CertificateTemplate from "./CertificateTemplate";
import { useReactToPrint } from "react-to-print";

export default function Certification() {
  const { userId } = useParams();
  const [userData, setUserData] = useState([]);
  const [loading, setLoading] = useState(true);
  const certificateRef = useRef();

  const handlePrint = useReactToPrint({
    content: () => certificateRef.current,
  });

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

  if (
    !certificationData ||
    !certificationData.certification ||
    !certificationData.certification.course
  ) {
    return (
      <div>
        <LoadingOverlay loading={loading} />
      </div>
    );
  }

  const datePass = certificationData.datePass;

  const dateObj = new Date(datePass);

  const formattedDate = `${dateObj.getDate().toString().padStart(2, "0")}-${(
    dateObj.getMonth() + 1
  )
    .toString()
    .padStart(2, "0")}-${dateObj.getFullYear()}`;

  const chunkArray = (array, size) => {
    const chunkedArr = [];
    for (let i = 0; i < array.length; i += size) {
      chunkedArr.push(array.slice(i, i + size));
    }
    return chunkedArr;
  };

  const chapterGroups = chunkArray(
    certificationData.certification.course.chapters,
    3
  );

  return (
    <div id="Certification">
      <div className="container">
        <div className="container1">
          <h5>{certificationData.certification.course.name}</h5>

          <div className="container1-column">
            <div className="container-column1">
              <div className="complete-avatar">
                {/* <img
                  src={certificationData.user.images[0].url}
                  alt="Avatar"
                  className="avatar"
                /> */}
                <img
                  src={
                    certificationData.user.images.length > 0
                      ? certificationData.user.images[0].url
                      : ""
                  }
                  alt="Avatar"
                  className="avatar"
                />
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
                  <p>
                    Coursera certifies their successful completion of University
                    of Minnesota Software Development Lifecycle Specialization.
                  </p>
                </div>

                <div className="column-chapter">
                  <h2> Chapter Completed</h2>
                  {certificationData.certification.course.chapters.map(
                    (chapter) => (
                      <p key={chapter.chapterId}>
                        {`Chapter ${chapter.index}: ${chapter.name}`}
                      </p>
                    )
                  )}
                </div>
              </div>
            </div>

            <div className="container2-column">
              <div className="container-column2">
                <div className="icon-course">
                  <img
                    src={certificationData.certification.course.images[0].url}
                    alt="Avatar"
                    className="avatar"
                    style={{ width: "100px", height: "60px" }}
                  />
                </div>

                <div className="course-container">
                  <div className="course-title">
                    <h2>{certificationData.certification.course.name}</h2>
                  </div>

                  <div className="course-of-instructor">
                    <h2>{certificationData.user.name}</h2>
                  </div>

                  <Box
                    sx={{
                      "& > legend": { mt: 2 },
                    }}
                  >
                    <Rating
                      name="read-only"
                      value={certificationData.user.comments[0].rating}
                      readOnly
                    />
                  </Box>
                </div>
              </div>
            </div>

            <div className="container-column3">
              <div className="column3-title1">
                <h4>WHAT YOU WILL LEARN</h4>
              </div>

              <div className="container-you-learn">
                {chapterGroups.map((group, groupIndex) => (
                  <div className="column3-column" key={groupIndex}>
                    {group.map((chapter) => (
                      <div className="column3-row" key={chapter.chapterId}>
                        <div className="column-learn">
                          <div className="row-learn">
                            <IoCheckmarkOutline
                              style={{ height: "20px", width: "50px" }}
                            />
                            <h2>{chapter.name}</h2>
                          </div>
                        </div>
                      </div>
                    ))}
                  </div>
                ))}
              </div>
            </div>
          </div>
        </div>

        <div className="container2">
          <div className="container-certification">
            <div className="certification-img">
              <CertificateTemplate
                userName={certificationData.user.name}
                courseName={certificationData.certification.course.name}
                date={formattedDate}
                instructorName={
                  certificationData.certification.course.user.name
                }
              />
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

              <div onClick={handlePrint} className="certification-bt-dowwnload">
                <div className="icon">
                  <BsDownload size={15} />
                </div>
                <div className="text">
                  <h2>Download Certificate</h2>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div style={{ display: "none" }}>
          <div ref={certificateRef}>
            <CertificateTemplate
              userName={certificationData.user.name}
              courseName={certificationData.certification.course.name}
              date={formattedDate}
              instructorName={certificationData.certification.course.user.name}
            />
          </div>
        </div>
      </div>
    </div>
  );
}
