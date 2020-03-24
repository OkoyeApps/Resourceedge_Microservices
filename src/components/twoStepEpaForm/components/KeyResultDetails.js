import React, { useState, useEffect } from 'react'
import KeyOutcomeComponent from './KeyOutcomeComponent';
import { connect } from 'react-redux'

import SupervisorEntry from './keyOutcomeSupervisorEntry';

function KeyResultDetails(props) {
    var { next, setNext } = props
    var [allKeyOutcomes, setAllKeyOutcomes] = useState([])
    const AddKeyResultArea = () => {
        var newEmptyObj = new Object();
        setAllKeyOutcomes([...allKeyOutcomes, newEmptyObj]);
    }
    useEffect(() => {
        // searchSupervisor()
    })
    const RenderKeyOutcome = () => {
        return Array.from({ length: allKeyOutcomes.length }).map((c, index) => {
            return (<KeyOutcomeComponent next={next} setNext={setNext} allKeyOutcomes={allKeyOutcomes} setAllKeyOutcomes={setAllKeyOutcomes} myIndex={index} currentActive={props.currentActive} epaData={props.epaData} />)
        })
    }
    // const result = [
    //     { name: "Arthur", nickname: "kidmeeno" },
    //     { name: "Joshua", nickname: "Josh Sherran" },
    //     { name: "Nonso", nickname: "nonicalx" }
    // ]
    console.log("ttt", props.data)
    return (
        <section id="key-result-area-details" className={`col-7 py-3 ${next ? "active-step" : "inactive-krad"}`}>
            <p className="steps">Step 2<span className="small-half">/2</span></p>
            <p className="kra-sm-text">Now enter the following details for each Key Results Area on the left respectively</p>
            <SupervisorEntry next={next} setNext={setNext} currentActive={props.currentActive} />
            {RenderKeyOutcome()}
            <div className="kra-sm-txt-blue pt-2 px-3" onClick={AddKeyResultArea}>
                {next ? <div> <span>+</span> <span>Add Key Outcome</span></div> : <></>}
            </div>
        </section>
    )
}
export default connect()(KeyResultDetails)