import React, { useState, useEffect } from "react";
import "./UserInfoPage.css";
import Header from "../../../components/Items/Header/Header";
import InfoStudent from "../../../components/User/Search/UserInfo/InfoStudent/InfoStudent";
import InfoFollow from "../../../components/User/Search/UserInfo/InfoFollow/InfoFollow";
import InfoRate from "../../../components/User/Search/UserInfo/InfoRate/InfoRate";
import InfoSlider from "../../../components/User/Search/UserInfo/InfoSlider/InfoSlider";
import Footer from "../../../components/Items/Footer/Footer";
import { useParams } from "react-router-dom";
import ApiService from "../../../api/ApiService";
import LoadingOverlay from "../../../components/LoadingOverlay";

export default function UserInfoPage() {
  const { id: userId } = useParams();
  const [userProfileToSeen, setUserProfileToSeen] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchUserProfileData = async () => {
      try {
        const response = await ApiService.getUserProfileToSeen(userId);
        setUserProfileToSeen(response);
      } catch (error) {
        console.log("Error fetching user profile data: ", error);
      }
    };

    if (userId) {
      fetchUserProfileData();
    }
  }, [userId]);

  useEffect(() => {
    const timeLoading = () => {
      setTimeout(() => {
        setLoading(false);
      }, 3000);
    };

    timeLoading();
  }, []);

  return (
    <div id="UserInfoPage">
      <LoadingOverlay loading={loading} />
      <Header />
      <div className="infoStudent">
        <InfoStudent user={userProfileToSeen} />
      </div>
      <div className="FL-Rate">
        <div className="Userfollow">
          <InfoFollow user={userProfileToSeen} />
        </div>
        <div className="Userrate">
          <InfoRate user={userProfileToSeen} />
          <InfoSlider user={userProfileToSeen} />
        </div>
      </div>
      <Footer />
    </div>
  );
}
