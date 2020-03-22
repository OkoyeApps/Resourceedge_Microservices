import React, { Component } from 'react';
import remove from '../../assets/images/remove.svg';


class CustomEpaField extends Component {
    constructor(props){
        super(props)
        this.state={
            epaInput:[],
            epaValues:[]
        }
    }

    // const [epaInput, setEpaInput] = useState([]);
    // const [epaInputValue, setEpaInputValue] = useState([]);
    // const [percentInputValue, setPercentInputValue] = useState([]);
    
    addMoreInputField = () => {
        // console.log("was clicked", epaInput.length&&epaInput.length, epaInputValue, percentInputValue);
        this.setState({epaInput:[...this.state.epaInput, {
            component:
                this.state.epaInput.length,
            value: {
                epaValue: "",
                epaPercent: ""
            }
        }],count:this.state.epaInput.length})
        console.log(this.state)
    }
    handleChange = (e) => {
        let {epaInput,count,epaValues} = this.state
        e.preventDefault()
        var valueKey = {[`${e.target.id}${epaInput[count].component}`]:e.target.value}
        // this.setState({epaValues:[...this.state.epaValues,{[valueKey]:e.target.value}]},()=>{console.log(this.state)})
        this.setState({epaValues:[...this.state.epaValues,valueKey]},()=>{console.log(this.state)})
    }
    removeInputComponent = (index) => {
        console.log("removed index", index);
        // let oldArray = epaInput
        this.state.epaInput.splice(index, 1)
        // this.state.percentInputValue.splice(index, 1)
        // this.state.epaInputValue.splice(index, 1)
        // console.log("finally",epaInput,percentInputValue,epaInputValue)
        // // setEpaInput(oldArray)
        // console.log("epa ooo", oldArray)
    }

    renderComponet = () => {
        let {epaInput} = this.state
        if (epaInput !== undefined){
            return epaInput.map((current, i) => {
                // console.log(epaInputValue, percentInputValue);
                return (
                    <article className="d-flex kra-inputs mb-2" id="kra-0">
                        <input type="text" className="form-control mr-2 kra-textbox" id="epatype" onChange={this.handleChange} />
                        <input type="text" className="form-control kra-percent" id="epapercent" placeholder="00%" onChange={this.handleChange} />
                        <div onClick={() => { this.removeInputComponent(i) }}><img src={remove} alt="remove kra" className="remove-kra mt-2 ml-1" /></div>
                    </article>
                )
            })
        }
    }
    render () {
        return (
            <div id="kra-inputs">
            {this.renderComponet()}
            <div className="kra-sm-txt-blue pt-1" onClick={this.addMoreInputField}>
                <span>+</span> <span>Add Key Result Area</span>
            </div>
        </div>
        )
    }
}

export default CustomEpaField