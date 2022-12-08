<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Add Brewery</a
    >

    <form class="add-form" v-on:submit.prevent="onSubmit" v-if="isFormShown">
      <div class="form-group" id="name">
        <label for="breweryName">Name: </label>
        <input
          required
          type="text"
          id="breweryName"
          name="breweryName"
          class="form-control"
          v-model="newBrewery.breweryName"
        />
      </div>

      <div class="form-group" id="zip">
        <label for="zipCode">Zip: </label>
        <input
          type="number"
          id="zipCode"
          name="zipCode"
          class="form-control"
          v-model.number="newBrewery.zipCode"
        />
      </div>
            <div class="form-group" id="web">
        <label for="breweryWebsite">Website: </label>
        <input
          required
          type="url"
          id="breweryWebsite"
          name="breweryWebsite"
          class="form-control"
          v-model="newBrewery.breweryWebsite"
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
import BreweryService from "@/services/BreweryServices"
export default {
    name: "BreweryAdd",
    data() {
        return{
            newBrewery:{
              zipCode:0,
              breweryName:'',
              breweryWebsite:'https://www.google.com/'
            },

            isFormShown:false,

        };

    },
    methods:{
        onSubmit() {
            BreweryService.addBrewery(this.newBrewery).then((response) =>{
                console.log("promise was a success",response)
                this.$router.push({name:"Brewery"});
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
    }
}
}
</script>

<style>
.form-control{
  height: 15px;
}
form{
  height: 50px;
  width: 75%;

  display: grid;
  grid-template-areas: 
  'name name'
  'zip zip'
  'web web'
  'submit cancel'
  ;
  

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

</style>
