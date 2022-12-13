import axios from "axios";

export default {
  getBeersByBreweryId(breweryId) {
    return axios.get('/beer/' + breweryId);
  },

  getAllBeers() {
    return axios.get('/beer');
  },
  addBeer(beer) {
    return axios.post('/beer', beer);
  },
  deleteBeer(beerId) {
    return axios.delete('/beer/'+beerId);
  },

}