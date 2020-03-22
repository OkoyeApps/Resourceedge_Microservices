import React, { useState, useEffect } from 'react'
import './appraiseNav.css'
import peopleIcon from '../../assets/images/peopleIcon.svg'
import youIcon from '../../assets/images/youIcon.svg'
import EpaAvatar from '../../assets/images/epaAvatar.svg'
import { withRouter } from 'react-router-dom'

function AppraiseNav(props) {
    var { setTab, tab } = props

    const handleTab = (selectedTab, link) => {
        props.history.push({ pathname: `${link}` })
        setTab(selectedTab)
    }

    useEffect(() => {
        if (props.location.pathname === '/appraisees/details' || props.location.pathname === '/appraisees') {
            setTab("appraise")
        } else if (props.location.pathname === '/epa/view') {
            setTab("view")
        } else if (props.location.pathname === '/epa/upload') {
            setTab('upload')
        }
    }, [props.location.pathname])
    return (

        <div className="inner-sidebar">
            <div className="text-center mb-5">
                <div>
                    <img src={EpaAvatar} alt="EPA Avatar" />
                </div>
                <div>
                    Employment performance<br /> agreement
                </div>
            </div>

            <section className="tab-section">
                <ul style={{ marginTop: "1rem" }}>
                    <li className="subs">
                        <div className="w-75 mx-auto">
                            <div className="row">
                                <div className="col-3"><img src={youIcon} alt="you" /></div>
                                <div className="col-9 subs d-flex align-items-center">You</div>
                            </div>
                        </div>
                    </li>
                    <li onClick={() => { handleTab("view", '/epa/view') }} className={`${tab === "view" ? "tabbed" : ""}`}>
                        <div className="w-75 mx-auto">
                            <div className="row">
                                <span className="col-3"></span>
                                <span className="col-9 d-flex align-items-center inner_sidebar_tabs">View</span>
                            </div>
                        </div>
                    </li>
                    <li onClick={() => { handleTab("upload", '/epa/upload') }} className={`${tab === "upload" ? "tabbed" : ""}`}>
                        <div className="w-75 mx-auto">
                            <div className="row">
                                <span className="col-3"></span>
                                <span className="col-9 d-flex align-items-center inner_sidebar_tabs">Upload</span>
                            </div>
                        </div>
                    </li>
                </ul>
            </section>

            <section className="tab-section">
                <ul style={{ marginTop: "1rem" }}>
                    <li className="subs">
                        <div className="w-75 mx-auto">
                            <div className="row">
                                <div className="col-3"><img src={peopleIcon} alt="people" /></div>
                                <div className="col-9 subs d-flex align-items-center">People (5)</div>
                            </div>
                        </div>
                    </li>
                    <li onClick={() => { handleTab("appraise", "/appraisees") }} className={`${tab === "appraise" ? "tabbed" : ""}`}>
                        <div className="w-75 mx-auto">
                            <div className="row">
                                <span className="col-3"></span>
                                <span className="col-9 d-flex align-items-center inner_sidebar_tabs">Your Appraisees</span>
                            </div>
                        </div>
                    </li>
                </ul>
            </section>
        </div>

    )
}

export default withRouter(AppraiseNav)