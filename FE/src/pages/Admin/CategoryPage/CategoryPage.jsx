import React from "react";
import './CategoryPage.css';
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import Category from "../../../components/Admin/Category/Category";


export default function CategoryPage() {
     return (
          <div id="CategoryPage">
               <div className="Header-Admin">
                    <Header />
               </div>
               <div className="Layout">
                    <div className="SideBar-container">
                         <SideBar type='category' />
                    </div>
                    <div className="Category-container">
                         <div className="Category-container">
                              <Category />
                         </div>
                    </div>
               </div>
          </div>
     );
}
