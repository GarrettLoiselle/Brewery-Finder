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

    <form v-on:submit.prevent="update" v-if="isNameFormShown" id='submitForm'>
      <div class="form-group" id="updateName">
        <label for="breweryName" >Name: </label>
        <input
          required
          type="text"
          id="breweryName"
          name="breweryName"
          class="form-control"
          v-model="BreweryToUpdate.breweryName"

        />
      </div>

      <div class="form-group" id="updateAddress">
        <label for="breweryAddress">Address: </label>
        <input
          type="text"
          id="breweryAddress"
          name="breweryAddress"
          class="form-control"
          v-model="BreweryToUpdate.breweryAddress"
        />
      </div>
            <div class="form-group" id="updateWeb">
        <label for="breweryWebsite">Website: </label>
        <input
          type="url"
          id="breweryWebsite"
          name="breweryWebsite"
          class="form-control"
          v-model="BreweryToUpdate.breweryWebsite"
        />
      </div>
      <input type="submit" class="btn btn-success" id="updateSubmit"/>
      <input
        type="button"
        v-on:click.prevent="resetForm"
        class="btn btn-success"
        value="Cancel"
        id="updateCancel"
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
      BreweryService.getBreweryById(this.BreweryToUpdate.breweryId).then(
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
      this.isNameFormShown = false;
    },
  },
};
</script>

<style>
.form-control{
  height: 15px;
}
div.container{
display: grid;
grid-template-areas:
'header' 
'nameForm'
'submitForm';
grid-template-rows: 1fr;
padding:10px ;

}
h2{
  grid-area: header;
}
form#nameForm{
  grid-area: nameForm;
  display: grid;
  grid-template-areas:
  'selectName selectName'
  'submitName cancelName';
  padding: 20px;
}
form#nameForm div#selectName{
  grid-area: selectName;
  padding: 10px;
}
form#nameForm input#submitName{
  grid-area: submitName;
  margin: 5px;
}
form#nameForm input#cancelName{
  grid-area: cancelName;
  margin: 5px;
}
form#submitForm{
  grid-area: submitForm;
  display: grid;
 grid-template-areas:
 'updateName updateName'
 'updateAddress updateAddress'
 'updateWeb updateWeb'
 'updateSubmit updateCancel' ;
  padding: 10px;
}
form#submitForm div#updateName{
  grid-area:updateName;
  padding:5px;
}
form#submitForm div#updateAddress{
  grid-area:updateAddress;
  padding:5px;
}
form#submitForm div#updateWeb{
  grid-area:updateWeb;
  padding:5px;
}
input#updateSubmit{
  grid-area: updateSubmit;
  margin:5px;
}
input#updateCancel{
  grid-area:updateCancel;
  margin:5px;
}

</style>
