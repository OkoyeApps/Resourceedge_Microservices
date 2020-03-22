import React from 'react';
import './circulerProgressBar.css';
import {
    CircularProgressbar,
    CircularProgressbarWithChildren,
    buildStyles
} from "react-circular-progressbar";


const CirculerProgressBar = (props) => {

    return (
        <CircularProgressbarWithChildren
            value={90}
            styles={buildStyles({
                pathColor: "rgba(29, 29, 29, 0.8)",
                trailColor: "inherit"
            })}>
            <div className="w-75">
                <CircularProgressbarWithChildren
                    value={80}
                    styles={buildStyles({
                        pathColor: "rgba(81, 163, 163, 0.6)",
                        trailColor: "innherit"
                    })}
                >
                    <span className="radial-bar-ratio">2.0</span>
                </CircularProgressbarWithChildren>
            </div>
        </CircularProgressbarWithChildren>
    )
}

export default CirculerProgressBar