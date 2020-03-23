import React, { useState, useEffect } from 'react'
import EpaAvatar from '../../assets/images/epaAvatar.svg'
import Avatar from 'react-avatar'
import AppraiseNav from '../../components/appraiseNav/appraiseNav'
import './appraisees.css'
import { withRouter } from 'react-router-dom'
import { connect } from 'react-redux'
import smallTick from '../../assets/images/small-tick.svg'
import { GetTeamMembers } from '../../reduxStore/actions/EpaActions'
import Skeleton from 'react-skeleton-loader'

function Appraisees(props) {
    const [tab, setTab] = useState("view")
    const [appraisees, setAppraisees] = useState([]);
    const [loading, setLoading] = useState(false)
    console.log(props)


    const getAppraisees = async () => {
        setLoading(true)
        await props.GetTeamMembers(1, (success, data) => {

            if (success) {
                setLoading(false)
                console.log("data in component", data)
                setAppraisees(data)
            } else {
                setLoading(false)
            }
        });

    }

    const handleLink = (data) => {
        props.history.push({ pathname: "/appraisees/details", state: data })
    }

    useEffect(() => {
        getAppraisees()

    }, [])

    return (
        <div className="row mx-0 pl-0">

            <div className="col-12 pl-0">
                <div className="row mx-0 mt-4 pl-0">

                    {loading ? <div className="row mx-0">
                        <div className="col-4 my-2"><Skeleton width={"22vw"} height="15vh" color={"lightgray"} borderRadius="0" /></div>
                        <div className="col-4 my-2 px-2"><Skeleton width={"22vw"} height="15vh" color={"lightgray"} borderRadius="0" /></div>
                        <div className="col-4 my-2"><Skeleton width={"22vw"} height="15vh" color={"lightgray"} borderRadius="0" /></div>
                    </div> :
                        appraisees.length > 0 ?
                            appraisees.map((a, i) => {
                                return (
                                    <section className="col-4 my-2" onClick={() => handleLink(a)}>
                                        <div className="small-card py-2">
                                            <div className="row mx-0">
                                                <div className="col-3 pr-0">

                                                    <div style={{ height: "45px", width: "45px" }}>
                                                        <Avatar size={"100%"} name={a.fullName} className="rounded-circle" />
                                                        <div className="ticked">
                                                            <img src={smallTick} alt="appraised" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div className="col-9 pl-1">
                                                    <div>
                                                        <div className="card-name">{a.fullName}</div>
                                                        <div className="group">{a.subgroup.name}</div>
                                                        <div className="card-email">{a.email}</div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                )
                            }) :
                            <div>No appraisees yet</div>
                    }


                </div>
            </div>
        </div>
    )
}

// const mapStateToProps = (state) => {
//     console.log("state from map", state)
//     return {
//         appraisees: state.epaReducer.result
//     }
// }

export default connect(null, { GetTeamMembers })(withRouter(Appraisees))
