import React,{useState, useEffect} from 'react';
import Email from './components/email'
import Password from './components/password';

export default function Login() {
    const [stage, setStage] = useState(1);

    const changeStage = (newStage) => {
        // event.preventDefault();
        setStage(newStage);
    }
    console.log(stage)
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