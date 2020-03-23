import React, { useState } from 'react'
import './twoStepEpaForm.css'
import CustomEpaField from '../customEpaFeild/customEpaFeild'
import KeyResultAreaComponent from './components/KeyResultAreaComponent';
import KeyResultDetails from './components/KeyResultDetails'
function TwoStepEpaForm(props) {
    var [filled, setFilled] = useState(false)
    var [next, setNext] = useState(false)
    var [epaData, setEpaData] = useState([]);
    var [currentIndex, setCurrentIndex] = useState(0)
    const moveToNext = () => {
        setNext(true)
    }
    console.log("what", epaData)
    console.log("current index", currentIndex)
    return (
        <div className="row mx-0">
            <KeyResultAreaComponent setNextView={setNext} setEpaData={setEpaData} setCurrentIndex={setCurrentIndex} />

            <KeyResultDetails setNext={setNext} next={next} currentActive={currentIndex} epaData={epaData} />
        </div>
    )
}

export default TwoStepEpaForm
