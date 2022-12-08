<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Update Brewery</a
    >
    <form v-on:submit.prevent="getBrewery" v-if="isFormShown">
      <div class="form-group">
        <label for="breweryId">Name: </label>
        <input
          type="text"
          id="breweryName"
          name="breweryName"
          class="form-control"
          v-model="BreweryToUpdate.breweryName"
        />
      </div>
      <input type="submit" class="btn btn-success" />
      <input
        type="button"
        v-on:click.prevent="resetForm"
        class="btn btn-success"
        value="Cancel"
      />
    </form>

    <form v-on:submit.prevent="update" v-if="isFormShown">
      <div class="form-group">
        <label for="breweryName">Name: </label>
        <input
          required
          type="text"
          id="breweryName"
          name="breweryName"
          class="form-control"
          v-model="BreweryToUpdate.breweryName"
        />
      </div>

      <div class="form-group">
        <label for="zipCode">Zip: </label>
        <input
          type="number"
          id="zipCode"
          name="zipCode"
          class="form-control"
          v-model.number="BreweryToUpdate.zipCode"
        />
      </div>
            <div class="form-group">
        <label for="breweryWebsite">Website: </label>
        <input
          type="url"
          id="breweryWebsite"
          name="breweryWebsite"
          class="form-control"
          v-model.number="BreweryToUpdate.breweryWebsite"
        />
      </div>
      <input type="submit" class="btn btn-success" />
      <input
        type="button"
        v-on:click.prevent="resetForm"
        class="btn btn-success"
        value="Cancel"
      />
    </form>
  </div>
</template>

<script>
import BreweryService from "@/services/BreweryServices";
export default {
  name: "BreweryUpdate",
  data() {
    return {
      BreweryToUpdate: {},

      isFormShown: false,
    };
  },
  methods: {
    getBrewery() {
      BreweryService.getBreweryByName(this.BreweryToUpdate.breweryName).then(
        (response) => {
          this.BreweryToUpdate = response.data;
        }
      );
      console.log(this.BreweryToUpdate.breweryName);
    },
    update() {
      BreweryService.updateBrewery(this.BreweryToUpdate)
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
      this.BreweryToUpdate = {};
      this.isFormShown = false;
    },
  },
};
</script>


