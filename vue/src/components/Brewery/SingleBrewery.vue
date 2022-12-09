<template>
  <div class="SingleBrewery"
          v-bind:to="{singleBeer}">
        {{ brewery.breweryId }}
        {{ brewery.breweryName }}
        {{ brewery.zipCode }}
        {{ brewery.breweryWebsite }}
      
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
    .getBreweryByName(this.$route.params.breweryName).then(response =>{
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
.allBeers table{
  border: groove 20px #644536;
}
.allBeers td{
  border: groove 5px #C4A381;
}
</style>