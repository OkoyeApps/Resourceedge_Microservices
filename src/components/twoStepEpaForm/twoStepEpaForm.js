import React, { useState } from 'react'
import './twoStepEpaForm.css'
import CustomEpaField from '../customEpaFeild/customEpaFeild'
import KeyResultAreaComponent from './components/KeyResultAreaComponent';
function TwoStepEpaForm(props) {
    var [filled, setFilled] = useState(false)
    var [next, setNext] = useState(false)

    const moveToNext = () => {
        setNext(true)
    }

    return (
        <div className="row mx-0">
            <KeyResultAreaComponent setNextView={setNext} />

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

                <article className="d-flex pt-3">
                    <div className="mr-4">
                        <label className="form-label">Key Outcomes</label>
                        <input type="text" className="form-control" disabled={next ? false : true} />
                    </div>
                    <div>
                        <label className="form-label">Timeline</label>
                        <input type="text" className="form-control" disabled={next ? false : true} />
                    </div>
                </article>
            </section>
        </div>
    )
}

export default TwoStepEpaForm
