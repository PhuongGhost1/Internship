import React, { useEffect, useState } from "react";
import "./Followed.css";
import ApiService from "../../../../../api/ApiService";
import Background_user from "../../../../../assets/background-user1.jpg";
import Avatar from "@mui/material/Avatar";
import AvatarGroup from "@mui/material/AvatarGroup";
import defaultImg from "../../../../../assets/add_profile.png";
import defaultAvatar from "../../../../../assets/IntructorIMG.png";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function Followed({ user }) {
  const [searchTerm, setSearchTerm] = useState("");
  const [data, setData] = useState([]);

  useEffect(() => {
    fetchFollowing(user.id);
  }, []);

  const fetchFollowing = async (userId) => {
    try {
      const response = await ApiService.getFollowing(userId);
      setData(response ? [response] : []);
    } catch (error) {
      console.error("Error fetching data: ", error);
    }
  };

  const removeFollowing = async (FollowerId, FollowedId) => {
    try {
      const deleteFollowing = await ApiService.removeFollowing(
        FollowerId,
        FollowedId,
      );
      toast.success(`Remove successfully!`);
      fetchFollowing(FollowerId);
      return deleteFollowing.data;
    } catch (error) {
      console.error("Error remove following: ", error);
      toast.error("Error removing following. Please try again.");
      throw error;
    }
  };

  const filteredData = data.flatMap((tutor) =>
    tutor.followFolloweds.filter((followed) =>
      followed.name.toLowerCase().includes(searchTerm.toLowerCase()),
    ),
  );

  return (
    <div id="Followed">
      <ToastContainer
        style={{ position: "fixed", top: 60, right: 20, zIndex: 9999 }}
      />
      <div id="search-bar">
        <input
          type="text"
          placeholder="Search Tutors..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
      </div>

      <div id="tutors-grid">
        {filteredData.length > 0 ? (
          filteredData.map((followed) => (
            <Link to={`/user/${followed.id}`} key={followed.id}>
              <div className="tutor-card">
                <div className="image-container">
                  <img
                    src={Background_user}
                    alt="Background"
                    className="background"
                  />
                  <div className="followerCount">
                    <p>Follower: {followed.followerCount}</p>
                    <p>Following: {followed.followFolloweds.length}</p>
                  </div>
                  <div className="follower-images">
                    {followed.followFollowers.length > 0 ? (
                      <AvatarGroup max={3} className="avatar-group">
                        {followed.followFollowers.map((follower) => (
                          <Avatar
                            key={follower.id}
                            alt={follower.name}
                            src={follower.images[0]?.url || defaultAvatar}
                            className="avatar"
                          />
                        ))}
                      </AvatarGroup>
                    ) : (
                      <p>No followers available</p>
                    )}
                  </div>
                  <div className="tutor-info">
                    <img
                      src={
                        followed.images === null
                          ? followed.images[0].url
                          : defaultImg
                      }
                      alt="Tutor"
                      className="tutor-image"
                    />
                    <div className="user-info">
                      <p className="tutor-name">{followed.name}</p>
                      <p className="course-count">
                        {followed.coursesCount} course
                        {followed.coursesCount !== 1 ? "s" : ""}
                      </p>
                    </div>
                  </div>
                </div>
                <div className="follower-info">
                  {/* Additional follower info can be added here */}
                </div>
                <button
                  className="unfollow-btn"
                  onClick={() =>
                    removeFollowing(data[0].followingListOfUserId, followed.id)
                  }
                >
                  UNFOLLOW
                </button>
              </div>
            </Link>
          ))
        ) : (
          <p>Loading....</p>
        )}
      </div>
    </div>
  );
}

Followed.propTypes = {
  user: PropTypes.shape({
    id: PropTypes.string.isRequired,
    username: PropTypes.string.isRequired,
  }).isRequired,
};

export default Followed;
