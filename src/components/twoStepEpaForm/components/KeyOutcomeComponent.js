import React, { useState, useEffect } from 'react';
import remove from '../../../assets/images/remove.svg'
import { connect } from 'react-redux'
import { updateKRA, RemoveKRA_From_list } from '../../../reduxStore/actions/krAction'
import CustomCalenderPicker from '../../customCalenderPicker/customCalenderPicker';

function KeyOutcomeComponent(props) {
    var { allKeyOutcomes, setAllKeyOutcomes, myIndex, temp, currentActive } = props

    const removeInputComponent = () => {
        allKeyOutcomes.splice(myIndex, 1)
        props.RemoveKRA_From_list(currentActive,myIndex)
        setAllKeyOutcomes(Array.from(allKeyOutcomes));
    }
    useEffect(() => {

    }, () => {
        props.oldData = {};
    })

    const handleChange = (e, value) => {     
        if(e === null){
            props.updateKRA(props.currentActive, props.myIndex, {timelimit : value});
        }else{
            var currentData = { ...currentData, [e.target.name]: e.target.value }
            props.updateKRA(props.currentActive, props.myIndex, currentData);
        }
    }

    return (
        <div className="keyOutcomeComponet">
            <article className="">
                <div className="row">
                    <div className="col-6">
                        <div className="">
                            <label className="form-label">Key Outcomes</label>
                            <input Value={props.oldData ? props.oldData.question : ''} type="text" className="form-control" disabled={temp ? false : true} name="question" onChange={handleChange} />
                        </div>
                    </div>
                    <div className="col-6">
                        <div>
                            <label className="form-label">Timeline</label>
                            <div className="d-flex align-items-baseline">
                                <CustomCalenderPicker  defaultValue={props.oldData ? props.oldData.timelimit : undefined} handleDatePick={(dateValue)=>{handleChange(null,dateValue)}}/>
                                <img src={remove} alt="remove" className="ml-2" onClick={removeInputComponent}/>
                            </div>
                        </div>
                    </div>
                </div>


            </article>
            <br />
        </div>
    )
}

export default connect(null, { updateKRA, RemoveKRA_From_list })(KeyOutcomeComponent)
