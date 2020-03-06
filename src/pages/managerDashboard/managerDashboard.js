import React from 'react';
import './managerDashboard.css';
import Avatar from "react-avatar";
import add from '../../assets/images/plusIcon.svg';


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
                            <img src={add} alt="good icon"  className=""/>
                            <p>Add Key Result Area</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default ManagerDashboard;
