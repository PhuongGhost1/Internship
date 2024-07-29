import React, { useEffect, useState } from "react";
import "./Followed.css";
import ApiService from "../../../../../api/ApiService";
import Background_user from "../../../../../assets/background-user1.jpg";
import Avatar from "@mui/material/Avatar";
import AvatarGroup from "@mui/material/AvatarGroup";
import defaultImg from "../../../../../assets/add_profile.png";

const Followed = ({ user }) => {
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
      fetchFollowing(FollowerId);
      return deleteFollowing.data;
    } catch (error) {
      console.error("Error remove following: ", error);
      throw error;
    }
  };

  // Filter data based on the search term and instructor name
  const filteredData = data.flatMap((tutor) =>
    tutor.followFolloweds.filter((followed) =>
      followed.name.toLowerCase().includes(searchTerm.toLowerCase()),
    ),
  );

  const defaultAvatar = "path_to_default_avatar_image"; // Define your default avatar URL here
  const defaultTutorImage = "path_to_default_tutor_image"; // Define your default tutor image URL here

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
        {filteredData.length > 0 ? (
          filteredData.map((followed) => (
            <div className="tutor-card" key={followed.id}>
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
          ))
        ) : (
          <p>Loading....</p>
        )}
      </div>
    </div>
  );
};

export default Followed;
