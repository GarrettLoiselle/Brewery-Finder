<template>
  <div class="brewery">
    <table>
      <thead>
        <tr>
          <th>Brewery ID</th>
          <th>Brewery Name</th>
          <th>Brewery Zip</th>
          <th>Brewery Website</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(brewery, index) in breweries" v-bind:key="index">
          <td>{{ brewery.breweryId }}</td>
          <td>{{ brewery.breweryName }}</td>
          <td>{{ brewery.zipCode }}</td>
          <td>{{ brewery.breweryWebsite }}</td>
          <td>
            <router-link v-bind:to="{name: 'beersList',params:{breweryName:brewery.breweryName}}">&nbsp;Beers</router-link>
            <!-- <v-btn text class="float-left" :to="BeersView" >Beers
            </v-btn> -->
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import BreweryService from "../services/BreweryServices";
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
</style>