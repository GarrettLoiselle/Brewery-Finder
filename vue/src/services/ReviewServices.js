import axios from 'axios';

export default{
    getReviews(){
        return axios.get('/Reviews')
    },
    getReviewByBeer(beerId){
        return axios.get('/Reviews'+beerId)
    },

}