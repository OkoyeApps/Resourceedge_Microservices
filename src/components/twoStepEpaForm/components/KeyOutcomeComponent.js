import React, { useState, useEffect } from 'react';
import remove from '../../../assets/images/remove.svg'

function KeyOutcomeComponent(props) {
    var { next, setNext, allKeyOutcomes, setAllKeyOutcomes, myIndex } = props

    const removeInputComponent = () => {
        allKeyOutcomes.splice(myIndex, 1)
        setAllKeyOutcomes(Array.from(allKeyOutcomes));
    }

    console.log("rendering in key outcome")
    return (
        <div>
            <article className="d-flex pt-3">
                <div className="mr-4">
                    <label className="form-label">Key Outcomes</label>
                    <input type="text" className="form-control" disabled={next ? false : true} name="outcome" />
                </div>
                <div>
                    <label className="form-label">Timeline</label>
                    <input type="date" className="form-control" disabled={next ? false : true} name="timeline" />
                </div>
                <div className="mt-2">
                    <label className="form-label"></label>
                    <div onClick={removeInputComponent}><img src={remove} alt="remove kra" className="remove-kra mt-2 ml-1" /></div>
                </div>

            </article>
        </div>
    )
}

export default KeyOutcomeComponent
