import React, { useState, useEffect } from 'react';
import remove from '../../../assets/images/remove.svg'
import { connect } from 'react-redux'
import { updateKRA } from '../../../reduxStore/actions/krAction'
import CustomCalenderPicker from '../../customCalenderPicker/customCalenderPicker';

function KeyOutcomeComponent(props) {
    var { next, setNext, allKeyOutcomes, setAllKeyOutcomes, myIndex } = props

    const removeInputComponent = () => {
        allKeyOutcomes.splice(myIndex, 1)
        setAllKeyOutcomes(Array.from(allKeyOutcomes));
    }

    const handleChange = (e) => {
        var currentData = { ...currentData, [e.target.name]: e.target.value }
        props.updateKRA(props.currentActive, props.myIndex, currentData)
    }

    console.log("rendering in key outcome")
    return (
        <div>
            <article className="mt-3">
                <div className="row">
                    <div className="col-md-6">
                        <div className="">
                            <label className="form-label kra-sm-text">Key Outcomes</label>
                            <input type="text" className="form-control" disabled={next ? false : true} name="question" onChange={handleChange} />
                        </div>
                    </div>
                    <div className="col-md-6 d-flex align-item-center">
                        <div className="w-100">
                            <label className="form-label kra-sm-text">Timeline</label>
                            <div className=" d-flex align-item-center">
                                <CustomCalenderPicker />
                                <div onClick={removeInputComponent} className=" d-flex align-item-center"><img src={remove} alt="remove kra" className="remove-kra ml-2" /></div>
                            </div>
                        </div>
                    </div>
                </div>
            </article>
        </div>
    )
}
const mapStateToProps = (state) => {
    console.log("ww", state)
}

export default connect(mapStateToProps, { updateKRA })(KeyOutcomeComponent)
