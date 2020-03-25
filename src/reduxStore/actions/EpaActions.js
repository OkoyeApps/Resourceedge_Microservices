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


const SearchForSupervisors = (searchVal, callback) => (dispatch, getState) => {
    console.log(searchVal)
    RequestProcessor.Get(`/supervisors?searchQuery=${searchVal}`, '', (success, header, status, data) => {
        console.log("search result", data)
        if (success) {
            callback(success, data)
        } else {
            callback(success, data)
        }
    })
}

// const Get

const GetPersonalEpas = (id = 1, callback) => (dispatch, getState) => {
    RequestProcessor.Get(`/resultarea/${id}`, "", (success, header, status, data) => {
        if (success) {
            callback(success, data);
        } else {
            //show error message;
            callback(success, data);

        }

    });
}


const ApproveOrRejectBySupervisor = (userid, epaId, approver, data, callback) => (dispatch, getState) => {
    RequestProcessor.Post(`/resultArea/${userid}/${epaId}/Approval/${approver}`, '', data, (success, header, status, data) => {
        if (success) {
            callback(success, data)
        } else {
            callback(success, data)
        }
    })
}

export { GetTeamMembers, GetPersonalEpas, GetTeamMemberEPA, SearchForSupervisors, ApproveOrRejectBySupervisor }


