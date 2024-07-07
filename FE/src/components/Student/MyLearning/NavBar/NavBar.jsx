import React, { useEffect } from "react";
import './NavBar.css';

export default function NavBar({ type }) {
    useEffect(() => {
        try {
            let progress1 = document.querySelector('.active')
            progress1.classList.remove('active')
        } catch (error) {

        }
        let progress2 = document.querySelector('.' + type)
        progress2.classList.add('active')
    }, [type])
    const handleTagClick = (name) => {
        window.location.href = `/student/my-learning/${name}`
    }
    return (
        <div id="nav-bar">
            <div className="title"><p>My learning</p></div>
            <div className="nav-btn">
                <div className="completed tag" onClick={() => { handleTagClick('completed') }}>Completed</div>
                <div className="in-progress tag" onClick={() => { handleTagClick('in-progress') }}>In Progress</div>
                <div className="saved tag" onClick={() => { handleTagClick('saved') }}>Saved</div>
                <div className="following tag" onClick={() => { handleTagClick('following') }}>Following</div>
            </div>
        </div>
    )
}