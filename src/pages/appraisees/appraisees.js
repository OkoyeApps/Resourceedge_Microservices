import React, { useState } from 'react'
import EpaAvatar from '../../assets/images/epaAvatar.svg'

export default function Appraisees() {
    const [tab, setTab] = useState("view")


    const handleTab = (selectedTab) => {
        setTab(selectedTab)
    }
    return (
        <div className="row mx-0">
            <div className="col-3 inner-sidebar text-center px-0">
                <div>
                    <img src={EpaAvatar} alt="EPA Avatar" />
                </div>
                <div>
                    Employment performance<br /> agreement
                </div>

                <section className="tab-section">
                    <ul>
                        <li>You</li>
                        <li onClick={() => { handleTab("view") }} className={`${tab === "view" ? "tabbed" : ""}`}>View</li>
                        <li onClick={() => { handleTab("upload") }} className={`${tab === "upload" ? "tabbed" : ""}`}>Upload</li>
                    </ul>
                </section>

                <section className="tab-section">
                    <ul>
                        <li>People (5)</li>
                        <li onClick={() => { handleTab("appraise") }} className={`${tab === "appraise" ? "tabbed" : ""}`}>Your Appraisees</li>
                    </ul>
                </section>
            </div>
        </div>
    )
}
