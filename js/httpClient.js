export class HttpClient {
  async get(url) {
    const res = await fetch(url);
    const data = await res.json();
    this.#handleError(data);
    return data;
  }

  #handleError(data) {
    //geo API doesn't return cod
    if (!data || (data.cod && data.cod !== 200) || data.length === 0) {
      throw new Error(data);
    }
  }
}
