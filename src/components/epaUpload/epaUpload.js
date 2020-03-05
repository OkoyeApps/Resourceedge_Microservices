import React from 'react';
import CustomModal from '../customModal/customModal';

export default function EpaUpload(props) {
    return (
        <div>
            <section className="text-center">
                <div className="notice-text">
                    Add your EPA
                </div>
                <div className="little-gray-text pt-4">
                    Add your Employee Performance Agreement to start tracking your progress
                </div>

            </section>
            <div className="mt-4">
                <CustomModal content={<div className="text-center"><button className="btn addBtn">+ Start Adding</button></div>} />
            </div>
        </div>
    )
}
