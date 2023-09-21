import React, { Component } from 'react';

//TODO : Change fetch to axios
export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { colors: [], loading: true };
    }

    componentDidMount() {
        this.fetchColorData()
        this.populateColorData();
    }

    static renderColorsTable(colors) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Color</th>
                    </tr>
                </thead>
                <tbody>
                    {colors.map(color =>
                        <tr key={color.color}>
                            <td>{color.color}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
            : App.renderColorsTable(this.state.colors);

        return (
            <div>
                <h1 id="tabelLabel" >Colors</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async fetchColorData() {
        const options = { method: "POST", headers: { 'Content-Type': 'application/json' }};
        const request = await fetch('api/colortimer/create', options);
    }

    async populateColorData() {
        const response = await fetch('api/colortimer');
        const data = await response.json();
        this.setState({ colors: data, loading: false });
    }
}
