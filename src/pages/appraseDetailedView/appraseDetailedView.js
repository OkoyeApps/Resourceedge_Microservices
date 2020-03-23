import React, { useState, useEffect } from 'react';
import Activity from '../../components/activity/activity'
import Avatar from 'react-avatar';
import './appraseDetailedView.css';
import { withRouter } from 'react-router-dom'
import { connect } from 'react-redux'
import { GetTeamMemberEPA } from '../../reduxStore/actions/EpaActions'
import CustomModal from '../../components/customModal/customModal';
import backArrow from '../../assets/images/backArrowIcon.svg';
import { Link } from 'react-router-dom';



const AppraseDetailView = (props) => {
    const [tab, setTab] = useState("view")
    const [appraseDetail, setAppraseDetail] = useState([])
    const [loading, setLoading] = useState(false)

    let { state } = props.location

    console.log("props in details", props)

    const getMemberEPA = async () => {
        await props.GetTeamMemberEPA(1, 1, (success, data) => {

            if (success) {
                setLoading(false)
                console.log("data in component", data)
                setAppraseDetail(data)
            } else {
                setLoading(false)
            }
        });

    }

    useEffect(() => {
        getMemberEPA()
    }, [])

    const handleBack = () => {
        props.history.push({ pathname: "/appraisees" })
    }
    return (
        <div className="row mx-0">

            <div className="col-12 inliner pl-0">
                <div className="row mx-0">
                    <div className="col-12 d-flex my-4 pl-0">
                        <img src={backArrow} alt="back" className="mr-2" onClick={handleBack} />
                        <span className="edit-apprais" onClick={handleBack}>back</span>
                    </div>

                    <div className="col-8">
                        <div className="card w-100 mb-4 p-4 border-0">
                            <div className="w-100  d-flex justify-content-center">
                                <div className="w-50 text-center">
                                    <ul className="appraises-detail-display">
                                        <li><Avatar size={"15vmin"} name={state.fullName} className="rounded-circle text-avatar" /></li>
                                        <li className="name">{state.fullName}</li>
                                        <li className="department">{state.subgroup.name}</li>
                                        <li className="email">{state.email}</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        {
                            appraseDetail.map((ad, i) => {
                                return (
                                    <div className="card w-100 p-3 border-0 mb-4">
                                        <div className="row w-100 mb-2">
                                            <div className="col-10 apprais-header">{ad.name} </div>
                                            <div className="col-2">
                                                <CustomModal
                                                    content={<div className=" edit-apprais">Edit</div>}
                                                    type={"upload-epa-form"}
                                                />
                                            </div>
                                        </div>
                                        <div className="row mb-3">
                                            <div className="col-12 d-flex" >
                                                <span className="appraise-weights">Weight: <b>{ad.weight}%</b></span>
                                                <span className="ml-2 appraise-weights">Appraiser: <b>{ad.appraiser === undefined || ad.appraiser === null || ad.appraiser === '' ? "none" : ad.appraiser}</b></span>
                                                <span className="ml-2 appraise-weights">HOD: <b>{ad.headOfDepartment === undefined || ad.headOfDepartment === null || ad.headOfDepartment === '' ? 'none' : ad.headOfDepartment}</b></span>
                                            </div>
                                        </div>
                                        <div className="row mb-3">
                                            <div className="col-12">
                                                <table className="w-100 keyoutcome-table">
                                                    <tr>
                                                        <th style={{ width: "60%" }}>Key Outcomes</th>
                                                        <th className="pl-5">Deadline</th>
                                                    </tr>
                                                    {
                                                        ad.keyOutcomes.map((adk, i) => {
                                                            return <tr>
                                                                <td className="d-flex"><span className="mr-1">{i + 1}.</span><span>{adk.question}</span></td>
                                                                <td className="pl-5">{new Date(adk.timeLimit).toLocaleDateString()}</td>
                                                            </tr>
                                                        })
                                                    }
                                                </table>
                                            </div>
                                        </div>
                                        <div className="row">
                                            <div className="col-12 d-flex justify-content-end">
                                                <div className="d-flex">
                                                    <CustomModal
                                                        content={<button className="form-control reject-btn">Reject</button>}
                                                        type={"reject-appraisal"}
                                                    />
                                                    <button className="form-control approve-btn ml-3">Approve</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                )
                            })
                        }

                    </div>
                    <Activity />
                </div>
            </div>
        </div>
    )
}

export default connect(null, { GetTeamMemberEPA })(withRouter(AppraseDetailView))