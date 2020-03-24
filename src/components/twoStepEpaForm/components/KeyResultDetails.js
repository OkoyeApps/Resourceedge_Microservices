import React, { useState } from 'react';
import KeyOutcomeComponent from './KeyOutcomeComponent';
import SupervisorEntry from './keyOutcomeSupervisorEntry';
import { connect } from 'react-redux';

function KeyResultDetails(props) {
    let { existingKeyArea, currentActive } = props
    var { temp } = props
    var [allKeyOutcomes, setAllKeyOutcomes] = useState([])
    const AddKeyResultArea = () => {
        var newEmptyObj = new Object();
        setAllKeyOutcomes([...allKeyOutcomes, newEmptyObj]);
    }

    const RenderKeyOutcome = () => {
        if (existingKeyArea[currentActive] && existingKeyArea[currentActive].keyoutcomes && allKeyOutcomes.length === 0) {
            return existingKeyArea[currentActive].keyoutcomes.map((x, index) => {
                return (<KeyOutcomeComponent oldData={{ question: x.question, timeline: x.timeline }} temp={temp} allKeyOutcomes={allKeyOutcomes} setAllKeyOutcomes={setAllKeyOutcomes} myIndex={index} currentActive={currentActive} />)
            })
        } else {
            return Array.from({ length: allKeyOutcomes.length }).map((c, index) => {
                return (<KeyOutcomeComponent temp={temp} allKeyOutcomes={allKeyOutcomes} setAllKeyOutcomes={setAllKeyOutcomes} myIndex={index} currentActive={currentActive} />)
            })
        }
    }

    return (
        <section id="key-result-area-details" className={`col-7 py-3 ${temp ? "active-step" : "inactive-krad"}`}>
            <p className="steps">Step 2<span className="small-half">/2</span></p>
            <p className="kra-sm-text">Now enter the following details for each Key Results Area on the left respectively</p>


            <SupervisorEntry temp={temp} currentActive={props.currentActive} />

            {RenderKeyOutcome()}


            {temp ? <div className="kra-sm-txt-blue pt-2 px-3" onClick={AddKeyResultArea}>
                <div> <span>+</span> <span>Add Key Outcome</span></div>
            </div>
                : <></>
            }
        </section>
    )
}
const mapStateToProps = (state) => {

    return (
        {
            existingKeyArea: state.KRA
        }
    )
}
export default connect(mapStateToProps, {})(KeyResultDetails)