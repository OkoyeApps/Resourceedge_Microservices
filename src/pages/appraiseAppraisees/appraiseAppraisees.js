import React, { useState } from 'react';
import Notification from '../../components/notifications/notifications'
import AppraiserAppraisalNav from '../../components/appraiser-appraisalNav/appraiser-appraisalNav'

import CirculerProgressBar from '../../components/circulerProgressBar/circulerProgressBar';
import Avatar from 'react-avatar';
import './appraiseAppraisees.css'



const AppraiseAppraisees = () => {
    const [tab, setTab] = useState("view")
    return (
        <div className="row mx-0">
            <div className="col-2 px-0">
                <AppraiserAppraisalNav tab={tab} setTab={setTab} />
            </div>
            <div className="col-10 inliner pt-5">
                <div className="row mx-0">
                    <div className="col-12">
                        <div className="row">
                            <div className="col-3 d-flex justify-content-center mb-4">
                                <div className="card w-100 py-4 px-2 border-0">
                                    <div className="row mb-4 d-flex align-items-center">
                                        <div className="col-3">
                                            <div>
                                                <Avatar size={"8vmin"} name="Eliezer Ajah" className="rounded-circle" />
                                            </div>
                                        </div>
                                        <div className="col-9 appraisees-detail d-flex flex-column">
                                            <span>Eliezer Ajah</span>
                                            <span>Genesys</span>
                                            <span>e.ajah@genesystechhub.com</span>
                                        </div>
                                    </div>
                                    <div className="row mb-4">
                                        <div className="col-12">
                                            <div className="d-flex justify-content-center align-items-center">
                                                <CirculerProgressBar rate={1.2} appraiseesPercent={90} appraiserPercent={30} />
                                            </div>
                                        </div>
                                    </div>
                                    <div className="row mb-2">
                                        <div className="col-12 d-flex justify-content-between">
                                            <div>Eliezer’s: <b>4</b> </div>
                                            <div>Yours: N/A</div>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col-12 d-flex justify-content-center">
                                            <button className="form-control w-50 epa-submit-btn">Appraise</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-3 d-flex justify-content-center mb-4">
                                <div className="card w-100 py-4 px-2 border-0">
                                    <div className="row mb-4 d-flex align-items-center">
                                        <div className="col-3">
                                            <div>
                                                <Avatar size={"8vmin"} name="Eliezer Ajah" className="rounded-circle" />
                                            </div>
                                        </div>
                                        <div className="col-9 appraisees-detail d-flex flex-column">
                                            <span>Eliezer Ajah</span>
                                            <span>Genesys</span>
                                            <span>e.ajah@genesystechhub.com</span>
                                        </div>
                                    </div>
                                    <div className="row mb-4">
                                        <div className="col-12">
                                            <div className="d-flex justify-content-center align-items-center">
                                                <CirculerProgressBar rate={1.2} appraiseesPercent={90} appraiserPercent={100} />
                                            </div>
                                        </div>
                                    </div>
                                    <div className="row mb-2">
                                        <div className="col-12 d-flex justify-content-between">
                                            <div>Eliezer’s: <b>4</b> </div>
                                            <div>Yours: N/A</div>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col-12 d-flex justify-content-center">
                                            <button className="form-control w-50 epa-submit-btn">Appraise</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-3 d-flex justify-content-center mb-4">
                                <div className="card w-100 py-4 px-2 border-0">
                                    <div className="row mb-4 d-flex align-items-center">
                                        <div className="col-3">
                                            <div>
                                                <Avatar size={"8vmin"} name="Eliezer Ajah" className="rounded-circle" />
                                            </div>
                                        </div>
                                        <div className="col-9 appraisees-detail d-flex flex-column">
                                            <span>Eliezer Ajah</span>
                                            <span>Genesys</span>
                                            <span>e.ajah@genesystechhub.com</span>
                                        </div>
                                    </div>
                                    <div className="row mb-4">
                                        <div className="col-12">
                                            <div className="d-flex justify-content-center align-items-center">
                                                <CirculerProgressBar rate={1.2} appraiseesPercent={90} appraiserPercent={100} />
                                            </div>
                                        </div>
                                    </div>
                                    <div className="row mb-2">
                                        <div className="col-12 d-flex justify-content-between">
                                            <div>Eliezer’s: <b>4</b> </div>
                                            <div>Yours: N/A</div>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col-12 d-flex justify-content-center">
                                            <button className="form-control w-50 epa-submit-btn">Appraise</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-3 d-flex justify-content-center mb-4">
                                <div className="card w-100 py-4 px-2 border-0">
                                    <div className="row mb-4 d-flex align-items-center">
                                        <div className="col-3">
                                            <div>
                                                <Avatar size={"8vmin"} name="Eliezer Ajah" className="rounded-circle" />
                                            </div>
                                        </div>
                                        <div className="col-9 appraisees-detail d-flex flex-column">
                                            <span>Eliezer Ajah</span>
                                            <span>Genesys</span>
                                            <span>e.ajah@genesystechhub.com</span>
                                        </div>
                                    </div>
                                    <div className="row mb-4">
                                        <div className="col-12">
                                            <div className="d-flex justify-content-center align-items-center">
                                                <CirculerProgressBar rate={1.2} appraiseesPercent={90} appraiserPercent={100} />
                                            </div>
                                        </div>
                                    </div>
                                    <div className="row mb-2">
                                        <div className="col-12 d-flex justify-content-between">
                                            <div>Eliezer’s: <b>4</b> </div>
                                            <div>Yours: N/A</div>
                                        </div>
                                    </div>
                                    <div className="row">
                                        <div className="col-12 d-flex justify-content-center">
                                            <button className="form-control w-50 epa-submit-btn">Appraise</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default AppraiseAppraisees;