import React, { useEffect, useState } from "react";
import "./CategoryPage.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import Category from "../../../components/Admin/Category/Category";
import LoadingOverlay from "../../../components/LoadingOverlay";

export default function CategoryPage() {
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const timeLoading = () => {
      setTimeout(() => {
        setLoading(false);
      }, 3000);
    };

    timeLoading();
  }, []);
  return (
    <div id="CategoryPage">
      <LoadingOverlay loading={loading} />
      <div className="Header-Admin">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type="category" />
        </div>
        <div className="Category-container">
          <Category />
        </div>
      </div>
    </div>
  );
}
