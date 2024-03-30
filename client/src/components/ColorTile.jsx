import React, { useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import ColorTimerService from '../services/ColorTimerService';

const ColorTile = (props) => {

    const [seconds, setSeconds] = useState(0);
    const [isTimerRunning, setIsTimerRunning] = useState(false);

    useEffect(() => {
        let timer;

        if (isTimerRunning) {
            timer = setInterval(() => {
                setSeconds(prevSeconds => prevSeconds + 1);
            }, 1000);
        }
        else {
            clearInterval(timer);
        }

        return () => clearInterval(timer);
    }, [isTimerRunning]);

    const timerToggle = () => {
        if (isTimerRunning) {
            ColorTimerService.startTimer(props.color).then((res) => {
                // Update timer
                console.log(res);
            });
        } else {
            ColorTimerService.stopTimer(props.color).then((res) => {
                // Update timer
                console.log(res);
            });
        }

        setIsTimerRunning(!isTimerRunning);
    }

    return (
        <div className='flex flex-row items-center justify-evenly'>
            <h3>{props.color}</h3>
            <button onClick={timerToggle}>{isTimerRunning ? 'Pause' : 'Start'}</button>
            <p>{seconds}</p>
        </div>
    );
};

ColorTile.propTypes = {
    color: PropTypes.string
};

export default ColorTile;
