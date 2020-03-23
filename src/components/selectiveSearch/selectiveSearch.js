import React, { useState } from 'react';
import './selectiveSearch.css'

export default function Selector(props) {
    var { dropClass, dropStyle, tagClass, tagStyle, searchClass, searchStyle, result, isSearchable, disableInput } = props
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
        setShow(false)
    }
    console.log(searchable,"lalalalal",show,)
    return (
        <div>
            <div className="drop w-100" id="mainInput" style={{ display: 'flex' }} onKeyPress={(e) => { tellCode(e) }}>
                <ul className="w-100">
                    {
                        data &&
                        data.map((item, index) => {
                            return <li key={index} style={{ ...tagStyle }} className="w-100"><div className={tagClass ? tagClass : "w-100 d-flex justify-content-between form-control"}>{item} <span onClick={() => { handleDelete(item) }}><i class="fas fa-times-circle"></i></span></div></li>
                        })
                    }
                    {
                        data.length >= 1 ?
                            ""
                            :
                            <li style={data.length === 0 ? { width: "100%" } : { width: "auto" }}><input disabled={disableInput} type="text" id='search' className={searchClass ? searchClass : "form-control"} placeholder={"Please search"} onChange={tellCode} autoFocus={true} autoComplete={false} /></li>
                    }
                </ul>
            </div>
            {
                searchable ?
                    show ? <div className={dropClass ? dropClass : "dropDown w-100"} style={{ ...dropStyle }}>
                        <ul className="w-100">
                            {result && result.map((item, index) => (<li onClick={handleSelect} key={index} className="w-100">{item.name}</li>))}
                        </ul>
                    </div> : <></>
                    : <></>
            }

        </div>
    )
}