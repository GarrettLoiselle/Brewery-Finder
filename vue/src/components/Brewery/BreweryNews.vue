<template>
  <div class="BreweryNews" v-bind:to="{ breweryNews }">
    <div id="main-grid">
      <h3>Brewery News</h3>
      <div class="news">
        <p>{{ breweryNews.news }}</p>
      </div>
    </div>
  </div>
</template>

<script>
import BreweryService from "../../services/BreweryServices";
export default {
  name: "BreweryNews",
  data: () => {
    return {
      breweryNews: {
      },
    };
  },
  created() {
    BreweryService.getNewsByBreweryId(this.$route.params.breweryId)
      .then((response) => {
        this.news = response.data;
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
div.BreweryNews {
  border: groove 20px #644536;
  background-color: black;
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