import axios from "axios";

export default{
    getAllBreweries() {
        return axios.get('/brewery');
      },
      getBreweryByName(breweryName) {
        return axios.get('/brewery/'+ breweryName);
      },
    addBrewery(brewery) {
        return axios.post('/brewery',brewery)
    },
    updateBrewery(brewery) {
        console.log(brewery)
        return axios.put('/brewery/'+brewery.breweryName,brewery)
    }
    
}