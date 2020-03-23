import RequestProcessor from '../../api/requestProcessor';


const GetTeamMembers = (userid) => (dispatch, getState) => {
    RequestProcessor.Get("/team/1", "", (success, header, status, data) => {
        console.log("data returned", success, header, status, data);
    });
};

// const Get

export {GetTeamMembers}



