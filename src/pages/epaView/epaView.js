import React, { useState, useEffect } from 'react'
import './epaView.css'
import Avatar from 'react-avatar';
import Activity from '../../components/activity/activity';
import { GetPersonalEpas } from '../../reduxStore/actions/EpaActions'
import { connect } from 'react-redux';
import ResultAccordion from './components/accordion';
import Skeleton from 'react-skeleton-loader'

const EpaView = (props) => {
    // var { data } = props
    const [data, setData] = useState([]);
    var [loading, setLoading] = useState(false)
    var [accept, setAccept] = useState(false)
    useEffect(() => {
        setLoading(true)
        props.GetPersonalEpas(1, (success, data) => {
            setLoading(true)
            if (success) {
                setData(data);
                setLoading(false)
                getReadyToAccept(data)
            } else {
                //show error message the right way
            }
        });
    }, [])


    const getReadyToAccept = (data) => {
        let status = false;
        data.map((d) => {
            status += d.approved
        })
        if (status === data.length) {
            setAccept(true)
        } else {
            setAccept(false)
        }
    }

    const viewWithData = () => {
        return (
            <div>
                <section className="row mx-0 pt-5">
                    <div className="col-12">
                        <div className="row mx-0 py-2">
                            <div className="col-11 d-flex align-items-center">
                                <div className="view-intro-txt">
                                    Hello Eliezer, this is your Employee Performance Agreement for {Date.now().year}
                                </div>
                            </div>
                            <div className="col-1">
                                <button className={`btn ${accept ? "btn-primary" : "btn-disabled"}`} disabled={!accept} >Accept</button>
                            </div>
                        </div>
                    </div>
                </section>

                <section className="row mx-0 mt-2">
                    <div className="col-12">
                        {
                            data.map((x, i) => {
                                return (

                                    < ResultAccordion epaValue={x} key={`epaview${i}`} />
                                )
                            }


                            )
                        }

                    </div>
                    {/* <Activity /> */}
                </section>
            </div>
        )
    }

    return (
        <div>
            {loading ?
                <div className="row mt-5 pt-5">
                    <div className="col-md-12">
                        <Skeleton height="15vh" width="100%" color="#e6e6e6" borderRadius="0" />
                        <Skeleton height="15vh" width="100%" color="#e6e6e6" borderRadius="0" />
                        <Skeleton height="15vh" width="100%" color="#e6e6e6" borderRadius="0" />
                        <Skeleton height="15vh" width="100%" color="#e6e6e6" borderRadius="0" />
                    </div>
                    {/* <div className="col-md-4">
                        <Skeleton height="70vh" width="100%" color="#e6e6e6" />
                    </div> */}

                </div> :
                data.length > 0 ? viewWithData() : <div className="d-flex align-items-center justify-content-center" style={{ marginTop: "40vh" }}><section className="text-center">
                    <div className="notice-text">
                        Nothing to see here
                    </div>
                    <div className="little-gray-text pt-4">
                        When you upload your Employee Performance Agreement, you’ll see it here
                    </div>
                </section></div>}
        </div>
    )
}

export default connect(null, { GetPersonalEpas })(EpaView)
