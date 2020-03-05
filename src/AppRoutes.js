import React from 'react'
import { BrowserRouter as Router, Route, Switch, Redirect } from 'react-router-dom';
import AuthLayout from './components/authLayout/authLayout'
import Login from './pages/authPage/login/login'
import Register from './pages/authPage/register/register'



const AuthRoute = ({ Component, path, exact, ...rest }) => {
    return <Route exact={exact} path={path} {...rest} render={props => {
        return <AuthLayout><Component /></AuthLayout>
    }} />
}

export default function AppRoutes() {
    return (
        <Router>
            <Switch>
                <AuthRoute path="/" exact Component={Register} />
                <AuthRoute path="/register" exact Component={Register} />
                <AuthRoute path="/login" exact Component={Login} />
            </Switch>
        </Router>

    )
}
