import React, { useEffect } from "react";
import "./SignInPage.css";
import { useNavigate } from "react-router-dom";
import success from '../../../assets/success.png'
import Cookies from 'js-cookie';

const SignInPage = () => {
  const navigate = useNavigate();

  useEffect(() => {
    const fetchToken = async () => {
      const queryParams = new URLSearchParams(window.location.search);
      const token = queryParams.get('token')

      if (token) {
        Cookies.set('token', token, { expires: 1, sameSite: 'None', secure: true });
        setTimeout(() => {
          navigate('/');
        }, 2000);
      } else {
        console.error('Invalid response from Google');
      }
    };

    fetchToken();
  }, [history]);

  return (
    <div id="sign-in-page">
      <img src={success} alt="" />
      <p>Your login has been completed successfully</p>
    </div>
  );
};

export default SignInPage;
