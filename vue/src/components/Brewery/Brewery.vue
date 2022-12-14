<template>
  <div class="brewery">
    <table>
      <thead>
        <tr>
          <th>Brewery Name</th>
          <th>Brewery Address</th>
          <th>Brewery Website</th>
          <th>Beer List</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(brewery, index) in breweries" v-bind:key="index">
          <td class="breweryHyperLink" ><router-link id='breweryName' @mouseover="hover=true" @mouseleave="hover=false" v-bind:to="{name: 'singleBrewery',params:{breweryId:brewery.breweryId}}">&nbsp;{{ brewery.breweryName }}</router-link></td>
          <td><Address>{{ brewery.breweryAddress }}</Address></td>
          <td><a v-bind:href="brewery.breweryWebsite">{{ brewery.breweryWebsite }}</a></td>
          <td class="beersHyperLink">
            <router-link @mouseover="hover=true" @mouseleave="hover=false" v-bind:to="{name: 'beersList',params:{breweryId:brewery.breweryId}}">&nbsp;Beers</router-link>
            <!-- <v-btn text class="float-left" :to="BeersView" >Beers
            </v-btn> -->
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import BreweryService from "../../services/BreweryServices";
export default {
  name: "Brewery",
  data: () => {
    return {
      breweries: {},
    };
  },
  created() {
    BreweryService.getAllBreweries()
      .then((response) => {
        this.breweries = response.data;
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
.brewery table{
  border: groove 20px #644536;
   background-color: black;

}
.brewery td{
  border: groove 5px #C4A381;
    font-family:cursive;
  color: rgb(236, 230, 230);
  padding: 5px;
}
.brewery td.breweryHyperLink{
  color:rgb(180, 85, 21);
  font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
}
.brewery th{
  background-color: black;
}
.brewery td.beersHyperLink{
  padding:10px;
}

</style>
