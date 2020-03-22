import React from 'react'
import Avatar from 'react-avatar'
import './userDropDown.css'

function UserDropDown(props) {
    return (
        <div className="user-card">
            <div>
                <Avatar size={"64px"} name="Eliezer Ajah" className="rounded-circle" />
            </div>
            <h5>Eliezer Ajah</h5>
            <h6 >Genesys</h6>
            <address >e.ajah@genesystechhub.com</address>

            <p>Logout</p>
        </div>
    )
}

export default UserDropDown
