import React, { useEffect, useState } from "react";
import "./Followed.css";
import ApiService from "../../../../../api/ApiService";
import Background_user from "../../../../../assets/background-user1.jpg";
import Avatar from "@mui/material/Avatar";
import AvatarGroup from "@mui/material/AvatarGroup";

const Followed = () => {
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

     // Filter data based on the search term and instructor name
     const filteredData = data.flatMap((tutor) =>
          tutor.followFolloweds.filter((followed) =>
               followed.name.toLowerCase().includes(searchTerm.toLowerCase())
          )
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
                                        <img src={Background_user} alt="Background" className="background" />
                                        <div className="followerCount">
                                             <p>Follower: {followed.followerCount}</p>
                                             <p>Following: {followed.followFolloweds.length}</p>
                                        </div>
                                        <div className="follower-images">
                                             {followed.followFollowers.length > 0 ? (
                                                  <AvatarGroup max={4} className="avatar-group">
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
                                                  src={followed.images[0]?.url || defaultTutorImage}
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
                                   <div className="unfollow-btn">UNFOLLOW</div>
                              </div>
                         ))
                    ) : (
                         <p>No instructors found</p>
                    )}
               </div>
          </div>
     );
};

export default Followed;
