import React, { useState } from "react";
import './FilterBar.css';
import { IoIosArrowDown } from "react-icons/io";
import MultiRangeSlider from "multi-range-slider-react";

export default function FilterBar() {
    const categoriesData = [
        { id: 1, name: "Back-end" },
        { id: 2, name: "Front-end" }
    ];

    const priceData = [
        { id: 1, name: "Free" },
        { id: 2, name: "Paid" }
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
        time: [],
        hardLevel: []
    });
    const [priceFilter, setPriceFilter] = useState(null);
    const [priceRange, setPriceRange] = useState({ min: 1, max: 200 });

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

    const handlePriceChange = (value) => {
        setPriceFilter(priceFilter === value ? null : value);
    };

    const renderSelectedFilters = () => {
        const filters = [
            ...Object.keys(selectedFilters).flatMap(section =>
                selectedFilters[section].map(filter => ({ section, filter }))
            ),
            ...(priceFilter ? [{
                section: 'price',
                filter: priceFilter === 'Free' ? 'Free' : `Paid: $${priceRange.min} - $${priceRange.max}`
            }] : [])
        ];

        return filters.map(({ section, filter }) => (
            <div key={`${section}-${filter}`} className="selected-filter">
                {filter}
                <button onClick={() => section === 'price' ? handlePriceChange(null) : handleCheckboxChange(section, filter)}>x</button>
            </div>
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
                                checked={selectedFilters[section]?.includes(item.name)}
                                onChange={() => handleCheckboxChange(section, item.name)}
                            /> {item.name}
                        </label>
                    </li>
                ))}
            </ul>
        );
    };

    const renderPriceOptions = () => {
        return (
            <ul className="sub-options">
                {priceData.map(item => (
                    <li key={item.id}>
                        <label>
                            <input
                                type="radio"
                                value={item.name}
                                checked={priceFilter === item.name}
                                onChange={() => handlePriceChange(item.name)}
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
                    {renderPriceOptions()}
                    {priceFilter === "Paid" && (
                        <>
                            <MultiRangeSlider
                                label={false}
                                ruler={false}
                                style={{ border: 'none', boxShadow: 'none' }}
                                min={1}
                                max={200}
                                step={1}
                                minValue={priceRange.min}
                                maxValue={priceRange.max}
                                onChange={(e) => setPriceRange({ min: e.minValue, max: e.maxValue })}
                                data-min="1"
                                data-max="200"
                            />
                            <div className="price-display">
                                <div className="price-min">
                                    <p className="price-name">Min:&ensp;</p>
                                    <p className="price-value">{priceRange.min}&nbsp;$</p>
                                </div>
                                <div className="price-max">
                                    <p className="price-name">Max:&ensp;</p>
                                    <p className="price-value">{priceRange.max}&nbsp;$</p>
                                </div>
                            </div>
                        </>
                    )}
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