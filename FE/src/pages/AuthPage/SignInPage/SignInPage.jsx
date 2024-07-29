import React, { useContext, useEffect } from "react";
import "./SignInPage.css";
import { useNavigate } from "react-router-dom";
import success from "../../../assets/success.png";
import Cookies from "js-cookie";
import { AuthContext } from "../../Context/AuthContext";

const SignInPage = () => {
  const navigate = useNavigate();
  const { login } = useContext(AuthContext);

  useEffect(() => {
    const fetchToken = async () => {
      const queryParams = new URLSearchParams(window.location.search);
      const token = queryParams.get("token");

      if (token) {
        Cookies.set("token", token, {
          expires: 1,
          sameSite: "None",
          secure: true,
        });

        try {
          await login(token);
          setTimeout(() => {
            navigate("/");
          }, 2000);
        } catch (error) {
          console.error("Login failed:", error);
        }
      } else {
        console.error("Invalid response from Google");
      }
    };

    fetchToken();
  }, [navigate, login]);

  return (
    <div id="sign-in-page">
      <img src={success} alt="" />
      <p>Your login has been completed successfully</p>
    </div>
  );
};

export default SignInPage;
