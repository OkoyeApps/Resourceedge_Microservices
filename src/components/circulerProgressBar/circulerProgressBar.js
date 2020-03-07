import React from 'react';
import './circulerProgressBar.css'

const CirculerProgressBar = (props) => {
    var formatAppraiseesParcent = `c100 p${props.appraiseesPercent} orange`;
    var formatAppraiserParcent = `c100 p${props.appraiserPercent} small green`;
    console.log(formatAppraiseesParcent, formatAppraiserParcent)
    return (
        <div>
            <div className={formatAppraiseesParcent}>
                <div className="slice">
                    <div className="bar"></div>
                    <div className="fill"></div>
                </div>
            </div>
            <div className={formatAppraiserParcent} style={{ position: "absolute", top: "16%", left: "31%", zIndex: "7" }}>
                <span>{props.rate}</span>
                <div className="slice">
                    <div className="bar" ></div>
                    <div className="fill"></div>
                </div>
            </div>
        </div>
    )
}

export default CirculerProgressBar