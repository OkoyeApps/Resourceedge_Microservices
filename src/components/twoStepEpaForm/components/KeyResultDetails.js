import React, { useState } from 'react';
import KeyOutcomeComponent from './KeyOutcomeComponent';
import { connect } from 'react-redux';
import './loader.css';
import SupervisorEntry from './keyOutcomeSupervisorEntry';

function KeyResultDetails(props) {

    var { temp } = props;
    var [allKeyOutcomes, setAllKeyOutcomes] = useState([]);


    const AddKeyResultArea = () => {
        var newEmptyObj = new Object();
        setAllKeyOutcomes([...allKeyOutcomes, newEmptyObj]);
    };


    const RenderKeyOutcome = () => {
        return Array.from({ length: allKeyOutcomes.length }).map((c, index) => {
            return (<KeyOutcomeComponent temp={temp} allKeyOutcomes={allKeyOutcomes} setAllKeyOutcomes={setAllKeyOutcomes} myIndex={index} currentActive={props.currentActive} />);
        });
    };

    const [load, setLoading] = useState(false);

    return (
        <>
            <section id="key-result-area-details" className={`col-7 py-3 ${temp ? "active-step" : "inactive-krad"}`}>
                <p className="steps">Step 2<span className="small-half">/2</span></p>
                <p className="kra-sm-text">Now enter the following details for each Key Results Area on the left respectively</p>


                <SupervisorEntry temp={temp} currentActive={props.currentActive} />

                {RenderKeyOutcome()}


                {temp ? <div className="kra-sm-txt-blue pt-2 px-3" onClick={AddKeyResultArea}>
                    <div> <span>+</span> <span>Add Key Outcome</span></div>
                </div>
                    : <></>
                }

                {
                    load &&
                    <div className={'avatar'} style={{ position: 'absolute', top: 0, right: 0, left: 0, bottom: 0, backgroundColor: '#e4e4e4' }}>

                    </div>
                }
            </section>

        </>
    );
}



export default connect()(KeyResultDetails);
