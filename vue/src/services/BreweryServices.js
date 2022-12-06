import axios from "axios";

export default{
    getAllBrewerys() {
        return axios.get('/brewery');
      }
    
}