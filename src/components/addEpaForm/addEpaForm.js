import React from 'react';
import './addEpaForm.css';
import plusIcon from '../../assets/images/plusIcon.svg'

const EpaForm = () => {
    return (
        <div className="EpaForm-wrapper">
            <div className="row">
                <div className="col-5 p-3">
                    <div className="mb-5 form-intro">Eliezer’s EPA (Draft)</div>
                    <div>
                        <div className="row mb-4 epa-form-header">
                            <div className="col-9">Key Result Areas</div>
                            <div className="col-3 text-center">Weight</div>
                        </div>
                        <div className="row mb-4 epa-form-tap">
                            <div className="col-9">Learnable Physical Internship</div>
                            <div className="col-3 text-center">56%</div>
                        </div>
                        <div className="row mb-4 epa-form-tap">
                            <div className="col-9">Learnable Physical Internship</div>
                            <div className="col-3 text-center">56%</div>
                        </div>
                        <div className="row mb-4 epa-form-tap">
                            <div className="col-9">Learnable Physical Internship</div>
                            <div className="col-3 text-center">56%</div>
                        </div>
                        <div className="row mb-4 epa-form-tap active-epa-tab py-2">
                            <div className="col-9">
                                <input className="form-control w-100"/>
                            </div>
                            <div className="col-3 text-center">
                                <input className="form-control w-100 text-center" type="number"/>
                            </div>
                        </div>
                        <div className="row mb-4">
                            <div className="col-12 add-text d-flex align-items-center">
                                <img src={plusIcon} alt="add" className="mr-2" />
                                <span>Add Key Result Area</span>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-12">
                                <div className="d-flex justify-content-between">
                                    <span className="form-error-message">*Total weight is less than 100%</span>
                                    <div className="d-flex">
                                        <span className="epa-total-score">Total weight:</span><span className="form-intro ml-2">99%</span>
                                    </div>
                                </div>
                                <button className="form-control w-100 epa-submit-btn">Submit</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div className="col-7 form-body pt-5">
                    <div className="row mb-4">
                        <div className="col-6 d-block">
                            <label>Appraiser</label>
                            <input className="form-control w-100" />
                        </div>
                        <div className="col-6 d-block">
                            <label>Head of Department</label>
                            <input className="form-control w-100" />
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-6 d-block">
                            <label>Key Outcome</label>
                            <input className="form-control w-100" />
                        </div>
                        <div className="col-6 d-block mb-4">
                            <label>Timeline</label>
                            <input className="form-control w-100" type="date" />
                        </div>
                    </div>
                    <div className="row">
                        <div className="col-12 add-text d-flex align-items-center">
                            <img src={plusIcon} alt="add" className="mr-2" />
                            <span>Add Key Outcome</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default EpaForm