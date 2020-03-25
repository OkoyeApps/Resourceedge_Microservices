import React, { useState, useEffect } from 'react';
import './customCalenderPicker.css';
import upArrow from '../../assets/images/directionArrow1.svg'
import downArrow from '../../assets/images/directionArrow2.svg'
import radioIcon from '../../assets/images/radioIcon.svg'

const date = new Date();
let selectedDate = new Date();
let selectedDays = date.getDate();
let selectedMonth = date.getMonth() + 1;
let selectedYear = date.getFullYear()

function CustomCalenderPicker(props) {
    const months = ['January', 'Febuary', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
    let formatMonth = date.getMonth() + 1
    const [show, setShow] = useState(false);
    const [month, setMonth] = useState(formatMonth);
    const [year, setYear] = useState(date.getFullYear());

    useEffect(() => {
        selectedDate = new Date();
        selectedDays = date.getDate();
        selectedMonth = date.getMonth() + 1;
        selectedYear = date.getFullYear()
    })

    const selectDateSetter = (d) => {
        selectedDate = new Date(year + '-' + month + '-' + d);
        selectedDays = d;
        selectedMonth = month;
        selectedYear = year;
        props.handleDatePick(`${selectedDays < 10 ? `0${selectedDays}` : selectedDays}/${selectedMonth < 10 ? `0${selectedMonth}` : selectedMonth}/${selectedYear}`);
        setShow(!show)
    }
    const moveToNextMonth = () => {
        setMonth(month + 1);
        if (month === 12) {
            setMonth(1)
            setYear(year + 1);
        }
    }
    const moveToPrevMonth = () => {
        setMonth(month - 1);
        if (month === 1) {
            setMonth(12)
            setYear(year - 1);
        }
    }
    // Format date for display
    const formatSelectedDate = () => {
        if (props.defaultValue) {
            return props.defaultValue
        } else {
            return `${selectedDays < 10 ? `0${selectedDays}` : selectedDays}/${selectedMonth < 10 ? `0${selectedMonth}` : selectedMonth}/${selectedYear}`
        }
    }

    const populateDates = () => {
        var dayCount = []
        let amount_days = 31;
        if (month === 2) {
            amount_days = 28
        }
        for (let i = 0; i < amount_days; i++) {
            dayCount = [...dayCount, i + 1]
        }
        return dayCount.map((d, i) => (
            <div key={i} className={checkForSelectedDay(d) ? "day selected custom-day" : "day custom-day"} onClick={() => { selectDateSetter(d) }}>{d}</div>
        ));
    }

    const checkForSelectedDay = d => {
        if (selectedDays === d && selectedMonth === month && selectedYear === year) {
            return true
        }
    }

    return (
        <div className="w-100" key={props.key}>
            <div className="date-picker form-control">
                <div className="selected-date" onClick={() => { setShow(!show) }}>{formatSelectedDate()}</div>
                {
                    show ?
                        <div className="dates">
                            <div className="month">
                                <div className="mth">{`${months[month - 1]} ${year}`}</div>
                                <div className="d-flex">
                                    <div className="arrows prev-mth" onClick={moveToPrevMonth}><img src={upArrow} alt="up"/></div>
                                    <div className="arrows next-mth" onClick={moveToNextMonth}><img src={downArrow} alt="down"/></div>
                                </div>
                            </div>
                            <div className="days">
                                {populateDates()}
                            </div>
                            <div className="d-flex align-items-center justify-content-center">
                                <img src={radioIcon} alt='radio'/>
                                <span className="ml-2 ongoing-calender">Continuous/Ongoing</span>
                            </div>
                        </div>
                        :
                        ""
                }
            </div>
        </div>
    );
}

export default CustomCalenderPicker;