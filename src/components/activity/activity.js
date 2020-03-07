import React from 'react'
import Avatar from 'react-avatar'

const Notification = () => {
    return (
        <aside className="col-4">
            <div className="activity-card">
                <h4>Activity</h4>
                <h6>New</h6>

                <section>
                    <div className="row mx-0">
                        <div className="col-2 pl-0"><Avatar size={"30px"} name="Susan Onu" className="rounded-circle" /></div>
                        <div className="col-10">
                            <div className="activity-text">
                                <span className="b-name">Susan Onuorah</span> approved your Employee Performance Agreement
                                <div className="timer">3 days ago</div>
                            </div>
                        </div>
                    </div>
                    <div className="row mx-0 mt-2">
                        <div className="col-2 pl-0"><Avatar size={"30px"} name="Emma Okoye" className="rounded-circle" /></div>
                        <div className="col-10">
                            <div className="activity-text">
                                <span className="b-name">You</span> accepted your Employee Performance Agreement
                                            <div className="timer">3 days ago</div>
                            </div>
                        </div>
                    </div>
                </section>

                <h6 className="mt-5">Earlier</h6>

                <section>
                    <div className="row mx-0">
                        <div className="col-2 pl-0"><Avatar size={"30px"} name="Ekene Onu" className="rounded-circle" /></div>
                        <div className="col-10">
                            <div className="activity-text">
                                <span className="b-name">Susan Onuorah</span> approved your Employee Performance Agreement
                                            <div className="timer">3 days ago</div>
                            </div>
                        </div>
                    </div>

                </section>
            </div>
        </aside>
    )
}

export default Notification