import React, { useState } from 'react';
import './appraisalResult.css';

export default function AppraisalResult() {

    return (
        <div>
            <div className=" row page-sizing">
                <div className="appraisal-score">
                    <p>Q1 2020 Overall Appraisal Score</p>
                    <div>
                        <h1>0.0</h1>
                        <p>out of 5</p>
                    </div>
                    <button className="btn score-button">N/A</button>
                </div>
                <div className="score-breakdown">
                    <div>
                        <div><p>Learnable Physical Internship</p></div>
                        <div className="score-upload-progress">
                            <p>0</p>
                            <div className="progress progress-adjust"></div>
                            <p>0 of 56%</p>
                        </div>
                    </div>
                    <div>
                        <div><p>Social Media</p></div>
                        <div className="score-upload-progress">
                            <p>0</p>
                            <div className="progress progress-adjust"></div>
                            <p>0 of 14%</p>
                        </div>
                    </div>
                    <div>
                        <div><p>ICDL</p></div>
                        <div className="score-upload-progress">
                            <p>0</p>
                            <div className="progress progress-adjust"></div>
                            <p>0 of 25%</p>
                        </div>
                    </div>
                    <div>
                        <div><p>Fencing and Wiring</p></div>
                        <div className="score-upload-progress">
                            <p>0</p>
                            <div className="progress progress-adjust"></div>
                            <p>0 of 5%</p>
                        </div>
                    </div>
                </div>
                <div className="no-appraisal">
                    <p>You haven’t been appraised this quarter. When you get appraised, you’ll see the results here</p>
                </div>
            </div>
        </div>
    )
}