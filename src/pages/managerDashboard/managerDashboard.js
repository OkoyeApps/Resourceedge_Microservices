import React from 'react';
import './managerDashboard.css';
import Avatar from "react-avatar";
import add from '../../assets/images/plusIcon.svg';
import good from '../../assets/images/Online.svg';
import CustomModal from '../../components/customModal/customModal';

const ManagerDashboard = () => {
    return (
        <div className="col-8">
            <div className="card w-100 mb-3 p-4">
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
                        <img src={add} alt="add"  className=""/>
                        <p>Add Key Result Area</p>
                    </div>
                </div>
            </div>
            <div className="card w-100 p-3">
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
        // <div className="manager-container">
        //     <div className="manager-back-select">
        //         <p>Back</p>
        //         <div className="row manager-appraisee-name">
        //             <div className="manager-appraisee-icon-container">
        //                 <div className="ic">
        //                     <Avatar size={"100px"} name="Eliezer Ajah" className="rounded-circle"/>
        //                 </div>
        //                 <h2>Eliezer Ajah</h2>
        //                 <h5>Genesys</h5>
        //                 <p>e.ajah@genesystechhub.com</p>
        //             </div>
        //         </div>
        //         <div className="manager-info-list">
        //             <div className="manager-year"><p>Year 2020</p></div>
        //             <div className="manager-period"><p>Period: Q2</p></div>
        //             <div className="manager-appraisal"><p>Appraiser: All</p></div>
        //             <div className="manager-add">
        //                 <div>
        //                     <img src={add} alt="add"  className=""/>
        //                     <p>Add Key Result Area</p>
        //                 </div>
        //             </div>
        //         </div>
        //         <div className="manager-employee-designation">
        //             <div className="employee-designation-box">
        //                 <div>
        //                     <div>
        //                         <h3>Learnable Physical Internship&nbsp;&nbsp;<img src={good} alt="good"  className=""/></h3>
        //                     </div>
        //                 </div>
        //                 <div><p>Expand</p></div>
        //             </div>
        //             <div className="manager-appraiser-details">
        //                 <p>Weight: <b>15%</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Appraiser: <b>Ekene Odum</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HOD: <b>Ekene Odum</b></p>
        //             </div>
        //             <div className="manager-key-outcomes">
        //                 <div className="manager-key-outcomes-head">
        //                     <p><b>Key Outcomes (3)</b></p>
        //                 </div>
        //                 <div className="manager-key-outcomes-head">
        //                     <p><b>Deadlines</b></p>
        //                 </div>
        //                 <div className="manager-key-outcomes-head this-head-margin">
        //                     <p>1.&nbsp;&nbsp;Supervise and facilitate the preparation of Learnable 2020's curriculum</p>
        //                 </div>
        //                 <div className="manager-key-outcomes-head this-head-margin">
        //                     <p>15 November 2020</p>
        //                 </div>
        //                 <div className="manager-key-outcomes-head this-head-margin">
        //                     <p>1.&nbsp;&nbsp;Supervise and facilitate the preparation of Learnable 2020's curriculum</p>
        //                 </div>
        //                 <div className="manager-key-outcomes-head this-head-margin">
        //                     <p>15 November 2020</p>
        //                 </div>
        //             </div>
        //             <div>
        //                 <button type="button" className="btn manager-aprrove-buttons">Edit</button>
        //                 <button type="button" className="btn manager-aprrove-buttons">Approve</button>
        //             </div>
        //         </div>
        //     </div>
        // </div>
    )
}

export default ManagerDashboard;
