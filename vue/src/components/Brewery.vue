<template>
  <div class="brewery">
    <table>
      <thead>
          <tr>
              <th>Brewery ID</th>
              <th>Brewery Name</th>
              <th>Brewery Zip</th>
          </tr>
      </thead>
      <tbody>
          <tr 
          v-for="(brewery,index) in brewerys" v-bind:key="index">
          <td>{{ brewery.brewery_ID }}</td>
          <td>{{brewery.brewery_Name }}</td>
          <td>{{ brewery.zip_Code }}</td>
          </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import BreweryService from '../services/BreweryServices'
export default {
  name: "Brewery",
  data:() => {  
    return{
      brewerys:{
        
      }
    }
  },
  created(){
    BreweryService
    .getAllBrewerys().then(response =>{
      this.brewerys=response.data;
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