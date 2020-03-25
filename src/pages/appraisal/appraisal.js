import React, { useState } from 'react'
import Play from '../../assets/images/play.svg'
import './appraisal.css'
import CustomModal from '../../components/customModal/customModal';

export default function Appraisal(props) {
    var [tab, setTab] = useState("self")

    return (
        <div className="row mx-0">

            <div className="col-12 d-flex justify-content-center pl-0">
                <div className="text-center appraisal">
                    <h4>Appraise Yourself</h4>
                    <p className="mt-3"> The Self-Appraisal is the first of the 2 stages of performance appraisal. The aim is to encourage staff members to take responsibility for their own performance by assessing their own achievements or failures and promoting self-management of development goals.</p>


                    <CustomModal
                        content={<button className="appraisalBtn"><img src={Play} alt="begin appraisal" className="mr-2" /> Begin Appraisal</button>}
                        type={"appraise-self-modal"}
                        showArrow={true}
                    />
                </div>
            </div>
        </div>
    )
}
