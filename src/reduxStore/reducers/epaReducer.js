import Constants from '../constants/index'


export default (state = {}, action) => {
    switch (action.type) {
        case Constants.Appraisees:
            return {
                result: action.payload
            }
        default: {
            return state
        }
    }
}