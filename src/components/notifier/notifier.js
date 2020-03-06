import React from 'react'
import Logo from '../../assets/images/logo.svg'
import Bell from '../../assets/images/bell.svg'
import Avatar from 'react-avatar';
import './notifier.css'
import searchIcon from '../../assets/images/Search.svg'
export default function notifier(props) {
    return (
        <div className="notifier d-flex">
                <div className="py-2 d-flex justify-content-center pl-0" style={{width:"6%"}}>
                    {/* <div className="row mx-0 logo">
                        <div className="col-4"></div>
                    </div> */}
                    <img src={Logo} alt="logo" />
                </div>
                <div className="py-2 pl-0" style={{width:"94%"}}>
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
                                <div className="col-6">
                                    <div className="row mx-0 d-flex align-items-center justify-content-end">
                                        <img src={Bell} alt="notification bell" />
                                        <Avatar name="Emma Okoye" className="rounded-circle ml-2" size={"25px"} />
                                        {/* <div className="col-6"><img src={Bell} alt="notification bell" /></div> */}
                                        {/* <div className="col-6"><Avatar name="Emma Okoye" className="rounded-circle" size={"25px"} /></div> */}
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </div>
    )
}
