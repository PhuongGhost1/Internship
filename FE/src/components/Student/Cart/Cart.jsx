import React, { useState, useEffect } from "react";
import './Cart.css';
import HtmlCss from '../../../assets/Html-Title.png';

import Box from '@mui/material/Box';
import Rating from '@mui/material/Rating';
import Checkbox from '@mui/material/Checkbox';
import FormControlLabel from '@mui/material/FormControlLabel';

import { MdPayments } from "react-icons/md";
import { MdOutlineDeleteForever } from "react-icons/md";

import user from '../../../../src/assets/user-avatar.jpg'
import { GoBookmark } from 'react-icons/go';
import { BsBarChartLine } from 'react-icons/bs';
import { IoVideocamOutline } from 'react-icons/io5';
import { AiOutlineFieldTime } from 'react-icons/ai';
import { TiStarOutline } from 'react-icons/ti';
import { PiUserCircleFill } from 'react-icons/pi';
import { Button, Stack } from '@mui/material';


export default function Cart() {

    // const [pagination, setPagination] = useState(1);
    // const paginatedData = datas.slice((pagination - 1) * itemsPerPage, pagination * itemsPerPage);

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
    const itemsPerPage = 4;

    const [pagination, setPagination] = useState(1);

    const paginatedData = datas.slice((pagination - 1) * itemsPerPage, pagination * itemsPerPage);

    const [checkedItems, setCheckedItems] = useState({
        all: false,
        item1: false,
        item2: false,
        item3: false,
        item4: false,
        item5: false,
        item6: false,
    });

    const [total, setTotal] = useState(0);

    const itemPrices = {
        item1: 499999,
        item2: 499999,
        item3: 499999,
        item4: 499999,
        item5: 499999,
        item6: 500000,
    };

    const handleAllChange = (event) => {
        const { checked } = event.target;
        setCheckedItems({
            all: checked,
            item1: checked,
            item2: checked,
            item3: checked,
            item4: checked,
            item5: checked,
            item6: checked,
        });
    };

    const handleItemChange = (event) => {
        const { name, checked } = event.target;
        setCheckedItems((prevState) => ({
            ...prevState,
            [name]: checked,
            all: checkedItems.all && checked,
        }));
    };

    useEffect(() => {
        const newTotal = Object.keys(checkedItems).reduce((sum, item) => {
            if (item !== 'all' && checkedItems[item]) {
                return sum + itemPrices[item];
            }
            return sum;
        }, 0);
        setTotal(newTotal);
    }, [checkedItems]);

    const items = ["item1", "item2", "item3", "item4", "item5", "item6"];

    return (
        <div id="Cart">
            <div className="display-cart">
                <div className="text-container">
                    <h2>
                        Shopping Cart Checkout
                    </h2>
                </div>

                <div className="container">
                    <div className="container1">
                        <Box>
                            <FormControlLabel
                                control={<Checkbox checked={checkedItems.all} onChange={handleAllChange} />}
                                label="All"
                            />
                        </Box>
                        {items.map((item, index) => (
                            <div key={index} className="container1-row">
                                <div className="container1-row1">
                                    <hr />
                                    <Box display="flex" justifyContent="center" alignItems="center" width="100%" height="80px">
                                        <Checkbox
                                            name={item}
                                            checked={checkedItems[item]}
                                            onChange={handleItemChange}
                                        />
                                    </Box>
                                </div>
                                <div className="container1-row2">
                                    <hr />
                                    <div className="column">
                                        <div className="cover-img-course">
                                            <img src={HtmlCss} alt="Avatar" className="avatar" />
                                        </div>
                                        <div className="course-container">
                                            <div className="course-title">
                                                <h2>HTML, CSS from Zero to Hero</h2>
                                            </div>
                                            <div className="course-of-instructor">
                                                <h2>Nguyen Manh Duy</h2>
                                            </div>
                                            <Box sx={{ '& > legend': { mt: 2 } }}>
                                                <Rating name="read-only" value={3} readOnly />
                                            </Box>
                                        </div>
                                        <div className="total-container">
                                            <div className="total-container-fix">
                                                <h3>đ</h3>
                                                <h2>{itemPrices[item].toLocaleString()}</h2>
                                            </div>
                                            <div className="button-delete-container">
                                                <div className="icon-bt">
                                                    <MdOutlineDeleteForever size={20} />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        ))}
                    </div>
                    <div className="container2">
                        <div className="container-total">
                            <div className="column1">
                                <h2>Total:</h2>
                            </div>

                            <div className="column2">
                                <h3>đ</h3>
                                <h2>{total.toLocaleString()}</h2>
                            </div>

                            <div className="column3">
                                <div className="pay-bt">
                                    <div className="icon">
                                        <MdPayments size={20} />
                                    </div>

                                    <div className="text">
                                        <h2>Pay</h2>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div className="text2-container">
                    <h2>
                        You might also like
                    </h2>
                </div>

                <div className="results">
                    {paginatedData.map((data, index) => {
                        return (
                            <div className="result" key={index}>
                                <div className="img-container">
                                    <img src={data.imgUrl} className="background" alt="" />
                                    <div className="owner">
                                        <img src={user} alt="" />
                                        <span>Nguyễn Mạnh Duy</span>
                                    </div>
                                    <div className="save-course-btn">
                                        <GoBookmark />
                                    </div>
                                </div>
                                <div className="title">{data.name}</div>
                                <div className="info">
                                    <div className="difficult tag"><BsBarChartLine /><span>Beginner</span></div>
                                    <div className="lecture tag"><IoVideocamOutline /><span>Videos</span></div>
                                    <div className="time tag"><AiOutlineFieldTime /><span>3.5 Hrs</span></div>
                                </div>
                                <div className="rating-countS">
                                    <div className="rating card"><TiStarOutline /> <span className="card-info">{data.ratingAVG}</span><span className="card-hint">({data.ratingCount})</span></div>
                                    <div className="student card"><PiUserCircleFill /> <span className="card-info">128</span><span className="card-hint">Students</span></div>
                                </div>
                                <div className="price-add">
                                    <span className="price">$ 30</span>
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
            </div>
        </div>
    );
}
