import React, { useState, useEffect } from 'react'
import Notifier from '../notifier/notifier'
import DashIcon from "../../assets/images/dashIcon.svg"
import EpaIcon from '../../assets/images/epaIcon.svg'
import AppraisalIcon from '../../assets/images/appraisalIcon.svg'
import { withRouter } from 'react-router-dom'

import './mainLayout.css'
function MainLayout(props) {
    var [position, setPosition] = useState("dash")



    const handleSwitch = (clickedPosition, link) => {
        console.log("now", clickedPosition)
        setPosition(clickedPosition)
        props.history.push({ pathname: `${link}` })
    }

    useEffect(() => {
        setPosition(props.purpose)
    }, [])

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
                        <div className={`my-5 ${position === "dash" ? "clicked" : "un-clicked"}`} onClick={() => { handleSwitch("dash", "/employee_performance_agreement") }}>
                            <img src={DashIcon} alt="dashboard icon" />
                        </div>
                        <div className={`my-5 ${position === "epa" ? "clicked" : "un-clicked"}`} onClick={() => { handleSwitch("epa", "/employee_performance_agreement") }}>
                            <img src={EpaIcon} alt="EPA icon" />
                        </div>
                        <div className={`my-5 ${position === "appraisal" ? "clicked" : "un-clicked"}`} onClick={() => { handleSwitch("appraisal", "/appraisal/self-evaluation") }}>
                            <img src={AppraisalIcon} alt="Appraisal icon" />
                        </div>
                    </section>
                </div>
                <div className="main-content" style={{ width: "95%" }}>
                    <div className="row m-0">
                        <div className="col-12 pl-0">
                            {props.children}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}


export default withRouter(MainLayout)