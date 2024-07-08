import React, { useState } from "react";
import './SearchResult.css';
import Card from "../../../Items/Card/Card";

export default function SearchResult() {
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

    const [currentPage, setCurrentPage] = useState(1);
    const itemsPerPage = 15;

    const indexOfLastItem = currentPage * itemsPerPage;

    const indexOfFirstItem = indexOfLastItem - itemsPerPage;

    const currentItems = datas.slice(indexOfFirstItem, indexOfLastItem);


    const totalPages = Math.ceil(datas.length / itemsPerPage);

    const pageNumbers = [];
    for (let i = 1; i <= totalPages; i++) {
        pageNumbers.push(i);
    }

    return (
        <div>
            <div id="search-cards">
                {currentItems.map((data, index) => (
                    <Card data={data} key={index} />
                ))}
            </div>
            <div className="pagination">
                <button
                    onClick={() => setCurrentPage(prev => Math.max(prev - 1, 1))}
                    disabled={currentPage === 1}
                >
                    Previous
                </button>
                {pageNumbers.map(number => (
                    <button
                        key={number}
                        onClick={() => setCurrentPage(number)}
                        className={currentPage === number ? "active" : ""}
                    >
                        {number}
                    </button>
                ))}
                <button
                    onClick={() => setCurrentPage(prev => Math.min(prev + 1, totalPages))}
                    disabled={currentPage === totalPages}
                >
                    Next
                </button>
            </div>
        </div>
    );
}