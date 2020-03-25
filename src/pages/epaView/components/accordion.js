import React, { useState } from 'react';
import tick from '../../../assets/images/Online.svg'



const CollapseView = ({ epaValue }) => {

    const [toggle, setToggle] = useState(false);

    return (
        <div className="epa-card mt-2">
            <div className="row mx-0">
                <div className="col-11 pl-0">
                    <h4>{epaValue.name}</h4><span className="pl-2">{epaValue.approved ? <img src={tick} alt="reviewed" /> : <></>}</span>
                </div>
                <div className="col-1">
                    <div className="view-epa pointer-cursor" style={{ cursor: "pointer" }} onClick={() => setToggle(!toggle)}>{toggle ? "Collapse" : "View"}</div>
                </div>
            </div>
            <article className="d-flex mt-2">
                <div className="epa-mains">
                    <span>Weight:</span><span>{epaValue.weight}%</span>
                </div>
                <div className="epa-mains mx-3">
                    <span>Appraiser:</span><span>{epaValue?.appraiser?.name}</span>
                </div>
                <div className="epa-mains">
                    <span>HOD:</span><span>{epaValue?.headOfDepartment?.name}</span>
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
                                {
                                    epaValue.keyOutcomes.map((ev, i) => {
                                        return (
                                            <tr>
                                                <td className="d-flex"><span className="mr-1">{i + 1}</span><span>{ev.question}</span></td>
                                                <td className="pl-5">{new Date(ev.timeLimit).toLocaleDateString()}</td>
                                            </tr>
                                        )
                                    })
                                }
                            </table>
                        </div>
                    </div>
            }
        </div>
    );

};


export default CollapseView;