import React, { useState } from "react";
import './SearchResult.css';
import { IoIosArrowDown } from "react-icons/io";
import { IoMdCheckmark } from "react-icons/io";

export default function SearchResult({ query }) {
    const datas = [
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/5e360aa2986a2a96295b34d639919836c323cbb6-1200x900.jpg?w=3840&q=100&fit=clip&auto=format",
            name: "Blockchain Developer",
            ratingAVG: 4.5,
            ratingCount: 2003,
            timeLearing: "7 hours 43 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/b122bbb8302858740db71ef43ad17f7097ec7b63-1200x900.jpg?w=3840&q=100&fit=clip&auto=format",
            name: "Blockchain With Solidity",
            ratingAVG: 4.5,
            ratingCount: 2003,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/180434427a41505e6661e4bee15580f296730630-1200x900.jpg?w=3840&q=100&fit=clip&auto=format",
            name: "Blockchain Fundamental",
            ratingAVG: 4.5,
            ratingCount: 279,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },

        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },

        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },

        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },

        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },

        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
        {
            imgUrl: "https://cdn.sanity.io/images/tlr8oxjg/production/882dcf032f8e9ab350c82a8f70acdfcbd2cbb839-1200x750.png?w=3840&q=100&fit=clip&auto=format",
            name: "Discovering Ethical AI",
            ratingAVG: 4.5,
            ratingCount: 1789,
            timeLearing: "8 hours 45 minutes"
        },
    ]
    const [isDropDown, setIsDropDown] = useState(false)
    const [sortBy, setSortBy] = useState('Newest')

    const hanldeSortClick = (item) => {
        setSortBy(item)
        setIsDropDown(false)
    }
    const toggleDropdown = () => {
        setIsDropDown(!isDropDown);
    };

    const itemsPerPage = 9;

    const [pagination, setPagination] = useState(1);

    const paginatedData = datas.slice((pagination - 1) * itemsPerPage, pagination * itemsPerPage);

    return (
        <div id="search-result">
            <div className="sort-info">
                <div className="info">
                    <p className="total-course">{datas.length} "{query}" course found</p>
                    <p className="course-show-current">Showing results of {datas.length}</p>
                </div>
                <div className="sort">
                    <div className="sort-contain">
                        <p className="title">Sort by:</p>
                        <div className="sort-base" onClick={toggleDropdown}>
                            <p className="sort-by">{sortBy}</p>
                            <div className="icon-contain">
                                <IoIosArrowDown />
                            </div>
                            <div className="sort-dropdown" style={isDropDown ? {} : { display: 'none' }}>
                                <div className="new block" onClick={() => { hanldeSortClick('Newest') }}>
                                    Newest
                                    <div className="icon-contain" style={sortBy === 'Newest' ? {} : { display: 'none' }}>
                                        <IoMdCheckmark />
                                    </div>
                                </div>
                                <div className="old block" onClick={() => { hanldeSortClick('Oldest') }}>
                                    Oldest
                                    <div className="icon-contain" style={sortBy === 'Oldest' ? {} : { display: 'none' }}>
                                        <IoMdCheckmark />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="results">
                {paginatedData.map((data, index) => {
                    return (
                        <div className="result" key={index}>
                            <img src="" alt="" />
                        </div>
                    )
                })}
            </div>
            <div className="pagination"></div>
        </div>
    );
}