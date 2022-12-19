import { weatherWidget } from './weatherWidget.js';
import { DEFAULT_MESSAGE } from './consts.js';

const form = document.querySelector('form');

form.addEventListener('submit', onSubmit);

function onSubmit(event) {
  event.preventDefault();

  const elements = getElements();

  const weather = weatherWidget({
    context: {
      lon: +elements.lon.value,
      lat: +elements.lat.value
    },
    onComplete: ({ city, country, temp }) => {
      elements.status.textContent = `City: ${city}, Country: ${country}, Temp: ${temp} C`;
    },
    onError: (err) => {
      elements.status.textContent = `Error occured: ${err.message || DEFAULT_MESSAGE}`;
    }
  });
  weather.getWeather();
}

function getElements() {
  return {
    status: document.getElementById('status'),
    lon: document.querySelector('#lon'),
    lat: document.querySelector('#lat')
  }
}