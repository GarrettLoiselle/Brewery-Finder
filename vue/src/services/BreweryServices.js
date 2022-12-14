import axios from "axios";

export default {
  getAllBreweries() {
    return axios.get('/brewery');
  },
  getBreweryById(breweryId) {
    return axios.get('/brewery/' + breweryId);
  },
  addBrewery(brewery) {
    return axios.post('/brewery/', brewery)
  },
  updateBrewery(brewery) {
    console.log(brewery)
    return axios.put('/brewery/' + brewery.breweryId, brewery)
  },
  getNewsByBreweryId(breweryId) {
    return axios.get('/breweryNews/' + breweryId)
  },
  getEventsByBreweryId(breweryId) {
    return axios.get('/breweryEvents/' + breweryId)
  },

}