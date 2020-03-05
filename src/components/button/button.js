import React from 'react'
import './button.css'
export default function button(props) {
    return (
        <div>
            <button className="btn big-btn" onClick={props.onClick}>{props.name}</button>
        </div>
    )
}
