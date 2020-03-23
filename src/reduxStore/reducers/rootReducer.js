import { combineReducers } from 'redux';
import authReducer from './authReducer';
import epaReducer from './epaReducer';
import kraReducer from './kraReducer'

export default combineReducers({
    authReducer, epaReducer,
    KRA: kraReducer
});