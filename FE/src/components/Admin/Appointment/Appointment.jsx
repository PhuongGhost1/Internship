import React from 'react';
import './Appointment.css';

export default function Appointment() {
    return (
        <div id="Appointment">
            <h2>Appointment</h2>
            <div className="appointment-container">
                {/* Replace with your appointment content */}
                <div className="appointment-item">
                    <div className="appointment-info">
                        <div className="appointment-title">Appointment Title 1</div>
                        <div className="appointment-date">Date: July 25, 2024</div>
                        <div className="appointment-time">Time: 10:00 AM - 11:00 AM</div>
                    </div>
                </div>
                <div className="appointment-item">
                    <div className="appointment-info">
                        <div className="appointment-title">Appointment Title 2</div>
                        <div className="appointment-date">Date: July 28, 2024</div>
                        <div className="appointment-time">Time: 2:00 PM - 3:00 PM</div>
                    </div>
                </div>
                {/* Add more appointment items as needed */}
            </div>
        </div>
    );
}
