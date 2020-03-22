import React from 'react'
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import AuthLayout from './components/authLayout/authLayout'
import MainLayout from './components/mainLayout/mainLayout'
import Login from './pages/authPage/login/login'
import Register from './pages/authPage/register/register'
import Appraisees from './pages/appraisees/appraisees'
import AppraseDetailView from './pages/appraseDetailedView/appraseDetailedView';
import Appraisal from './pages/appraisal/appraisal'
import AppraisalResult from './pages/appraisalResult/appraisalResult';
import EmployeePerformanceForAppraiser from './pages/employeePerfomance/employeePerfomance'
import AppraiseAppraisees from './pages/appraiseAppraisees/appraiseAppraisees';
import ManagerDashboard from './pages/managerDashboard/managerDashboard';
import EpaView from './pages/epaView/epaView'
import EpaUpload from './pages/epaUpload/epaUpload'


const AuthRoute = ({ Component, path, exact, ...rest }) => {
    return <Route exact={exact} path={path} {...rest} render={props => {
        return <AuthLayout><Component /></AuthLayout>
    }} />
}

const MainRoute = ({ Component, path, exact, purpose, ...rest }) => {
    console.log('back', purpose)
    return <Route exact={exact} path={path} {...rest} render={props => {
        return <MainLayout purpose={purpose} role={"appraiser"}><Component /></MainLayout>
    }} />
}

export default function AppRoutes() {
    return (
        <Router>
            <Switch>
                <AuthRoute path="/" exact Component={Register} />
                <AuthRoute path="/register" exact Component={Register} />
                <AuthRoute path="/login" exact Component={Login} />
                <MainRoute path='/epa/view' exact={true} Component={EpaView} purpose="epa" />
                <MainRoute path="/epa/upload" exact={true} Component={EpaUpload} purpose="epa" />
                <MainRoute path="/appraisees" exact Component={Appraisees} purpose="epa" />
                <MainRoute path='/appraisees/details' exact Component={AppraseDetailView} purpose="epa" />
                <MainRoute path="/appraisal/self-evaluation" exact Component={Appraisal} purpose="appraisal" />
                <MainRoute path='/employee_performance_result/view' exact Component={AppraisalResult} purpose='appraisal' />
                <MainRoute path="/employee_performance_agreement/view" exact Component={EmployeePerformanceForAppraiser} purpose="appraisal" />
                <MainRoute path='/appraise/appraisees' exact Component={AppraiseAppraisees} purpose="appraisal" />
                <MainRoute path='/manager_dashboard' exact Component={ManagerDashboard} purpose="dash" />
            </Switch>
        </Router>

    )
}
