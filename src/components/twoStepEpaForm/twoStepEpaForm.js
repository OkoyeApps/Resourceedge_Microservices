import React, { useState } from 'react'
import './twoStepEpaForm.css'
import CustomEpaField from '../customEpaFeild/customEpaFeild'
import KeyResultAreaComponent from './components/KeyResultAreaComponent';
import KeyResultDetails from './components/KeyResultDetails'
function TwoStepEpaForm(props) {
    var [filled, setFilled] = useState(false)
    var [next, setNext] = useState(false)
    var [epaData, setEpaData] = useState([]);
    const moveToNext = () => {
        setNext(true)
    }

    return (
        <div className="row mx-0">
            <KeyResultAreaComponent setNextView={setNext} setEpaData={setEpaData} />

            <KeyResultDetails setNext={setNext} next={next} />
        </div>
    )
}

export default TwoStepEpaForm
