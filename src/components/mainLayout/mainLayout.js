import React, { useState } from 'react'
import Notifier from '../notifier/notifier'
import DashIcon from "../../assets/images/dashIcon.svg"
import EpaIcon from '../../assets/images/epaIcon.svg'
import AppraisalIcon from '../../assets/images/appraisalIcon.svg'

import './mainLayout.css'
export default function MainLayout(props) {
    var [position, setPosition] = useState("dash")



    const handleSwitch = (clickedPosition) => {
        setPosition(clickedPosition)
    }
    return (
        <div>
            <div className="row mx-0">
                <div className="col-12 px-0">
                    <Notifier />
                </div>
            </div>
            <div className="row mx-0">
                <div className="col-1 narrow-bar d-flex justify-content-center align-items-center">
                    <section>
                        <div className={`my-5 ${position === "dash" ? "clicked" : "un-clicked"}`} onClick={() => { handleSwitch("dash") }}>
                            <img src={DashIcon} alt="dashboard icon" />
                        </div>
                        <div className={`my-5 ${position === "epa" ? "clicked" : "un-clicked"}`} onClick={() => { handleSwitch("epa") }}>
                            <img src={EpaIcon} alt="EPA icon" />
                        </div>
                        <div className={`my-5 ${position === "appraisal" ? "clicked" : "un-clicked"}`} onClick={() => { handleSwitch("appraisal") }}>
                            <img src={AppraisalIcon} alt="Appraisal icon" />
                        </div>
                    </section>
                </div>
                <div className="col-11 main-content pl-0">
                    {props.children}
                </div>
            </div>
        </div>
    )
}
