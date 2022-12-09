<template>
  <div class="SingleBrewery" v-bind:to="{singleBeer}">
    <div id="main-grid">
        <div id="breweryName">
          {{ brewery.breweryName }}
        </div>
        <div id="breweryAddress">
       <Address>{{ brewery.breweryAddress }}</Address> 
        </div>
        <div id="breweryWeb">
        {{ brewery.breweryWebsite }}
        </div>
        <div id="breweryImg">
         This will be BreweryImg 
        </div>
        <div id="breweryDesc">
          This will be BreweryDesc
        </div>
    </div>
  </div>
</template>

<script>
import BreweryService from '../../services/BreweryServices'
export default {
  name: "Brewery",
  data:() => {  
    return{
      brewery:{

      },
    }
  },
  created(){
    BreweryService
    .getBreweryById(this.$route.params.breweryId).then(response =>{
      this.brewery=response.data;
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
<style scoped>
div.SingleBrewery {
  border: groove 20px #644536;
  background-color: black;
}
div#main-grid{
   display: grid;
  grid-template-areas:
  'breweryName breweryName breweryName'
  'breweryImg breweryWeb breweryAddress'
  'breweryDesc breweryDesc breweryDesc' ;
  grid-template-columns: 1fr 1fr 1fr;
  align-items: center;
  row-gap: 10px;
  column-gap: 10px;
}
div#breweryName{
  grid-area: breweryName;
  border: groove 5px #C4A381;
   padding:10px
}
div#breweryImg{
  grid-area: breweryImg;
  border: groove 5px #C4A381;
   padding:10px
}
div#breweryWeb{
  grid-area: breweryWeb;
  border: groove 5px #C4A381;
  padding:10px
}
div#breweryAddress{
  grid-area: breweryAddress;
  border: groove 5px #C4A381;
   padding:10px
}
div#breweryDesc{
  grid-area: breweryDesc;
  border: groove 5px #C4A381;
   padding:10px
}
</style>