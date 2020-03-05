import React, { useState } from 'react';

export default function Email() {
    const [stage, setStage] = useState(1);

    const changeStage = (newStage) => {
        // event.preventDefault();
        setStage(newStage);
    }
    return (
        <div className="login-box">
            <div className="name-box">
            <hi className="welcome-text">Welcome Back!</hi>
            {console.log(stage)}
            </div>
            <p className="text">We know you’ve been working hard, let’s measure your progress</p>
            {/* <form> */}
                <input type="email" className="form-control enter-mail" id="email" placeholder="Please enter your company email address"/>
                <button className="btn proceed" onClick={() => { changeStage(2) }}>Proceed</button>
            {/* </form> */}
        </div>
    )
}