import Constants from '../constants'


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


export { SeedReducer, updateKRA, UpdateKRA_Supervisors }  