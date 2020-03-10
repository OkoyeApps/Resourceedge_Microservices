import React, { useState, useEffect } from 'react';
import Email from './components/email'
import Password from './components/password';
import { connect } from 'react-redux';
import { auth } from '../../../reduxStore/actions/authAction';


const Login = (props) => {
    const [stage, setStage] = useState(1);

    return (
        <div>
            {
                stage === 1 ?
                    <Email checkForStep={(step) => { setStage(step) }} />
                    :
                    <Password checkForStep={() => { setStage(2) }} />
            }
        </div>
    )
}
const mapStateToProps = (state) => {
    console.log(state)
    return state
}

export default connect(mapStateToProps, { auth })(Login);