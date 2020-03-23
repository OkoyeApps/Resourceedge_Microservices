import React, { useState, useEffect } from 'react'
import KeyOutcomeComponent from './KeyOutcomeComponent'
function KeyResultDetails(props) {

    var { next, setNext } = props
    var [allKeyOutcomes, setAllKeyOutcomes] = useState([])

    const AddKeyResultArea = () => {
        var newEmptyObj = new Object();
        setAllKeyOutcomes([...allKeyOutcomes, newEmptyObj]);
    }


    const RenderKeyOutcome = () => {
        return Array.from({ length: allKeyOutcomes.length }).map((c, index) => {
            return (<KeyOutcomeComponent next={next} setNext={setNext} allKeyOutcomes={allKeyOutcomes} setAllKeyOutcomes={setAllKeyOutcomes} myIndex={index} />)
        })
    }


    return (
        <section id="key-result-area-details" className={`col-7 py-3 ${next ? "active-step" : "inactive-krad"}`}>
            <p className="steps">Step 2<span className="small-half">/2</span></p>
            <p className="kra-sm-text">Now enter the following details for each Key Results Area on the left respectively</p>

            <article className="d-flex pt-3">
                <div className="mr-4">
                    <label className="form-label kra-sm-text">Appraiser</label>
                    <input type="text" className="form-control" disabled={next ? false : true} />
                </div>
                <div>
                    <label className="form-label kra-sm-text">Head of Department</label>
                    <select className="form-control" disabled={next ? false : true} >
                        <option></option>
                    </select>
                </div>
            </article>


            {RenderKeyOutcome()}


            <div className="kra-sm-txt-blue pt-2 px-3" onClick={AddKeyResultArea}>
                {next ? <div> <span>+</span> <span>Add Key Outcome</span></div> : <></>}
            </div>
        </section>
    )
}

export default KeyResultDetails
