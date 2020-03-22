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


    useEffect(() => {
        if (props.location.pathname === '/appraisal/self-evaluation') {
            setTab("self")
        } else if (props.location.pathname === '/employee_performance_agreement/view') {
            setTab("appraisal")
        } else if (props.location.pathname === '/appraise/appraisees') {
            setTab('appraise')
        }
    }, [props.location.pathname])


    return (
        <div className="inner-sidebar">
            <div className="text-center mb-5">
                <div>
                    <img src={appraisalAvatar} alt="EPA Avatar" />
                </div>
                <div>
                    Appraisal
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
                    <li onClick={() => { handleTab("self", "appraisal/self-evaluation") }} className={`${tab === "self" ? "tabbed" : ""}`}>
                        <div className="w-75 mx-auto">
                            <div className="row">
                                <span className="col-3"></span>
                                <span className="col-9 d-flex align-items-center inner_sidebar_tabs">Appraise Self </span>
                            </div>
                        </div>
                    </li>
                    <li onClick={() => { handleTab("appraisal", "employee_performance_agreement/view") }} className={`${tab === "appraisal" ? "tabbed" : ""}`}>
                        <div className="w-75 mx-auto">
                            <div className="row">
                                <span className="col-3"></span>
                                <span className="col-9 d-flex align-items-center inner_sidebar_tabs">Appraisal Results</span>
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
                    <li onClick={() => { handleTab("appraise", "appraise/appraisees") }} className={`${tab === "appraise" ? "tabbed" : ""}`}>
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

export default withRouter(AppraiserAppraisalNav)
