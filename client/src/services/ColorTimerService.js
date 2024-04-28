import axios from 'axios';

class ColorTimerService
{
    // static async fetchColorData() {
    //     const options = { method: "POST", headers: { 'Content-Type': 'application/json' }};
    //     const request = await fetch('api/colortimer/create', options);
    //     // Send request
    // }

    static async startTimer(color) {
        try {
            const response = await axios.post('api/colortimer/start-timer/' + color);
            return response.data ?? null;
        }
        catch (error) {
            console.log(error);
            return null;
        }
    }

    static async stopTimer(color, timeElapsed) {
        try {
            const response = await axios.post('api/colortimer/stop-timer/' + color + '/' + timeElapsed);
            return response.data ?? null;
        }
        catch (error) {
            return null;
        }
    }

    static async fetchAllColorData() {
        const response = await fetch('api/colortimer');
        const data = await response.json();
        return data;
    }

    // When adding new color, include the following properties : DateCreated, DateInitialTimerStart, DateLastTimerStart
    static async addNewColor(color) {
        await axios.post('api/colortimer/create/' + color);
    }
}

export default ColorTimerService;