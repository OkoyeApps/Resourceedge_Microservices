import React, { useState, useEffect } from 'react'
import EpaAvatar from '../../assets/images/epaAvatar.svg'
import { withRouter } from 'react-router-dom'

function EmployeeEpaNav(props) {
    const [tab, setTab] = useState("view")


    const handleTab = (selectedTab, link) => {
        props.history.push({ pathname: `${link}` })
        setTab(selectedTab)
    }


    useEffect(() => {
        console.log("props", props)
        if (props.location.pathname === '/epa/view') {
            setTab("view")
        } else if (props.location.pathname === '/epa/upload') {
            setTab('upload')
        }
    }, [])
    return (
        <div>
            <div className="row mx-0">
                <div className="col-12 px-0 inner-sidebar text-center">
                    <div>
                        <img src={EpaAvatar} alt="EPA Avatar" />
                    </div>
                    <div>
                        Employment performance<br /> agreement
                </div>

                    <section className="tab-section">
                        <ul>
                            <li onClick={() => { handleTab("view", '/epa/view') }} className={`${tab === "view" ? "tabbed" : ""}`}>View</li>
                            <li onClick={() => { handleTab("upload", '/epa/upload') }} className={`${tab === "upload" ? "tabbed" : ""}`}>Upload</li>
                        </ul>
                    </section>
                </div>
            </div>
        </div>
    )
}

export default withRouter(EmployeeEpaNav)
