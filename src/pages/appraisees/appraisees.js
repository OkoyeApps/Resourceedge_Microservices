import React, { useState } from 'react'
import EpaAvatar from '../../assets/images/epaAvatar.svg'
import Avatar from 'react-avatar'
import AppraiseNav from '../../components/appraiseNav/appraiseNav'
import './appraisees.css'
import { withRouter } from 'react-router-dom'
import smallTick from '../../assets/images/small-tick.svg'

function Appraisees(props) {
    const [tab, setTab] = useState("view")
    console.log(props)


    const handleLink = () => {
        props.history.push({ pathname: "/appraisees/details" })
    }

    return (
        <div className="row mx-0 pl-0">

            <div className="col-12 pl-0">
                <div className="row mx-0 mt-4 pl-0">


                    <section className="col-4 my-2" onClick={handleLink}>
                        <div className="small-card py-2">
                            <div className="row mx-0">
                                <div className="col-3 pr-0">

                                    <div style={{ height: "45px", width: "45px" }}>
                                        <Avatar size={"100%"} name="Eliezer Ajah" className="rounded-circle" />
                                        <div className="ticked">
                                            <img src={smallTick} alt="appraised" />
                                        </div>
                                    </div>
                                </div>
                                <div className="col-9 pl-1">
                                    <div>
                                        <div className="card-name">Eliezer Ajah</div>
                                        <div className="group">Genesys</div>
                                        <div className="card-email">e.ajah@genesystechhub.com</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                    <section className="col-4 my-2" onClick={handleLink}>
                        <div className="small-card py-2">
                            <div className="row mx-0">
                                <div className="col-3 pr-0">
                                    <div style={{ height: "45px", width: "45px" }}>
                                        <Avatar size={"100%"} name="Eliezer Ajah" className="rounded-circle" />
                                        <div className="ticked">
                                            <img src={smallTick} alt="appraised" />
                                        </div>
                                    </div>
                                </div>
                                <div className="col-9 pl-1">
                                    <div>
                                        <div className="card-name">Eliezer Ajah</div>
                                        <div className="group">Genesys</div>
                                        <div className="card-email">e.ajah@genesystechhub.com</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                    <section className="col-4 my-2" onClick={handleLink}>
                        <div className="small-card py-2">
                            <div className="row mx-0">
                                <div className="col-3 pr-0">
                                    <div style={{ height: "45px", width: "45px" }}>
                                        <Avatar size={"100%"} name="Eliezer Ajah" className="rounded-circle" />
                                        <div className="ticked">
                                            <img src={smallTick} alt="appraised" />
                                        </div>
                                    </div>
                                </div>
                                <div className="col-9 pl-1">
                                    <div>
                                        <div className="card-name">Eliezer Ajah</div>
                                        <div className="group">Genesys</div>
                                        <div className="card-email">e.ajah@genesystechhub.com</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                    <section className="col-4 my-2" onClick={handleLink}>
                        <div className="small-card py-2">
                            <div className="row mx-0">
                                <div className="col-3 pr-0">
                                    <div style={{ height: "45px", width: "45px" }}>
                                        <Avatar size={"100%"} name="Eliezer Ajah" className="rounded-circle" />
                                        <div className="ticked">
                                            <img src={smallTick} alt="appraised" />
                                        </div>
                                    </div>
                                </div>
                                <div className="col-9 pl-1">
                                    <div>
                                        <div className="card-name">Eliezer Ajah</div>
                                        <div className="group">Genesys</div>
                                        <div className="card-email">e.ajah@genesystechhub.com</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                    <section className="col-4 my-2" onClick={handleLink}>
                        <div className="small-card py-2">
                            <div className="row mx-0">
                                <div className="col-3 pr-0">
                                    <div style={{ height: "45px", width: "45px" }}>
                                        <Avatar size={"100%"} name="Eliezer Ajah" className="rounded-circle" />
                                        <div className="ticked">
                                            <img src={smallTick} alt="appraised" />
                                        </div>
                                    </div>
                                </div>
                                <div className="col-9 pl-1">
                                    <div>
                                        <div className="card-name">Eliezer Ajah</div>
                                        <div className="group">Genesys</div>
                                        <div className="card-email">e.ajah@genesystechhub.com</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    )
}

export default withRouter(Appraisees)
