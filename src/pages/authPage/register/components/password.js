import React, { useState, useEffect } from 'react';
import '../register.css';
import closedEye from '../../../../assets/images/closedEye.svg';
import openEye from '../../../../assets/images/openEye.svg';

export default function Password(props) {

     useEffect(()=>{
        props.checkForStep(1)
    },[])

    const [data, setData] = useState("");
    const [showBorder, setShowBorder] = useState(false);
    const [newPassword, changePassword] = useState("password");
    const [icon, changeIcon] = useState("open");

    const handleChange = (e) => {
        setData({ [e.target.id]: e.target.value })
    }

    const checkForValue = () => {
        if (data.email === "") {
            setShowBorder(false)
        } else {
            setShowBorder(true)
        }
    }
    const showPassword = () => {
        if (newPassword == "password") {
            changePassword("text");
            changeIcon("hide");
        }
        else {
            changePassword("password");
            changeIcon("open");
        }
    }

    return (
        <div className="login-box">
            <div className="name-box">
                <hi className="welcome-text">Hello Eliezer!</hi>
            </div>
            <p className="text">Please create your new password</p>
            {/* <form> */}
                <div className="form-control enter-mail" onKeyUp={checkForValue}
                    style={showBorder === true ? { border: "1px solid #1D1D1D" } : { border: "1px solid #DDDDDD" }}>
                    <div className="row h-100">
                        <div className="col-2"></div>
                        <div className="col-8 h-100">
                            <input className="w-100 h-100 text-center" type={`${newPassword}`} id="password" placeholder="Password" onChange={handleChange} />
                        </div>
                        <div className="col-2 d-flex align-items-center justify-content-center">
                            {icon === "open" ? 
                                <img src={openEye} alt="good icon" onMouseDown={showPassword} className="password-icon"/>
                                :
                                <img src={closedEye} alt="good icon" onMouseDown={showPassword} className="password-icon"/>
                            }
                        </div>
                    </div>
                </div>
                <button className="btn proceed" onClick={() => { props.checkForStep(2) }}>Proceed</button>
            {/* </form> */}
        </div>
    )
}