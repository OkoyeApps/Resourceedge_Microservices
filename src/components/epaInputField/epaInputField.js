import React, { useState, useEffect } from 'react';
import remove from '../../assets/images/remove.svg';


const EpaInputField = () => {
    const [epaInput, setEpaInput] = useState([]);
    const [epaInputValue, setEpaInputValue] = useState([]);
    // const [epaValues, setEpaValues] = useState([]);
    const [percentInputValue, setPercentInputValue] = useState([]);
    const [reMount, setRemount] = useState(false);
    var epaValues;
    var percentValues;

    const addMoreInputField = () => {
        console.log(epaValues,percentValues,epaInput)
        setEpaInput([...epaInput, {
            value: {
                epaValue: epaValues,
                epaPercent: percentValues
            }
        }])
        setRemount(!reMount)
    }

    const removeInputComponent = (index) => {
        console.log("removed index", index);
        epaInput.splice(index, 1)
        console.log("finally", epaInput)
        setRemount(!reMount)
    }
    console.log(epaInput.length)

    const renderComponet = () => {
        console.log(epaInputValue, percentInputValue);
        if(epaInput.length >= 1){
            console.log("we cn go ahead")
            // setEpaValues([...epaValues, epaInputValue, percentInputValue])
        }
        return epaInput.map((current, i) => {
            return (
                <article className="d-flex kra-inputs mb-2" id="kra-0">
                    <input type="text" className="form-control mr-2 kra-textbox" id="epatype" onChange={(e) => {epaValues = e.target.value}} />
                    <input type="text" className="form-control kra-percent" id="epapercent" placeholder="00%" onChange={(e) => { percentValues = e.target.value}} />
                    <div onClick={() => { removeInputComponent(i) }}><img src={remove} alt="remove kra" className="remove-kra mt-2 ml-1" /></div>
                </article>
            )
        })
    }
    useEffect(() => {
        console.log(epaInput.length)
    }, [reMount]);
    return (
        <div id="kra-inputs">
            {renderComponet()}
            <div className="kra-sm-txt-blue pt-1" onClick={addMoreInputField}>
                <span>+</span> <span>Add Key Result Area</span>
            </div>
        </div>
    )
}

export default EpaInputField