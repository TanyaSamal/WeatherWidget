import { BASE_URL } from './consts.js';

export class WeatherWidget {
    constructor(params) {
        this.context = params.context;
        this.onComplete = params.onComplete;
        this.onError = params.onError;
    }

    async getWeather() {
        const url = `${BASE_URL}?lat=${this.context.lat}&lon=${this.context.lon}`;
        try {
            const res = await fetch(url);
            const data = await res.json();
            if (data.city) {
                this.onComplete(data);
            }
        } catch (err) {
            this.onError(err);
        }
    }
}
