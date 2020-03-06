import React, { useState, useEffect } from 'react'
import './appraiseNav.css'
import peopleIcon from '../../assets/images/peopleIcon.svg'
import youIcon from '../../assets/images/youIcon.svg'
import EpaAvatar from '../../assets/images/epaAvatar.svg'
import { withRouter } from 'react-router-dom'

function AppraiseNav(props) {
    var { setTab, tab } = props

    const handleTab = (selectedTab) => {
        setTab(selectedTab)
    }

    useEffect(() => {
        console.log("props", props)
        if (props.location.pathname === '/appraisees/details' || props.location.pathname === '/appraisees') {
            setTab("appraise")
        }
    }, [])
    return (

        <div className="inner-sidebar text-center">
            <div>
                <img src={EpaAvatar} alt="EPA Avatar" />
            </div>
            <div>
                Employment performance<br /> agreement
                </div>

            <section className="tab-section">
                <ul style={{ marginTop: "1rem" }}>
                    <li className="subs"><img src={youIcon} alt="you" className="mr-3" />You</li>
                    <li onClick={() => { handleTab("view") }} className={`${tab === "view" ? "tabbed" : ""}`}>View</li>
                    <li onClick={() => { handleTab("upload") }} className={`${tab === "upload" ? "tabbed" : ""}`}>Upload</li>
                </ul>
            </section>

            <section className="tab-section">
                <ul style={{ marginTop: "1rem" }}>
                    <li className="subs"><img src={peopleIcon} alt="people" className="mr-3" />People (5)</li>
                    <li onClick={() => { handleTab("appraise") }} className={`${tab === "appraise" ? "tabbed" : ""}`}>Your Appraisees</li>
                </ul>
            </section>
        </div>

    )
}

export default withRouter(AppraiseNav)