import axios from "axios";

export default{
    getAllBrewerys() {
        return axios.get('/brewery');
      },
    addBrewery(brewery) {
        return axios.post('/addBrewery',brewery)
    }
    
}