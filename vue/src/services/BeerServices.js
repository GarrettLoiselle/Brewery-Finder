import axios from "axios";

export default{
    getBeersByBreweryName(breweryName) {
        return axios.get('/beer/'+ breweryName);
      },
    }