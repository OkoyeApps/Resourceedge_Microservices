import React from 'react'
import './resultSheet.css'
import tick from '../../assets/images/Online.svg'

function AppraisalResultSheet() {
    return (
        <div className="result-card my-3">
            <span className="category">Social Media</span><span><img src={tick} alt="verified" className="ml-1" /></span>
            <div className="mt-3">
                <span className="appraise-weights">Weight: <b>56%</b></span>
                <span className="ml-2 appraise-weights">Appraiser: <b>Ositadinma Nwangwu</b></span>
                <span className="ml-2 appraise-weights">HOD: <b>Ekene Odum</b></span>
            </div>

            <div className="mt-4">
                <table className="w-100 keyoutcome-table">
                    <tr>
                        <th style={{ width: "50%" }}>Key Outcomes</th>
                        <th>Deadline</th>
                        <th className="text-center">You</th>
                        <th className="text-center">Ositadinma</th>
                        <th className="text-center">Ekene</th>
                    </tr>
                    <tr>
                        <td className="d-flex"><span className="mr-1">1.</span><span> Supervise and facilitate the preparation of Learnable 2020’s curriculum</span></td>
                        <td>15 November 2020</td>
                        <td className="text-center">3</td>
                        <td className="text-center">2</td>
                        <td className="text-center">-</td>
                    </tr>
                    <tr>
                        <td className="d-flex"><span className="mr-1">2.</span><span> Supervise and facilitate the preparation of Learnable 2020’s curriculum</span></td>
                        <td>15 November 2020</td>
                        <td className="text-center">2</td>
                        <td className="text-center">2</td>
                        <td className="text-center">-</td>
                    </tr>
                    <tr>
                        <td className="d-flex"><span className="mr-1">3.</span><span> Supervise and facilitate the preparation of Learnable 2020’s curriculum</span></td>
                        <td>15 November 2020</td>
                        <td className="text-center">2</td>
                        <td className="text-center">4</td>
                        <td className="text-center">-</td>
                    </tr>
                </table>
            </div>


            <div className="row mx-0 mt-5">
                <div className="col-6 result-comments">
                    <p className="">Comments</p>
                    <p>Wonderful performance this year, keep it up.</p>
                </div>
                <div className="col-6 result-comments">
                    <p>Recommendations</p>
                    <p>Focus harder your organizational skills. Don’t be quick to share food when you’re hungry</p>
                </div>
            </div>

        </div>
    )
}

export default AppraisalResultSheet
