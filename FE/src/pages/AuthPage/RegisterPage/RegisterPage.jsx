import React, { useEffect, useState, useRef } from "react";
import './RegisterPage.css';
import { useLocation, useNavigate } from 'react-router-dom'
import { FaCheck } from "react-icons/fa6";
import { IoMdEyeOff } from "react-icons/io";
import { IoMdEye } from "react-icons/io";
import { IoCheckmarkCircleSharp } from "react-icons/io5";
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import FormControl from '@mui/joy/FormControl';
import FormLabel from '@mui/joy/FormLabel';
import Radio from '@mui/joy/Radio';
import RadioGroup from '@mui/joy/RadioGroup';
import dayjs, { Dayjs } from 'dayjs';
import localizedFormat from 'dayjs/plugin/localizedFormat';
import utc from 'dayjs/plugin/utc';
import timezone from 'dayjs/plugin/timezone';


dayjs.extend(localizedFormat);
dayjs.extend(utc);
dayjs.extend(timezone);

dayjs.tz.setDefault('Asia/Ho_Chi_Minh');


import Header from "../../../components/Items/Header/Header";

import add_profile from "../../../assets/add_profile.png"
import Logo from "../../../assets/Logo.png";
import background_forest from '../../../assets/background_forest.png'
import email_receive from '../../../assets/email_receive.png'
import password_icon from '../../../assets/password.png'

