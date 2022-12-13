<template>
  <div class="SingleBrewery" v-bind:to="{brewery}">
    <div id="main-grid">
        <div id="breweryName">
          {{ brewery.breweryName }}
        </div>
        <div id="breweryAddress">
       <Address>{{ brewery.breweryAddress }}</Address> 
        </div>
        <div id="breweryWeb">
        {{ brewery.breweryWebsite}}
        </div>
        <div id="breweryImg">
        <img v-bind:src="brewery.breweryImg" alt="breweryimg"> 
        </div>
        <div id="breweryDesc">
        {{brewery.breweryDescription}}
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
  'breweryImg breweryDesc breweryDesc' ;
  grid-template-columns: 1fr 1fr 1fr;
  align-items: center;
  row-gap: 10px;
  column-gap: 10px;
  margin: 10px;
}
div#breweryName{
  grid-area: breweryName;
  border: groove 5px #C4A381;
   padding:10px;
     font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
  color: rgb(180, 85, 21);
}
div#breweryImg{
  grid-area: breweryImg;
  border: groove 5px #C4A381;
  padding: 10px;
}
div#breweryWeb{
  grid-area: breweryWeb;
  border: groove 5px #C4A381;
  padding:10px;
    font-family:cursive;
  color: rgb(236, 230, 230);
}
div#breweryAddress{
  grid-area: breweryAddress;
  border: groove 5px #C4A381;
   padding:10px;
     font-family:cursive;
  color: rgb(236, 230, 230);
}
div#breweryDesc{
  grid-area: breweryDesc;
  border: groove 5px #C4A381;
   padding:10px;
     font-family:cursive;
  color: rgb(236, 230, 230);
}
div#breweryImg img{
  height: 400px;
  width: 400px;
}
</style>