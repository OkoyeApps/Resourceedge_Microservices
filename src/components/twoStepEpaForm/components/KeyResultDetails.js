import React, { useState } from 'react';
import KeyOutcomeComponent from './KeyOutcomeComponent';
import SupervisorEntry from './keyOutcomeSupervisorEntry';
import { connect } from 'react-redux';
import './loader.css';
import { updateKRA } from '../../../reduxStore/actions/krAction';

function KeyResultDetails(props) {
    let { existingKeyArea, currentActive, load } = props;
    var { temp } = props;
    var [allKeyOutcomes, setAllKeyOutcomes] = useState([]);
    const AddKeyResultArea = () => {
        var newEmptyObj = new Object();
        props.updateKRA(currentActive, allKeyOutcomes.length, {});
        setAllKeyOutcomes([...allKeyOutcomes, newEmptyObj]);
    };

    const RenderKeyOutcome = () => {
        if (existingKeyArea[currentActive] && existingKeyArea[currentActive].keyoutcomes && existingKeyArea[currentActive].keyoutcomes.length > 0) {
            if (existingKeyArea[currentActive].keyoutcomes.length > 1) {
                var oldComponent = existingKeyArea[currentActive].keyoutcomes.map((x, index) => {
                    return (<KeyOutcomeComponent key={(Math.random() + 2.1) * 5.2214} oldData={{ question: x.question, timelimit: x.timelimit }} temp={temp}
                        allKeyOutcomes={allKeyOutcomes} setAllKeyOutcomes={setAllKeyOutcomes}
                        myIndex={index} currentActive={currentActive} />);
                });

                return oldComponent;
            } else {
                if (existingKeyArea[currentActive].keyoutcomes.length === 0 && existingKeyArea[currentActive].keyoutcomes[0].question
                    || existingKeyArea[currentActive].keyoutcomes[0].timelimit) {
                   return <KeyOutcomeComponent key={(Math.random() + 2.1) * 5.2214} oldData={{
                        question: existingKeyArea[currentActive].keyoutcomes[0].question,
                        timelimit: existingKeyArea[currentActive].keyoutcomes[0].timelimit
                    }}
                        temp={temp} allKeyOutcomes={allKeyOutcomes}
                        setAllKeyOutcomes={setAllKeyOutcomes} myIndex={0} currentActive={currentActive} />;
                } else {
                    return <KeyOutcomeComponent key={(Math.random() + 2.1) * 5.2214} temp={temp} allKeyOutcomes={allKeyOutcomes}
                        setAllKeyOutcomes={setAllKeyOutcomes} myIndex={0} currentActive={currentActive} />;
                }
            }

        } else {
            return Array.from({ length: allKeyOutcomes.length }).map((c, index) => {
                return (<KeyOutcomeComponent key={(Math.random() + 2.1) * 5.2214} temp={temp} allKeyOutcomes={allKeyOutcomes} setAllKeyOutcomes={setAllKeyOutcomes} myIndex={index} currentActive={currentActive} />);
            });
        }
    };

    return (
        <>
            <section id="key-result-area-details" className={`col-7 py-3 ${temp ? "active-step" : "inactive-krad"}`}>
                <p className="steps">Step 2<span className="small-half">/2</span></p>
                <p className="kra-sm-text">Now enter the following details for each Key Results Area on the left respectively</p>


                <SupervisorEntry temp={temp} currentActive={props.currentActive} /> <br />

                {RenderKeyOutcome()}
                {temp ? <div className="kra-sm-txt-blue pt-2 px-3" onClick={AddKeyResultArea}>
                    <div> <span>+</span> <span>Add Key Outcome</span></div>
                </div>
                    : <></>
                }
                {
                    load &&
                    <div className={'avatar'} style={{ position: 'absolute', top: 0, right: 0, left: 0, bottom: 0, backgroundColor: '#e4e4e4' }}> </div>
                }
            </section>
        </>
    );
}
const mapStateToProps = (state) => {

    return (
        {
            existingKeyArea: state.KRA
        }
    );
};
export default connect(mapStateToProps, { updateKRA })(KeyResultDetails);
