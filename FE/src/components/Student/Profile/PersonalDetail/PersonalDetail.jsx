import React, { useState, useEffect } from "react";
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

export default function PersonalDetail() {
    const [isOpenVisible, setIsOpenVisible] = useState(false);
    const [isOpenEdit, setIsOpenEdit] = useState(false);
    const [photo, setPhoto] = useState(null);

    useEffect(() => {
        if (isOpenVisible) {
            document.body.style.overflow = 'hidden';
        } else {
            document.body.style.overflow = 'auto';
        }
    }, [isOpenVisible]);

    useEffect(() => {
        if (isOpenEdit) {
            document.body.style.overflow = 'hidden';
        } else {
            document.body.style.overflow = 'auto';
        }
    }, [isOpenEdit]);

    useEffect(() => {
        document.body.style.overflow = (isOpenVisible || isOpenEdit) ? 'hidden' : 'auto';
    }, [isOpenVisible, isOpenEdit]);

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

        const intervalId = setInterval(changeAvatar, 2000); // Change every 2 seconds
        avatars[currentIndex].classList.add("active"); // Start with the first image visible

        return () => clearInterval(intervalId);
    }, []);

    return (
        <div id="personal-detail">
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
                                    <input className="boxfistandlastname" type="fistandlastname" name="" id="" />
                                </div>

                                <div className="popup2-row-title" title="Your user name">
                                    <p>User name</p>
                                </div>

                                <div className="input-container">
                                    <input type="username" maxLength={'15'} minLength={'5'} name="" id="" />
                                </div>

                                <div className="popup2-row-title" title="Date of your birth">
                                    <p>Date of birth</p>
                                </div>

                                <div className="input-container">
                                    <input type="date" name="" id="" style={{ width: '28%' }} />
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
                                    <select className="gender-select" id="gender" name="gender">
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
                            <h2>Share profile link</h2>
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
    )
}
