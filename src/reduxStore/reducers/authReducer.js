import Constants from '../constants/index'

export default (state = {}, action) => {
    switch (action.type) {
        case Constants.AUTH:
            return {
                result: action.payload
            }
        default:
            return state
    }
}