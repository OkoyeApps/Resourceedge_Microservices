import React from 'react'
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import AuthLayout from './components/authLayout/authLayout'
import MainLayout from './components/mainLayout/mainLayout'
import EPA from './pages/epa/epa'
import Login from './pages/authPage/login/login'
import Register from './pages/authPage/register/register'
import Appraisees from './pages/appraisees/appraisees'
import AppraseDetailView from './pages/appraseDetailedView/appraseDetailedView';
import Appraisal from './pages/appraisal/appraisal'
import AppraisalResult from './pages/appraisalResult/appraisalResult';
import EmployeePerformanceForAppraiser from './pages/employeePerfomance/employeePerfomance'
import AppraiseAppraisees from './pages/appraiseAppraisees/appraiseAppraisees';
import ManagerDashboard from './pages/managerDashboard/managerDashboard';



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
                <AuthRoute path="/" exact Component={Register} />
                <AuthRoute path="/register" exact Component={Register} />
                <AuthRoute path="/login" exact Component={Login} />
                <MainRoute path='/employee_performance_agreement' exact Component={EPA} />
                <MainRoute path="/appraisees" exact Component={Appraisees} />
                <MainRoute path='/appraisees/details' exact Component={AppraseDetailView} />
                <MainRoute path="/appraisal/self-evaluation" exact Component={Appraisal} />
                <MainRoute path='/employee_performance_result/view' exact Component={AppraisalResult} />
                <MainRoute path="/employee_performance_agreement/view" exact Component={EmployeePerformanceForAppraiser} />
                <MainRoute path='/appraise/appraisees' exact Component={AppraiseAppraisees} />
                <MainRoute path="/appraisal" exact Component={Appraisal} />
                <MainRoute path='/employee_performance_result' exact Component={AppraisalResult} />
                <MainRoute path='/appraise/appraisees' exact Component={AppraiseAppraisees} />
                <MainRoute path='/manager_dashboard' exact Component={ManagerDashboard} />
            </Switch>
        </Router>

    )
}
