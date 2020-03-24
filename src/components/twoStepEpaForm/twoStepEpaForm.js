import React, { useState } from 'react'
import './twoStepEpaForm.css'
import CustomEpaField from '../customEpaFeild/customEpaFeild'
import KeyResultAreaComponent from './components/KeyResultAreaComponent';
import KeyResultDetails from './components/KeyResultDetails';
import KeyDetailParent from './components/KeyResultDetailsParent';




function TwoStepEpaForm(props) {
    var [next, setNext] = useState(false)
    var [epaData, setEpaData] = useState([]);
    var [keyResultAreas, setKeyResultAreas] = useState([]);
    var [pickedKRA, setPickedKRA] = useState(0);
    var [currentIndex, setCurrentIndex] = useState(0);
    // // var [keyResultComponent, setKeyResultComponet] = useState(false)
    // const keyResultComponet = keyResultAreas.map((current)=>(
    //     <>
    //         <KeyResultDetails setNext={setNext} next={next} currentActive={currentIndex} epaData={epaData} name={current.name} />
    //     </>
    // ))
    const moveToNext = () => {
        setNext(true)
    }
    console.log("what", epaData)
    console.log("current index", currentIndex);
    console.log("keyAreas selection", keyResultAreas);
    console.log("picked KRA", pickedKRA);
    return (
        <div className="row mx-0">
            <KeyResultAreaComponent setNextView={setNext}  setCurrentIndex={setCurrentIndex} setKeyResultArea={setKeyResultAreas} pickKRA={(index)=>{setPickedKRA(index)}}/>
           <KeyDetailParent kraIndex={currentIndex} totalkra={keyResultAreas.length}/>
           
           
           
           
           
            {/* {
                keyResultAreas.length === 0 ?
                <KeyResultDetails setNext={setNext} next={next} currentActive={currentIndex} />
                :
                keyResultComponet[pickedKRA]
            } */}
        </div>
    )
}

export default TwoStepEpaForm
