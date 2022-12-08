<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Update Brewery</a
    >
    <form v-on:submit.prevent="getBrewery" v-if="isFormShown" id="nameForm" >
      <div class="form-group" id="selectName">
        <label for="breweryId">Name: </label>
        <input
          type="text"
          id="breweryName"
          name="breweryName"
          class="form-control"
          v-model="BreweryToUpdate.breweryName"
        />
      </div>
      <input type="submit" class="btn btn-success" id="submitName" v-on:click="isNameFormShown = true"/>
      <input
        type="button"
        v-on:click.prevent="resetForm"
        class="btn btn-success"
        value="Cancel"
        id="cancelName"
      />
    </form>

    <form v-on:submit.prevent="update" v-if="isNameFormShown">
      <div class="form-group">
        <label for="breweryName" id="name">Name: </label>
        <input
          required
          type="text"
          id="breweryName"
          name="breweryName"
          class="form-control"
          v-model="BreweryToUpdate.breweryName"

        />
      </div>

      <div class="form-group" id="zip">
        <label for="zipCode">Zip: </label>
        <input
          type="number"
          id="zipCode"
          name="zipCode"
          class="form-control"
          v-model.number="BreweryToUpdate.zipCode"
        />
      </div>
            <div class="form-group" id="web">
        <label for="breweryWebsite">Website: </label>
        <input
          type="url"
          id="breweryWebsite"
          name="breweryWebsite"
          class="form-control"
          v-model.number="BreweryToUpdate.breweryWebsite"
        />
      </div>
      <input type="submit" class="btn btn-success" id="submit"/>
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

<style>
.form-control{
  height: 15px;
}
div.containter{
display: grid;
grid-template-areas: 
'nameForm'
'submitForm';
grid-template-rows: 1fr;


}
form#nameForm{
  grid-area: nameForm;
   display: flex;
   flex-direction: column;
   justify-content: center;
   align-items: center;

}
form#submitForm{
  grid-area: submitForm;
  display: flex;
  flex-direction: column;
  justify-content: center;
   align-items: center;
}
/* form#nameForm div#selectName{
  grid-area: name;
  padding: 10px;
}
form div#name{
  grid-area: name;
  padding: 10px;
}
form div#zip{
  grid-area: zip;
}
form div#web{
  grid-area: web;
  padding: 10px;
}
form input#submit{
  grid-area: submit;
  margin-right: 5px;
}
form input#cancel{
  grid-area: cancel;
  margin-left:5px;
}
form#nameForm input#submitName{
  grid-area: submit;
  margin-right: 5px;
}
form#nameForm input#cancelName{
  grid-area: cancel;
  margin-left:5px;
} */
</style>
