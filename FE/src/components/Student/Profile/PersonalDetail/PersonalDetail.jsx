import React, { useState, useEffect, useContext } from "react";
import './PersonalDetail.css'

import Pic1 from '../../../../assets/Collection-Avatar/1.png'
import Pic2 from '../../../../assets/Collection-Avatar/2.png'
import Pic3 from '../../../../assets/Collection-Avatar/3.png'
import Pic4 from '../../../../assets/Collection-Avatar/4.png'
import Pic5 from '../../../../assets/Collection-Avatar/5.png'
import Pic6 from '../../../../assets/Collection-Avatar/6.png'
import Pic7 from '../../../../assets/Collection-Avatar/7.png'
import Pic8 from '../../../../assets/Collection-Avatar/8.png'
import Pic9 from '../../../../assets/Collection-Avatar/9.png'

// import { PiUserFocus } from "react-icons/pi";
import { LuPenSquare } from "react-icons/lu";
import { GoLink } from "react-icons/go";
import { TbPhotoCirclePlus } from "react-icons/tb";
import { LuPlus } from "react-icons/lu";
import { AuthContext } from "../../../../pages/Context/AuthContext";

export default function PersonalDetail() {
    const [isOpenVisible, setIsOpenVisible] = useState(false);
    const [isOpenEdit, setIsOpenEdit] = useState(false);
    const [isOpenAddInfo, setIsOpenAddInfo] = useState(false);
    const [photo, setPhoto] = useState(null);
    const { user } = useContext(AuthContext)

    const [name, setName] = useState('');
    const [userName, setUserName] = useState('');
    const [dob, setDob] = useState(null);
    const [description, setDescription] = useState('');
    const [gender, setGender] = useState('')

    useEffect(() => {
        if (user) {
            setName(user.name)
            setUserName(user.username)
            setDob(user.dob)
            setDescription(user.description)
            setGender(user.gender)
        }
    }, [user])

    useEffect(() => {
        if (isOpenVisible, isOpenEdit, isOpenAddInfo) {
            document.body.style.overflow = 'hidden';
        } else {
            document.body.style.overflow = 'auto';
        }
    }, [isOpenVisible, isOpenEdit, isOpenAddInfo]);

    useEffect(() => {
        document.body.style.overflow = (isOpenVisible || isOpenEdit || isOpenAddInfo) ? 'hidden' : 'auto';
    }, [isOpenVisible, isOpenEdit, isOpenAddInfo]);

    const handlePhotoChange = (event) => {
        const file = event.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = (e) => {
                setPhoto(e.target.result);
            };
            reader.readAsDataURL(file);
        }
    };

    const handleIconClick = () => {
        document.getElementById('file-input').click();
    };

    const handleRemovePhoto = () => {
        setPhoto(null);
    };

    useEffect(() => {
        const avatars = document.querySelectorAll("#personal-detail .row-avatar img");
        let currentIndex = 0;

        function changeAvatar() {
            avatars[currentIndex].classList.remove("active");
            currentIndex = (currentIndex + 1) % avatars.length;
            avatars[currentIndex].classList.add("active");
        }

        const intervalId = setInterval(changeAvatar, 2500); // Change every 2.5 seconds
        avatars[currentIndex].classList.add("active"); // Start with the first image visible

        return () => clearInterval(intervalId);
    }, []);

    const [fbValue, setFbValue] = useState('');
    const [githubValue, setGithubValue] = useState('');
    const [twitterValue, setTwitterValue] = useState('');
    const [linkedinValue, setLinkedinValue] = useState('');
    const [errors, setErrors] = useState({
        fb: '',
        github: '',
        twitter: '',
        linkedin: ''
    });

    const handleFbChange = (event) => {
        const value = event.target.value;
        setFbValue(value);
        validateAndUpdateError(value, 'fb');
    };

    const handleGithubChange = (event) => {
        const value = event.target.value;
        setGithubValue(value);
        validateAndUpdateError(value, 'github');
    };

    const handleTwitterChange = (event) => {
        const value = event.target.value;
        setTwitterValue(value);
        validateAndUpdateError(value, 'twitter');
    };

    const handleLinkedinChange = (event) => {
        const value = event.target.value;
        setLinkedinValue(value);
        validateAndUpdateError(value, 'linkedin');
    };

    const validateAndUpdateError = (value, field) => {
        if (value.trim() === '') {
            setErrors(prevErrors => ({
                ...prevErrors,
                [field]: '' // Clear error if field is empty
            }));
        } else if (!validateUrl(value)) {
            setErrors(prevErrors => ({
                ...prevErrors,
                [field]: 'Please ensure the URL has been entered correctly'
            }));
        } else {
            setErrors(prevErrors => ({
                ...prevErrors,
                [field]: '' // Clear error if URL format is correct
            }));
        }
    };

    useEffect(() => {
        // Validate initial values on component mount
        validateAndUpdateError(fbValue, 'fb');
        validateAndUpdateError(githubValue, 'github');
        validateAndUpdateError(twitterValue, 'twitter');
        validateAndUpdateError(linkedinValue, 'linkedin');
    }, []); // Empty dependency array to run effect only once on mount

    const validateUrl = (url) => {
        return url.startsWith('https://');
    };

    const handleRemoveClick = (field) => {
        switch (field) {
            case 'fb':
                setFbValue('');
                break;
            case 'github':
                setGithubValue('');
                break;
            case 'twitter':
                setTwitterValue('');
                break;
            case 'linkedin':
                setLinkedinValue('');
                break;
            default:
                break;
        }
        setErrors(prevErrors => ({
            ...prevErrors,
            [field]: '' // Clear error when input is removed
        }));
    };

    return (
        <div id="personal-detail">
            <div className="personal-detail-container-row1">
                <div className="personal-detail-container-column">
                    <div className="row-edit">
                        <div className="row-edit-button">
                            <LuPenSquare size={25} onClick={() => { setIsOpenEdit(true) }} />
                        </div>
                        <div className="popup-edit" style={isOpenEdit ? { display: 'block' } : { display: 'none' }}>
                            <div className="popup-edit-container">
                                <div className="popup-edit-buttonclose" onClick={() => { setIsOpenEdit(false) }} title="Close Popup">Close X</div>

                                <div className="popup-row">
                                    <div className="popup-row-title">
                                        <p>Personal details</p>
                                    </div>

                                    <div className="popup2-row-text">
                                        <p>Add your personal details as you would like it to appear on your profile.</p>
                                    </div>

                                    <div className="popup-row-text2">
                                        <p style={{ marginTop: '10px' }}>Profile Photo</p>
                                    </div>

                                    <div className="popup-row-iconphoto">
                                        <input
                                            type="file"
                                            accept="image/*"
                                            onChange={handlePhotoChange}
                                            style={{ display: 'none' }}
                                            id="file-input"
                                        />
                                        {photo ? (
                                            <img src={photo} alt="Uploaded" style={{ display: 'none' }} />
                                        ) : (
                                            <div onClick={handleIconClick} style={{ cursor: 'pointer' }}>
                                                <TbPhotoCirclePlus size={'120%'} />
                                            </div>
                                        )}
                                    </div>

                                    <div className="popup-row-addphotos">
                                        <input
                                            type="file"
                                            accept="image/*"
                                            onChange={handlePhotoChange}
                                            style={{ display: 'none' }}
                                            id="file-input"
                                        />
                                        <label htmlFor="file-input" className="photo-label">
                                            {photo ? (
                                                <img src={photo} alt="Uploaded" className="uploaded-photo" onClick={() => document.getElementById('file-input').click()} />
                                            ) : (
                                                <button className="upload-button" onClick={() => document.getElementById('file-input').click()}>Upload Photo</button>
                                            )}
                                        </label>
                                    </div>

                                    {photo && (
                                        <div className="photo-buttons">
                                            <button className="btChanged" type="button" onClick={() => document.getElementById('file-input').click()}>Change photo</button>
                                            <button className="btRemoved" type="button" onClick={handleRemovePhoto} style={{ backgroundColor: 'none' }}>Remove photo</button>
                                        </div>
                                    )}

                                    <div className="popup2-row-text2">
                                        <p style={{ marginBottom: '35px' }}>Maximum size: 1MB. Supported formats: JPG, GIF, or PNG.</p>
                                    </div>

                                    <div className="popup2-row-title" title="Your fist name and last name">
                                        <p>First and last name</p>
                                    </div>

                                    <div className="input-container">
                                        <input className="boxfistandlastname" type="text" name="" id=""
                                            value={name}
                                            onChange={(e) => { setName(e.target.value) }}
                                        />
                                    </div>

                                    <div className="popup2-row-title" title="Your user name">
                                        <p>User name</p>
                                    </div>

                                    <div className="input-container">
                                        <input type="text" maxLength={'15'} minLength={'5'} name="" id=""
                                            value={userName}
                                            onChange={(e) => { setUserName(e.target.value) }}
                                        />
                                    </div>

                                    <div className="popup2-row-title" title="Date of your birth">
                                        <p>Date of birth</p>
                                    </div>

                                    <div className="input-container">
                                        <input
                                            type="date"
                                            style={{ width: '28%' }}
                                            value={dob}
                                            onChange={(e) => setDob(e.target.value)} // Update state on change
                                        />
                                    </div>

                                    <div className="popup2-row-title" title="Bio">
                                        <p>Introduce</p>
                                    </div>

                                    <div className="input-container">
                                        <textarea
                                            className="boxintroduce"
                                            name="introduce"
                                            id="introduce"
                                            placeholder="Introduce yourself..."
                                            style={{ minHeight: '150px', resize: 'vertical' }}
                                            value={description}
                                            onChange={(e) => setDescription(e.target.value)}
                                        ></textarea>
                                    </div>

                                    <div className="line">
                                        <hr />
                                    </div>

                                    <div className="popup-row-text2">
                                        <p style={{ marginTop: '10px', marginBottom: '25px' }}>Demographic Information</p>
                                    </div>

                                    <div className="popup2-row-title" title="Sexuality">
                                        <p>Gender</p>
                                    </div>

                                    <div className="input-container">
                                        <select className="gender-select" id="gender" name="gender"
                                            value={gender}
                                            onChange={(e) => setGender(e.target.value)}
                                        >
                                            <option value="">Select Gender</option>
                                            <option value="woman">Woman</option>
                                            <option value="man">Man</option>
                                            <option value="non-binary">Non Binary</option>
                                            <option value="transgender-woman">Transgender Woman</option>
                                            <option value="transgender-man">Transgender Man</option>
                                            <option value="agender">Agender</option>
                                            <option value="gender-not-listed">Gender Identity Not Listed</option>
                                            <option value="prefer-not-to-say">Prefer Not to Say</option>
                                        </select>
                                    </div>

                                    <div>
                                        <button className="btSavechanged">Save Changes</button>
                                    </div>

                                    <div>
                                        <label style={{ marginTop: '10px' }} htmlFor=""></label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="row">
                        <h2>Personal details</h2>
                    </div>
                    <div className="row-avatar" id="avatarContainer">
                        <img src={Pic1} alt="Avatar" className="avatar" />
                        <img src={Pic2} alt="Avatar" className="avatar" />
                        <img src={Pic3} alt="Avatar" className="avatar" />
                        <img src={Pic4} alt="Avatar" className="avatar" />
                        <img src={Pic5} alt="Avatar" className="avatar" />
                        <img src={Pic6} alt="Avatar" className="avatar" />
                        <img src={Pic7} alt="Avatar" className="avatar" />
                        <img src={Pic8} alt="Avatar" className="avatar" />
                        <img src={Pic9} alt="Avatar" className="avatar" />
                    </div>

                    <div className="row-username">
                        <h10>HUNGLCSE161248</h10>
                    </div>
                    <div className="row-share-profile">
                        <div className="row-share-profile-container">
                            <div className="icon">
                                <GoLink size={16} />
                            </div>
                            <div className="text">
                                <h2>Share profile link  </h2>
                            </div>
                        </div>
                    </div>
                    <div className="row-update">
                        <div className="row-update-container">
                            <div className="text" onClick={() => { setIsOpenVisible(true) }}>
                                <h2>Update profile visibility</h2>
                            </div>
                            <div className="popup-visible-profile" style={isOpenVisible ? { display: 'block' } : { display: 'none' }}>
                                <div className="popup-visible-profile-buttonclose-container">
                                    <div className="popup-visible-profile-buttonclose" onClick={() => { setIsOpenVisible(false) }} title="Close Popup">Close X</div>
                                </div>

                                <div className="popup-row">
                                    <div className="popup-row-title">
                                        <p>Profile visibility and privacy settings</p>
                                    </div>

                                    <div className="popup-row-text">
                                        <p>Sharing your profile is a great way to stand out by showcasing your skills and accomplishments on CodeCourse.</p>
                                    </div>

                                    <div className="popup-row-text2">
                                        <p style={{ marginTop: '10px' }}>Who do you want to see your profile?</p>
                                        <div className="popup-row-text2-container">
                                            <div>
                                                <input className="popup-row-text2-button" type="checkbox" id="public1" value="public" />
                                            </div>
                                            <div>
                                                <p className="popup-row-text2">Anyone with my link</p>
                                            </div>
                                        </div>
                                        <p className="popup-row-text3" style={{ marginTop: '10px', fontWeight: '100' }}>Anyone who has the link to your profile can view it (but it won’t appear as a result on search engines).</p>

                                    </div>

                                    <div className="popup-row-text2">
                                        <p style={{ marginTop: '10px' }}>Who do you want to see your course enrroled</p>
                                        <div className="popup-row-text2-container">
                                            <div>
                                                <input className="popup-row-text2-button" type="checkbox" id="public2" value="public" />
                                            </div>
                                            <div>
                                                <p className="popup-row-text2">Anyone with my link</p>
                                            </div>
                                        </div>
                                        <p className="popup-row-text3" style={{ marginTop: '10px', fontWeight: '100' }}>Anyone who has the link to your profile can view it (but it won’t appear as a result on search engines).</p>
                                    </div>

                                    <div>
                                        <button className="popup-row-button">Save changes</button>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div className="overlay1" style={isOpenVisible ? { display: 'block' } : { display: 'none' }} onClick={() => { setIsOpenVisible(false) }}></div>
                <div className="overlay2" style={isOpenEdit ? { display: 'block' } : { display: 'none' }} onClick={() => { setIsOpenEdit(false) }}></div>
            </div>

            <div className="personal-detail-container-row2">
                <div className="personal-detail-container-column2">
                    <div className="row-info">
                        <h2>Additional info</h2>
                    </div>

                    <div className="row-info">
                        <p>Help recruiters get to know you better by describing what makes you a great candidate and sharing other links.</p>
                        <div className="row-info-container" onClick={() => { setIsOpenAddInfo(true) }} >
                            <div className="icon">
                                <LuPlus size={15} />
                            </div>
                            <div className="text">
                                <h2>Add additional info</h2>
                            </div>
                        </div>
                    </div>

                    <div className="popup-add-info" style={isOpenAddInfo ? { display: 'block' } : { display: 'none' }}>
                        <div className="popup-add-info-buttonclose" onClick={() => { setIsOpenAddInfo(false) }} title="Close Popup">Close X</div>
                        <div className="popup-row">

                            <div className="popup-row-title">
                                <p>Additional info</p>
                            </div>

                            <div className="popup3-row-title">
                                <p>Help employers get to know you better by adding other links and describing what makes you a great candidate.</p>
                            </div>

                            <div className="popup3-row-text">
                                <p style={{ marginTop: '10px' }}>Additional links</p>
                            </div>

                            <div className="popup3-row-title2">
                                <p>Already have a LinkedIn profile, GitHub account, or personal portfolio? Add up to 4 links to make it easier for employers to view your work.</p>
                            </div>

                            <div className="popup3-row-box">
                                <div className="box">
                                    <div className="box-content1">
                                        <h2>Facebook</h2>
                                    </div>
                                    <div className="box-content2">
                                        <input
                                            type="text"
                                            placeholder="https://"
                                            value={fbValue}
                                            onChange={handleFbChange}
                                            className="url-input"
                                        />
                                    </div>
                                    <div className="box-content3">
                                        <button onClick={() => handleRemoveClick('fb')} className="remove-button">
                                            Remove
                                        </button>
                                    </div>
                                </div>

                                <div className="box">
                                    <div className="box-content1">
                                        <h2>GitHub</h2>
                                    </div>
                                    <div className="box-content2">
                                        <input
                                            type="text"
                                            placeholder="https://"
                                            value={githubValue}
                                            onChange={handleGithubChange}
                                            className="url-input"
                                        />
                                    </div>
                                    <div className="box-content3">
                                        <button onClick={() => handleRemoveClick('github')} className="remove-button">
                                            Remove
                                        </button>
                                    </div>
                                </div>

                                <div className="box">
                                    <div className="box-content1">
                                        <h2>Twitter</h2>
                                    </div>
                                    <div className="box-content2">
                                        <input
                                            type="text"
                                            placeholder="https://"
                                            value={twitterValue}
                                            onChange={handleTwitterChange}
                                            className="url-input"
                                        />
                                    </div>
                                    <div className="box-content3">
                                        <button onClick={() => handleRemoveClick('twitter')} className="remove-button">
                                            Remove
                                        </button>
                                    </div>
                                </div>

                                <div className="box">
                                    <div className="box-content1">
                                        <h2>LinkedIn</h2>
                                    </div>
                                    <div className="box-content2">
                                        <input
                                            type="text"
                                            placeholder="https://"
                                            value={linkedinValue}
                                            onChange={handleLinkedinChange}
                                            className="url-input"
                                        />
                                    </div>
                                    <div className="box-content3">
                                        <button onClick={() => handleRemoveClick('linkedin')} className="remove-button">
                                            Remove
                                        </button>
                                    </div>
                                </div>

                                {Object.values(errors).some(error => error) && (
                                    <div className="error-message">
                                        <h2>Please ensure all URLs have been entered correctly</h2>
                                    </div>
                                )}
                            </div>

                            <div className="line" style={{ marginTop: '10px' }}>
                                <hr />
                            </div>

                            <div style={{ marginBottom: '45px' }}>
                                <button className="btSavechanged">Save Changes</button>
                            </div>

                        </div>
                    </div>

                    <div className="overlay3" style={isOpenAddInfo ? { display: 'block' } : { display: 'none' }} onClick={() => { setIsOpenAddInfo(false) }}></div>
                </div>
            </div>
        </div>
    )
}
