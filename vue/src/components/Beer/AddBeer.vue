<template>
  <div class="container">
    <div id="beer-button">
      <a
        v-on:click="isFormShown = true"
        v-if="!isFormShown"
        class="btn btn-success"
        >Add Beer</a
      >
    </div>

    <form class="add-form" v-on:submit.prevent="onSubmit" v-if="isFormShown">
      <div class="form-group" id="breweryName">
        <label for="breweryName">Brewery Name: </label>
        <input
          required
          type="text"
          id="breweryName"
          name="breweryName"
          class="form-control"
          v-model="newBrewery.breweryName"
        />
      </div>
      <div class="form-group" id="beerName">
        <label for="beerName">Name: </label>
        <input
          required
          type="text"
          id="beerName"
          name="beerName"
          class="form-control"
          v-model="newBeer.beerName"
        />
      </div>

      <div class="form-group" id="beerInfo">
        <label for="beerInfo">Description: </label>
        <input
          type="number"
          id="beerInfo"
          name="beerInfo"
          class="form-control"
          v-model="newBeer.beerInfo"
        />
      </div>
      <div class="form-group" id="beerImg">
        <label for="beerImg">Image URL: </label>
        <input
          required
          type="url"
          id="beerImg"
          name="beerImg"
          class="form-control"
          v-model="newBeer.beerImg"
        />
      </div>
      <input type="submit" class="btn btn-success" id="submit" />
      <input
        type="button"
        v-on:click.prevent="resetForm"
        class="btn btn-success"
        value="Cancel"
        id="cancel"
      />
    </form>
  </div>
</template>

<script>
import BreweryService from "@/services/BreweryServices";
export default {
  name: "BreweryAdd",
  data() {
    return {
      newBeer: {
        breweryName: "",
        beerInfo: "",
        beerName: "",
        beerImg: "https://www.google.com/",
      },

      isFormShown: false,
    };
  },
  methods: {
    onSubmit() {
      BreweryService.addBrewery(this.newBrewery)
        .then((response) => {
          console.log("promise was a success", response);
          this.$router.push({ name: "Brewery" });
        })
        .catch((error) => {
          if (error.response) {
            console.log("HTTP Response Code: ", error.response.data.status);
            console.log("Description: ", error.response.data.title);
          } else {
            console.log("Network Error");
          }
        });

      this.resetForm();
    },
    resetForm() {
      this.newBrewery = {};
      this.isFormShown = false;
    },
  },
};
</script>

<style>

div#beer-button {
  display: flex;
  font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
  color: rgb(180, 85, 21);
  font-size: 1.75rem;
  justify-content: center;
  align-items: center;

}

.form-control {
  height: 15px;
}
div.container {
  border: groove 20px #644536;
  background-color: black;
  margin: 20px;
  padding: 20px;
}
form {
  height: 50px;
  width: 75%;

  display: grid;
  grid-template-areas:
    "name name"
    "info info"
    "img img"
    "submit cancel";
}
form div#beerName {
  grid-area: name;
  padding: 10px;
}
form div#beerInfo {
  grid-area: info;
}
form div#beerImg {
  grid-area: img;
  padding: 10px;
}
form input#submit {
  grid-area: submit;
  margin-right: 5px;
}
form input#cancel {
  grid-area: cancel;
  margin-left: 5px;
}
</style>
