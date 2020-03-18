import React from 'react'
import './twoStepEpaForm.css'
function TwoStepEpaForm(props) {
    return (
        <div className="row mx-0">
            <section id="key-result-area" className="col-5 active-step py-3">
                <article className="d-flex">
                    <p className="steps">Step 1/<span className="small-half">2</span></p>
                    <div className="">x</div>
                </article>
                <p className="kra-sm-text pb-4">Please fill in all your Key Result Areas and their weights</p>
                <article className="d-flex">
                    <p className="kra-textbox kra-sm-text">Key Result Areas (0)</p>
                    <p className="ml-1 kra-sm-text">Weight</p>
                </article>

                <article className="d-flex kra-inputs">

                    <input type="text" className="form-control mr-2 kra-textbox" />
                    <input type="text" className="form-control kra-percent" placeholder="00%" />

                </article>

                <div className="kra-sm-txt-blue pt-1">
                    <span>+</span> <span>Add Key Result Area</span>
                </div>

                <div className="d-flex justify-content-end kra-sm-text">
                    <p>Total weight: <b>0%</b></p>
                </div>

                <div className="text-center">
                    <button className="btn btn-primary">Save and Proceed to Step 2</button>
                </div>
            </section>

            <section id="key-result-area-details" className="col-7 py-3 inactive-krad">
                <p className="steps">Step 2/<span className="small-half">2</span></p>
                <p>Now enter the following details for each Key Results Area on the left respectively</p>

                <article className="d-flex">
                    <div>
                        <label className="form-label">Appraiser</label>
                        <input type="text" className="form-control" />
                    </div>
                    <div>
                        <label className="form-label">Head of Department</label>
                        <select className="form-control">
                            <option></option>
                        </select>
                    </div>
                </article>

                <article className="d-flex">
                    <div>
                        <label className="form-label">Key Outcomes</label>
                        <input type="text" className="form-control" />
                    </div>
                    <div>
                        <label className="form-label">Timeline</label>
                        <input type="text" className="form-control" />
                    </div>
                </article>
            </section>
        </div>
    )
}

export default TwoStepEpaForm
