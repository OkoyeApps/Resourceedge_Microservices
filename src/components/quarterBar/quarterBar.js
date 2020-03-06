import React, { useState } from 'react'
import './quarterBar.css'

const QuarterBar = (props) => {
    var [quarter, setQuarter] = useState("q1")

    const handleQuarter = (q) => {
        setQuarter(q)
    }
    return (
        <div className="bar">
            <select>
                <option>2020</option>
                <option>2019</option>
                <option>2018</option>
                <option>2017</option>
                <option>2016</option>
            </select>
            <div className={`ml-3 ${quarter === "q1" ? "bar-q" : ''}`} onClick={() => handleQuarter("q1")}>Quarter 1</div>
            <div className={`${quarter === "q2" ? "bar-q" : ''}`} onClick={() => handleQuarter("q2")}>Quarter 2</div>
            <div className={`${quarter === "q3" ? "bar-q" : ''}`} onClick={() => handleQuarter("q3")}>Quarter 3</div>
            <div className={`${quarter === "q4" ? "bar-q" : ''}`} onClick={() => handleQuarter("q4")}>Quarter 4</div>
        </div>
    )
}

export default QuarterBar
