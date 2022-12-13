<template>
  <div class="container">
    <div id="beer-button">
      <a
        v-on:click="isDeleteFormShown = true"
        v-if="!isDeleteFormShown"
        class="btn btn-success"
        >Delete Beer</a
      >
    </div>

    <form class="delete-form" v-on:submit.prevent="onSubmit" v-if="isDeleteFormShown">
                 <select class="dropper" v-model="deletedBeer.breweryId" v-if="isDeleteFormShown" @change.prevent="toGetBeers">
         <option v-for="(brewery,index) in breweries" :value="brewery.breweryId" v-bind:key="index" >
{{brewery.breweryName}}
         </option>
     </select>
                <select class="dropper" v-model="deletedBeer.beerId" v-if="isDeleteFormShown">
         <option v-for="(beer,index) in beers" :value="beer.beerId" v-bind:key="index" >
{{beer.beerName}}
         </option>
     </select>
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
import BeerService from "@/services/BeerServices";
import AuthService from "@/services/AuthService";
export default {
  name: "deleteBeer",
  data() {
    return {
      deletedBeer: {
        beerId:0,
        breweryId:0,
        beerName: "",
      },
      breweries:[],
      beers:[],
      user: this.$store.state.user,
      isDeleteFormShown: false,
    };
  },
    created(){
      AuthService.GetBreweriesBasedOnUserId(this.user.userId).then(
        (response)=>{
this.breweries=response.data;
      })
    },
  methods: {
    toGetBeers(){
      this.beers=[];
BeerService.getBeersByBreweryId(this.deletedBeer.breweryId)
.then((response)=>{
  this.beers=response.data
  })
    },
    onSubmit() {
      BeerService.deleteBeer(this.deletedBeer.beerId)
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
      this.isDeleteFormShown = false;
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
