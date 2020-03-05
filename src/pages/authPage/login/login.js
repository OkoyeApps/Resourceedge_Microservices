import React from 'react';
import './login.css'

export default function login() {
    return (
        <div className="login-box">
            <div className="name-box">
            <hi className="welcome-text">Welcome Back!</hi>
            </div>
            <p className="text">We know you’ve been working hard, let’s measure your progress</p>
            <form>
                <input type="email" className="form-control enter-mail" id="email" placeholder="Please enter your company email address"/>
                <button className="btn proceed">Proceed</button>
            </form>
        </div>
    )
}