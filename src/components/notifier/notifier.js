import React from 'react'
import Logo from '../../assets/images/logo.svg'
import Bell from '../../assets/images/bell.svg'
import Avatar from 'react-avatar';
import './notifier.css'
export default function notifier(props) {
    return (
        <div>
            <div className="row mx-0">
                <div className="col-5 py-2 px-0 d-flex justify-content-left pl-4">
                    <div className="row mx-0 logo">
                        <div className="col-4"><img src={Logo} alt="logo" /></div>
                        <div className="col-8"><div>Resource<br />Edge</div></div>
                    </div>
                </div>
                <div className="col-7 py-2 d-flex justify-content-end">
                    <div className="row mx-0">
                        <div className="col-6"><img src={Bell} alt="notification bell" /></div>
                        <div className="col-6"><Avatar name="Emma Okoye" className="rounded-circle" size={"25px"} /></div>
                    </div>
                </div>
            </div>
        </div>
    )
}
