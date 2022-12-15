<template>
  <div class="container" id="reviewForm">
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
          class="form-controlReview"
          v-model="newReview.reviewerName"
        />
      </div>
      <div id="rating">
      <label id="ratingLabel">Rating:</label><select class="dropperReview" v-model="newReview.rating" v-if="isFormShown">
         <option >1</option>
         <option >2</option>
         <option >3</option>
         <option >4</option>
         <option >5</option>
     </select>
      </div>
      <div class="form-group" id="reviewInfo">
        <label for="reviewInfo" id="reviewDesc">Review: </label>
        <input
          type="text"
          id="reviewInfo"
          name="reviewInfo"
          class="form-controlReview"
          v-model="newReview.reviewInfo"
        />
      </div>
      <input type="submit" class="btn btn-success" id="submitReview" />
      <input
        type="button"
        v-on:click.prevent="resetForm"
        class="btn btn-success"
        value="Cancel"
        id="cancelReview"
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
      componentKey:0
    };
  },
  methods: {
    onSubmit() {
      ReviewService.addReview(this.newReview)
        .then((response) => {
          console.log("promise was a success", response);
          window.location.reload();
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

<style scoped>

 #reviewerNameField {
  margin-left: 100px; 
  width: 185px;

}
div#review-button {
  display: flex;
  font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
  color: rgb(180, 85, 21);
  font-size: 1.75rem;
  justify-content: center;
  align-items: center;

}

.form-controlReview {
  height: 15px;
}
div.container#reviewForm {
  border: groove 20px #644536;
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
    "name name"
    "rating rating"
    "info info"
    "submit cancel";
}
form div#reviewerName {
  grid-area: name;
  padding: 10px;
  display: block;
  float: left;
}
form div#Rating {
  grid-area: rating;
  padding: 10px;
  display: block;
  float: right;
}


form div#reviewInfo {
  grid-area: info;
   display: block;
  float: right;
}
form input#submitReview {
  grid-area: submit;
  margin: 5px;
}
form input#cancelReview {
  grid-area: cancel;
  margin: 5px;
}

form .dropperReview {
  height: 19px;
} 
</style>
