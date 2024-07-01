import React, { useEffect } from "react";
import './SearchPage.css';

import SearchBar from "../../../components/User/Search/SearchBar/SearchBar";
import FilterBar from "../../../components/User/Search/FilterBar/FilterBar";
import SearchResult from "../../../components/User/Search/SearchResult/SearchResult";
import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";
import { useLocation } from 'react-router-dom';


export default function SearchPage() {
    let query = new URLSearchParams(useLocation().search);
    let q = query.get("q");

    return (
        <div id="search-page">
            <Header />
            <div className="search-page-container">
                <div className="filter-result">
                    <div className="filter-container">
                        <FilterBar />
                    </div>
                    <div className="result-container">
                        <SearchBar query={q} />
                        <SearchResult />
                    </div>
                </div>
            </div>
            <Footer />
        </div>
    )
}