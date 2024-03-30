import React, { Component } from 'react';
import ColorTimerService from './services/ColorTimerService';

import ColorTile from './components/ColorTile';

//TODO : Change fetch to axios
export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);

        this.state = {
            colors: [],
            loading: true,
            // Below properties should be on another component
            isTimerRunning : false,
            seconds: 0
        };

        this.interval = null;
    }

    componentDidMount() {
        // this.fetchColorTimerData();
        // setInterval(this.fetchColorTimerData, 1000);
    }

    //#region Event handlers
    fetchColorTimerData = async () => {
        this.setState({ loading: true });
        const colorData = await ColorTimerService.fetchAllColorData();
        this.setState({ colors: colorData, loading: false });
    }

    addColor = async (color) => {
        this.setState({ loading: true });
        await ColorTimerService.addNewColor(color);
        const colorData = await ColorTimerService.fetchAllColorData();
        this.setState({ colors: colorData, loading: false });
    }

    //#endregion

    render() {
        return (
            <div className='h-screen'>
                <button className='place-content-center' onClick={() => this.addColor('Red')}>Add Color</button>
                <button className='place-content-center' onClick={() => this.addColor('Blue')}>Add Color</button>
                <button className='place-content-center' onClick={() => this.addColor('Green')}>Add Color</button>
                <div>
                    {this.state.colors.map((color) => {
                        return (
                            <ColorTile key={color.color} color={color.color}></ColorTile>
                        )
                    })}
                </div>
            </div>
        );
    }
}
