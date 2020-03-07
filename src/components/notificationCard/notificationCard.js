import React from 'react'
import Avatar from 'react-avatar'
import './notificationCard.css'
function NotificationCard() {
    return (
        <div className="notification-card">
            <h4>Notifications</h4>
            <p>New</p>
            <section className="d-flex">
                <Avatar size={"30px"} name="Ekene Odum" className="rounded-circle" />
                <div className="ml-2">
                    <div className="note">Ekene Odum approved your Employee Performance Agreement</div>
                    <span className="note-time">3 days ago</span>
                </div>
            </section>

            <p className="mt-5">Earlier</p>
            <section className="d-flex">
                <Avatar size={"30px"} name="Julius Okeke" className="rounded-circle" />
                <div className="ml-2">
                    <div className="note">Julius Okeke approved your Employee Performance Agreement</div>
                    <span className="note-time">3 days ago</span>
                </div>
            </section>
            {/* <section>
                <div className="row mx-0">
                    <div className="col-2">
                        <Avatar size={"30px"} name="Ekene Odum" className="rounded-circle" />
                    </div>
                    <div className="col-10">
                        <div className="note">Ekene Odum approved your Employee Performance Agreement</div>
                        <span className="note-time">3 days ago</span>
                    </div>
                </div>
            </section>
            <p>Earlier</p>
            <section>
                <div className="row mx-0">
                    <div className="col-2">
                        <Avatar size={"30px"} name="Ekuma Sandra" className="rounded-circle" />
                    </div>
                    <div className="col-10">
                        <div className="note">Ekuma Sandra approved your Employee Performance Agreement</div>
                        <span className="note-time">3 days ago</span>
                    </div>
                </div>
            </section> */}
        </div>
    )
}

export default NotificationCard
