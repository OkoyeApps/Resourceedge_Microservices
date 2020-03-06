import React from 'react';
import Notification from '../../components/notifications/notifications'
import Avatar from 'react-avatar';
import './appraseDetailedView.css';
import CustomModal from '../../components/customModal/customModal';
import backArrow from '../../assets/images/backArrowIcon.svg';
import { Link } from 'react-router-dom';



const AppraseDetailView = () => {
    return (
        <div className="row">
            <div className="col-12 d-flex my-4">
                <Link>
                <img src={backArrow} alt="back" className="mr-2"/>
                <span className="edit-apprais">back</span>
                </Link>
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
                        <span className="ml-2 appraise-weights">Weight: <b>56%</b></span>
                        <span className="ml-2 appraise-weights">Weight: <b>56%</b></span>
                        <span className="ml-2 appraise-weights">Weight: <b>56%</b></span>
                        <span className="ml-2 appraise-weights">Weight: <b>56%</b></span>
                        </div>
                    </div>
                    <div className="row mb-3">
                        <div className="col-12">
                        <table className="w-100 keyoutcome-table">
                                <tr>
                                    <th>Key Outcomes</th>
                                    <th>Deadline</th>
                                </tr>
                                <tr>
                                    <td>1.  Supervise and facilitate the preparation of Learnable 2020’s curriculum</td>
                                    <td>15 November 2020</td>
                                </tr>
                                <tr>
                                    <td>2.  Supervise and facilitate the preparation of Learnable 2020’s curriculum</td>
                                    <td>15 November 2020</td>
                                </tr>
                                <tr>
                                    <td>3.  Supervise and facilitate the preparation of Learnable 2020’s curriculum</td>
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
    )
}

export default AppraseDetailView