import React from "react";
import ClipLoader from "react-spinners/ClipLoader";
import PropTypes from "prop-types";
import "./LoadingOverlay.css";

function LoadingOverlay({ loading }) {
    if (!loading) return null;

    return (
        <div className="loading-overlay">
            <ClipLoader color="#00BFFF" loading={loading} size={50} />
        </div>
    );
}

LoadingOverlay.propTypes = {
    loading: PropTypes.bool.isRequired,
};

export default LoadingOverlay;
