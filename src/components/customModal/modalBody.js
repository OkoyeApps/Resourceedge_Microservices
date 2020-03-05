import React, { useEffect, useState } from 'react';
import './customModal.css';
// import closeIcon from '../../images/closeIcon.svg';


const ModalBody = (props) => {
    var [toCloseModal, setToCloseModal] = useState(false);
    useEffect(() => {
        setToCloseModal(true)
    }, [])
    return (
        <div className={"__modal__body__ d-flex justify-content-center align-items-center"} onClick={toCloseModal ? props.closeModal : ""}>
            <div className={"card px-3 "} onMouseOver={() => { setToCloseModal(false) }} onMouseLeave={() => { setToCloseModal(true) }}>
                <div className={"position-absolute justify-content-between"} style={{ width: "95%", textAlign: "right", zIndex: "3" }}>
                    <div></div>
                    <div onClick={props.closeModal} >
                    </div>
                </div>
                {props.content}
            </div>
        </div>
    )
}

export default ModalBody