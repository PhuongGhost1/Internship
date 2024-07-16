import React from "react";
import PropTypes from "prop-types";
import "./CertificateTemplate.css";

const CertificateTemplate = ({
  userName,
  courseName,
  date,
  instructorName,
}) => {
  return (
    <div id="certificate-template">
      <div className="container pm-certificate-container">
        <div className="outer-border"></div>
        <div className="inner-border"></div>

        <div className="pm-certificate-border col-xs-12">
          <div className="row pm-certificate-header">
            <div className="pm-certificate-title cursive col-xs-12 text-center">
              <h2>Gaurav Public Schools Certificate of Completion</h2>
            </div>
          </div>

          <div className="row pm-certificate-body">
            <div className="pm-certificate-block">
              <div className="col-xs-12">
                <div className="row">
                  <div className="col-xs-2"></div>
                  <div className="pm-certificate-name underline margin-0 col-xs-8 text-center">
                    <span className="pm-name-text bold">{userName}</span>
                  </div>
                  <div className="col-xs-2"></div>
                </div>
              </div>

              <div className="col-xs-12">
                <div className="row">
                  <div className="col-xs-2"></div>
                  <div className="pm-earned col-xs-8 text-center">
                    <span className="pm-earned-text padding-0 block cursive">
                      has earned
                    </span>
                    <span className="pm-credits-text block bold sans">
                      PD175: 1.0 Credit Hours
                    </span>
                  </div>
                  <div className="col-xs-2"></div>
                  <div className="col-xs-12"></div>
                </div>
              </div>

              <div className="col-xs-12">
                <div className="row">
                  <div className="col-xs-2"></div>
                  <div className="pm-course-title col-xs-8 text-center">
                    <span className="pm-earned-text block cursive">
                      while completing the training course entitled
                    </span>
                  </div>
                  <div className="col-xs-2"></div>
                </div>
              </div>

              <div className="col-xs-12">
                <div className="row">
                  <div className="col-xs-2"></div>
                  <div className="pm-course-title underline col-xs-8 text-center">
                    <span className="pm-credits-text block bold sans">
                      {courseName}
                    </span>
                  </div>
                  <div className="col-xs-2"></div>
                </div>
              </div>
            </div>

            <div className="col-xs-12">
              <div className="row">
                <div className="pm-certificate-footer">
                  <div className="col-xs-4 pm-certified col-xs-4 text-center">
                    <span className="pm-credits-text block sans">
                      Gaurav City School District
                    </span>
                    <span className="pm-empty-space block underline"></span>
                    <span className="bold block">
                      {instructorName}, Staff Development
                    </span>
                  </div>
                  <div className="col-xs-4"></div>
                  <div className="col-xs-4 pm-certified col-xs-4 text-center">
                    <span className="pm-credits-text block sans">
                      Date Completed
                    </span>
                    <span className="pm-empty-space block underline"></span>
                    <span className="bold block">{date}</span>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

CertificateTemplate.propTypes = {
  userName: PropTypes.string.isRequired,
  courseName: PropTypes.string.isRequired,
  date: PropTypes.string.isRequired,
  instructorName: PropTypes.string.isRequired,
};

export default CertificateTemplate;
