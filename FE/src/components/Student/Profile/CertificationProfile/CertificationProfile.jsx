import React from "react";
import './CertificationProfile.css';
import CSLogo from '../../../../assets/CS_logo.png';
import { IoInformationCircleOutline } from "react-icons/io5";


const certifications = [
    {
        title: "React Development Specialization",
        institution: "CertNexus",
        fields: ["Leadership and Management", "Strategy and Operations", "Critical Thinking", "Human Learning"],
        duration: "8 month program",
        completionDate: "Completed November 2023",
        certificateLink: "#",
        imageSrc: CSLogo,
    },
    {
        title: "React Development Specialization",
        institution: "React",
        fields: ["React", "JavaScript", "Front-end Development"],
        duration: "6 month program",
        completionDate: "Completed May 2024",
        certificateLink: "#",
        imageSrc: CSLogo, 
    },
    {
        title: "Java Enterprise Edition Specialization",
        institution: "LearnQuest",
        fields: ["Java Programming", "Full-Stack Web Development", "Programming Principles"],
        duration: "3 month program",
        completionDate: "Completed January 2024",
        certificateLink: "#",
        imageSrc: CSLogo, 
    },
];

export default function CertificationProfile() {
    return (
        <div id="certification-profile">
            <div className="credentials-title">
                <h3 className="education-title">Credentials</h3>
                <IoInformationCircleOutline className="info-icon"/>
            </div>
            <div id="credentials">
                {certifications.map((cert, index) => (
                    <div key={index} className="credential-item" id={`credential-item-${index}`}>
                        <div className="certification-header">
                            <div className="certification-image">
                            <img src={cert.imageSrc} alt={cert.title} />
                            </div>
                            <div className="certification-details">
                                <h3 id={`credential-title-${index}`}>{cert.title}</h3>
                                <p id={`institution-${index}`}>{cert.institution}</p>
                                <div className="fields" id={`fields-${index}`}>
                                    {cert.fields.map((field, i) => (
                                        <span key={i} className="field-tag" id={`field-tag-${index}-${i}`}>{field}</span>
                                    ))}
                                </div>
                                <p id={`duration-${index}`}>{cert.duration} • {cert.completionDate}</p>
                                <a href={cert.certificateLink} className="view-certificate" id={`view-certificate-${index}`}>View certificate</a>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}