import React, { useState, useEffect } from 'react';
import remove from '../../assets/images/remove.svg';


const EpaInputField = ({setTotalWeight, currentTotalWeight, myIndex, setAllKeyResultArea, AllKeyResultAreas, forceUpdate}) => {
    const removeInputComponent = () => {
        AllKeyResultAreas.splice(myIndex, 1)
       setAllKeyResultArea(Array.from(AllKeyResultAreas));
    }

    const AddNewResultArea = (e) => {
        var tempObj = AllKeyResultAreas[myIndex];
        var currentObj = tempObj;
        if(e.target.name === 'weight') {
            var currentWeight = isNaN(parseInt(tempObj.weight)) ? 0 : parseInt(tempObj.weight)
            var reducedWeight = currentTotalWeight -  currentWeight;
            if(reducedWeight > 0){
                var weightToAdd =  isNaN(parseInt(e.target.value)) ? 0 : parseInt(e.target.value)
                    var nextTotalWeight = reducedWeight + weightToAdd;
                    if(nextTotalWeight <= 100){
                        setTotalWeight(nextTotalWeight);
                    }else{
                        e.target.value = 0
                        var result = currentTotalWeight - currentWeight
                        setTotalWeight(result)
                    }
                }else{
                    setTotalWeight(isNaN(parseInt(e.target.value)) ? 0 : parseInt(e.target.value));
                }
            }
            currentObj = {...currentObj, [e.target.name] : e.target.value}
            AllKeyResultAreas[myIndex] = currentObj;
             setAllKeyResultArea(AllKeyResultAreas)
    }

    const renderComponet = () => {
               return (
               <article className="d-flex kra-inputs mb-2" id="kra-0">
                    <input type="text" name="name" className="form-control mr-2 kra-textbox"  onChange={AddNewResultArea} />
                    <input type="number" name="weight" min="0" step="1" className="form-control kra-percent" placeholder="00%" onChange={AddNewResultArea} />
                    <div onClick={removeInputComponent}><img src={remove} alt="remove kra" className="remove-kra mt-2 ml-1" /></div>
               </article>)
    }

    return (
        <div id="kra-inputs">
            {renderComponet()}
        </div>
    )
}

export default EpaInputField