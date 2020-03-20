import React, { useEffect, useState } from 'react';
import ModalBody from './modalBody';
import EpaForm from '../addEpaForm/addEpaForm';
import RejectAppraisal from '../rejectAppraisal/rejectAppraisal';
import AppraiseSelf from '../appraiseSelf/appraiseSelf';
import TwoStepEpaForm from '../twoStepEpaForm/twoStepEpaForm'

const CustomModal = (props) => {
    var [openModal, setOpenModal] = useState(false);

    if (openModal === true) {
        return (
            <ModalBody
                // content={<EpaForm/>}
                content={
                    props.type === "upload-epa-form" ?
                        // <EpaForm/>
                        <TwoStepEpaForm />
                        :
                        props.type === "reject-appraisal" ?
                            <RejectAppraisal />
                            :
                            props.type === "appraise-self-modal" ?
                                <AppraiseSelf />
                                :
                                props.type === "apprainseAppraisee" ?
                                    <AppraiseSelf />
                                    :
                                    ""
                }
                closeModal={() => setOpenModal(false)}
                keepOpen={() => setOpenModal(true)}
                showArrow={props.showArrow}
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