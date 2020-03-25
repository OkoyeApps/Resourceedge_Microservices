import Constants from '../constants'
import requestProcessor from '../../api/requestProcessor';


const SeedReducer = (data) => (dispatch, getState) => {
    dispatch({ type: Constants.Kra, payload: data })
}

const updateKRA = (kraindex, keyoutcomeIndex, data) => (dispatch, getState) => {
    var state = getState();
    var AllKRA = state.KRA;
    var specificKeyResultArea = AllKRA[kraindex];
    if (specificKeyResultArea.hasOwnProperty("keyoutcomes")) {
        var currentKeyoutcome = specificKeyResultArea.keyoutcomes[keyoutcomeIndex];
        currentKeyoutcome = { ...currentKeyoutcome, ...data };
        specificKeyResultArea.keyoutcomes[keyoutcomeIndex] = currentKeyoutcome;
        AllKRA[kraindex] = specificKeyResultArea;

    } else {
        var keyoutcomeObj = { keyoutcomes: [{ ...data }] }
        specificKeyResultArea = { ...specificKeyResultArea, ...keyoutcomeObj };
        AllKRA[kraindex] = specificKeyResultArea;
    }
    dispatch({
        type: Constants.UPDATE_KRA,
        payload: AllKRA
    })
}

const UpdateKRA_Supervisors = (kraindex, type = "", data) => (dispatch, getState) => {
    var state = getState();
    var AllKRA = state.KRA;
    var specificKeyResultArea = AllKRA[kraindex];
    specificKeyResultArea = performCheckAndUpdate(specificKeyResultArea, type, data);
    AllKRA[kraindex] = specificKeyResultArea;
}

function performCheckAndUpdate(specificKeyResultArea, type, data) {
    if (specificKeyResultArea.hasOwnProperty(type)) {
        specificKeyResultArea[type] = { ...specificKeyResultArea[type], ...data };
    } else {
        specificKeyResultArea = { ...specificKeyResultArea, [type]: { ...data } };
    }
    return specificKeyResultArea;
}

const UploadkeyResultAreas = (callback) => (dispatch, getState) => {
    var state = getState();
    var AllKRA = state.KRA;
    var authDetails = state.auth;
    AllKRA.map(x => x["myId"] = 1);
    AllKRA.map(area => {
        if (area.keyoutcomes) {
            var nonNullKeyoutcomes = area.keyoutcomes.filter(x => x != null || x != undefined);
            area.keyoutcomes = nonNullKeyoutcomes;
        }
    })

    console.log('data to post', AllKRA);
    requestProcessor.Post("/resultarea/1", "", AllKRA, (success, header, status, data) => {
        if (success) {
            callback(success, data);
        } else {
            callback(false, data);
        }
    })
}


export { SeedReducer, updateKRA, UpdateKRA_Supervisors, UploadkeyResultAreas }  