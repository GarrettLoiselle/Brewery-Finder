<template>
  <div class="SingleBeer" v-bind:to="{singleBeer}" >
    <div id="main-grid">
      <div id="beerName">
            {{singleBeer.beerName }}
      </div>
      <div id="beerDesc">
            {{ singleBeer.beerInfo }}
      </div>
      <div id="beerImg">
        this will be beer img
      </div>
    </div>
  </div>
</template>

<script>
import BeerService from '../../services/BeerServices'
export default {
  name: "Beer",
  data:() => {  
    return{
      beers:[

      ]

      ,
    singleBeer:{

        },
    }
  },
  created(){
    BeerService
    .getAllBeers().then(response =>{
      this.beers=response.data;
              this.beers.forEach(beer => {
    if(beer.beerId==this.$route.params.beerId){
        this.singleBeer=beer;
    }
    
});
      
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
      this.getBeer();
  },
};
</script>
<style scoped>
div.SingleBeer {
  border: groove 20px #644536;
  background-color: black;
}
div#main-grid{
   display: grid;
  grid-template-areas:
  'beerName beerName'
  'beerImg beerDesc' ;
  grid-template-columns: 1fr 1fr;
  align-items: center;
  row-gap: 10px;
  column-gap: 10px;
}
div#beerName{
  grid-area: beerName;
  border: groove 5px #C4A381;
   padding:10px
}
div#beerImg{
  grid-area: beerImg;
  border: groove 5px #C4A381;
   padding:10px
}
div#beerDesc{
  grid-area: beerDesc;
  border: groove 5px #C4A381;
   padding:10px
}
</style>