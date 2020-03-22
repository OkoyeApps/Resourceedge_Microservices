import React from 'react'
import './epaView.css'
import tick from '../../assets/images/Online.svg'
import Avatar from 'react-avatar';
import Activity from '../../components/activity/activity';

export default function EpaView(props) {
    var { data } = props
    console.log("props", props)


    const viewWithData = () => {
        return (
            <div>
                <section className="row mx-0 pt-5">
                    <div className="col-8">
                        <div className="row mx-0 py-2">
                            <div className="col-11 d-flex align-items-center">
                                <div className="view-intro-txt">
                                    Hello Eliezer, this is your Employee Performance Agreement for 2020
                                </div>
                            </div>
                            <div className="col-1">
                                <button className="btn btn-disabled">Accept</button>
                            </div>
                        </div>
                    </div>
                </section>

                <section className="row mx-0 mt-2">
                    <div className="col-8">
                        {
                            data.map((x, i) => (
                                <div className="epa-card mt-2">
                                    <div className="row mx-0">
                                        <div className="col-11 pl-0">
                                            <h4>Learning Physical Internship</h4><span className="pl-2"><img src={tick} alt="reviewed" /></span>
                                        </div>
                                        <div className="col-1">
                                            <div className="view-epa">View</div>
                                        </div>
                                    </div>
                                    <article className="d-flex">
                                        <div className="epa-mains">
                                            <span>Weight:</span><span>56%</span>
                                        </div>
                                        <div className="epa-mains mx-3">
                                            <span>Appraiser:</span><span>Ositadimma Nwangwu</span>
                                        </div>
                                        <div className="epa-mains">
                                            <span>HOD:</span><span>Ekene Odum</span>
                                        </div>
                                    </article>

                                    <div className="key-outcome mt-2">
                                        Key Outcomes (3)
                                    </div>
                                </div>
                            ))
                        }

                    </div>
                    <Activity />
                </section>
            </div>
        )
    }

    return (
        <div>
            {data ? viewWithData() : <div className="d-flex align-items-center justify-content-center" style={{ marginTop: "40vh" }}><section className="text-center">
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
