import React, { useState } from 'react'
import './twoStepEpaForm.css'
import CustomEpaField from '../customEpaFeild/customEpaFeild'
import KeyResultAreaComponent from './components/KeyResultAreaComponent';
import KeyResultDetails from './components/KeyResultDetails'
import KeyOutcomeDetailParent from './components/keyOutcomeDetailParent';

function TwoStepEpaForm(props) {
    var [next, setNext] = useState(false)
    var [TotalKrasAdded, setTotalKrasAdded] = useState([]);
    var [currentIndex, setCurrentIndex] = useState(null)

    return (
        <div className="row mx-0">
            <KeyResultAreaComponent setNextView={setNext} setTotalKrasAdded={setTotalKrasAdded} setCurrentIndex={setCurrentIndex} setShow={props.setShow} closeModal={props.closeModal} />
            <KeyOutcomeDetailParent ActiveKraIndex={currentIndex} kraLength={TotalKrasAdded} closeModal={props.closeModal} />
        </div>
    )
}

export default TwoStepEpaForm
