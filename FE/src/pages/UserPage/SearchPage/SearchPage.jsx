import React, { useEffect, useState, useCallback, useContext } from "react";
import './SearchPage.css';

import SearchBar from "../../../components/User/Search/SearchBar/SearchBar";
import FilterBar from "../../../components/User/Search/FilterBar/FilterBar";
import SearchResult from "../../../components/User/Search/SearchResult/SearchResult";
import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";
import { useLocation, useNavigate } from 'react-router-dom';
import ApiService from "../../../api/ApiService";
import { AuthContext } from "../../Context/AuthContext";


export default function SearchPage() {
    let query = new URLSearchParams(useLocation().search);
    let q = query.get("q");
    let page = query.get("page")

    const { user } = useContext(AuthContext)

    const [categories, setCategories] = useState([]);
    const [selectedCategories, setSelectedCategories] = useState([])
    const [datas, setDatas] = useState([])
    const navigation = useNavigate()

    useEffect(() => {
        fetchCategories()
    }, [])

    const fetchCategories = async () => {
        const data = await ApiService.GetCategories();
        setCategories(data);
    }

    const handleSelectedCategories = useCallback((categoryId) => {
        setSelectedCategories(prev =>
            prev.includes(categoryId)
                ? prev.filter(id => id !== categoryId)
                : [...prev, categoryId]
        );
    }, []);

    const [value, setValue] = useState([0, 300]);

    const [ratingSelected, setRatingSelected] = useState(
        [
            {
                starCount: 5,
                isSelected: false,
            },
            {
                starCount: 4,
                isSelected: false,
            },
            {
                starCount: 3,
                isSelected: false,
            },
            {
                starCount: 2,
                isSelected: false,
            },
            {
                starCount: 1,
                isSelected: false,
            },
        ]
    )

    const hanldeRatingSelected = (starCount) => {
        setRatingSelected(prev => prev.map((rating, index) => {
            if (rating.starCount == starCount) {
                return {
                    ...rating,
                    isSelected: !rating.isSelected
                }
            }
            return rating
        }))
    }

    const [difficultSelected, setDifficultSelected] = useState(
        [
            {
                name: 'Beginner',
                isSelected: false,
            },
            {
                name: 'Intermediate',
                isSelected: false,
            },
            {
                name: 'Advanced',
                isSelected: false,
            },
        ]
    )

    const hanldeDifficultClick = (index) => {
        setDifficultSelected(prev => {
            return prev.map((item, i) => {
                if (i === index) {
                    return {
                        ...item,
                        isSelected: !item.isSelected
                    }
                }
                return item
            })
        })
    }

    useEffect(() => {
        let userId = null;
        if (user) {
            userId = user.id
        }
        fetchSearchFilter(page, 9, q
            , selectedCategories, value, ratingSelected, difficultSelected, userId
        );
    }, [page, q, selectedCategories, value, ratingSelected, difficultSelected, user])

    const fetchSearchFilter = async (page, items
        , query, categories, priceRange, ratings, levels, userId
    ) => {
        const data = await ApiService.SearchFilter(page, items
            , query, categories, priceRange, ratings, levels, userId
        )
        setDatas(data)
    }

    return (
        <div id="search-page">
            <Header />
            <div className="search-page-container">
                <SearchBar 
                    query={q} 
                    handleInputSearch />
                <div className="filter-result">
                    <div className="filter-container">
                        <FilterBar
                            categories={categories}
                            handleSelectedCategories={handleSelectedCategories}
                            selectedCategories={selectedCategories}
                            value={value}
                            setValue={setValue}
                            ratingSelected={ratingSelected}
                            hanldeRatingSelected={hanldeRatingSelected}
                            difficultSelected={difficultSelected}
                            hanldeDifficultClick={hanldeDifficultClick} />
                    </div>
                    <div className="result-container">
                        <SearchResult query={q} datas={datas} />
                    </div>
                </div>
            </div>
            <Footer />
        </div>
    )
}