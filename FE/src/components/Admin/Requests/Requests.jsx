import React, { useEffect, useState } from "react";
import "./Requests.css";
import { RxCross2 } from "react-icons/rx";
import { GoDotFill } from "react-icons/go";
import { FaCalendarDay } from "react-icons/fa6";
import { FaUserCheck } from "react-icons/fa6";
import { SiGmail } from "react-icons/si";
import { FaPhoneAlt } from "react-icons/fa";
import { FaInfoCircle } from "react-icons/fa";
import ApiService from "../../../api/ApiService";
import user_ava from "../../../assets/Collection-Avatar/1.png";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const AdminRequests = () => {
  const [requests, setRequests] = useState([]);

  const [currentNum, setCurrentNum] = useState(0);
  const [isVisiblePopUp, setIsVisiblePopUp] = useState(false);
  const [updateInProgress, setUpdateInProgress] = useState(false);

  useEffect(() => {
    const fetchUserRequests = async () => {
      try {
        const userRequestData =
          await ApiService.getRequestBecomeInstructorManagementByAdmin();
        setRequests(userRequestData);
      } catch (error) {
        console.log("Error fetching user requests data: ", error);
      }
    };

    fetchUserRequests();
  }, []);

  const statusToString = (status) => {
    switch (status) {
      case 1:
        return "Approved";
      case 2:
        return "Rejected";
      default:
        return "Pending";
    }
  };

  const stringToStatus = (statusString) => {
    switch (statusString) {
      case "Approved":
        return 1;
      case "Rejected":
        return 2;
      default:
        return 0;
    }
  };

  const handleStatusChange = async (id, statusString) => {
    const status = stringToStatus(statusString);
    try {
      setUpdateInProgress(true);

      const updatedStatus = await ApiService.UpdateRequestRoleUserByAdmin(
        id,
        status,
      );

      if (updatedStatus) {
        setRequests(
          requests.map((request) =>
            request.userRequest.id === id
              ? { ...request, status: status }
              : request,
          ),
        );
        toast.success(`Updated successfully!`);
      } else {
        console.log("Update status failed or no update needed.");
      }
    } catch (error) {
      console.error("Error updating status:", error);
      toast.error("Error updating status. Please try again.");
    } finally {
      setUpdateInProgress(false);
    }
  };

  const handleOpenPopUpClick = (num) => {
    setIsVisiblePopUp(true);
    try {
      setTimeout(() => {
        let progress = document.querySelector(".popup");
        progress.classList.add("open");
      }, 200);
    } catch (error) {
      <h2>Error Search</h2>;
    }
    setCurrentNum(num);
  };

  const handleCrossClick = () => {
    let progress = document.querySelector(".popup");
    progress.classList.remove("open");
    setTimeout(() => {
      setIsVisiblePopUp(false);
    }, 500);
  };

  return (
    <div id="AdminRequests">
      <ToastContainer
        style={{ position: "fixed", top: 60, right: 20, zIndex: 9999 }}
      />
      <h2>Request to become an Instructor</h2>
      <ul className="request-list">
        {requests.map((request, index) => (
          <li
            key={request.id}
            className={`request-item ${statusToString(
              request.userRequest.roleUserReqs[0].status,
            ).toLowerCase()}`}
          >
            <p>
              <strong>Student:</strong> {request.userRequest.username}
            </p>
            <p>
              <strong>Request:</strong> {request.title}
            </p>
            <p>
              <strong>Status:</strong> Pending
            </p>
            <div className="action-request">
              <span className="button-view-request">
                <FaInfoCircle
                  onClick={() => {
                    handleOpenPopUpClick(index);
                  }}
                />
              </span>
            </div>
            {request.userRequest.roleUserReqs[0].status === 0 ||
              (request.userRequest.roleUserReqs[0].status === 2 &&
                (request.isRead === false || request.isRead === true) && (
                  <div className="actions">
                    <button
                      onClick={() =>
                        handleStatusChange(request.userRequest.id, "Approved")
                      }
                    >
                      Approve
                    </button>
                    <button
                      onClick={() =>
                        handleStatusChange(request.userRequest.id, "Rejected")
                      }
                    >
                      Reject
                    </button>
                  </div>
                ))}
          </li>
        ))}
      </ul>
      {isVisiblePopUp && (
        <div className="popup">
          <div className="cross">
            <RxCross2 onClick={handleCrossClick} />
          </div>
          <div className="popup-container">
            <div className="popup-info">
              <div className="popup-info-image">
                <img
                  src={
                    requests[currentNum].userRequest.images != null &&
                    requests[currentNum].userRequest.images.length > 0
                      ? requests[currentNum].userRequest.images[0].url
                      : user_ava
                  }
                  alt={
                    requests[currentNum].userRequest.images != null &&
                    requests[currentNum].userRequest.images.length > 0
                      ? requests[currentNum].userRequest.images[0].url
                      : user_ava
                  }
                />
              </div>
              <div className="popup-info-title">
                <h2>{requests[currentNum].userRequest.username}</h2>
                <div className="popup-info-title2">
                  <p>Age 21</p>
                  <GoDotFill />
                  <p>Viet Nam</p>
                </div>
              </div>
            </div>
            <div className="popup-status">
              <div className="popup-statuss">
                <FaCalendarDay />
                <p>{requests[currentNum].userRequest.createAt}</p>
              </div>
              <div className="popup-statuss">
                <FaUserCheck />
                {requests[currentNum].userRequest.createAt === null ? (
                  <p>Chua co thong tin</p>
                ) : (
                  requests[currentNum].userRequest.createAt
                )}
              </div>
            </div>
            <div className="popup-contact">
              <div className="popup-card">
                <SiGmail />
                <p>{requests[currentNum].userRequest.email}</p>
              </div>
              <div className="popup-card">
                <FaPhoneAlt />
                <p>{requests[currentNum].userRequest.phone}</p>
              </div>
            </div>
            <div className="details">
              <h3>Details</h3>
              <div className="content" style={{ whiteSpace: "pre-line" }}>
                {requests[currentNum].userRequest.description
                  .split(" + ")
                  .map((item, index) => (
                    <div key={index}>{item}</div>
                  ))}
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default AdminRequests;
