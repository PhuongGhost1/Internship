import React, { createContext, useEffect, useState } from "react";
import Cookies from "js-cookie";
import ApiService from "../../api/ApiService";
import LoadingOverlay from "../../components/LoadingOverlay";

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const [roles, setRoles] = useState([]);

  useEffect(() => {
    const fetchUser = async () => {
      const token = Cookies.get("token");
      if (token) {
        try {
          const response = await ApiService.login(token);
          setUser(response);
          const userRoles = await ApiService.RolePermissions(response.id);
          setRoles(userRoles);
        } catch (error) {
          console.error("Login failed:", error);
        } finally {
          setIsLoading(false);
        }
      } else {
        setIsLoading(false);
      }
    };

    fetchUser();
  }, []);

  const login = async (token) => {
    try {
      const response = await ApiService.login(token);
      setUser(response);
    } catch (error) {
      console.error("Login failed:", error);
    }
  };

  const checkLogin = async (email, password) => {
    try {
      const response = await ApiService.checkLogin(email, password);
      return response;
    } catch (error) {
      console.error("Check login failed:", error);
      throw error;
    }
  };

  return (
    <AuthContext.Provider value={{ user, checkLogin, login, roles }}>
      {isLoading ? <LoadingOverlay loading={isLoading} /> : children}
    </AuthContext.Provider>
  );
};

export { AuthProvider, AuthContext };
