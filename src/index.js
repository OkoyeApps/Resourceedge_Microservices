import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import { Provider } from 'react-redux'
import configureStore from './reduxStore/store';
window.jQuery = window.$ = require('jquery');
window.select2 = require('selectize');
window.jQuery.select2 = window.select2;
window.$.__proto__.select2 = window.select2;

const renderApp = () => {
    
    return (
        <Provider store={configureStore()}>
            <App />
        </Provider>
    );
}
ReactDOM.render(renderApp(), document.getElementById('root'));
// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
