import axios from 'axios';

export default{
    getReviews(){
        return axios.get('/Reviews')
    },
    getReviewByBeerId(beerId){
        return axios.get('/BeerReview/'+beerId)
    },
    addReview(beerReview){
        return axios.post('/BeerReview/'+beerReview.beerId,beerReview)
    },

}