import React, { useEffect } from "react";
import './SignInPage.css';
import { useNavigate } from 'react-router-dom'
import axios from "axios";

const SignInPage = () => {
    const history = useNavigate();

    useEffect(() => {
        const fetchToken = async () => {
            const queryParams = new URLSearchParams(window.location.search);
            const code = queryParams.get('code');
            const state = queryParams.get('state');
            const scope = queryParams.get('scope');
            const authuser = queryParams.get('authuser');
            const hd = queryParams.get('hd');
            const prompt = queryParams.get('prompt')

            if (code && state) {
                try {
                    console.log(code)
                    console.log(state)
                    console.log(scope)
                    console.log(authuser)
                    console.log(hd)
                    console.log(prompt)
                    console.log(`http://localhost:5144/api/v1/web/user/signin-google?code=${code}&state=${state}&scope=${scope}&authuser=${authuser}&hd=${hd}&prompt=${prompt}`)
                    const response = await axios.get(`http://localhost:5144/api/v1/web/user/signin-google?code=${code}&state=${state}&scope=${scope}&authuser=${authuser}&hd=${hd}&prompt=${prompt}`);
                    console.log(response.data)
                    const { token } = response.data;

                    // Store the token in local storage or cookies
                    localStorage.setItem('authToken', token);

                    // Redirect to the home page or dashboard
                    history('/');
                    console.error('Error fetching token', error);
                } catch {

                }
            } else {
                console.error('Invalid response from Google');
            }
        };

        fetchToken();
    }, [history]);

    return <div>Signing in with Google...</div>;
};

export default SignInPage;