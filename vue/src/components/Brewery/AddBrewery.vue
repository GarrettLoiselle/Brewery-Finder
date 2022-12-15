<template>
  <div class="container">
    <div id="brewery-button">
      <a
        v-on:click="isFormShown = true"
        v-if="!isFormShown"
        class="btn btn-success"
        >Add Brewery</a
      >
    </div>
    <div class="formDiv">
      <form
        class="add-form"
        v-on:submit.prevent="onSubmit"
        v-if="isFormShown"
        id="addBrewery"
      >
              <div class="form-group" id="addBrewerUsername">
          <label for="brewerUsername" id="userNameLabel">Username: </label>
          <input
            required
            type="text"
            id="brewerUsername"
            name="brewerUsername"
            class="form-control"
            v-model="newBrewery.brewerUsername"
          />
        </div>
        <div class="form-group" id="addName">
          <label for="breweryName" id="breweryNameLabel">Name: </label>
          <input
            required
            type="text"
            id="breweryNameInput"
            name="breweryName"
            class="form-control"
            v-model="newBrewery.breweryName"
            autofocus
          />
        </div>

        <div class="form-group" id="addAddress">
          <label for="breweryAddress" id="breweryAddressLabel">Address: </label>
          <input
            type="text"
            id="breweryAddressInput"
            name="breweryAddress"
            class="form-control"
            v-model="newBrewery.breweryAddress"
            required
          />
        </div>
        <div class="form-group" id="addWeb">
          <label for="breweryWebsite" id="websiteLabel">Website: </label>
          <input
            type="url"
            id="websiteInput"
            name="breweryWebsite"
            class="form-control"
            v-model="newBrewery.breweryWebsite"
          />
        </div>
        <div class="form-group" id="addImage">
          <label for="breweryImg" id="imgBreweryLabel">Image: </label>
          <input
            type="text"
            id="imgBreweryInput"
            name="breweryImg"
            class="form-control"
            v-model="newBrewery.breweryImg"
          />
        </div>
        <div class="form-group" id="addDesc">
          <label for="breweryDescription" id="breweryDescLabel">Description: </label>
          <input
            type="text"
            id="breweryDescInput"
            name="breweryDescription"
            class="form-control"
            v-model="newBrewery.breweryDescription"
            required
          />
        </div>
        <input type="submit" class="btn btn-success" id="breweryAddSubmit" />
        <input
          type="button"
          v-on:click.prevent="resetForm"
          class="btn btn-success"
          value="Cancel"
          id="breweryAddCancel"
        />
      </form>
    </div>
  </div>
</template>

<script>
import BreweryService from "@/services/BreweryServices";
export default {
  name: "BreweryAdd",
  data() {
    return {
      newBrewery: {
        breweryAddress: "",
        breweryName: "",
        breweryWebsite: "https://www.google.com/",
        breweryImg: "",
        breweryInfo: "",
        brewerUsername:"",
      },
      isFormShown: false,
    };
  },
  methods: {
    onSubmit() {
      BreweryService.addBrewery(this.newBrewery)
        .then((response) => {
          console.log("promise was a success", response);
          this.$router.push("Brewery" );
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
      this.newBrewery = {        
        breweryAddress: "",
        breweryName: "",
        breweryWebsite: "https://www.google.com/",
        breweryImg: "",
        breweryInfo: "",
        brewerUsername:"",};
      this.isFormShown = false;
    },
  },
};
</script>

<style>

#breweryDescInput {
  display: block;
  float: left;
  margin-right: -10%;
}

#breweryDescLabel{
  display: block;
  float: left;
  font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
  color: rgb(180, 85, 21);
  margin-left: -20%;
  margin-right: 10%
}

#imgBreweryInput {
  display: block;
  float: left;
  margin-right: -4%;
}

#imgBreweryLabel{
  display: block;
  float: left;
  font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
  color: rgb(180, 85, 21);
  margin-right: 10%;
}

#websiteInput {
  display: block;
  float: left;
  margin-right: 0%;
}

#websiteLabel{
  display: block;
  float: left;
  margin-right: 10%;
  font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
  color: rgb(180, 85, 21);
}

#breweryAddressInput {
  display: block;
  float: left;
  
}

#breweryAddressLabel {
  display: block;
  float: left;
  font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
  color: rgb(180, 85, 21);
  margin-right: 10%;
}

#breweryNameInput {
   display: block;
  float: left;
  margin-right: -51%;
}

#breweryNameLabel {
  display: block;
  float: left;
  margin-left: -45%;
  margin-right: 10%;
  font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
  color: rgb(180, 85, 21);
}

#userNameLabel {
  display: block;
  float: left;
  margin-left: -5%;
  margin-right: 10%;
  font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
  color: rgb(180, 85, 21);
}

div#brewery-button {
  display: flex;
  font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
  color: rgb(180, 85, 21);
  font-size: 1.75rem;
  justify-content: center;
  align-items: center;

}

.form-group {
  display: flex;
}

.form-control {
  height: 15px;
}
div.container {
  border: groove 10px #c4a381;
  background-color: black;
  display: flex;

}
div.formDiv {
  display: flex;
  flex-direction: column;
}
form#addBrewery {
  height: 100%;
  width: 100%;

  display: grid;
  grid-template-areas:
  "username username"
    "name name"
    "address address"
    "web web"
    "image image"
    "desc desc"
    "submit cancel";
  column-gap: 10px;
  row-gap: 10px;
  grid-template-rows: 1fr;
}
form div#addBrewerUsername {
  grid-area: username;
  padding: 1%;
}
form div#addName {
  grid-area: name;
  padding: 1%;
}
form div#addAddress {
  grid-area: address;
  padding: 1%;
}
form div#addWeb {
  grid-area: web;
  padding: 1%;
}

form div#addImage {
  grid-area: image;
  padding: 1%;
}
form div#addDesc {
  grid-area: desc;
  padding: 1%;
}
form input#breweryAddSubmit {
  grid-area: submit;
  margin-right: 5px;
}
form input#breweryAddCancel {
  grid-area: cancel;
  margin-left: 5px;
}
</style>
