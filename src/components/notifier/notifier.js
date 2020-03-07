import React, { useState } from 'react'
import Logo from '../../assets/images/logo.svg'
import Bell from '../../assets/images/bell.svg'
import Avatar from 'react-avatar';
import UserDropDown from '../userDropDown/userDropDown'
import './notifier.css'
import searchIcon from '../../assets/images/Search.svg'
import NotificationCard from '../notificationCard/notificationCard'
export default function Notifier(props) {

    var [userCard, setUserCard] = useState(false)
    var [notificationCard, setNotificationCard] = useState(false)

    const showUserCard = () => {
        setUserCard(!userCard)
    }
    const showNotificationCard = () => {
        setNotificationCard(!notificationCard)
    }


    return (
        <div className="notifier d-flex">
            <div className="py-2 d-flex justify-content-center pl-0" style={{ width: "5%" }}>
                {/* <div className="row mx-0 logo">
                        <div className="col-4"></div>
                    </div> */}
                <img src={Logo} alt="logo" />
            </div>
            <div className="py-2 pl-0" style={{ width: "95%" }}>
                {/* <div className="col-8"><div>Resource<br />Edge</div></div>
                    <div className="row mx-0">
                        <div className="col-6"><img src={Bell} alt="notification bell" /></div>
                        <div className="col-6"><Avatar name="Emma Okoye" className="rounded-circle" size={"25px"} /></div>
                    </div> */}
                <div className="row m-0 p-0">
                    <div className="col-2 px-0">
                        <div className="logo-text">Resource<br />Edge</div>
                    </div>
                    <div className="col-10 pl-0">
                        <div className="row">
                            <div className="col-6">
                                <div className="form-control d-flex align-item-center search-field">
                                    <img src={searchIcon} alt="search" />
                                    <form className="w-100">
                                        <input placeholder="search" className="w-100 ml-2 h-100" />
                                    </form>
                                </div>
                            </div>
                            <div className="col-6 d-flex align-items-center">
                                <div className="mx-0 d-flex align-items-center justify-content-end w-100 pr-2">
                                    <img src={Bell} alt="notification bell" onClick={showNotificationCard} />

                                    <Avatar name="Emma Okoye" className="rounded-circle ml-2" size={"25px"} onClick={showUserCard} style={{ cursor: "pointer" }} />

                                    {/* <div className="col-6"><img src={Bell} alt="notification bell" /></div> */}
                                    {/* <div className="col-6"><Avatar name="Emma Okoye" className="rounded-circle" size={"25px"} /></div> */}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className={`${userCard ? 'slide' : 'no-slide'}`}>
                <UserDropDown />
            </div>
            <div className={`${notificationCard ? 'slide' : 'no-slide'}`}>
                <NotificationCard />
            </div>
        </div>
    )
}
