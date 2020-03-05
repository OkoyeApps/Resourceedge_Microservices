import React, { useState } from 'react'
import EpaAvatar from '../../assets/images/epaAvatar.svg'
import EpaView from '../../components/epaView/epaView'
import EpaUpload from '../../components/epaUpload/epaUpload'
import './epa.css'

export default function Epa() {

    const [tab, setTab] = useState("view")


    const handleTab = (selectedTab) => {
        setTab(selectedTab)
    }
    return (
        <div className="row mx-0">
            <div className="col-3 px-0 inner-sidebar text-center">
                <div>
                    <img src={EpaAvatar} alt="EPA Avatar" />
                </div>
                <div>
                    Employment performance<br /> agreement
                </div>

                <section className="tab-section">
                    <ul>
                        <li onClick={() => { handleTab("view") }} className={`${tab === "view" ? "tabbed" : ""}`}>View</li>
                        <li onClick={() => { handleTab("upload") }} className={`${tab === "upload" ? "tabbed" : ""}`}>Upload</li>
                    </ul>
                </section>
            </div>
            <div className="col-9 epa-content">
                {tab === "view" ? <EpaView data={[1, 2, 3, 4]} /> : <EpaUpload />}
            </div>

        </div>
    )
}
