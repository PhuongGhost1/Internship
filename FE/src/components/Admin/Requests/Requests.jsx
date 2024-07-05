import React, { useState } from "react";
import './Requests.css';

const AdminRequests = () => {
     const [requests, setRequests] = useState([
          { id: 1, studentName: "John Doe", requestMessage: "I want to become an instructor.", status: "Pending" },
          { id: 2, studentName: "Jane Smith", requestMessage: "Please consider me as an instructor.", status: "Pending" }
     ]);

     const handleStatusChange = (id, status) => {
          setRequests(requests.map(request =>
               request.id === id ? { ...request, status } : request
          ));
     };

     return (
          <div id="AdminRequests">
               <h2>Request to become an Instructor</h2>
               <ul>
                    {requests.map((request) => (
                         <li key={request.id} className={`request-item ${request.status.toLowerCase()}`}>
                              <p><strong>Student:</strong> {request.studentName}</p>
                              <p><strong>Request:</strong> {request.requestMessage}</p>
                              <p><strong>Status:</strong> {request.status}</p>
                              {request.status === "Pending" && (
                                   <div className="actions">
                                        <button onClick={() => handleStatusChange(request.id, "Approved")}>Approve</button>
                                        <button onClick={() => handleStatusChange(request.id, "Rejected")}>Reject</button>
                                   </div>
                              )}
                         </li>
                    ))}
               </ul>
          </div>
     );
};

export default AdminRequests;
