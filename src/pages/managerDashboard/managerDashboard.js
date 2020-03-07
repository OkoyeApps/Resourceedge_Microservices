import React from 'react';
import './managerDashboard.css';
import Avatar from "react-avatar";
import add from '../../assets/images/plusIcon.svg';
import good from '../../assets/images/Online.svg';


const ManagerDashboard = () => {
    return (
        <div className="manager-container">
            <div className="manager-back-select">
                <p>Back</p>
                <div className="row manager-appraisee-name">
                    <div className="manager-appraisee-icon-container">
                        <div className="ic">
                            <Avatar size={"100px"} name="Eliezer Ajah" className="rounded-circle"/>
                        </div>
                        <h2>Eliezer Ajah</h2>
                        <h5>Genesys</h5>
                        <p>e.ajah@genesystechhub.com</p>
                    </div>
                </div>
                <div className="row manager-info-list">
                    <div className="manager-year"><p>Year 2020</p></div>
                    <div className="manager-period"><p>Period: Q2</p></div>
                    <div className="manager-appraisal"><p>Appraiser: All</p></div>
                    <div className="manager-add">
                        <div>
                            <img src={add} alt="add"  className=""/>
                            <p>Add Key Result Area</p>
                        </div>
                    </div>
                </div>
                <div className="manager-employee-designation">
                    <div className="employee-designation-box">
                        <div>
                            <div>
                                <h3>Learnable Physical Internship&nbsp;&nbsp;<img src={good} alt="good"  className=""/></h3>
                            </div>
                        </div>
                        <div><p>Expand</p></div>
                    </div>
                    <div className="manager-appraiser-details">
                        <p>Weight: <b>15%</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Appraiser: <b>Ekene Odum</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HOD: <b>Ekene Odum</b></p>
                    </div>
                    <div className="manager-key-outcomes">
                        <p>Key Outcomes(3)</p>
                    </div>
                    <div>
                        <button type="button" className="btn manager-aprrove-buttons">Edit</button>
                        <button type="button" className="btn manager-aprrove-buttons">Approve</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default ManagerDashboard;
