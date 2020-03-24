import React, { useState, useEffect } from 'react';
import remove from '../../../assets/images/remove.svg'
import { connect } from 'react-redux'
import { updateKRA } from '../../../reduxStore/actions/krAction'
import CustomCalenderPicker from '../../customCalenderPicker/customCalenderPicker';

function KeyOutcomeComponent(props) {
    var { allKeyOutcomes, setAllKeyOutcomes, myIndex, temp } = props

    const removeInputComponent = () => {
        allKeyOutcomes.splice(myIndex, 1)
        setAllKeyOutcomes(Array.from(allKeyOutcomes));
    }

    const handleChange = (e, value) => {
        
        if(e === null){
            console.log("correct value format",value)
            props.updateKRA(props.currentActive, props.myIndex, {timeline : value});
        }else{
            var currentData = { ...currentData, [e.target.name]: e.target.value }
            props.updateKRA(props.currentActive, props.myIndex, currentData);
        }
    }

    console.log("rendering in key outcome")
    return (
        <div>
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
                            <div className="d-flex align-items-center">
                                <CustomCalenderPicker key={Math.random()+1*Math.random()+0.2} defualtValue={props.oldData ? props.oldData.timeline : ''} handleDatePick={(dateValue)=>{handleChange(null,dateValue)}}/>
                                <img src={remove} alt="remove" className="ml-2" onClick={removeInputComponent}/>
                            </div>
                        </div>
                    </div>
                </div>


            </article>
        </div>
    )
}
const mapStateToProps = (state) => {
    console.log("ww", state)
}

export default connect(mapStateToProps, { updateKRA })(KeyOutcomeComponent)
