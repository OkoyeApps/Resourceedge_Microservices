import React, { useState, useEffect } from 'react';

export default function Email(props) {
    

    useEffect(()=>{
        props.checkForStep(1)
    },[])
    return (
        <div className="login-box">
            <div className="name-box">
                <hi className="welcome-text">Welcome Back!</hi>
                {/* {console.log(stage)} */}
            </div>
            <p className="text">We know you’ve been working hard, let’s measure your progress</p>
            {/* <form> */}
                <input type="email" className="form-control enter-mail" id="email" placeholder="Please enter your company email address"/>
                <button className="btn proceed" onClick={() => { props.checkForStep(2) }}>Proceed</button>
            {/* </form> */}
        </div>
    )
}