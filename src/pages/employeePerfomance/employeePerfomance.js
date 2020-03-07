import React, { useState } from 'react'
import AppraiserAppraisalNav from '../../components/appraiser-appraisalNav/appraiser-appraisalNav'

function EmployeePerfomance() {
    var [tab, setTab] = useState('employeePerformance')

    return (
        <div className='row mx-0'>
            <div className="col-3 px-0"><AppraiserAppraisalNav tab={tab} setTab={setTab} /></div>
            <div className="col-10">

            </div>

        </div>
    )
}

export default EmployeePerfomance
