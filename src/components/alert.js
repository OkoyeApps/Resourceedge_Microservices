import React, { Component } from 'react';
import PropTypes from 'prop-types';
import './alert.css'


export default class Alert extends Component {

    static defaultProps = {
        type: 'info',
        // bgColor: '#d2e3fa',
        width: '350px',
        data: "The Alert title is the thing",
        color: '#a5a5a5',
        position: 'TR',
        title: 'Alerting title Commodo consectetur sit Lorem ullamco veniam nulla id sunt.',
        highlight: '#2798b7',
        // hoverStyle: '#fff'
    }

    state = {
        showDetail: false,
        display: true,
        hover: false
    }

    close = () => {
        this.setState({ display: false })
    }

    toggleSwitch = () => {
        this.setState({ showDetail: !this.state.showDetail });
    }

    renderView = () => {
        const {
            type,
            bgColor,
            width,
            data,
            color,
            position,
            title,
            hoverStyle
        } = this.props;

        return (
            <div
                className={'dev-animate-body'}
                style={{
                    backgroundColor: `${type === 'success' ? '#a8eab7' : type === 'danger' ? '#d08b9357' : type === 'info' ? '#b9e5ec' : '#ffdbb8'}`,
                    width: `${width}`,
                    minWidth: '25%',
                    color: `${color}`,
                    top: `${(position === 'TR' || position === 'TL') && '5px'}`,
                    right: `${(position === 'TR' || position === 'BR') && '5px'}`,
                    bottom: `${(position === 'BR' || position === 'BL') && '5px'}`,
                    left: `${(position === 'TL' || position === 'BL') && '5px'}`,
                    boxShadow: 'darkgrey 0px 0px 7px 0px',
                    position: `${(position === 'BR' || position === 'BL') && 'fixed'}`
                }}
                onMouseOver={() => this.setState({ ...this.state, hover: true })}
                onMouseLeave={() => this.setState({ ...this.state, hover: false })}
            >

                <div>
                    <span
                        className={
                            (type === 'warning') ?
                                'fa fa-warning text-warning' :
                                (type === "danger") ?
                                    "fa fa-times-circle text-danger" :
                                    (type === "success") ?
                                        "fa fa-check text-success" :
                                        (type === "info") &&
                                        "fa fa-info-circle text-info"
                        }>
                    </span>
                    <p onClick={this.toggleSwitch} style={{ color: type === 'success' ? '#28a745' : type === 'danger' ? '#dc3545' : type === 'info' ? '#17a2b8' : '#b3b300' }}>{title ? title : data}</p>
                    <div>
                        {
                            data &&
                            <span onClick={this.toggleSwitch} className={'fa fa-caret-' + (this.state.showDetail ? 'up' : 'down')}></span>
                        }
                        <span onClick={this.close} className={'fa fa-times'}></span>
                    </div>
                </div>
                {
                    this.state.showDetail &&
                    data &&
                    <>
                        <hr />
                        <p onClick={this.toggleSwitch} style={{ color: type === 'success' ? '#28a745' : type === 'danger' ? '#dc3545' : type === 'info' ? '#17a2b8' : '#b3b300' }}>{title}</p>
                        <p>{data}</p>
                    </>
                }

            </div >
        )
    }

    render() {
        return (
            this.state.display &&
            <this.renderView />
        )
    }
}


Alert.propTypes = {
    type: PropTypes.string.isRequired,
    bgColor: PropTypes.string,
    title: PropTypes.string.isRequired, //Label for the alert Eg.('Network Error encountered! ')
    data: PropTypes.string.isRequired,
    width: PropTypes.string,
    color: PropTypes.string,
    position: PropTypes.string,
}