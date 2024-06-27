import React, { useEffect, useState } from "react";
import './SearchBar.css';

import { IoIosSearch } from "react-icons/io";
import { useNavigate } from "react-router-dom";

export default function SearchBar({ query }) {
    const [valueInput, setValueInput] = useState(query)
    const navigate = useNavigate()

    useEffect(() => {
        setValueInput(query);
    }, [query]);

    const handleInputChange = (e) => {
        setValueInput(e.target.value);
        navigate(`/search?q=${e.target.value}`);
    };

    return (
        <div id="search-bar">
            <div className="search-icon">
                <IoIosSearch />
            </div>
            <div className="input-container">
                <input type="text" onChange={handleInputChange} value={valueInput} />
            </div>
        </div>
    )
}