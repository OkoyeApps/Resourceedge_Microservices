import React, { useState } from 'react'
import './twoStepEpaForm.css'
import remove from '../../assets/images/remove.svg'
function TwoStepEpaForm(props) {
    var [filled, setFilled] = useState(false)
    var [next, setNext] = useState(false)



    const AddKRA = () => {
        const inputs = document.getElementById('kra-inputs')
        inputs.insertAdjacentHTML('beforeend', `<article class="d-flex kra-inputs mt-2"><input type="text" class="form-control mr-2 kra-textbox" /><input type="text" class="form-control kra-percent" placeholder="00%" id="percent-input" /><div><img src=${remove} class="remove-kra mt-2 ml-1"/></div></article>`)
    }


    const RemoveBtn = () => {
        return (
            <div><img src={remove} alt="remove kra" className="remove-kra mt-2 ml-1" onClick={() => { removeKra('kra-0') }} /></div>
        )
    }




    const handleKRAChange = () => {

    }

    const handleWeightChange = () => {

    }

    const moveToNext = () => {
        setNext(true)
    }
    const EditKra = () => {
        setNext(false)
    }

    const removeKra = (id) => {
        var kraToRemove = document.getElementById(id)
        kraToRemove.remove()
    }

    return (
        <div className="row mx-0">
            <section id="key-result-area" className={`col-5 ${next ? '' : 'active-step'} py-3`}>
                <article className="d-flex">
                    <p className="steps">Step 1<span className="small-half">/2</span></p>
                    {next ? <div className="edit-kra" style={{ cursor: "pointer" }} onClick={EditKra}>Edit</div> : <div className="">x</div>}
                </article>
                <p className="kra-sm-text pb-4">Please fill in all your Key Result Areas and their weights</p>
                <article className="d-flex">
                    <p className="kra-sm-text split-txt ml-2">Key Result Areas (0)</p>
                    <p className="ml-1 kra-sm-text">Weight</p>
                </article>
                <div id="input-space">
                    <div id="kra-inputs">
                        <article className="d-flex kra-inputs" id="kra-0">
                            <input type="text" className="form-control mr-2 kra-textbox" />
                            <input type="text" className="form-control kra-percent" placeholder="00%" />
                            <div><img src={remove} alt="remove kra" className="remove-kra mt-2 ml-1" onClick={() => { removeKra('kra-0') }} /></div>
                        </article>
                    </div>


                    <div className="kra-sm-txt-blue pt-1" onClick={AddKRA}>
                        <span>+</span> <span>Add Key Result Area</span>
                    </div>
                </div>

                <div className="d-flex justify-content-end kra-sm-text">
                    <p>Total weight: <b>0%</b></p>
                </div>

                <div className="text-center">
                    {next ? <button className="btn btn-success py-3 sub-epa-btn">Submit EPA</button> :
                        <button className="btn btn-primary next-step-btn py-3" onClick={moveToNext}>Save and Proceed to Step 2</button>}
                </div>
            </section>

            <section id="key-result-area-details" className={`col-7 py-3 ${next ? "active-step" : "inactive-krad"}`}>
                <p className="steps">Step 2<span className="small-half">/2</span></p>
                <p className="kra-sm-text">Now enter the following details for each Key Results Area on the left respectively</p>

                <article className="d-flex pt-3">
                    <div className="mr-4">
                        <label className="form-label kra-sm-text">Appraiser</label>
                        <input type="text" className="form-control" disabled />
                    </div>
                    <div>
                        <label className="form-label kra-sm-text">Head of Department</label>
                        <select className="form-control" disabled>
                            <option></option>
                        </select>
                    </div>
                </article>

                <article className="d-flex pt-3">
                    <div className="mr-4">
                        <label className="form-label">Key Outcomes</label>
                        <input type="text" className="form-control" disabled />
                    </div>
                    <div>
                        <label className="form-label">Timeline</label>
                        <input type="text" className="form-control" disabled />
                    </div>
                </article>
            </section>
        </div>
    )
}

export default TwoStepEpaForm
