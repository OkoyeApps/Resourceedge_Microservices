import React, { useState } from 'react'
import './twoStepEpaForm.css'
import CustomEpaField from '../customEpaFeild/customEpaFeild'
import KeyResultAreaComponent from './components/KeyResultAreaComponent';
import KeyResultDetails from './components/KeyResultDetails'
function TwoStepEpaForm(props) {
    var [filled, setFilled] = useState(false)
    var [next, setNext] = useState(false)

    const moveToNext = () => {
        setNext(true)
    }

    return (
        <div className="row mx-0">
            <KeyResultAreaComponent setNextView={setNext} />
<<<<<<< HEAD
            <section id="key-result-area-details" className={`col-7 py-3 ${next ? "active-step" : "inactive-krad"}`}>
                <p className="steps">Step 2<span className="small-half">/2</span></p>
                <p className="kra-sm-text">Now enter the following details for each Key Results Area on the left respectively</p>
=======
>>>>>>> 2b2cdb5c158437da521bf24c18abc033f7e12fc6

            <KeyResultDetails setNext={setNext} next={next} />
        </div>
    )
}

export default TwoStepEpaForm
