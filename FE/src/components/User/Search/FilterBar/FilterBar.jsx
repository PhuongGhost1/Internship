import React, { useState } from "react";
import './FilterBar.css';
import { IoIosArrowDown } from "react-icons/io";

export default function FilterBar() {
    const categoriesData = [
        { id: 1, name: "Back-end" },
        { id: 2, name: "Front-end" }
    ];

    const priceData = [
        { id: 1, name: "Low" },
        { id: 2, name: "Medium" },
        { id: 3, name: "High" }
    ];

    const timeData = [
        { id: 1, name: "Short" },
        { id: 2, name: "Medium" },
        { id: 3, name: "Long" }
    ];

    const hardLevelData = [
        { id: 1, name: "Easy" },
        { id: 2, name: "Intermediate" },
        { id: 3, name: "Advanced" }
    ];

    const [openSection, setOpenSection] = useState(null);
    const [selectedFilters, setSelectedFilters] = useState({
        categories: [],
        price: [],
        time: [],
        hardLevel: []
    });

    const toggleSection = (section) => {
        setOpenSection(openSection === section ? null : section);
    };

    const handleCheckboxChange = (section, value) => {
        setSelectedFilters(prevState => {
            const sectionFilters = prevState[section];
            if (sectionFilters.includes(value)) {
                return {
                    ...prevState,
                    [section]: sectionFilters.filter(item => item !== value)
                };
            } else {
                return {
                    ...prevState,
                    [section]: [...sectionFilters, value]
                };
            }
        });
    };

    const renderSelectedFilters = () => {
        return Object.keys(selectedFilters).map(section => (
            selectedFilters[section].map(filter => (
                <div key={`${section}-${filter}`} className="selected-filter">
                    {filter} <button onClick={() => handleCheckboxChange(section, filter)}>x</button>
                </div>
            ))
        ));
    };

    const renderOptions = (data, section) => {
        return (
            <ul className="sub-options">
                {data.map(item => (
                    <li key={item.id}>
                        <label>
                            <input
                                type="checkbox"
                                value={item.name}
                                checked={selectedFilters[section].includes(item.name)}
                                onChange={() => handleCheckboxChange(section, item.name)}
                            /> {item.name}
                        </label>
                    </li>
                ))}
            </ul>
        );
    };

    return (
        <div id="filter-bar">
            <div className="selected-filters">
                {renderSelectedFilters()}
            </div>

            <div className="filter-item">
                <div className="filter-btn-container">
                    <a className="filter-text">Categories</a>
                    <button
                        className={`filter-button ${openSection === 'categories' ? 'active' : ''}`}
                        onClick={() => toggleSection('categories')}><IoIosArrowDown />
                    </button>
                </div>
                <div className={`sub-options-container ${openSection === 'categories' ? 'open' : ''}`}>
                    {renderOptions(categoriesData, 'categories')}
                </div>
            </div>

            <div className="filter-item">
                <div className="filter-btn-container">
                    <a className="filter-text">Price</a>
                    <button
                        className={`filter-button ${openSection === 'price' ? 'active' : ''}`}
                        onClick={() => toggleSection('price')}><IoIosArrowDown />
                    </button>
                </div>
                <div className={`sub-options-container ${openSection === 'price' ? 'open' : ''}`}>
                    {renderOptions(priceData, 'price')}
                </div>
            </div>

            <div className="filter-item">
                <div className="filter-btn-container">
                    <a className="filter-text">Time</a>
                    <button
                        className={`filter-button ${openSection === 'time' ? 'active' : ''}`}
                        onClick={() => toggleSection('time')}><IoIosArrowDown />
                    </button>
                </div>
                <div className={`sub-options-container ${openSection === 'time' ? 'open' : ''}`}>
                    {renderOptions(timeData, 'time')}
                </div>
            </div>

            <div className="filter-item">
                <div className="filter-btn-container">
                    <a className="filter-text">Hard Level</a>
                    <button
                        className={`filter-button ${openSection === 'hardLevel' ? 'active' : ''}`}
                        onClick={() => toggleSection('hardLevel')}><IoIosArrowDown />
                    </button>
                </div>
                <div className={`sub-options-container ${openSection === 'hardLevel' ? 'open' : ''}`}>
                    {renderOptions(hardLevelData, 'hardLevel')}
                </div>
            </div>
        </div>
    );
}
