<template>
  <div class="container">
    <div id="review-button">
      <a
        v-on:click="isFormShown = true"
        v-if="!isFormShown"
        class="btn btn-success"
        >Add Review</a
      >
    </div>
<form class="add-form" v-on:submit.prevent="onSubmit" v-if="isFormShown">
        <div class="form-group" id="reviewerName">
        <label for="reviewerName" id="reviewerName"> Your Name: </label>
        <input
          required
          type="text"
          id="reviewerNameField"
          name="reviewerName"
          class="form-control"
          v-model="newReview.reviewerName"
        />
      </div>
      <label id="ratingLabel">Rating:</label><select class="dropper" v-model="newReview.rating" v-if="isFormShown">
         <option >1</option>
         <option >2</option>
         <option >3</option>
         <option >4</option>
         <option >5</option>
     </select>
      <div class="form-group" id="reviewInfo">
        <label for="reviewInfo" id="reviewDesc">Review: </label>
        <input
          type="text"
          id="reviewInfo"
          name="reviewInfo"
          class="form-control"
          v-model="newReview.reviewInfo"
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
import ReviewService from '../../services/ReviewServices';
export default {
  name: "addReview",
  data() {
    return {
      newReview: {
        reviewerName:"",
        beerId: Number(this.$route.params.beerId),
        rating:1,
        reviewInfo: "Meh",
      },
      isFormShown: false,
    };
  },
  methods: {
    onSubmit() {
      ReviewService.addReview(this.newReview)
        .then((response) => {
          console.log("promise was a success", response);
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
      this.newReview = {
        beerId: Number(this.$route.params.beerId),
        reviewerName:"",
        rating:1,
        reviewInfo: "Meh",};
      this.isFormShown = false;
    },
  },
};
</script>

<style>

#reviewerNameField {
  margin-left: 100px; 
  width: 185px;

}
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
  border: groove 20px #c4a381;
  background-color: black;
  margin: 20px;
  padding: 20px;
  display: flex;
  justify-content: center;
  align-items: center;
  min-width: 20rem;
}
form.add-form {
  height: 100%;
  width: 100%;

  display: grid;
  grid-template-areas:
    "beerBreweryName beerBreweryName"
    "name name"
    "info info"
    "img img"
    "submit cancel";
}
form div#reviewerName {
  grid-area: name;
  padding: 10px;
}


form div#reviewInfo {
  grid-area: info;
}
form input#submit {
  grid-area: submit;
  margin: 5px;
}
form input#cancel {
  grid-area: cancel;
  margin: 5px;
}

form .dropper {
  height: 19px;
}
</style>
