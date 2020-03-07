import React, { useState } from 'react'
import EpaAvatar from '../../assets/images/epaAvatar.svg'
import Avatar from 'react-avatar'
import AppraiseNav from '../../components/appraiseNav/appraiseNav'
import './appraisees.css'
import { withRouter } from 'react-router-dom'

function Appraisees(props) {
    const [tab, setTab] = useState("view")
    console.log(props)


    const handleLink = () => {
        props.history.push({ pathname: "/appraisees/details" })
    }

    return (
        <div className="row mx-0">
            <div className="col-2  px-0" >
                <AppraiseNav tab={tab} setTab={setTab} />
            </div>
            <div className="col-10">
                <div className="row mx-0 mt-4">


                    <section className="col-4 my-2" onClick={handleLink}>
                        <div className="small-card py-2">
                            <div className="row mx-0">
                                <div className="col-2 pr-0">
                                    <div>
                                        <Avatar size={"45px"} name="Eliezer Ajah" className="rounded-circle" />
                                    </div>
                                </div>
                                <div className="col-10">
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
                                <div className="col-2 pr-0">
                                    <div>
                                        <Avatar size={"45px"} name="Eliezer Ajah" className="rounded-circle" />
                                    </div>
                                </div>
                                <div className="col-10">
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
                                <div className="col-2 pr-0">
                                    <div>
                                        <Avatar size={"45px"} name="Eliezer Ajah" className="rounded-circle" />
                                    </div>
                                </div>
                                <div className="col-10">
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
                                <div className="col-2 pr-0">
                                    <div>
                                        <Avatar size={"45px"} name="Eliezer Ajah" className="rounded-circle" />
                                    </div>
                                </div>
                                <div className="col-10">
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
                                <div className="col-2 pr-0">
                                    <div>
                                        <Avatar size={"45px"} name="Eliezer Ajah" className="rounded-circle" />
                                    </div>
                                </div>
                                <div className="col-10">
                                    <div>
                                        <div className="card-name">Eliezer Ajah</div>
                                        <div className="group">Genesys</div>
                                        <div className="card-email">e.ajah@genesystechhub.com</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                    {/* 
                    <section className="col-4 my-2" onClick={handleLink}>
                        <div className="small-card py-2">
                            <div className="row mx-0">
                                <div className="col-3">
                                    <div>
                                        <Avatar size={"40px"} name="Udochi Kaduru" className="rounded-circle" />
                                    </div>
                                </div>
                                <div className="col-9 pl-0">
                                    <div>
                                        <div className="card-name">Udochi Kaduru</div>
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
                                <div className="col-3">
                                    <div>
                                        <Avatar size={"40px"} name="Daniel Ngozika" className="rounded-circle" />
                                    </div>
                                </div>
                                <div className="col-9 pl-0">
                                    <div>
                                        <div className="card-name">Daniel Ngozika</div>
                                        <div className="group">Tenece</div>
                                        <div className="card-email">e.ajah@genesystechhub.com</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>


                    <section className="col-4 my-2" onClick={handleLink}>
                        <div className="small-card py-2">
                            <div className="row mx-0">
                                <div className="col-3">
                                    <div>
                                        <Avatar size={"40px"} name="Jerry Uke" className="rounded-circle" />
                                    </div>
                                </div>
                                <div className="col-9 pl-0">
                                    <div>
                                        <div className="card-name">Jerry Uke</div>
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
                                <div className="col-3">
                                    <div>
                                        <Avatar size={"40px"} name="Nnenna Okibe" className="rounded-circle text-avatar" />
                                    </div>
                                </div>
                                <div className="col-9 pl-0">
                                    <div>
                                        <div className="card-name">Nnenna Okibe</div>
                                        <div className="group">Genesys</div>
                                        <div className="card-email">n.okibe@genesystechhub.com</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section> */}
                </div>
            </div>
        </div>
    )
}

export default withRouter(Appraisees)
