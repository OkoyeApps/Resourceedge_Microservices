import { combineReducers } from 'redux';
import authReducer from './authReducer';
import epaReducer from './epaReducer'

export default combineReducers({
    authReducer, epaReducer
});