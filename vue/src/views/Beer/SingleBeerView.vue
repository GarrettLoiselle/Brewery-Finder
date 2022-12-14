<template>
<div id="singleBeerAndReviews">
  <h2></h2>
  <div class ="snglbeer">
  <singleBeer/>
  </div>
  <div class = "snglreview">
  <review/>
  </div>
  <addReview/>
</div>
</template>

<script>
import SingleBeer from '../../components/Beer/SingleBeer.vue'
import Review from '../../components/Review/Review.vue'
import AddReview from '../../components/Review/AddReview.vue'
export default {
  components:{
    SingleBeer,
    Review,
    AddReview,
  }

}
</script>
<style scoped>
#singleBeerAndReviews{
  display: grid;
  grid-template-areas:
  'singleBeer review';
  grid-template-columns: 3fr 1fr ;
  margin: 10px;
}
div.snglbeer{
  grid-area: singleBeer;
}
div.snglreview{
  grid-area: review;
  display: flex;
}

</style>