export default function RegisterPage() {
    const location = useLocation()
    const queryParams = new URLSearchParams(location.search)
    const step = queryParams.get('step')

    const [numbers, setNumbers] = useState({
        num1: '',
        num2: '',
        num3: '',
        num4: '',
        num5: ''
    })
    const [prossbarWidth, setProcessbarWidth] = useState('0%')
    const [display, setDisplay] = useState({
        block1: 'none',
        block2: 'none',
        block3: 'none'
    })
    const [isVisiblePassword, setIsVisiblePassword] = useState(false)
    const [isVisibleConfirmPassword, setIsVisibleConfirmPassword] = useState(false)

    useEffect(() => {
        if (step === '1') {
            setProcessbarWidth('20%')
            setDisplay({
                block1: 'none',
                block2: 'none',
                block3: 'none'
            })
        } else if (step === '2') {
            setProcessbarWidth('50%')
            setDisplay({
                block1: 'flex',
                block2: 'none',
                block3: 'none'
            })
        } else if (step === '3') {
            setProcessbarWidth('79%')
            setDisplay({
                block1: 'flex',
                block2: 'flex',
                block3: 'flex'
            })
        } else {

        }
    }, [step])

    const inputRefs = {
        num1: useRef(null),
        num2: useRef(null),
        num3: useRef(null),
        num4: useRef(null),
        num5: useRef(null)
    };
    const [dobvalue, setdobvalue] = useState(dayjs().tz());
    const [gendervalue, setgendervalue] = useState('male');

    const handleRadioChange = (event) => {
        setgendervalue(event.target.value);
    };

    const navigate = useNavigate();


    useEffect(() => {
        console.log(step)
        document.body.classList.add('no-scroll');
    }, [])

    const handleChange = (e, numKey, nextRef) => {
        const value = e.target.value;
        if (!isNaN(value) && value !== '') {
            setNumbers((prevNumbers) => ({
                ...prevNumbers,
                [numKey]: value
            }));
            if (value.length === e.target.maxLength && nextRef) {
                nextRef.current.focus();
            }
        } else {
            setNumbers((prevNumbers) => ({
                ...prevNumbers,
                [numKey]: ''
            }));
        }
    };

    const handleKeyDown = (e, numKey, prevRef) => {
        if (e.key === 'Backspace' && !numbers[numKey]) {
            e.preventDefault();
            if (prevRef) {
                prevRef.current.focus();
                const prevKey = Object.keys(inputRefs).find(
                    key => inputRefs[key] === prevRef
                );
                setNumbers((prevNumbers) => ({
                    ...prevNumbers,
                    [prevKey]: ''
                }));
            }
        }
    };

    const handleNextClick = () => {
        navigate('/signup?step=3')
    }

    return (
        <div id="register">
            <Header />
            <div className="register-container" style={{ backgroundImage: `url(${background_forest})` }}>
                {(step) && (
                    <div className="progress-bar-container">
                        <div className="1 step-container">
                            <div className="step">
                                <div className="checked" style={{ display: display.block1 }}>
                                    <FaCheck />
                                </div>
                                1
                            </div>
                            <p>Email Authentication</p>
                        </div>
                        <div className="2 step-container" >
                            <div className="step">
                                <div className="checked" style={{ display: display.block2 }}>
                                    <FaCheck />
                                </div>
                                2
                            </div>
                            <p>EnterPassword</p>
                        </div>
                        <div className="3 step-container">
                            <div className="step">
                                <div className="checked" style={{ display: display.block3 }}>
                                    <FaCheck />
                                </div>
                                3
                            </div>
                            <p>Profile</p>
                        </div>
                        <div className="progress-bar">
                            <div className="progressing" style={{ width: prossbarWidth }}></div>
                        </div>
                    </div>
                )}
                {step === null && (
                    <div className="form-register">
                        <img src={Logo} alt="" className="logo-img" />
                        <p className="title-cr">Create Your Account to Ignite Your Learning Journey!</p>
                        <div className="form">
                            <p className="email">Email Address</p>
                            <div className="input i-email">
                                <input type="email" placeholder="name@domain.com" />
                            </div>
                            <div className="input-btn" onClick={() => { navigate('/signup?step=1') }}>
                                Next
                            </div>
                        </div>
                    </div>
                )}
                {step !== null && (
                    <div className="form-email">
                        {step === '1' && (
                            <React.Fragment>
                                <img src={email_receive} alt="" className="email-logo" />
                                <p className="verify-title">Verify your email</p>
                                <p className="verify-intro">Please enter the 5 digit code sent to duynmse173649@fpt.edu.vn</p>
                                <div className="digit-code">
                                    <input type="text" className="digit-1" maxLength={1} value={numbers.num1} onChange={(e) => handleChange(e, 'num1', inputRefs.num2)} ref={inputRefs.num1} onKeyDown={(e) => handleKeyDown(e, 'num1', null)} />
                                    <input type="text" className="digit-2" maxLength={1} value={numbers.num2} onChange={(e) => handleChange(e, 'num2', inputRefs.num3)} ref={inputRefs.num2} onKeyDown={(e) => handleKeyDown(e, 'num2', inputRefs.num1)} />
                                    <input type="text" className="digit-3" maxLength={1} value={numbers.num3} onChange={(e) => handleChange(e, 'num3', inputRefs.num4)} ref={inputRefs.num3} onKeyDown={(e) => handleKeyDown(e, 'num3', inputRefs.num2)} />
                                    <input type="text" className="digit-4" maxLength={1} value={numbers.num4} onChange={(e) => handleChange(e, 'num4', inputRefs.num5)} ref={inputRefs.num4} onKeyDown={(e) => handleKeyDown(e, 'num4', inputRefs.num3)} />
                                    <input type="text" className="digit-5" maxLength={1} value={numbers.num5} onChange={(e) => handleChange(e, 'num5', null)} ref={inputRefs.num5} onKeyDown={(e) => handleKeyDown(e, 'num5', inputRefs.num4)} />
                                </div>
                                <button className="confirm-btn" onClick={() => { navigate('/signup?step=2') }}>Confirm</button>
                            </React.Fragment>
                        )}
                        {step === '2' && (
                            <React.Fragment>
                                <img src={password_icon} alt="" className="email-logo" />
                                <p className="verify-title">Set password for your account</p>
                                <p className="verify-intro">To complete your account setup, please create a password below.</p>
                                <div className="input-password-container">
                                    <p className="title-password">Password</p>
                                    <div className="input">
                                        <input type={isVisiblePassword ? "text" : "password"} className="input-password" />
                                        <div className="svg-contain" onClick={() => { setIsVisiblePassword((prev) => !prev) }}>
                                            {isVisiblePassword ? (<IoMdEye />) : (<IoMdEyeOff />)}
                                        </div>
                                    </div>
                                </div>
                                <div className="input-password-container confirm">
                                    <p className="title-password confirm">Confirm Password</p>
                                    <div className="input">
                                        <input type={isVisibleConfirmPassword ? "text" : "password"} className="input-password confirm" />
                                        <div className="svg-contain" onClick={() => { setIsVisibleConfirmPassword((prev) => !prev) }}>
                                            {isVisibleConfirmPassword ? (<IoMdEye />) : (<IoMdEyeOff />)}
                                        </div>
                                    </div>
                                </div>
                                <div className="requirements">
                                    <div className="requirement-container">
                                        <div className="checked-svg-container">
                                            <div className="checked-circle">
                                            </div>
                                            <IoCheckmarkCircleSharp style={{ display: 'none' }} />
                                        </div>
                                        <p className="requirement">At least 10 character</p>
                                    </div>
                                    <div className="requirement-container">
                                        <div className="checked-svg-container">
                                            <div className="checked-circle">
                                            </div>
                                            <IoCheckmarkCircleSharp />
                                        </div>
                                        <p className="requirement">Contain 1 special character &#40;example: # ? ! &&#41;</p>
                                    </div>
                                    <div className="requirement-container">
                                        <div className="checked-svg-container">
                                            <div className="checked-circle">
                                            </div>
                                            <IoCheckmarkCircleSharp />
                                        </div>
                                        <p className="requirement">Contain 1 uppercase character</p>
                                    </div>
                                </div>
                                <div className="next-button" onClick={handleNextClick}>Next</div>
                            </React.Fragment>
                        )}
                        {step === '3' && (
                            <React.Fragment>
                                <img src={add_profile} alt="" className="email-logo" />
                                <p className="verify-title">Tell us about your self</p>
                                <Box
                                    component="form"
                                    sx={{
                                        '& > :not(style)': { m: 1, width: '25ch' },
                                    }}
                                    noValidate
                                    autoComplete="off"
                                >
                                    <TextField id="standard-basic" label="Username" variant="standard" />
                                    <TextField id="standard-basic" label="Full-Name" variant="standard" />
                                </Box>
                                <LocalizationProvider dateAdapter={AdapterDayjs}>
                                    <DemoContainer components={['DatePicker', 'DatePicker']}>
                                        <DatePicker
                                            label="Date of birth"
                                            format="DD/MM/YYYY"
                                            value={dobvalue}
                                            onChange={(newValue) => setdobvalue(newValue)}
                                        />
                                    </DemoContainer>
                                </LocalizationProvider>
                                <FormControl>
                                    <RadioGroup
                                        name="controlled-radio-buttons-group"
                                        value={gendervalue}
                                        onChange={handleRadioChange}
                                        sx={{ my: 1 }}
                                    >
                                        <Radio value="male" label="Male" />
                                        <Radio value="female" label="Female" />
                                        <Radio value="RTX4090Ti" label="RTX4090 Ti" />
                                    </RadioGroup>
                                </FormControl>
                                <div className="next-button" >Next</div>
                            </React.Fragment>
                        )}
                    </div>
                )}
            </div>
        </div>
    )
}