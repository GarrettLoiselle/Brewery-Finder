<template>
  <div class="SingleBeer"
          v-bind:to="{singleBeer}">
          {{ singleBeer.beerId }}
          {{singleBeer.beerName }}
          {{ singleBeer.beerInfo }}
      
  </div>
</template>

<script>
import BeerService from '../services/BeerServices'
export default {
  name: "Beer",
  data:() => {  
    return{
      beers:{

      },
    singleBeer:{

        },
    }
  },
  created(){
    BeerService
    .getAllBeers().then(response =>{
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
  methods:{
      getBeer(){
this.singleBeer=this.beers.forEach(beer => {
    if(beer.beerId==this.$route.params.beerId){
        return beer;
    }
    
});
          
      }
  }
};
</script>
<style scoped>
.allBeers table{
  border: groove 20px #644536;
}
.allBeers td{
  border: groove 5px #C4A381;
}
</style>