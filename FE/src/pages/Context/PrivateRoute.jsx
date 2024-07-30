import React, { useContext } from "react";
import { Navigate } from "react-router-dom";
import { AuthContext } from "./AuthContext";
import PropTypes from "prop-types";

const PrivateRoute = ({ element, roles: requiredRoles }) => {
  const { user, roles } = useContext(AuthContext);

  if (!user) {
    return <Navigate to="/login" />;
  }

  if (!requiredRoles?.some((role) => roles?.includes(role))) {
    return <Navigate to="/login" />;
  }

  return element;
};

PrivateRoute.propTypes = {
  element: PropTypes.element.isRequired,
  roles: PropTypes.arrayOf(PropTypes.string).isRequired,
};

export default PrivateRoute;
