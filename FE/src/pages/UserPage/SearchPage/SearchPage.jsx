import React from "react";
import './SearchPage.css';

import SearchBar from "../../../components/User/Search/SearchBar/SearchBar";
import FilterBar from "../../../components/User/Search/FilterBar/FilterBar";
import SearchResult from "../../../components/User/Search/SearchResult/SearchResult";
import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";

export default function SearchPage() {
    return (
        <div id="search-page">
            <Header />
            <div className="search-page-container">
                <SearchBar />
                <div className="filter-result">
                    <div className="filter-container">
                        <FilterBar />
                    </div>
                    <div className="result-container">
                        <SearchResult />
                    </div>
                </div>
            </div>
            <Footer />
            
        </div>
    )
}