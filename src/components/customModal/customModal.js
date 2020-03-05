import React, { useEffect, useState } from 'react';
import ModalBody from './modalBody';
import EpaForm from '../addEpaForm/addEpaForm';

const CustomModal = (props) => {
    var [openModal, setOpenModal] = useState(false);

    if (openModal === true) {
        return (
            <ModalBody
                content={<EpaForm/>}
                closeModal={() => setOpenModal(false)}
                keepOpen={() => setOpenModal(true)}
            />
        )
    } else {
        return (
            <div onClick={() => setOpenModal(true)} style={{ cursor: "pointer" }}>
                {props.content}
            </div >
        )
    }
}

export default CustomModal