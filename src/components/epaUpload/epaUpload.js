import React from 'react';
import CustomModal from '../customModal/customModal';

export default function EpaUpload(props) {
    return (

        <div className="d-flex align-items-center justify-content-center" style={{ marginTop: "40vh" }}>
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
                content={<div className="text-center"><button className="btn addBtn">+ Start Adding</button></div>}
                type={"upload-epa-form"} 
                />
            </div>
        </div>

    )
}
