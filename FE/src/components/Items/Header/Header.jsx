import React, { useContext, useEffect, useRef, useState } from "react";
import './Header.css';

import Logo from '../../../assets/Logo.png'

import { IoSearchOutline } from "react-icons/io5";
import SliderCards from "../SliderCards/SliderCards";
import { AuthContext } from "../../../pages/Context/AuthContext";
import { HiOutlineUserCircle } from "react-icons/hi2";
import { LuUserCog } from "react-icons/lu";
import { LuBookMarked } from "react-icons/lu";
import { LuBarChartBig } from "react-icons/lu";
import { TbBellCheck } from "react-icons/tb";
import { BiLogOut } from "react-icons/bi";
import Cookies from "js-cookie"

import ApiService from "../../../api/ApiService";

export default function Header() {
	const [isDropDown, setIsDropDown] = useState(false);
	const [height, setHeight] = useState('0px');
	const contentDropdownRef = useRef(null);
	const { user } = useContext(AuthContext);
	const [imgUser, setImgUser] = useState(null);
	const [isDropDownUser, setIsDropDownUser] = useState(false);
	const [searchInput, setSearchInput] = useState('')
	const [datas, setDatas] = useState([])

	useEffect(() => {
		if (isDropDown) {
			let process = document.querySelector('.search-result-container');
			process.classList.add("show");
			let process1 = document.querySelector('.search-bar');
			process1.classList.add("slide");
			setHeight(`376px`);
		} else {
			let process = document.querySelector('.search-result-container');
			process.classList.remove("show");
			let process1 = document.querySelector('.search-bar');
			process1.classList.remove("slide");
			setHeight('0px');
		}
	}, [isDropDown]);

	useEffect(() => {
		setDatas(null)
		fetchSearch(1, 6, searchInput)
	}, [searchInput])


	const handleSearchFocus = () => {
		setIsDropDown(true);
	}


	const handleCancelBtn = () => {
		setIsDropDown(false);
	}

	const handleLogOut = () => {
		Cookies.remove('token')
		window.location.href = '/'
	}

	const fetchSearch = async (page, items, query) => {
		const data = await ApiService.SearchCourses(page, items, query)
		setDatas(data);
	}

	const hanldeInputKeyDown = (e) => {
		console.log('Already put')
		if (e.key === 'Enter') {
			// console.log('Already put')
			window.location.href = `/search?q=${searchInput}&page=1`
		}
	}

	return (
		<div id="header">
			<div className="header-shown">
				<div className="logo-title">
					<a href="/" className="logo-link">
						<img src={Logo} alt="" className="logo" />
					</a>
					<span className="title">CodeCourse</span>
				</div>
				<div className="search-container">
					<div className="search-bar">
						<IoSearchOutline />
						<input
							type="text"
							placeholder="Searching for course"
							onFocus={handleSearchFocus}
							value={searchInput}
							onChange={(e) => { setSearchInput(e.target.value) }}
							onKeyDown={hanldeInputKeyDown}
						/>
					</div>
				</div>

				<div className="action-button">
					{isDropDown ? (
						<div className="cancel-btn" onClick={handleCancelBtn}>CANCEL</div>
					) : (
						user ? (
							<div className="user-action" onClick={() => { setIsDropDownUser(prev => !prev) }}>
								<div className="user-logo">
									{imgUser ?
										<img src={imgUser} alt="" />
										:
										<HiOutlineUserCircle />
									}
								</div>
								<div className="user-info">
									<p className="name">{user.username}</p>
									<p className="email">{user.email}</p>
								</div>
								<div className={`user-dropdown ${isDropDownUser ? 'active' : ''}`}>
									<div className="dropdown-container">
										<div className="arrow"></div>
										<div className="notification special-block">
											<TbBellCheck />
											Notification
										</div>
										<a href="/student/profile" className="selection-block">
											<LuUserCog />
											Account Profile
										</a>
										<a href="/student/my-learning/completed" className="selection-block">
											<LuBookMarked />
											My Learning
										</a>
										<a href="/" className="selection-block">
											<LuBarChartBig />
											Dashboard
										</a>
										<div className="logout special-block" onClick={handleLogOut}>
											<BiLogOut />
											Log Out
										</div>
									</div>
								</div>
							</div>
						) : (
							<div className="login-signup">
								<a href="/login" className="login">Log in</a>
								<a href="/signup" className="signup">Sign Up</a>
							</div>
						))}
				</div>
			</div>
			<div
				ref={contentDropdownRef}
				className="search-result-container"
				style={{ height: height }}
			>
				<p className="title">Recommend</p>
				<div className="slider-container">
					<SliderCards datas={datas} />
				</div>
			</div>
		</div >
	);
}