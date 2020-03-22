import React, { useState } from 'react';
import './appraisalResult.css';
import ScoreBoard from '../../components/scoreBoard/scoreBoard'
import QuarterBar from '../../components/quarterBar/quarterBar'
import ResultCard from '../../components/appraisalResultSheet/appraisalResultSheet'
export default function AppraisalResult() {
    var [tab, setTab] = useState("appraisal")
    return (
        <div className="row mx-0 ">
            <div className="col-12 page-sizing appraisal-result pl-0">
                <div className="d-flex justify-content-center">
                    <QuarterBar />
                </div>
                <div>
                    <ScoreBoard />
                </div>


                <div className="no-appraisal">
                    <p>You haven’t been appraised this quarter. When you get appraised, you’ll see the results here</p>
                </div>
                <div>
                    <ResultCard />
                    <ResultCard />
                    <ResultCard />
                    <ResultCard />
                </div>
            </div>
        </div>
    )
}