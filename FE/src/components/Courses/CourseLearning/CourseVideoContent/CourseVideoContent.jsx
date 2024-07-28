import React, { useCallback, useEffect, useRef, useState } from "react";
import './CourseVideoContent.css';
import { LuHome } from "react-icons/lu";
import { SlArrowRight, SlArrowLeft } from "react-icons/sl";
import Hls from 'hls.js';
import { IoMdPlay, IoMdPause } from "react-icons/io";
import { FaVolumeOff, FaVolumeLow, FaVolumeHigh } from "react-icons/fa6";
import { IoSettingsSharp } from "react-icons/io5";
import { BsArrowsFullscreen } from "react-icons/bs";
import Box from '@mui/material/Box';
import Stack from '@mui/material/Stack';
import Slider from '@mui/material/Slider';
import LinearProgress from '@mui/material/LinearProgress';
import { FaPlus } from "react-icons/fa6";
import { FaMinus } from "react-icons/fa6";
import ApiService from "../../../../api/ApiService";

export default function CourseVideoContent({ lectureName }) {
    const [videoUrl, setvideoUrl] = useState('');
    const [videoName, setVideoName] = useState('');
    const [videoInfo, setVideoInfo] = useState({
        isPause: true,
        isMuted: false,
        volume: 100,
        currentTime: '0:00',
        maxTime: '0:00',
        isOpenSetting: false,
        videoQuality: '1080p',
        playRate: 1.00,
    });

    const [progress, setProgress] = useState(0);
    const [progressEdit, setProgressEdit] = useState(0)
    const [isHoverProgress, setIsHoverProgress] = useState(false)
    const [isOpenSetting, setIsOpenSetting] = useState(false)
    const videoRef = useRef(null);
    const hlsRef = useRef(null);

    useEffect(() => {
        const src = videoUrl;

        if (Hls.isSupported()) {
            const hls = new Hls();
            hls.loadSource(src);
            hls.attachMedia(videoRef.current);
            hls.on(Hls.Events.MANIFEST_PARSED, () => {
                videoRef.current.play();
            });
            hlsRef.current = hls;
        } else if (videoRef.current && videoRef.current.canPlayType('application/vnd.apple.mpegurl')) {
            videoRef.current.src = src;
            videoRef.current.addEventListener('canplay', () => {
                videoRef.current.play();
            });
        }

        const updateProgress = () => {
            if (videoRef.current) {
                const currentTime = videoRef.current.currentTime;
                const duration = videoRef.current.duration;
                setProgress((currentTime / duration) * 100);
                setProgressEdit((currentTime / duration) * 100);
                setVideoInfo(prev => ({
                    ...prev,
                    currentTime: formatTime(currentTime),
                    maxTime: formatTime(duration)
                }));
            }
        };

        if (videoRef.current) {
            videoRef.current.addEventListener('timeupdate', updateProgress);
            videoRef.current.addEventListener('loadedmetadata', updateProgress);
        }

        return () => {
            if (videoRef.current) {
                videoRef.current.removeEventListener('timeupdate', updateProgress);
                videoRef.current.removeEventListener('loadedmetadata', updateProgress);
            }
            if (hlsRef.current) {
                hlsRef.current.destroy();
                hlsRef.current = null;
            }
        };
    }, [videoUrl]);

    useEffect(() => {
        fetchVideoUrl(lectureName)
    }, [lectureName])

    const fetchVideoUrl = async (hashCode) => {
        const data = await ApiService.GetLecture(hashCode);
        setvideoUrl(data.videoUrl);
        setVideoName(data.name);
    }

    useEffect(() => {
        console.log(videoInfo.isPause)
    }, [videoInfo.isPause])

    const formatTime = (time) => {
        const minutes = Math.floor(time / 60);
        const seconds = Math.floor(time % 60);
        return `${minutes}:${seconds < 10 ? '0' : ''}${seconds}`;
    };

    const handleTogglePauseClick = () => {
        if (videoInfo.isPause) {
            videoRef.current.play();
        } else {
            videoRef.current.pause();
        }
        setVideoInfo(prev => ({
            ...prev,
            isPause: !prev.isPause
        }));
    };

    const hanldeToggleVolumeClick = () => {
        videoRef.current.muted = !videoInfo.isMuted;
        setVideoInfo(prev => ({
            ...prev,
            isMuted: !videoInfo.isMuted
        }));
    };

    const handleVolumeChange = (event, newValue) => {
        videoRef.current.volume = newValue / 100;
        setVideoInfo(prev => ({
            ...prev,
            volume: newValue,
            isMuted: newValue === 0
        }));
    };

    const handleProgressEditChange = (e) => {
        videoRef.current.pause();
        setProgressEdit(e.target.value);
        setTimeout(() => {
            const newTime = (e.target.value / 100) * videoRef.current.duration
            videoRef.current.currentTime = newTime
            if (videoInfo.isPause) {
                videoRef.current.pause();
            } else {
                videoRef.current.play();
            }
        }, 200)
    }
    const handleHoverVolume = (status) => {
        if (status) {
            let progress = document.querySelector('.dropout-volume')
            progress.classList.add('hover')
        }
        else {
            let progress = document.querySelector('.dropout-volume')
            progress.classList.remove('hover')
        }
    }

    const handleFullScreen = () => {
        if (videoRef.current.requestFullscreen) {
            videoRef.current.requestFullscreen();
        } else if (videoRef.current.mozRequestFullScreen) { // Firefox
            videoRef.current.mozRequestFullScreen();
        } else if (videoRef.current.webkitRequestFullscreen) { // Chrome, Safari, and Opera
            videoRef.current.webkitRequestFullscreen();
        } else if (videoRef.current.msRequestFullscreen) { // IE/Edge
            videoRef.current.msRequestFullscreen();
        }
    };

    const handlePlayRateClick = (status) => {
        if (status) {
            if (videoInfo.playRate !== 2.00) {
                const newRate = videoInfo.playRate + 0.25
                setVideoInfo(prev => ({
                    ...prev,
                    playRate: newRate
                }))
                videoRef.current.playbackRate = newRate
            }
        } else {
            if (videoInfo.playRate !== 0.75) {
                const newRate = videoInfo.playRate - 0.25
                setVideoInfo(prev => ({
                    ...prev,
                    playRate: newRate
                }))
                videoRef.current.playbackRate = newRate
            }
        }
    }

    return (
        <div id="course-video-content">
            <div className="action-btn">
                <div className="path">
                    <LuHome className="home-icon redict" />
                    <SlArrowRight className="arrow" />
                    <span className="course redict">Course</span>
                    <SlArrowRight className="arrow" />
                    <span className="lecture-name redict">{videoName}</span>
                </div>
                <div className="prev-next">
                    <div className="prev btn">
                        <SlArrowLeft className="arrow left" />
                        Prev
                    </div>
                    <div className="next btn">
                        Next
                        <SlArrowRight className="arrow right" />
                    </div>
                </div>
            </div>
            <div className="video-container">
                <video ref={videoRef} width='100%' height='100%' />
                <div className="video-control">
                    {videoInfo.isPause && (
                        <div className="play-btn" onClick={handleTogglePauseClick}>
                            <IoMdPlay />
                        </div>
                    )}
                    <div className="control-bar">
                        <div className="progress-bar"
                            onMouseEnter={() => { setIsHoverProgress(true) }}
                            onMouseLeave={() => { setIsHoverProgress(false) }}
                        >
                            {!isHoverProgress && (
                                <Box sx={{ width: '100%' }}>
                                    <LinearProgress variant="determinate" value={progress} />
                                </Box>
                            )}
                            {isHoverProgress && (
                                <div className="hover-progress">
                                    <div className="bar">
                                        <input type="range" min={0} max={100} step={0.1}
                                            value={progressEdit}
                                            onChange={handleProgressEditChange}
                                        />
                                    </div>
                                </div>
                            )}
                        </div>
                        <div className="btn-control">
                            <div className="pause-time">
                                <div className="play-container" onClick={handleTogglePauseClick}>
                                    {videoInfo.isPause ? (
                                        <IoMdPlay className="play icon" />
                                    ) : (
                                        <IoMdPause className="pause icon" />
                                    )}
                                </div>
                                <div className="volume-container"
                                    onMouseEnter={() => { handleHoverVolume(true) }}
                                    onMouseLeave={() => { handleHoverVolume(false) }}
                                >
                                    <FaVolumeOff className="volume icon" onClick={hanldeToggleVolumeClick} />
                                    <div className="dropout-volume">
                                        <Box sx={{ width: 'calc(100% - 10px)' }}>
                                            <Stack spacing={2} direction="row" sx={{ mb: 1 }} alignItems="center">
                                                <Slider
                                                    aria-label="Default"
                                                    value={videoInfo.volume}
                                                    onChange={handleVolumeChange}
                                                />
                                            </Stack>
                                        </Box>
                                    </div>
                                </div>
                                <span className="time">{videoInfo.currentTime} / {videoInfo.maxTime}</span>
                            </div>
                            <div className="setting-extend">
                                <div className="setting-container">
                                    <IoSettingsSharp className="setting icon" onClick={() => { setIsOpenSetting(prev => !prev) }} />
                                    {isOpenSetting && (
                                        <div className="setting-dropUp">
                                            <p className="title">Playback Rate</p>
                                            <div className="rate edit">
                                                <FaMinus onClick={() => { handlePlayRateClick(false) }} style={(videoInfo.playRate === 0.75) ? { color: '#8b8b8b' } : {}} />
                                                <span>{videoInfo.playRate}x</span>
                                                <FaPlus onClick={() => { handlePlayRateClick(true) }} style={(videoInfo.playRate === 2) ? { color: '#8b8b8b' } : {}} />
                                            </div>
                                        </div>
                                    )}
                                </div>
                                <BsArrowsFullscreen className="full-screen icon" onClick={handleFullScreen} />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
