import React, { createContext, useEffect, useState } from "react";
import Cookies from 'js-cookie';
import ApiService from "../../api/ApiService";

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null)
    useEffect(() => {
        const token = Cookies.get('token');
        if (token) {
            login(token);
        }
    }, []);
    const login = async (token) => {
        const response = await ApiService.login(token);
        setUser(response)
    }
    const checkLogin = async (email, password) => {
        const response = await ApiService.checkLogin(email, password)
        return response
    }
    const userRole = async (userId) => {
        const response = await ApiService.GetUserRole(userId)
        return response.name
    }
    return (
        <AuthContext.Provider value={{ user, checkLogin, userRole }}>
            {children}
        </AuthContext.Provider>
    )
}

export { AuthProvider, AuthContext };