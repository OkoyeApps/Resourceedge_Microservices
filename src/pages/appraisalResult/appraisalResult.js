import React, { useState } from 'react';
import './appraisalResult.css';
import ScoreBoard from '../../components/scoreBoard/scoreBoard'
import AppraisalNav from '../../components/appraisalNav/appraisalNav'
import QuarterBar from '../../components/quarterBar/quarterBar'
export default function AppraisalResult() {
    var [tab, setTab] = useState("self")
    return (
        <div className="row mx-0">
            <div className="col-2 px-0">
                <AppraisalNav tab={tab} setTab={setTab} />
            </div>
            <div className="col-10 page-sizing">
                <div className="d-flex justify-content-center">
                    <QuarterBar />
                </div>
                <ScoreBoard />
                <div className="no-appraisal">
                    <p>You haven’t been appraised this quarter. When you get appraised, you’ll see the results here</p>
                </div>
            </div>
        </div>
    )
}