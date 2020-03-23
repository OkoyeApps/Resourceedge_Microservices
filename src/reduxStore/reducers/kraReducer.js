import Constants from '../constants/index'


export default (state = [], action) => {
    switch (action.type) {
        case Constants.Kra:
            return [...state, ...action.payload]

        case Constants.UPDATE_KRA:
            return action.payload
        default: {
            return state
        }
    }
}