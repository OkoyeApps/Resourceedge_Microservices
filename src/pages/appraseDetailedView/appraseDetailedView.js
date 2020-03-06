import React, { useState } from 'react';
import Notification from '../../components/notifications/notifications'
import Avatar from 'react-avatar';
import './appraseDetailedView.css';
import AppraiseNav from '../../components/appraiseNav/appraiseNav'
import { withRouter } from 'react-router-dom'

import CustomModal from '../../components/customModal/customModal';
import backArrow from '../../assets/images/backArrowIcon.svg';
import { Link } from 'react-router-dom';



const AppraseDetailView = (props) => {
    const [tab, setTab] = useState("view")

    const handleBack = () => {
        props.history.push({ pathname: "/appraisees" })
    }
    return (
        <div className="row">
            <div className="col-3 px-0">
                <AppraiseNav tab={tab} setTab={setTab} />
            </div>
            <div className="col-9 inliner">
                <div className="row mx-0">
                    <div className="col-12 d-flex my-4">
                        <img src={backArrow} alt="back" className="mr-2" onClick={handleBack} />
                        <span className="edit-apprais" onClick={handleBack}>back</span>
                    </div>

                    <div className="col-8">
                        <div className="card w-100 mb-2 p-4">
                            <div className="w-100  d-flex justify-content-center">
                                <div className="w-50 text-center">
                                    <ul className="appraises-detail-display">
                                        <li><Avatar size={"15vmin"} name="Eliezer Ajah" className="rounded-circle" /></li>
                                        <li className="name">Eliezer Ajah</li>
                                        <li className="department">Genesys</li>
                                        <li className="email">e.ajah@genesystechhub.com</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div className="card w-100 p-3">
                            <div className="row w-100 mb-2">
                                <div className="col-10 apprais-header">Learnable Physical Internship </div>
                                <div className="col-2 edit-apprais">Edit</div>
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
                            <div className="row">
                                <div className="col-12 d-flex justify-content-end">
                                    <div className="d-flex">
                                        <CustomModal
                                            content={<button className="form-control reject-btn">Reject</button>}
                                            type={"reject-appraisal"}
                                        />
                                        <button className="form-control approve-btn ml-3">Approve</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <Notification />
                </div>
            </div>
        </div>
    )
}

export default withRouter(AppraseDetailView)