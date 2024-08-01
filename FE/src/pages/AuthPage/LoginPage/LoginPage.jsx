import React, { useContext, useEffect, useState } from "react";
import "./LoginPage.css";
import Header from "../../../components/Items/Header/Header";

import Logo_White from "../../../assets/Logo_White.png";
import { FaUser } from "react-icons/fa";
import { RiLockPasswordFill } from "react-icons/ri";
import FormGroup from "@mui/material/FormGroup";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
import { FaGoogle } from "react-icons/fa";
import { AuthContext } from "../../Context/AuthContext";
import ApiService from "../../../api/ApiService";
import Cookies from "js-cookie";
import { useNavigate } from "react-router-dom";
import LoadingOverlay from "../../../components/LoadingOverlay";

export default function LoginPage() {
  const { checkLogin } = useContext(AuthContext);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [isLoading, setIsLoading] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    document.body.classList.add("no-scroll");
  }, []);

  const handleLogInBtn = async () => {
    setIsLoading(true);
    try {
      const response = await checkLogin(email, password);

      if (response.token) {
        Cookies.set("token", response.token, {
          expires: 1,
          sameSite: "None",
          secure: true,
        });
        navigate(`/sign-in?token=${response.token}`);
      } else {
        navigate("/error");
      }
    } catch (error) {
      console.error("Login failed:", error);
      navigate("/error");
    } finally {
      setIsLoading(false);
    }
  };

  const handleGoogleLogin = async () => {
    const data = await ApiService.LoginGoogle();
    window.location.href = data.returnAuthUrl;
  };
  return (
    <div id="log-in">
      {isLoading ? (
        <LoadingOverlay loading={isLoading} />
      ) : (
        <>
          <Header />
          <div className="log-in-container">
            <img src={Logo_White} alt="" className="logo" />
            <p className="title">Account Login</p>
            <div className="login-form">
              <div className="email bar">
                <div className="logo-container">
                  <FaUser />
                </div>
                <input
                  type="text"
                  value={email}
                  placeholder="Username or Email address"
                  onChange={(e) => setEmail(e.target.value)}
                />
              </div>
              <div className="password bar">
                <div className="logo-container">
                  <RiLockPasswordFill />
                </div>
                <input
                  type="password"
                  value={password}
                  placeholder="Password"
                  onChange={(e) => setPassword(e.target.value)}
                />
              </div>
              <div className="action-btn">
                <FormGroup>
                  <FormControlLabel
                    control={<Checkbox defaultChecked />}
                    label="Remember me?"
                  />
                </FormGroup>
                <div className="forgot-password-container">
                  <span>Forgot password?</span>
                </div>
              </div>
              <div className="login-btn" onClick={handleLogInBtn}>
                Log In
              </div>
              <div className="or-title">
                <span>or</span>
              </div>
              <div className="facebook-google">
                <div className="google btn" onClick={handleGoogleLogin}>
                  <FaGoogle />
                </div>
              </div>
              <div className="ask-cr">
                <span className="title-ask">Don't have an account?</span>
                <span className="sign-up-btn">Sign Up</span>
              </div>
            </div>
          </div>
        </>
      )}
    </div>
  );
}
