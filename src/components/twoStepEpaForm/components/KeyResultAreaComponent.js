import React, { useState, useEffect } from 'react';
import EpaInputField from '../../epaInputField/epaInputField'
import remove from '../../../assets/images/remove.svg'
// var lastIndex = 0;

const KeyResultAreaComponent = (props) => {
    var [next, setNext] = useState(false)
    var [totalWeight, setTotalWeight] = useState(0);
    var [AllKeyResultAreas, setAllKeyResultArea] = useState([]);
    var [currentKey, setCurrentKey] = useState(0);

    const moveToNext = () => {
        setNext(true)
        props.setNextView(true)
    }
    const EditKra = () => {
        setNext(false)
        props.setNextView(false)
    }

    const removeKra = (id) => {
        var kraToRemove = document.getElementById(id)
        kraToRemove.remove()
    }

   const  AddKeyResultArea = () => {
        //  lastIndex = AllKeyResultAreas.length -1;
        var newEmptyObj = new Object();
         setAllKeyResultArea([...AllKeyResultAreas, newEmptyObj]);
    }

    const forceUpdate =(newResult) => {
        setAllKeyResultArea(newResult);
    } 

    const RenderEpas = () => {
        return Array.from({ length: AllKeyResultAreas.length }).map((c, index) => {
           return  (<EpaInputField  setTotalWeight={setTotalWeight} currentTotalWeight={totalWeight} myIndex={index} 
            setAllKeyResultArea={setAllKeyResultArea} AllKeyResultAreas={AllKeyResultAreas} forceUpdate={forceUpdate}/>)
        })
    }
    return (
        <section  id="key-result-area" className={`col-5 ${next ? '' : 'active-step'} py-3`}>
            <article className="d-flex">
                <p className="steps">Step 1<span className="small-half">/2</span></p>
                {next ? <div className="edit-kra" style={{ cursor: "pointer" }} onClick={EditKra}>Edit</div> : <div className="">x</div>}
            </article>
            <p className="kra-sm-text pb-4">Please fill in all your Key Result Areas and their weights</p>
            <article className="d-flex">
                <p className="kra-sm-text split-txt ml-2">Key Result Areas (0)</p>
                <p className="ml-1 kra-sm-text">Weight</p>
            </article>
            <div id="input-space">
               {RenderEpas()}
                <div className="kra-sm-txt-blue pt-1" onClick={AddKeyResultArea}>
                    <span>+</span> <span>Add Key Result Area</span>
                </div>
            </div>

            <div className="d-flex justify-content-end kra-sm-text">
                <p>Total weight: <b>{totalWeight}%</b></p>
            </div>

            <div className="text-center">
                {next ? <button className="btn btn-success py-3 sub-epa-btn">Submit EPA</button> :
                    <button className="btn btn-primary next-step-btn py-3" onClick={moveToNext}>Save and Proceed to Step 2</button>}
            </div>
        </section>



    );
};

export default KeyResultAreaComponent;