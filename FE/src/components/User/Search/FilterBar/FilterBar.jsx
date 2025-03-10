import React, { useState } from "react";
import './FilterBar.css';
import { IoFilter } from "react-icons/io5";
import { IoIosArrowDown } from "react-icons/io";
import Checkbox from '@mui/material/Checkbox';
import Box from '@mui/material/Box';
import Slider from '@mui/material/Slider';
import Rating from '@mui/material/Rating';
import { FaCircleCheck } from "react-icons/fa6";

export default function FilterBar({ categories,
    handleSelectedCategories,
    selectedCategories,
    value,
    setValue,
    ratingSelected,
    hanldeRatingSelected,
    difficultSelected,
    hanldeDifficultClick }) {
    const [openDropdowns, setOpenDropdowns] = useState({
        categorycontainer: false,
        pricerangecontainer: false,
        ratingcontainer: false,
        difficultcontainer: false
    });

    function removeHyphens(str) {
        return str.replace(/-/g, '');
    }

    const handleChange = (event, newValue) => {
        setValue(newValue);
    };

    const handleDropdownClick = (target) => () => {
        const progress = document.querySelector(`#filter-bar .${target} .items`);
        if (progress) {
            progress.classList.toggle('active');
        }
        const newTarget = removeHyphens(target)
        setOpenDropdowns((prev) => ({
            ...prev,
            [newTarget]: !prev[newTarget]
        }));
    };

    return (
        <div id="filter-bar">
            <div className="filter-title">
                <IoFilter />
                <span>Filter</span>
            </div>
            <div className="category-container block">
                <div className="title">
                    <span>Categories</span>
                    <div className="action-container ">
                        <IoIosArrowDown onClick={handleDropdownClick('category-container')} className={openDropdowns.categorycontainer ? 'rotated' : ''} />
                    </div>
                </div>
                <div className="dropdown-container">
                    <div className="categories items">
                        {categories.map((data, index) => {
                            return (
                                <div className="category item" key={index}>
                                    <Checkbox
                                        checked={selectedCategories.includes(data.id)}
                                        onChange={() => { handleSelectedCategories(data.id) }}
                                        inputProps={{ 'aria-label': 'controlled' }}
                                    />
                                    <span className="data-name">{data.name}</span>
                                </div>
                            )
                        })}
                    </div>
                </div>
            </div>
            <div className="price-range-container block">
                <div className="title">
                    <span>Price Range</span>
                    <div className="action-container ">
                        <IoIosArrowDown onClick={handleDropdownClick('price-range-container')} className={openDropdowns.pricerangecontainer ? 'rotated' : ''} />
                    </div>
                </div>
                <div className="dropdown-container">
                    <div className="price items">
                        <Box sx={{ width: '100%' }}>
                            <Slider
                                getAriaLabel={() => 'Temperature range'}
                                value={value}
                                onChange={handleChange}
                                valueLabelDisplay="auto"
                                min={0}
                                max={300}
                            />
                        </Box>
                        <div className="price-show">
                            <div className="min-container">
                                <span>$ {value[0]}</span>
                            </div>
                            <div className="connect">
                            </div>
                            <div className="max-container">
                                <span>$ {value[1]}</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="rating-container block">
                <div className="title">
                    <span>Customers Rating</span>
                    <div className="action-container ">
                        <IoIosArrowDown onClick={handleDropdownClick('rating-container')} className={openDropdowns.ratingcontainer ? 'rotated' : ''} />
                    </div>
                </div>
                <div className="dropdown-container">
                    <div className="ratings items">
                        {ratingSelected.map((data, index) => {
                            return (
                                <div className="rating item">
                                    <Checkbox
                                        checked={data.isSelected}
                                        onChange={() => { hanldeRatingSelected(data.starCount) }}
                                        inputProps={{ 'aria-label': 'controlled' }}
                                    />
                                    <Box
                                        sx={{
                                            '& > legend': { mt: 2 },
                                        }}
                                    >
                                        <Rating name="read-only" value={data.starCount} readOnly />
                                    </Box>
                                </div>
                            )
                        })}
                    </div>
                </div>
            </div>
            <div className="difficult-container block">
                <div className="title">
                    <span>Difficult Level</span>
                    <div className="action-container ">
                        <IoIosArrowDown onClick={handleDropdownClick('difficult-container')} className={openDropdowns.difficultcontainer ? 'rotated' : ''} />
                    </div>
                </div>
                <div className="dropdown-container">
                    <div className="difficults items">
                        <div className="block-height-difficults">
                            {difficultSelected.map((data, index) => {
                                return (
                                    <div className={`difficult item ${data.isSelected ? 'selected' : ''}`} onClick={() => { hanldeDifficultClick(index) }}>
                                        <span className="name">{data.name}</span>
                                        {data.isSelected && (
                                            <div className="icon-tick">
                                                <FaCircleCheck />
                                            </div>
                                        )}
                                    </div>
                                )
                            })}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}