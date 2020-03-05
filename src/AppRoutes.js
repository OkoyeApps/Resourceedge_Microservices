import React from 'react'
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import AuthLayout from './components/authLayout/authLayout'
import MainLayout from './components/mainLayout/mainLayout'
import Login from './pages/login/login'
import EPA from './pages/epa/epa'


const AuthRoute = ({ Component, path, exact, ...rest }) => {
    return <Route exact={exact} path={path} {...rest} render={props => {
        return <AuthLayout><Component /></AuthLayout>
    }} />
}

const MainRoute = ({ Component, path, exact, ...rest }) => {
    return <Route exact={exact} path={path} {...rest} render={props => {
        return <MainLayout><Component /></MainLayout>
    }} />
}

export default function AppRoutes() {
    return (
        <Router>
            <Switch>
                <AuthRoute path="/" exact Component={Login} />
                <AuthRoute path="/login" exact Component={Login} />
                <MainRoute path='/employee_performance_agreement' exact Component={EPA} />
            </Switch>
        </Router>

    )
}
