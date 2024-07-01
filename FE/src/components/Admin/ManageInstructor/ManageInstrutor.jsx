import React from "react";
import './ManageInstructor.css';


export default function ManageInstructor() {

    return (
        <div id="ManageInstructor">
            <div className="table-container">
                <table>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Email</th>
                            <th>Company</th>
                            <th>Title</th>
                            <th>Status</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    );
}
