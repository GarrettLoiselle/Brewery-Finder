<template>
  <div class="beers">
    <table>
      <thead>
          <tr>
              <th>Beer ID</th>
              <th>Beer Name</th>
              <th>Beer Description</th>
          </tr>
      </thead>
      <tbody>
          <tr 
          v-for="(beer,index) in beers" v-bind:key="index">
          <td>{{ beer.beerId }}</td>
          <td>{{beer.beerName }}</td>
          <td>{{ beer.beerInfo }}</td>
          </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import BeerService from '../services/BeerServices'
export default {
  name: "Beer",
  data:() => {  
    return{
      beers:{

      }

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
};
</script>
