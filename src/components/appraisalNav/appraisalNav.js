import React, { useEffect } from 'react'
import appraisalAvatar from '../../assets/images/appraisalAvatar.svg'
import { withRouter } from 'react-router-dom'
const AppraisalNav = (props) => {

    var { setTab, tab } = props

    const handleTab = (selectedTab, link) => {
        props.history.push({ pathname: `/${link}` })
        setTab(selectedTab)
    }


    useEffect(() => {
        if (props.location.pathname === '/appraisal/self-evaluation') {
            setTab("self")
        } else if (props.location.pathname === '/employee_performance_result/view') {
            setTab('appraisal')
        }
    }, [props.location.pathname])


    return (
        <div className="inner-sidebar text-center">
            <div>
                <img src={appraisalAvatar} alt="EPA Avatar" />
            </div>
            <div>
                Appraisal
                </div>

            <section className="tab-section pt-4">
                <ul style={{ marginTop: "1rem" }}>
                    <li onClick={() => { handleTab("self", "appraisal/self-evaluation") }} className={`${tab === "self" ? "tabbed" : ""}`}>Self-Assessment</li>
                    <li onClick={() => { handleTab("appraisal", "employee_performance_result/view") }} className={`${tab === "appraisal" ? "tabbed" : ""}`}>Appraisal Results</li>
                </ul>
            </section>
        </div>
    )
}

export default withRouter(AppraisalNav)
