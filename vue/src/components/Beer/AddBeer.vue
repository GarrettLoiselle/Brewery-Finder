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
      <div id="beerDropper">

      <label class="form-group dropDown">Brewery:</label
      ><select class="dropper" id="addBeerDropper" v-model="newBeer.breweryId" v-if="isFormShown">
        <option
          v-for="(brewery, index) in breweries"
          :value="brewery.breweryId"
          v-bind:key="index"
        >
          {{ brewery.breweryName }}
        </option>
      </select>
      </div>
      <div class="form-group" id="beerName">
        <label for="beerName">Beer Name:</label>
        <input
          required
          type="text"
          id="beerNameField"
          name="beerName"
          class="form-control"
          v-model="newBeer.beerName"
        />
      </div>

      <div class="form-group" id="beerInfo">
        <label for="beerInfo">Description: </label>
        <input
          type="text"
          id="beerInfoField"
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
          id="beerImgField"
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

<script scoped>
import AuthService from "@/services/AuthService";
import BeerService from "../../services/BeerServices";
export default {
  name: "addBeer",
  data() {
    return {
      newBeer: {
        breweryName: "",
        beerInfo: "",
        beerName: "",
        beerImg: "https://www.google.com/",
      },
      user: this.$store.state.user,
      isFormShown: false,
      breweries: [],
    };
  },
  created() {
    AuthService.GetBreweriesBasedOnUserId(this.user.userId).then((response) => {
      this.breweries = response.data;
    });
  },
  methods: {
    onSubmit() {
      BeerService.addBeer(this.newBeer)
        .then((response) => {
          console.log("promise was a success", response);
          this.$router.push("Beers");
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
      this.newBeer = {
        breweryName: "",
        beerInfo: "",
        beerName: "",
        beerImg: "https://www.google.com/",
      };
      this.isFormShown = false;
    },
  },
};
</script>

<style >
#addBeerDropper {
  display:block;
  float: right;
  margin-left: 25%;
  width: 97%
  
}
div#beerDropper{
  grid-area: dropper;
}
#beerNameField {
  display: block;
  float: right;
  margin-left: 21%;
}

#beerInfoField {
  display: block;
  float: right;
  margin-left: 18%;
}

#beerImgField {
  display: block;
  float: right;
  margin-left: 22%;
}

div#beer-button {
  display: flex;
  font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
  color: rgb(180, 85, 21);
  font-size: 1.75rem;
  justify-content: center;
  align-items: center;
}


div.container {
  border: groove 20px #c4a381;
  background-color: black;
  margin: 20px;
  padding: 20px;
  display: grid;
  grid-template-areas:
  'dropper dropper'
  'name name'
  'info info'
  'img img'
  'submit cancel';
  justify-content: center;
  align-items: center;
  min-width: 20rem;
}
form.add-form {
  height: 100%;
  width: 100%;
}

form div#beerName {
  grid-area: name;
  padding: 10px;
  font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
  color: rgb(180, 85, 21);
}

form div#beerInfo {
  grid-area: info;
  font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
  color: rgb(180, 85, 21);
}
form div#beerImg {
  grid-area: img;
  padding: 10px;
  font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
  color: rgb(180, 85, 21);
}

select.dropper {
  
  display: block;
  float: right;
  height: 20px;
  width: 90%;
}

.form-group.dropDown {
  margin-left: -67%;
  font-family: Impact, Haettenschweiler, "Arial Narrow Bold", sans-serif;
  color: rgb(180, 85, 21);
}

</style>
