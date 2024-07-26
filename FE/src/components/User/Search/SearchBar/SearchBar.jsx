import React, { useEffect, useState } from "react";
import './SearchBar.css';

import { IoIosSearch } from "react-icons/io";
import { useNavigate } from "react-router-dom";
import { IoIosArrowForward } from "react-icons/io";
import { ImCancelCircle } from "react-icons/im";
import Book from '../../../../assets/book.jpg';

export default function SearchBar({ query}) {
    const [valueInput, setValueInput] = useState(query)
    const navigate = useNavigate()

    useEffect(() => {
        setValueInput(query);
    }, [query]);

    const handleInputChange = (e) => {
        setValueInput(e.target.value);
        navigate(`/search?q=${e.target.value}&page=1`);
    };

    return (
        <div id="search-bar">
            <div className="introduce-bar">
                <img src={Book} alt="" />
                <div className="introduce-content">
                    <div className="nav-btn">
                        <span>Home</span>
                        <IoIosArrowForward />
                        <span className="search-btn">Search</span>
                    </div>
                    <p className="title">Courses</p>
                </div>
                <div className="search-container">
                    <div className="search-bar-item">
                        <div className="search-bar-border">
                            <IoIosSearch className="search-icon" />
                            <input type="text" value={valueInput} onChange={handleInputChange}/>
                            <ImCancelCircle className="cancel-icon" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}