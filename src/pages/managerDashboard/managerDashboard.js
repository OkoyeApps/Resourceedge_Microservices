import React, { useState } from 'react';
import './managerDashboard.css';
import Avatar from "react-avatar";
import add from '../../assets/images/plusIcon.svg';
import good from '../../assets/images/Online.svg';
import CustomModal from '../../components/customModal/customModal';
import Activity from '../../components/activity/activity';
import AppraiserAppraisalNav from '../../components/appraiser-appraisalNav/appraiser-appraisalNav'

const ManagerDashboard = (props) => {

    const [tab, setTab] = useState('sss')
    return (
        <div className="">
            <div className="row mx-0">
                <div className="col-2 px-0">
                    <AppraiserAppraisalNav setTab={setTab} tab={tab} />
                </div>
                <div className="col-10 pt-5 inliner">
                    <div className="row mx-0">
                        <div className="col-8">
                            <div className="card w-100 mb-3 p-4 border-0">
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
                            <div className="manager-info-list">
                                <div className="manager-year"><p><b>Year: 2020</b></p></div>
                                <div className="manager-period"><p><b>Period: Q2</b></p></div>
                                <div className="manager-appraisal"><p><b>Appraiser: All</b></p></div>
                                <div className="manager-add">
                                    <div>
                                        <img src={add} alt="add" className="" />
                                        <p>Add Key Result Area</p>
                                    </div>
                                </div>
                            </div>
                            <div className="card w-100 p-3  border-0">
                                <div className="row w-100 mb-2">
                                    <div className="col-10 apprais-header">Learnable Physical Internship </div>
                                    <div className="col-2 edit-apprais">Expand</div>
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
                                                <th style={{ width: "60%" }}>Key Outcomes</th>
                                                <th className="adjust-manager-outcomes">Deadline</th>
                                            </tr>
                                            <tr>
                                                <td className="d-flex"><span className="mr-1">1.</span><span> Supervise and facilitate the preparation of Learnable 2020’s curriculum</span></td>
                                                <td className="adjust-manager-outcomes">15 November 2020</td>
                                            </tr>
                                            <tr>
                                                <td className="d-flex"><span className="mr-1">2.</span><span> Supervise and facilitate the preparation of Learnable 2020’s curriculum</span></td>
                                                <td className="adjust-manager-outcomes">15 November 2020</td>
                                            </tr>
                                            <tr>
                                                <td className="d-flex"><span className="mr-1">3.</span><span> Supervise and facilitate the preparation of Learnable 2020’s curriculum</span></td>
                                                <td className="adjust-manager-outcomes">15 November 2020</td>
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

                        <Activity />


                    </div>
                </div>
            </div>

        </div>

    )
}

export default ManagerDashboard;
