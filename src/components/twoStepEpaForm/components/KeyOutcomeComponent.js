import React, { useState, useEffect } from 'react';
import remove from '../../../assets/images/remove.svg'
import { connect } from 'react-redux'
import { updateKRA } from '../../../reduxStore/actions/krAction'

function KeyOutcomeComponent(props) {
    var { allKeyOutcomes, setAllKeyOutcomes, myIndex, temp } = props

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
            <article className="d-flex pt-3">
                <div className="mr-4">
                    <label className="form-label">Key Outcomes</label>
                    <input type="text" className="form-control" disabled={temp ? false : true} name="question" onChange={handleChange} />
                </div>
                <div>
                    <label className="form-label">Timeline</label>
                    <input type="date" className="form-control" disabled={temp ? false : true} name="timeLimit" onChange={handleChange} />
                </div>
                <div className="mt-2">
                    <label className="form-label"></label>
                    <div onClick={removeInputComponent}><img src={remove} alt="remove kra" className="remove-kra mt-2 ml-1" /></div>
                </div>

            </article>
        </div>
    )
}
const mapStateToProps = (state) => {
    console.log("ww", state)
}

export default connect(mapStateToProps, { updateKRA })(KeyOutcomeComponent)
