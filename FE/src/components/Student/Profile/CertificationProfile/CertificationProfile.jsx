import React, { useEffect, useState } from "react";
import "./CertificationProfile.css";
// import CSLogo from '../../../../assets/CS_logo.png';
import { IoInformationCircleOutline } from "react-icons/io5";
import { IoIosArrowDown } from "react-icons/io";
import { IoIosArrowUp } from "react-icons/io";
import ApiService from "../../../../api/ApiService";

export default function CertificationProfile({ user }) {
  const [showAll, setShowAll] = useState(false);
  const [itemShow, setItemShow] = useState(3);
  const [certifications, setCertifications] = useState([]);

  useEffect(() => {
    const fetchCertificationData = async () => {
      try {
        const certificationData = await ApiService.getCredentials(user.id);
        setCertifications(certificationData);
      } catch (error) {
        console.log("Error fetching get credentials list: ", error);
      }
    };

    fetchCertificationData();
  }, []);

  const handleShowMore = () => {
    if (itemShow === 3) {
      setItemShow(certifications.length);
      setShowAll(true);
    } else if (itemShow === certifications.length) {
      setItemShow(3);
      setShowAll(false);
    }
  };

  return (
    <div id="certification-profile">
      <div className="credentials-title">
        <h3 className="education-title">Credentials</h3>
        <IoInformationCircleOutline className="info-icon" />
      </div>
      <div id="credentials">
        <div className="credentials-container">
          {certifications.map((cert, index) => (
            <div
              key={index}
              className="credential-item"
              id={`credential-item-${index}`}
              style={index < itemShow ? {} : { display: "none" }}
            >
              <div className="certification-header">
                <div className="certification-image">
                  <img
                    src={cert.certification.course.images[0].url}
                    alt={cert.certification.course.name}
                  />
                </div>
                <div className="certification-details">
                  <h3 id={`credential-title-${index}`}>
                    {cert.certification.course.name}
                  </h3>
                  <p className={`field-tag`}>
                    {cert.certification.course.cateCoruse[0].category.names[0]}
                  </p>
                  {/* <div className="fields" id={`fields-${index}`}>
                                                  {cert.fields.map((field, i) => (
                                                       <span key={i} className="field-tag" id={`field-tag-${index}-${i}`}>{field}</span>
                                                  ))}
                                             </div> */}
                  <p
                    id={`duration-${index}`}
                    title="Total time and date of receiving the certificate"
                  >
                    {cert.certification.course.estimatedLearningTime} Minutes •{" "}
                    {new Date(cert.datePass)
                      .toLocaleDateString("en-GB", {
                        day: "2-digit",
                        month: "2-digit",
                        year: "numeric",
                      })
                      .replace(/\//g, "-")}
                  </p>

                  <a
                    href={`/student/certification/${cert.user.id}`}
                    className="view-certificate"
                    id={`view-certificate-${index}`}
                  >
                    View certificate
                  </a>
                </div>
              </div>
            </div>
          ))}
        </div>
        <div className="show-more">
          <div className="show-icon">
            <button className="show-all" onClick={handleShowMore}>
              {showAll ? (
                <IoIosArrowUp className="arrow" />
              ) : (
                <IoIosArrowDown className="arrow" />
              )}
              {showAll ? "Show less" : "Show more"}
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}
