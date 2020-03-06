import React from 'react';
import './appraiseSelf.css'

const AppraiseSelf = () => {
    return (
        <div className="appraise-self-wrapper">
            <div className="row">
                <div className="col-10 text-left py-4">
                    <div className="row mb-2">
                        <div className="col-12 apprais-header">Learnable Physical Internship </div>
                    </div>
                    <div className="row mb-3">
                        <div className="col-12 d-flex" >
                            <span className="appraise-weights">Weight: <b>56%</b></span>
                            <span className="ml-2 appraise-weights">Appraiser: <b>Ositadinma Nwangwu</b></span>
                            <span className="ml-2 appraise-weights">HOD: <b>Ekene Odum</b></span>
                            {/* <span className="ml-2 appraise-weights">Weight: <b>56%</b></span>
                                    <span className="ml-2 appraise-weights">Weight: <b>56%</b></span> */}
                        </div>
                    </div>
                    <br />
                    <div className="row mb-3">
                        <div className="col-12">
                            <table className="w-100 keyoutcome-table">
                                <tr>
                                    <th style={{ width: "70%" }}>Key Outcomes</th>
                                    <th>Deadline</th>
                                </tr>
                                <tr>
                                    <td className="d-flex"><span className="mr-1">1.</span><span> Supervise and facilitate the preparation of Learnable 2020’s curriculum</span></td>
                                    <td>15 November 2020</td>
                                </tr>
                                <tr>
                                    <td className="d-flex"><span className="mr-1">2.</span><span> Supervise and facilitate the preparation of Learnable 2020’s curriculum</span></td>
                                    <td>15 November 2020</td>
                                </tr>
                                <tr>
                                    <td className="d-flex"><span className="mr-1">3.</span><span> Supervise and facilitate the preparation of Learnable 2020’s curriculum</span></td>
                                    <td>15 November 2020</td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <br />
                    <div className="row">
                        <div className="col-12">
                            <b>1/4</b>
                        </div>
                    </div>
                </div>

                <div className="col-2 form-body p-0 d-flex justify-content-center" >
                    <div className="d-flex flex-column justify-content-between w-70 h-100">
                        <div></div>
                        <div className="scores d-block">
                            <div className="score-header">Your Score</div>
                            <div className="d-block mb-2">
                                <select className="form-control">
                                    <option>1</option>
                                </select>
                                <label>average</label>
                            </div>
                            <div className="d-block mb-2">
                                <select className="form-control">
                                    <option>1</option>
                                </select>
                                <label>average</label>
                            </div>
                            <div className="d-block mb-2">
                                <select className="form-control">
                                    <option>1</option>
                                </select>
                                <label>average</label>
                            </div>
                        </div>
                        <div className="mb-4">
                            <button className="form-control appraise-self-btn">Next</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default AppraiseSelf