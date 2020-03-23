import React, { useState } from 'react';
import tick from '../../../assets/images/Online.svg'



const CollapseView = ({ epaValue }) => {

    const [toggle, setToggle] = useState(false);

    return (
        <div className="epa-card mt-2">
            <div className="row mx-0">
                <div className="col-11 pl-0">
                    <h4>{epaValue.name}</h4><span className="pl-2"><img src={tick} alt="reviewed" /></span>
                </div>
                <div className="col-1">
                    <div className="view-epa pointer-cursor" style={{cursor: "pointer"}} onClick={() => setToggle(!toggle)}>View</div>
                </div>
            </div>
            <article className="d-flex mt-2">
                <div className="epa-mains">
                    <span>Weight:</span><span>{epaValue.weight}%</span>
                </div>
                <div className="epa-mains mx-3">
                    <span>Appraiser:</span><span>{epaValue.appraiser.name}</span>
                </div>
                <div className="epa-mains">
                    <span>HOD:</span><span>{epaValue.headOfDepartment.name}</span>
                </div>
            </article>

            {
                !toggle ?
                    <div className="key-outcome mt-2">
                        Key Outcomes <b>({epaValue.keyOutcomes.length})</b>
                    </div>
                    :
                    <div className="row mt-3">
                        <div className="col-12">
                            <table className="w-100 keyoutcome-table">
                                <tr>
                                    <th style={{ width: "60%" }}>Key Outcomes</th>
                                    <th className="pl-5">Deadline</th>
                                </tr>
                                <tr>
                                    <td className="d-flex"><span className="mr-1">1.</span><span> Supervise and facilitate the preparation of Learnable 2020’s curriculum</span></td>
                                    <td className="pl-5">15 November 2020</td>
                                </tr>
                                <tr>
                                    <td className="d-flex"><span className="mr-1">2.</span><span> Supervise and facilitate the preparation of Learnable 2020’s curriculum</span></td>
                                    <td className="pl-5">15 November 2020</td>
                                </tr>
                                <tr>
                                    <td className="d-flex"><span className="mr-1">3.</span><span> Supervise and facilitate the preparation of Learnable 2020’s curriculum</span></td>
                                    <td className="pl-5">15 November 2020</td>
                                </tr>
                            </table>
                        </div>
                    </div>
            }
        </div>
    );

};


export default CollapseView;