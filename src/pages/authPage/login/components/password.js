import React, { useState } from 'react';

export default function Password() {
    
    return (
        <div className="login-box">
            <div className="name-box">
            <hi className="welcome-text">Welcome Back!</hi>
            </div>
            <p className="text">We know you’ve been working hard, let’s measure your progress</p>
            {/* <form> */}
                <input type="password" className="form-control enter-mail" id="email" placeholder="Enter password"/>
                <button className="btn proceed" >Proceed</button>
            {/* </form> */}
        </div>
    )
}