import React from "react";
import './Timeline.css';
import { VscVmActive } from "react-icons/vsc";
const timeLine = [{
    month: 'June 2024',
    detail: [{
        activity: 'Created 9 commits in 1 repository',
        link: 'OtakuIsMe/MusicApp',
        href: 'https://github.com/OtakuIsMe/MusicApp',
        date: '9 June'
    },
    {
        activity: 'Created 9 commits in',
        link: 'OtakuIsMe/MusicApp',
        href: 'https://github.com/OtakuIsMe/MusicApp',
        date: '9 June'
    }
    ]
},
{
    month: "Jul 2024",
    detail: [{
        activity: 'Created 9 commits in 1 repository',
        link: 'OtakuIsMe/MusicApp',
        href: 'https://github.com/OtakuIsMe/MusicApp',
        date: '10 Jul'
    },
    {
        activity: 'Created 9 commits in',
        link: 'OtakuIsMe/MusicApp',
        href: 'https://github.com/OtakuIsMe/MusicApp',
        date: '10 Jul'
    }
    ]
}];
export default function Timeline() {
    return (
        <div id="time-line">
            <div className="timeline">
                {timeLine.map((Tl, index) => {
                    return (
                        <React.Fragment key={index}>
                            <div key={index} className="month">{Tl.month}</div>
                            <div className="activity">
                                <div className="details">
                                    {Tl.detail.map((de, i) => {
                                        return (
                                            <div key={i} className="detail-month">
                                                <VscVmActive className="icons" />
                                                <div className="detail-contents">
                                                    <p key={i}>{de.activity}</p>
                                                    <div className="detail-contents-bottom">
                                                        <a key={i} href={de.href}>{de.link}</a>
                                                        <span key={i} >{de.date}</span>
                                                    </div>
                                                </div>
                                            </div>
                                        )
                                    })}
                                </div>
                            </div>
                        </React.Fragment>
                    )
                })}
            </div>
        </div>
    );
}