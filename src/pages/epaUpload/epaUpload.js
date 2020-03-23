import React, { useEffect } from 'react';
import CustomModal from '../../components/customModal/customModal';
import Add from '../../assets/images/add.svg'

const EpaUpload = (props) => {




    return (

        <div className="" style={{ marginTop: "38vh" }}>
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
                />
            </div>
        </div>

    )
}


export default EpaUpload