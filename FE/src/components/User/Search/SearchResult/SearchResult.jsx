import React, { useEffect, useState } from "react";
import './SearchResult.css';
import { IoIosArrowDown } from "react-icons/io";
import { IoMdCheckmark } from "react-icons/io";
import user from '../../../../assets/user-avatar.jpg'
import { GoBookmark } from "react-icons/go";
import { BsBarChartLine } from "react-icons/bs";
import { IoVideocamOutline } from "react-icons/io5";
import { AiOutlineFieldTime } from "react-icons/ai";
import { TiStarOutline } from "react-icons/ti";
import { PiUserCircleFill } from "react-icons/pi";
import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import { formatTimeToHours } from "../../../../utils/Validation";

export default function SearchResult({ query, datas }) {
    useEffect(()=>{
        console.log(datas)
    },[datas])
    const [isDropDown, setIsDropDown] = useState(false)
    const [sortBy, setSortBy] = useState('Newest')

    const hanldeSortClick = (item) => {
        setSortBy(item)
        setIsDropDown(false)
    }
    const toggleDropdown = () => {
        setIsDropDown(!isDropDown);
    };

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
                {datas.map((data, index) => {
                    return (
                        <div className="result" key={index}>
                            <div className="img-container">
                                <img src={data.courseImg} className="background" alt="" />
                                <div className="owner">
                                    <img src={data.instructorImg} alt="" />
                                    <span>{data.instructorName}</span>
                                </div>
                                <div className="save-course-btn">
                                    <GoBookmark />
                                </div>
                            </div>
                            <div className="title">{data.courseName}</div>
                            <div className="info">
                                <div className="difficult tag"><BsBarChartLine /><span>{data.courseLevel}</span></div>
                                <div className="lecture tag"><IoVideocamOutline /><span>{data.lectureCount} Videos</span></div>
                                <div className="time tag"><AiOutlineFieldTime /><span>{formatTimeToHours(data.timeTotal)}</span></div>
                            </div>
                            <div className="rating-countS">
                                <div className="rating card"><TiStarOutline /> <span className="card-info">{data.ratingAVG}</span><span className="card-hint">({data.ratingCount})</span></div>
                                <div className="student card"><PiUserCircleFill /> <span className="card-info">{data.studentCount}</span><span className="card-hint">Students</span></div>
                            </div>
                            <div className="price-add">
                                <span className="price">$ {data.price}</span>
                                <div className="btn-contain">
                                    <Stack spacing={2} direction="row">
                                        <Button variant="contained" style={{ borderRadius: '10px', padding: '10px 20px' }}>Add To Cart</Button>
                                    </Stack>
                                </div>
                            </div>
                        </div>
                    )
                })}
            </div>
            <div className="pagination"></div>
        </div>
    );
}