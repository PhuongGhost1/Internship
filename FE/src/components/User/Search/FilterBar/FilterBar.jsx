import React, { useState } from "react";
import './FilterBar.css';
import { IoFilter } from "react-icons/io5";
import { IoIosArrowDown } from "react-icons/io";

export default function FilterBar() {
    return (
        <div id="filter-bar">
            <div className="filter-title">
                <IoFilter />
                <span>Filter</span>
            </div>
            <div className="category-container">
                <div className="title">
                    <span>Categories</span>
                    <div className="action-container">
                        <IoIosArrowDown />
                    </div>
                    <div className="dropdown-container">

                    </div>
                </div>
            </div>
        </div>
    )
}
