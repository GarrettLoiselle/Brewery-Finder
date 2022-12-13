<template>
  <div class="container">
    <div id="beer-button">
      <a
        v-on:click="isDeleteFormShown = true"
        v-if="!isDDeleteFormShown"
        class="btn btn-success"
        >Delete Beer</a
      >
    </div>

    <form class="delete-form" v-on:submit.prevent="onSubmit" v-if="isDeleteFormShown">
      <div class="form-group" id="deletedBeerBreweryName">
        <label for="beerName">Brewery Name: </label>
        <input
          required
          type="text"
          id="deletedBeerBreweryName"
          name="deletedBeerBreweryName"
          class="form-control"
          v-model="newBeer.breweryName"
        />
      </div>
      <div class="form-group" id="deletedBeerName">
        <label for="beerName"> Beer Name: </label>
        <input
          required
          type="text"
          id="beerName"
          name="beerName"
          class="form-control"
          v-model="newBeer.beerName"
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
import BreweryService from "@/services/BeerServices";
export default {
  name: "deleteBeer",
  data() {
    return {
      deletedBeer: {
        breweryName: "",
        beerName: "",
      },

      isFormShown: false,
    };
  },
  methods: {
    onSubmit() {
      BreweryService.deletebeer(this.deletedBeer)
        .then((response) => {
          console.log("promise was a success", response);
          this.$router.push("Beer");
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
      this.deletedBeer = {};
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
  display: flex;
  justify-content: center;
  align-items: center;
}
form {
  height: 100%;
  width: 100%;

  display: grid;
  grid-template-areas:
    "beerBreweryName beerBreweryName"
    "name name"
    "submit cancel";
}
form div#deletedBeerName {
  grid-area: name;
  padding: 10px;
}
form div#deletedBeerBreweryName {
  grid-area: name;
  padding: 10px;
}
form input#submit {
  grid-area: submit;
  margin: 5px;
}
form input#cancel {
  grid-area: cancel;
  margin: 5px;
}
</style>
