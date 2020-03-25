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
    const moveToNext = () => {
        setNext(true)
    }
    return (
        <div className="row mx-0">
            <KeyResultAreaComponent setNextView={setNext} setTotalKrasAdded={setTotalKrasAdded} setCurrentIndex={setCurrentIndex} closeModal={props.closeModal} setShow={props.setShow} />

            {/* <KeyResultDetails temp={next} currentActive={currentIndex} /> */}
            <KeyOutcomeDetailParent ActiveKraIndex={currentIndex} kraLength={TotalKrasAdded} />
        </div>
    )
}

export default TwoStepEpaForm
