import React, { useState, useEffect } from 'react';
import CustomModal from '../../components/customModal/customModal';
import Add from '../../assets/images/add.svg'
import Alert from '../../components/alert'
const EpaUpload = (props) => {

    var [show, setShow] = useState(false)


    return (

        <div className="" style={{ marginTop: "38vh" }}>
            {show ? <Alert type={'success'} title='Key result area submitted' data="" /> : <></>}
            <section className="text-center">
                <div className="notice-text">
                    Add your EPA
                </div>
                <div className="little-gray-text pt-4">
                    Add your Employee Performance Agreement to start tracking your progress
                </div>

            </section>
            <div className="mt-4">
                <CustomModal
                    content={<div className="text-center"><button className="btn addBtn"><img src={Add} alt="add" /> Start Adding</button></div>}
                    type={"upload-epa-form"}
                    setShow={setShow}
                />
            </div>
        </div>

    )
}


export default EpaUpload