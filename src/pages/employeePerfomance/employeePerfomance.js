import React, { useState } from 'react'
import AppraiserAppraisalNav from '../../components/appraiser-appraisalNav/appraiser-appraisalNav'
import Avatar from 'react-avatar'
import './employeePerformance.css'
import ResultCard from '../../components/appraisalResultSheet/appraisalResultSheet'

function EmployeePerfomance() {
    var [tab, setTab] = useState('employeePerformance')

    return (
        <div className='row mx-0'>
            <div className="col-2 px-0"><AppraiserAppraisalNav tab={tab} setTab={setTab} /></div>
            <div className="col-10 wrap-view">
                <div className="row mx-0">
                    <div className='col-6'>
                        <div className="personal-card mt-4">
                            <div className="text-center">
                                <Avatar size={"100px"} name="Eliezer Ajah" className="rounded-circle" />
                            </div>
                            <h4 className="text-center">Eliezer Ajah</h4>
                            <h6 className="text-center">Genesys</h6>
                            <address className="text-center mb-0">e.ajah@genesystechhub.com</address>
                        </div>
                    </div>
                    <div className='col-6 d-flex align-items-center'>
                        <div className="appraisal-score mt-4">
                            <p>Q1 2020 Overall Appraisal Score</p>
                            <div>
                                <h1>0.0</h1>
                                <p>out of 5</p>
                            </div>
                            <button className="btn score-button">N/A</button>
                        </div>
                    </div>
                </div>
                <section className="row mx-0">
                    <div className="col-12">
                        <ResultCard />
                    </div>
                </section>
            </div>

        </div>
    )
}

export default EmployeePerfomance
