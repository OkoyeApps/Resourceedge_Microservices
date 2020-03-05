import React, { useState } from 'react';
import './register.css';
import Email from '../register/components/email';
import Password from '../register/components/password';

export default function Register() {
    const [stage, setStage] = useState(1);

    const changeStage = (newStage) => {
        // event.preventDefault();
        setStage(newStage);
    }
    console.log(stage);

    return (
        <div>
            {
                stage === 1 ?
                <Email checkForStep={(step)=>{ setStage(step)}}/>
                :
                <Password checkForStep={()=>{setStage(2)}}/>
            }
        </div>
    )
}
