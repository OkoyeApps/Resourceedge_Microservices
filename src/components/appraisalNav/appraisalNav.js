import React from 'react'
import EpaAvatar from '../../assets/images/epaAvatar.svg'

const appraisalNav = (props) => {

    var { setTab, tab } = props

    const handleTab = (selectedTab) => {
        setTab(selectedTab)
    }
    return (
        <div className="inner-sidebar text-center">
            <div>
                <img src={EpaAvatar} alt="EPA Avatar" />
            </div>
            <div>
                Appraisal
                </div>

            <section className="tab-section">
                <ul style={{ marginTop: "1rem" }}>
                    <li onClick={() => { handleTab("self") }} className={`${tab === "self" ? "tabbed" : ""}`}>Self-Assessment</li>
                    <li onClick={() => { handleTab("appraisal") }} className={`${tab === "appraisal" ? "tabbed" : ""}`}>Appraisal Results</li>
                </ul>
            </section>
        </div>
    )
}

export default appraisalNav
