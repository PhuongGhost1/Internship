import { useEffect } from "react";
import "./LoginPage.css";
import Header from "../../../components/Header/Header";

import Logo_White from "../../../assets/Logo_White.png";
import { FaUser } from "react-icons/fa";
import { RiLockPasswordFill } from "react-icons/ri";
import FormGroup from "@mui/material/FormGroup";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
import { TiSocialFacebook } from "react-icons/ti";
import { FaGoogle } from "react-icons/fa";

export default function LoginPage() {
  useEffect(() => {
    document.body.classList.add("no-scroll");
  }, []);

  const handleGoogleLogin = () => {
    window.location.href = "http://localhost:5144/User/login-google";
  };

  const handleFacebookLogin = () => {
    window.location.href = "http://localhost:5144/User/login-facebook";
  };

  return (
    <div id="log-in">
      <Header />
      <div className="log-in-container">
        <img src={Logo_White} alt="" className="logo" />
        <p className="title">Account Login</p>
        <div className="login-form">
          <div className="email bar">
            <div className="logo-container">
              <FaUser />
            </div>
            <input type="text" placeholder="Username or Email address" />
          </div>
          <div className="password bar">
            <div className="logo-container">
              <RiLockPasswordFill />
            </div>
            <input type="password" placeholder="Password" />
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
          <div className="login-btn">Log In</div>
          <div className="or-title">
            <span>or</span>
          </div>
          <div className="facebook-google">
            <div className="google btn" onClick={handleGoogleLogin}>
              <FaGoogle />
            </div>
            <div className="facebook btn" onClick={handleFacebookLogin}>
              <TiSocialFacebook />
            </div>
          </div>
          <div className="ask-cr">
            <span className="title-ask">Dont have account?</span>
            <span className="sign-up-btn">Sign Up</span>
          </div>
        </div>
      </div>
    </div>
  );
}
