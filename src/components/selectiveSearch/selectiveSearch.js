import React, { useState } from 'react'

export default function Selector(props) {
    var { dropClass, dropStyle, tagClass, tagStyle, searchClass, searchStyle, result, isSearchable } = props
    let $ = window;
    const [data, setData] = useState([]);
    const [show, setShow] = useState(false);

    var searchable = isSearchable ? isSearchable : false
    
    const tellCode = (e) => {
        var inputValue = document.querySelector('#search');
        if (inputValue.value === '') {
            setShow(false)
            if ($.event.inputType === "deleteContentBackward") {
                if (data.length !== 0) {
                    inputValue.value = data[data.length - 1]
                    setData(data.slice(0, data.length - 1))
                }
            }
            if (data.length === 0) {

                return;
            }
        }


        if ($.event.keyCode === 13) {
            if (e.target.value.trim() !== "") {
                setData([...data, e.target.value])
                inputValue.value = " ";
            }
        }

        if (e.target.value.trim() !== "") {
            props.setValue(inputValue.value)
            setShow(true)
        } else {
            setShow(false)
        }
        console.log("input", e.target.value)
        console.log("show", show)
    }


    const handleDelete = (value) => {
        setData(data.filter((item) => item !== value))
    }

    const handleSelect = (e) => {
        setData([...data, e.target.innerText])
        document.querySelector('#search').value = " "
    }

    return (
        <div>
            <div className="drop" id="mainInput" style={{ display: 'flex' }} onKeyPress={(e) => { tellCode(e) }}>
                <ul>
                    {
                        data &&
                        data.map((item, index) => {
                            return <li key={index} style={{ ...tagStyle }}><span className={tagClass ? tagClass : "capsule"}>{item} <span onClick={() => { handleDelete(item) }} className="fa fa-times-circle"></span></span></li>
                        })
                    }
                    <li style={data.length === 0 ? { width: "100%" } : { width: "auto" }}><input type="text" id='search' style={{ ...searchStyle }} className={searchClass ? searchClass : "search"} placeholder={"Please search"} onChange={tellCode} autoFocus={true} /></li>
                </ul>
            </div>
            {
                searchable ?
                    show ? <div className={dropClass ? dropClass : "dropDown"} style={{ ...dropStyle }}>
                        <ul>
                            {result && result.map((item, index) => (<li onClick={handleSelect} key={index}>{item.name}</li>))}
                        </ul>
                    </div> : <></>
                    : <></>
            }


        </div>

    )
}
