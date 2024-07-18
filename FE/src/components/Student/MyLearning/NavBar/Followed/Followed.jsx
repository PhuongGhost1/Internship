import React, { useEffect, useState } from "react";
import "./Followed.css";
import ApiService from "../../../../../api/ApiService";
import Background_user from "../../../../../assets/background-user1.jpg";
import Avatar from "@mui/material/Avatar";
import AvatarGroup from "@mui/material/AvatarGroup";

const Followed = () => {
  // const [currentPage, setCurrentPage] = useState(1);
  // const [tutors, setTutors] = useState(tutorsData);
  // const tutorsPerPage = 15;
  const [searchTerm, setSearchTerm] = useState("");
  const [data, setData] = useState([]);

  useEffect(() => {
    fetchFollowing("user_e5d1e4648e");
  }, []);

  const fetchFollowing = async (userId) => {
    try {
      const response = await ApiService.getFollowing(userId);
      setData(response ? [response] : []);
    } catch (error) {
      console.error("Error fetching data: ", error);
    }
  };

  const filteredData = data.filter((tutor) =>
    tutor.followFolloweds[0].name
      .toLowerCase()
      .includes(searchTerm.toLowerCase())
  );

  // Logic for displaying current tutors
  // const indexOfLastTutor = currentPage * tutorsPerPage;
  // const indexOfFirstTutor = indexOfLastTutor - tutorsPerPage;
  // const currentTutors = filteredTutors.slice(indexOfFirstTutor, indexOfLastTutor);

  // // Logic for handling page numbers
  // const pageNumbers = [];
  // for (let i = 1; i <= Math.ceil(filteredTutors.length / tutorsPerPage); i++) {
  //      pageNumbers.push(i);
  // }

  // // Handle Unfollow button click
  // const handleUnfollow = (name) => {
  //      if (window.confirm(Are you sure you want to unfollow ${name}?)) {
  //           setTutors(tutors.filter(tutor => tutor.name !== name));
  //      }
  // };

  return (
    <div id="Followed">
      <div id="search-bar">
        <input
          type="text"
          placeholder="Search Tutors..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
      </div>

      <div id="tutors-grid">
        {filteredData.map((tutor) =>
          tutor.followFolloweds.map((followed) => (
            <div className="tutor-card" key={`${tutor.id}-${followed.id}`}>
              <div className="image-container">
                <img src={Background_user} alt="" className="background" />
                <div className="tutor-info">
                  <img src={followed.images[0]?.url || ""} alt="" />
                  <div className="user-info">
                    <p className="tutor-name">{followed.name}</p>
                    <p className="course-count">
                      {followed.coursesCount} course
                      {followed.coursesCount !== 1 ? "s" : ""}
                    </p>
                    <p>Follower: {followed.followerCount}</p>
                    <p>Following: {followed.followFolloweds.length}</p>
                    <div className="follower-images">
                      <AvatarGroup max={4} className="avatar-group">
                        {followed.followFollowers.map((follower) => (
                          <Avatar
                            key={follower.id}
                            alt={follower.name}
                            src={follower.images[0]?.url || ""}
                            className="avatar"
                          />
                        ))}
                      </AvatarGroup>
                    </div>
                  </div>
                </div>
              </div>
              <div className="follower-info">
                {/* Additional follower info can be added here */}
              </div>
              <div className="unfollow-btn">UNFOLLOW</div>
            </div>
          ))
        )}
      </div>
      {/*
               {pageNumbers.length > 1 && ( // Only show pagination if there is more than 1 page
                    <div className="pagination">
                         <button onClick={() => setCurrentPage(currentPage - 1)} disabled={currentPage === 1}>
                              Previous
                         </button>
                         {pageNumbers.map(number => (
                              <button
                                   key={number}
                                   onClick={() => setCurrentPage(number)}
                                   className={currentPage === number ? 'active' : ''}
                                   disabled={currentPage === number}
                              >
                                   {number}
                              </button>
                         ))}
                         <button onClick={() => setCurrentPage(currentPage + 1)} disabled={currentPage === pageNumbers.length}>
                              Next
                         </button>
                    </div>
               )} */}
    </div>
  );
};

export default Followed;
