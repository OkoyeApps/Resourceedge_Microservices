import React from 'react';
import './managerDashboard.css';
import Avatar from "react-avatar";


const ManagerDashboard = () => {
    return (
        <div className="manager-container">
            <div className="manager-back-select">
                <p>Back</p>
                <div className="row manager-appraisee-name">
                    <div className="manager-appraisee-icon-container">
                        <div className="ic">
                            <Avatar size={"100px"} name="Elizer Abe" className="rounded-circle"/>
                        </div>
                        <h2>Elizer Ajah</h2>
                        <h5>Genesys</h5>
                        <p>e.ajah@genesystechhub.com</p>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default ManagerDashboard;
