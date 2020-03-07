import React, { useEffect } from 'react'
import appraisalAvatar from '../../assets/images/appraisalAvatar.svg'
import { withRouter } from 'react-router-dom'
import peopleIcon from '../../assets/images/peopleIcon.svg'
import youIcon from '../../assets/images/youIcon.svg'

const AppraiserAppraisalNav = (props) => {

    var { setTab, tab } = props

    const handleTab = (selectedTab, link) => {
        props.history.push({ pathname: `/${link}` })
        setTab(selectedTab)
    }



    return (
        <div className="inner-sidebar text-center">
            <div>
                <img src={appraisalAvatar} alt="EPA Avatar" />
            </div>
            <div>
                Appraisal
                </div>

            <section className="tab-section">
                <ul style={{ marginTop: "1rem" }}>
                    <li className="subs"><img src={youIcon} alt="you" className="mr-3" />You</li>
                    <li onClick={() => { handleTab("self", "") }} className={`${tab === "self" ? "tabbed" : ""}`}>Appraise Self</li>
                    <li onClick={() => { handleTab("appraisal", "") }} className={`${tab === "appraisal" ? "tabbed" : ""}`}>Appraisal Results</li>
                </ul>
            </section>

            <section className="tab-section">
                <ul style={{ marginTop: "1rem" }}>
                    <li className="subs"><img src={peopleIcon} alt="people" className="mr-3" />People (5)</li>
                    <li onClick={() => { handleTab("employeePerformance", "employee_performance_agreement/view") }} className={`${tab === "employeePerformance" ? "tabbed" : ""}`}>Your Appraisees</li>
                </ul>
            </section>
        </div>
    )
}

export default withRouter(AppraiserAppraisalNav)