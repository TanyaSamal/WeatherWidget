import { appid, API_WEATHER_URL, API_GEO_URL, QUERY_PARAMS, KELVIN } from './consts.js';
import { HttpClient } from './httpClient.js';

const httpClient = new HttpClient();

export function weatherWidget(params) {
  return {
    getWeather: () => { getWeather(params) }
  }
}

async function getWeather(params) {
  setQueryParams(API_WEATHER_URL, params.context);
  try {
    const data = await httpClient.get(API_WEATHER_URL);
    const geoResults = await getLocation(params.context, params.onError);
    if (geoResults) {
      const readyData = normalizeData(data, geoResults);
      params.onComplete(readyData);
    }
  } catch(err) {
    params.onError(err)
  }
}

function normalizeData(data, geoResults) {
  return {
    temp: (data.main.temp - KELVIN).toFixed(2),
    country: geoResults.country,
    city: geoResults.city
  }
}

function setQueryParams(url, context) {
  const expandedContect = {...context, appid};
  QUERY_PARAMS.forEach((key) => {
    url.searchParams.set(key, expandedContect[key]);
  });
}

async function getLocation(context, onError) {
  setQueryParams(API_GEO_URL, context);
  try {
    const data = await httpClient.get(API_GEO_URL);
    return {
      city: data[0].name,
      country: data[0].country
    }
  } catch(err) {
    onError(err);
    return null;
  }
}
