import React, { useState, useEffect } from 'react'


function KraDisplayComponent(props) {
    var { allKRA } = props
    console.log("props", props)
    var [tab, setTab] = useState("");

    const switchTab = (clickedTab, index) => {
        props.setCurrentIndex(index)
        setTab(clickedTab);
    }

    useEffect(() => {
        setTab(allKRA[0].name)
    }, [])

    return (
        <div>
            <ul className="kra-display-list">
                {
                    allKRA.map((k, i) => {
                        return <li className={`d-flex px-5 py-3 mb-2 ${tab === k.name ? 'selected-kra' : ''}`} onClick={() => { switchTab(k.name, i)}}>
                            <div className="kra-display-name">{k.name}</div>
                            <div className="kra-display-weight">{k.weight}</div>
                        </li>
                    })
                }

            </ul>
        </div>
    )
}

export default KraDisplayComponent
