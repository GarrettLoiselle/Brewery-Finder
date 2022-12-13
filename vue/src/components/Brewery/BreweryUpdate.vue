<template>
  <div class="container">
  <div class="formDiv">
    <div id='updateButton'>
    <a
      v-on:click=" isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Update Brewery</a
    >
    </div>
     <select id="dropper" v-model="selected" v-if="isFormShown" @ontouchstart="getBrewery(selected)">
         <option v-for="(brewery,index) in breweries" :value="brewery.breweryId" v-bind:key="index" >
          <!-- <a v-if="active" @click.prevent="isNameFormShown = true, BreweryToUpdate.breweryId=brewery.breweryId, getBrewery,isFormShown=false">{{brewery.breweryName}}</a> -->
{{brewery.breweryName}}
         </option>
     </select>
    <form v-on:submit.prevent="update" id='submitForm'>
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
                <div class="form-group" id="updateImg">
        <label for="breweryWebsite">Image: </label>
        <input
          type="text"
          id="breweryImg"
          name="breweryImg"
          class="form-control"
          v-model="BreweryToUpdate.breweryImg"
        />
          <div class="form-group" id="updateDescription">
          <label for="breweryDescription">Description: </label>
          <input
            type="text"
            id="breweryDescription"
            name="breweryDescription"
            class="form-control"
            v-model="BreweryToUpdate.breweryDescription"
          />
        </div>
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
  </div>
</template>

<script>
import BreweryService from "@/services/BreweryServices";
import AuthService from "@/services/AuthService";
export default {
  name: "BreweryUpdate",
  data() {
    return {
      breweries:[],
      BreweryToUpdate: {},
      user: this.$store.state.user,
      isFormShown: false,
    };
  },
  created(){
      AuthService.GetBreweriesBasedOnUserId(this.user.userId).then(
        (response)=>{
this.breweries=response.data;
      })
    },
  methods: {
    getBrewery(breweryId) {
       this.isFormShown=false;
      BreweryService.getBreweryById(breweryId).then(
        (response) => {
          this.BreweryToUpdate = response.data;
        }
      );
      console.log(this.BreweryToUpdate.breweryName);
    },
    update() {
      BreweryService.updateBrewery(this.BreweryToUpdate)
        .then((response) => {
          console.log(response)
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
div#updateButton{
   font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
  color: rgb(180, 85, 21);
  font-size: 1.75rem;
}
.form-control{
  height: 15px;
}
form{
  height: 100%;
  width: 100%;
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
  padding: 10px;
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
 'updateImg updateImg'
 'updateDescription updateDescription'
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
form#submitForm div#updateImg{
  grid-area:updateImg;
  padding:5px;
}
form#submitForm div#updateDescription{
  grid-area:updateDescription;
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
div#updateButton{
   font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
  color: rgb(180, 85, 21);
  font-size: 1.75rem;
}

</style>
