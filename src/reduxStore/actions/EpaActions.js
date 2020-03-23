import RequestProcessor from '../../api/requestProcessor';
import Constants from '../constants/index'


const GetTeamMembers = (userid, callback) => (dispatch, getState) => {
    RequestProcessor.Get("/team/1", "", (success, header, status, data) => {
        console.log("data returned", success, header, status, data);
        if (success) {
            callback(success, data);
        } else {
            callback(success, data);
        }
        // dispatch({ type: Constants.Appraisees, payload: data })
    })

};

const GetTeamMemberEPA = (myId, userid, callback) => (dispatch, getState) => {
    RequestProcessor.Get(`/team/${myId}/teammeber/${userid}`, "", (success, header, status, data) => {
        console.log("data returned", success, header, status, data);
        if (success) {
            callback(success, data);
        } else {
            callback(success, data);
        }
        // dispatch({ type: Constants.Appraisees, payload: data })
    })

};

// const Get

export { GetTeamMembers, GetTeamMemberEPA }



