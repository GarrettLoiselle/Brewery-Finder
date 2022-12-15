import axios from 'axios';

export default{
    getReviews(){
        return axios.get('/Reviews')
    },
    getReviewByBeerId(beerId){
        return axios.get('/BeerReview/'+beerId)
    },
    addReview(beerReview,beerId){
        return axios.post('/singleBeer/'+beerId,beerReview)
    },

}