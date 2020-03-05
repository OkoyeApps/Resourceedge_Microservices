import React from 'react'
import AuthImg from '../../assets/images/authImg.png'
import './authLayout.css'
export default function authLayout(props) {
    return (
        <div className="row mx-0">
            <div className="col-3 px-0">
                <div>
                    <img src={AuthImg} alt="auth" className="authImg" />
                </div>
            </div>
            <div className="col-9 d-flex justify-content-center align-items-center">
                {props.children}
            </div>
        </div>
    )
}
