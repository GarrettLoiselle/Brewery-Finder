<template>
  <div class="allBeers">
    <table>
      <thead>
        <tr>
          <th>Beer Name</th>
          <th>Beer Description</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(beer, index) in beers" v-bind:key="index">
          <td>
            <router-link
            class="beer-name"
              v-bind:to="{
                name: 'singleBeer',
                params: { beerId: beer.beerId },
              }"
              >&nbsp;{{ beer.beerName }}</router-link
            >
          </td>
          <td class="beer-info">{{ beer.beerInfo }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import BeerService from "../../services/BeerServices";
export default {
  name: "Beer",
  data: () => {
    return {
      beers: {},
    };
  },
  created() {
    BeerService.getAllBeers()
      .then((response) => {
        this.beers = response.data;
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
.allBeers table {
  border: groove 20px #644536;
  background-color: black;
  margin: 20px;
}
.allBeers td {
  border: groove 5px #c4a381;
}
.allBeers td#button {
  padding: 10px;
}
.allBeers .beer-info {
  text-align: left;
  font-family:cursive;
  color: rgb(236, 230, 230);
}

.allBeers .beer-name {
  text-align: left;
  font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
  color: rgb(180, 85, 21);
  font-size: 1.5rem;
}
</style>
