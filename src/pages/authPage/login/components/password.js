import React, { useState } from 'react';

export default function Password() {
    
    return (
        <div className="login-box">
            <div className="name-box">
            <hi className="welcome-text">Hello Eliezer!</hi>
            </div>
            <p className="text">Please enter your passoword</p>
            {/* <form> */}
                <input type="password" className="form-control enter-mail" id="password" placeholder="Password"/>
                <button className="btn proceed" >Proceed</button>
            {/* </form> */}
        </div>
    )
}