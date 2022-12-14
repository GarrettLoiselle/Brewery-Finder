<template>
    <table id="newsTable">
      <thead>
        <tr>
      <th>Brewery News</th>
        </tr>
      </thead>
      <tbody>
      <tr v-for="(item, index) in breweryNews" v-bind:key="index">
        <td>{{ item.news }}</td>
      </tr>
      </tbody>
    </table>
</template>

<script>
import BreweryService from "../../services/BreweryServices";
export default {
  name: "BreweryNews",
  data: () => {
    return {
      breweryNews: [],
      
    };
  },
  created() {
    BreweryService.getNewsByBreweryId(this.$route.params.breweryId)
      .then((response) => {
        this.breweryNews = response.data;
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
 table#newsTable{
  border: groove 20px #644536;
   background-color: black;

}
table#newsTable td{
  border: groove 5px #C4A381;
    font-family:cursive;
  color: rgb(236, 230, 230);
  padding: 5px;
}

h3 {
  font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
  color: rgb(180, 85, 21);
}

div.news {
  font-family: cursive;
  color: rgb(236, 230, 230);
}
</style>