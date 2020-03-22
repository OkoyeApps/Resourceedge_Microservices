import React, { useState, useEffect } from 'react'
import Notifier from '../notifier/notifier'
import DashIcon from "../../assets/images/dashIcon.svg"
import EpaIcon from '../../assets/images/epaIcon.svg'
import AppraisalIcon from '../../assets/images/appraisalIcon.svg'
import AppraisalNav from '../appraisalNav/appraisalNav'
import AppraiserNav from '../appraiseNav/appraiseNav'
import AppraiserAppraisalNav from '../appraiser-appraisalNav/appraiser-appraisalNav'
import EmployeeEpaNav from '../employeeEpaNav/employeeEpaNav'
import { withRouter } from 'react-router-dom'

import './mainLayout.css'
function MainLayout(props) {
    var [position, setPosition] = useState("dash")
    var [tab, setTab] = useState("self")
    console.log("wew", props.purpose)


    const handleSwitch = (clickedPosition, link) => {
        console.log("now", clickedPosition)
        setPosition(clickedPosition)
        props.history.push({ pathname: `${link}` })
    }

    useEffect(() => {
        setPosition(props.purpose)
    }, [props.location.pathname])


    const renderInnerNav = () => {
        if (props.role === "appraiser") {
            if (props.purpose === 'appraisal') {
                return <AppraiserAppraisalNav tab={tab} setTab={setTab} />
            } else if (props.purpose === 'epa') {
                return <AppraiserNav tab={tab} setTab={setTab} />
            } else if (props.purpose === 'dash') {
                return <></>
            }

        } else if (props.role === 'employee') {
            if (props.purpose === 'appraisal') {
                return <AppraisalNav tab={tab} setTab={setTab} />
            } else if (props.purpose === 'epa') {
                return <EmployeeEpaNav tab={tab} setTab={setTab} />
            } else if (props.purpose === 'dash') {
                return <></>
            }
        }
    }

    return (
        <div>
            <div className="row mx-0 stick-top">
                <div className="col-12 px-0">
                    <Notifier />
                </div>
            </div>
            <div className="w-100 d-flex content-wrapper">
                <div className="narrow-bar d-flex justify-content-center align-items-center" style={{ width: "5%" }}>
                    <section>
                        <div className={`my-5 ${position === "dash" ? "clicked" : "un-clicked"}`} onClick={() => { handleSwitch("dash", "/epa/view") }}>
                            <img src={DashIcon} alt="dashboard icon" />
                        </div>
                        <div className={`my-5 ${position === "epa" ? "clicked" : "un-clicked"}`} onClick={() => { handleSwitch("epa", "/epa/view") }}>
                            <img src={EpaIcon} alt="EPA icon" />
                        </div>
                        <div className={`my-5 ${position === "appraisal" ? "clicked" : "un-clicked"}`} onClick={() => { handleSwitch("appraisal", "/appraisal/self-evaluation") }}>
                            <img src={AppraisalIcon} alt="Appraisal icon" />
                        </div>
                    </section>
                </div>
                <div className="main-content" style={{ width: "95%" }}>
                    <div className="row m-0">
                        <div className="col-2  pl-0">
                            {renderInnerNav()}
                        </div>
                        <div className="col-10">
                            {props.children}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}


export default withRouter(MainLayout)