import React, { useState, useEffect } from 'react';
import KeyResultDetails from './KeyResultDetails'
import { connect } from 'react-redux';
var tempArray = [];

const KeyOutcomeDetailParent = (props) => {
    var { ActiveKraIndex, KRA } = props
    const [keyOutcomeComponentArray, setKeyoutcomeComponentArray] = useState(tempArray);
    const [activeComponent, setComponent] = useState(null);
    useEffect(() => {
        GenerateKeyOutcomeComponent()
    }, [KRA])

    useEffect(() => {
        renderEquivalentComponentForActiveKRA();
    }, [ActiveKraIndex])

    const GenerateKeyOutcomeComponent = () => {
        var result = Array.from({ length: KRA.length }).map((x, index) => {
            return <KeyResultDetails next={true} currentActive={index} key={index} temp={true} />
        })
        tempArray = result;
        setKeyoutcomeComponentArray(result);
    }

    const renderEquivalentComponentForActiveKRA = () => {
        var aa = tempArray[ActiveKraIndex] == null ? <KeyResultDetails next={true} currentActive={ActiveKraIndex} temp={false} closeModal={props.closeModal} /> : tempArray[ActiveKraIndex];
        if (ActiveKraIndex !== null) {
            tempArray = [...tempArray, aa];
            setComponent(aa);
        } else {
            setComponent(aa);
        }
    }

    return (
        activeComponent ? activeComponent : <></>
    )
}

const mapstateToProps = (state) => {
    console.log("state gotten", state);
    return {
        KRA: state.KRA
    }
}

export default connect(mapstateToProps)(React.memo(KeyOutcomeDetailParent, (oldProps, newProps) => {
    // return oldProps.KRA.length === newProps.KRA.length ?false: true;
}));