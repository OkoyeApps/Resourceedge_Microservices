import React, { useState } from 'react';
import '../register.css';
import goodIcon from '../../../../assets/images/goodIcon.svg';

export default function Email() {
    const [data, setData] = useState("");
    const [showBorder, setShowBorder] = useState(false);

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

    return (
        <div className="login-box">
            <div className="name-box">
                <hi className="welcome-text">Welcome!</hi>
            </div>
            <p className="text">We know you’ve been working hard, let’s measure your progress</p>
            <form>
                <div className="form-control enter-mail" onKeyUp={checkForValue}
                    style={showBorder === true ? { border: "1px solid #1D1D1D" } : { border: "1px solid #DDDDDD" }}>
                    <div className="row h-100">
                        <div className="col-2"></div>
                        <div className="col-8 h-100">
                            <input className="w-100 h-100 text-center" type="email" id="email" placeholder="Please enter your company email address" onChange={handleChange} />
                        </div>
                        <div className="col-2 d-flex align-items-center justify-content-center">
                            <img src={goodIcon} alt="good icon" />
                        </div>
                    </div>
                </div>
                <button className="btn proceed">Proceed</button>
            </form>
        </div>
    )
}