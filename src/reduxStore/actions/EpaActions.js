import RequestProcessor from '../../api/requestProcessor';


const GetTeamMembers = (userid) => (dispatch, getState) => {
    RequestProcessor.Get("/team/1", "", (success, header, status, data) => {
        console.log("data returned", success, header, status, data);
    });
};

const GetPersonalEpas = (id=1, callback) => (dispatch, getState) => {
    RequestProcessor.Get(`/resultarea/${id}`, "", (success, header, status, data) => {
        if(success){
            callback(success, data);
        }else{
            //show error message;
        }
       
    });
}

export {GetTeamMembers, GetPersonalEpas}



