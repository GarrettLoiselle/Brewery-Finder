<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Add Brewery</a
    >

    <form v-on:submit.prevent="onSubmit" v-if="isFormShown">
      <div class="form-group">
        <label for="name">Name: </label>
        <input
          required
          type="text"
          id="name"
          name="name"
          class="form-control"
          v-model="newBrewery.brewery_Name"
        />
      </div>

      <div class="form-group">
        <label for="age">Zip: </label>
        <input
          type="number"
          id="zip_Code"
          name="zip_Code"
          class="form-control"
          v-model="newBrewery.zip_Code"
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
import BreweryService from "@/services/BreweryServices"
export default {
    name: "BreweryAdd",
    data() {
        return{
            newBrewery:{},

            isFormShown:false,

        }

    },
    methods:{
        onSubmit() {
            BreweryService.addBrewery(this.newBrewery).then((response) =>{
                console.log("promise was a success",response)
                this.$router.push({name:"Brewerys"});
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

</style>
