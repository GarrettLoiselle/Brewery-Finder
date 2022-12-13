<template>
  <div class="beers">
    <table>
      <thead>
          <tr>
              <th>Reviewer</th>
              <th>Rating</th>
              <th>Review</th>
          </tr>
      </thead>
      <tbody>
          <tr 
          v-for="(review,index) in reviews" v-bind:key="index">
          <td id='reviewer'>{{review.reviewer}}</td>
          <td id='rating'>{{ review.rating }}</td>
          <td id='reviewContent'>{{ review.reviewContent }}</td>
          </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import ReviewServices from '../../services/ReviewServices'
export default {
  name: "Beer",
  data:() => {  
    return{
      reviews:{

      }

    }
  },
  created(){
    ReviewServices
    .getBeersByBreweryId(this.$route.params.breweryId).then(response =>{
      this.beers=response.data;
      })
      .catch((error) => {
        if (error.response) {
          this.message =
            "Error: HTTP Response Code: " + error.response.data.status;
          this.message += "    Description: " + error.response.data.title;
        } else {
          this.message = "Network Error";
        }
      });
  },
};
</script>
<style>

.beers table{
  border: groove 20px #644536;
  background-color: black;
   margin: 20px;
}
.beers td#beerName{
    font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
  color: rgb(180, 85, 21);
  font-size: 1.5rem;
  padding:5px;
}
.beers td{
  border: groove 5px #C4A381;
    font-family:cursive;
  color: rgb(236, 230, 230);
  padding:5px;
}
.beers td#button{
  padding:10px;
}
</style>