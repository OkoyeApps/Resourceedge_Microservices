import React from 'react';
import './rejectAppraisal.css'

const RejectAppraisal = () => {
    return (
        <div className="reject-appraisal-wrapper p-2">
            <div className="row">
                <div className="col-12 text-center mb-4 ">
                    <p className="intro-text">Reject the Key Result Area “Learnable Physical Internship” <strong>from Eliezer Ajah?</strong></p>
                </div>
                <div className="col-12 text-center mb-2">
                    <p className="instruction-text">Please tell us why you’re rejecting it</p>
                </div>
                <div className="col-12 mb-3">
                    <textarea className="w-100 h-100">
                    </textarea>
                </div>
                <div className="col-12 d-flex justify-content-center">
                    <div className="w-70 d-flex">
                        <button className="form-control mr-3 reject-btn">Cancel</button>
                        <button className="form-control approve-btn">Reject</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default RejectAppraisal