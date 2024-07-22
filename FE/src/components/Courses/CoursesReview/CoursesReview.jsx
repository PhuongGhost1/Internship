import React, { useEffect } from "react";
import './CoursesReview.css';
import { formatNumber } from "../../../utils/Validation";
import { IoStar } from "react-icons/io5";
import ProgressBar from 'react-bootstrap/ProgressBar';
import { dateEngformat } from "../../../utils/Validation";
import avatar from '../../../assets/user-avatar.jpg'
import { BsDot } from "react-icons/bs";

export default function CoursesReview({ comments }) {

    return (
        <div id="courses-review">
            <div className="rating-container">
                <p className="title">Learner reviews</p>
                <div className="rating-overview">
                    <div className="star-avg">
                        <IoStar />
                        <span className="avg">4.5</span>
                    </div>
                    <span className="total-reviews">{formatNumber(200000)} reviews</span>
                </div>
                <div className="rating-statistical">
                    <ul className="rating-block">
                        <li className="5s rating">
                            <span>5 stars</span>
                            <div className="progress-container">
                                <ProgressBar now={67.39} />
                            </div>
                            <span>67.39%</span>
                        </li>
                        <li className="4s rating">
                            <span>4 stars</span>
                            <div className="progress-container">
                                <ProgressBar now={21.98} />
                            </div>
                            <span>21.98%</span>
                        </li>
                        <li className="3s rating">
                            <span>3 stars</span>
                            <div className="progress-container">
                                <ProgressBar now={6.51} />
                            </div>
                            <span>6.51%</span>
                        </li>
                        <li className="2s rating">
                            <span>2 stars</span>
                            <div className="progress-container">
                                <ProgressBar now={2.12} />
                            </div>
                            <span>2.12%</span>
                        </li>
                        <li className="1s rating">
                            <span>1 star</span>
                            <div className="progress-container">
                                <ProgressBar now={1.98} />
                            </div>
                            <span>1.98%</span>
                        </li>
                    </ul>
                </div>
            </div>
            <div className="comment-container">
                {!(comments == null || comments.length == 0) ? (
                    <>
                        <p className="title">Showing 3 of 4</p>
                        <div className="comments">
                            {comments.map((comment, index) => {
                                return (
                                    <div className="comment" key={index}>
                                        <div className="name-avatar">
                                            <div>
                                                <img src={comment.userImage ? comment.userImage : avatar} alt="" className="avatar-user" />
                                                <p className="username">{comment.comment.user.username}</p>
                                            </div>
                                        </div>
                                        <div className="comment-ratingStar">
                                            <div className="rating-update">
                                                <IoStar className="star-icon" />
                                                <span className="num-rating">{comment.comment.rating}</span>
                                                <BsDot className="dot-icon" />
                                                <span className="time-up">Reviewed on {dateEngformat(comment.comment.createdAt)}</span>
                                            </div>
                                            <div className="comment-description">
                                                <p>{comment.comment.comment1}</p>
                                            </div>
                                        </div>
                                    </div>
                                )
                            })}
                        </div>
                        <p className="view-more">View More Comments</p>
                    </>
                ) : (
                    <div className="no-comment">
                        <div className="no-comment-design">
                            <div className="no-comment-card top">
                                <div className="user-account">
                                    <div className="circle-out">
                                        <div className="circle-in"></div>
                                    </div>
                                </div>
                                <div className="comments-blur">
                                    <div className="comments-blur-container">
                                        <div className="comment-blur long"></div>
                                        <div className="comment-blur short"></div>
                                    </div>
                                </div>
                            </div>
                            <div className="no-comment-card bottom">
                                <div className="user-account">
                                    <div className="circle-out">
                                        <div className="circle-in"></div>
                                    </div>
                                </div>
                                <div className="comments-blur">
                                    <div className="comments-blur-container">
                                        <div className="comment-blur long"></div>
                                        <div className="comment-blur short"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <p className="no-comment-title">No comment yet</p>
                    </div>
                )}
            </div>
        </div>
    )
}