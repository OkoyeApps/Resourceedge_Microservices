import React, { useState } from 'react'

function KeyOutcomeComponent(props) {
    var { next, setNext } = props

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
            </article>
        </div>
    )
}

export default KeyOutcomeComponent
