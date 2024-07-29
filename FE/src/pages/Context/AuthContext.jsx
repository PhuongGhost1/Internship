import React, { createContext, useEffect, useState } from "react";
import Cookies from "js-cookie";
import ApiService from "../../api/ApiService";
import LoadingOverlay from "../../components/LoadingOverlay";

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const fetchUser = async () => {
      const token = Cookies.get("token");
      if (token) {
        try {
          login(token).finally(() => {
            setIsLoading(false);
          });
        } catch (error) {
          console.error("Login failed:", error);
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
    const response = await ApiService.checkLogin(email, password);
    return response;
  };
  return (
    <AuthContext.Provider value={{ user, checkLogin }}>
      {isLoading ? <LoadingOverlay loading={isLoading} /> : children}
    </AuthContext.Provider>
  );
};

export { AuthProvider, AuthContext };
