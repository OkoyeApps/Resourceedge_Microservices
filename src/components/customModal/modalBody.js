import React, { useEffect, useState } from 'react';
import './customModal.css';
import leftArrow from '../../assets/images/leftArrowModal.svg'
import rightArrow from '../../assets/images/rightArrowModal.svg'
// import closeIcon from '../../images/closeIcon.svg';


const ModalBody = (props) => {
    var [toCloseModal, setToCloseModal] = useState(false);
    useEffect(() => {
        setToCloseModal(true)
    }, [])
    if (props.showArrow === true) {
        return (
            <div className={"__modal__body__ d-flex justify-content-center align-items-center"} onClick={toCloseModal ? props.closeModal : ""}>
                <div className={"px-3 d-flex"} onMouseOver={() => { setToCloseModal(false) }} onMouseLeave={() => { setToCloseModal(true) }}>
                    <img src={leftArrow} alt="arrow" className="modal-arrow" />
                    <div className="card spacing-modal-body px-3 mx-5">
                        {props.content}
                    </div>
                    <img src={rightArrow} alt="arrow" className="modal-arrow" />
                </div>
            </div>
        )
    } else {
        return (
            <div className={"__modal__body__ d-flex justify-content-center align-items-center"} onClick={toCloseModal ? props.closeModal : ""}>
                <div className={"card"} onMouseOver={() => { setToCloseModal(false) }} onMouseLeave={() => { setToCloseModal(true) }}>
                    <div className="spacing-modal-body">
                        <div className={"position-absolute justify-content-between"} style={{ width: "95%", textAlign: "right", zIndex: "3" }}>
                            <div></div>
                            <div onClick={props.closeModal} >
                            </div>
                        </div>
                        {props.content}
                    </div>
                </div>
            </div>
        )
    }
}

export default ModalBody