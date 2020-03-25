import React, { useState, useEffect } from 'react';
import EpaInputField from '../../epaInputField/epaInputField';
import KraDisplayComponent from './kraDisplayComponent';
import { connect } from 'react-redux';
import { SeedReducer, UploadkeyResultAreas } from '../../../reduxStore/actions/krAction';
import Alert from '../../alert'
// var lastIndex = 0;

const KeyResultAreaComponent = (props) => {
    var [next, setNext] = useState(false);
    var [totalWeight, setTotalWeight] = useState(0);
    var [AllKeyResultAreas, setAllKeyResultArea] = useState([]);
    var [isValidForNext, setIsvalidForNext] = useState(false);
    const [alertMe, setalertMe] = useState({ show: false, title: '', type: '', position: '' })

    const moveToNext = () => {
        setNext(true);
        props.setNextView(true);
    };
    const EditKra = () => {
        setNext(false);
        props.setNextView(false);
    };



    const AddKeyResultArea = () => {
        var newEmptyObj = new Object();
        setAllKeyResultArea([...AllKeyResultAreas, newEmptyObj]);
    };

    const forceUpdate = (newResult) => {
        setAllKeyResultArea(newResult);
    };

    const validateForNonEmptyFields = () => {
        var isValid = AllKeyResultAreas.includes(x => x.name === '' && x.weight === '');
        if (!isValid) {
            moveToNext();
            props.SeedReducer(AllKeyResultAreas);
            props.setTotalKrasAdded(AllKeyResultAreas.length);
            props.setCurrentIndex(0);
        } else {
            alert("one of your key result area field is empty");
        }
    };


    const RenderEpas = () => {
        return Array.from({ length: AllKeyResultAreas.length }).map((c, index) => {
            return (<EpaInputField setTotalWeight={setTotalWeight} currentTotalWeight={totalWeight} myIndex={index}
                setAllKeyResultArea={setAllKeyResultArea} AllKeyResultAreas={AllKeyResultAreas} forceUpdate={forceUpdate} c={c} />);
        });
    };

    const SubmitFinalUploadOfEPA = () => {
        props.UploadkeyResultAreas((success, data) => {
            if (success) {
                props.closeModal();
                props.setShow(true)
            } else {
                //show error messages
            }
        });
    };

    return (
        <>
            <section id="key-result-area" className={`col-5 ${next ? '' : 'active-step'} py-3 px-0`}>
                <article className="d-flex px-3">
                    <p className="steps">Step 1<span className="small-half">/2</span></p>
                    {next ? <div className="edit-kra" style={{ cursor: "pointer" }} onClick={EditKra}>Edit</div> : <div className="">x</div>}
                </article>
                <p className="kra-sm-text pb-4 px-3">Please fill in all your Key Result Areas and their weights</p>
                <article className="d-flex px-3">
                    <p className="kra-sm-text split-txt ml-2">Key Result Areas ({AllKeyResultAreas.length})</p>
                    <p className="kra-sm-text">Weight</p>
                </article>
                <div id="input-space">
                    {next === false ? RenderEpas() : <KraDisplayComponent allKRA={AllKeyResultAreas} setCurrentIndex={props.setCurrentIndex} pickKRA={props.pickKRA} />}
                    <div className="kra-sm-txt-blue pt-1 px-3" onClick={AddKeyResultArea}>
                        {next === false ? <div> <span>+</span> <span>Add Key Result Area</span></div> : <></>}
                    </div>
                </div>
                <div className={"alwaysBottom"}>
                    <div className="d-flex justify-content-end kra-sm-text pr-3">
                        <p>Total weight: <b>{totalWeight}%</b></p>
                    </div>

                    <div className="text-center ">
                        {
                            next ?
                                <button className="btn btn-success py-3 sub-epa-btn" onClick={SubmitFinalUploadOfEPA}>Submit EPA</button> :
                                <button className="btn btn-primary next-step-btn py-3" style={{ background: totalWeight === 100 ? "" : "gray" }} onClick={validateForNonEmptyFields} disabled={totalWeight === 100 ? false : true}>Save and Proceed to Step 2</button>}
                    </div>
                </div>



            </section>

        </>
    );
};




export default connect(null, { SeedReducer, UploadkeyResultAreas })(KeyResultAreaComponent);