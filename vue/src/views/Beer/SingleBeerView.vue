<template>
<div id="singleBeerAndReviews">
  <h2></h2>
  <singleBeer/>
  <review/>
</div>
</template>

<script>
import SingleBeer from '../../components/Beer/SingleBeer.vue'
import Review from '../../components/Review/Review.vue'
export default {
  components:{
    SingleBeer,
    Review
  }

}
</script>
<style scoped>
#singleBeerAndReviews{
  display: flex;
  flex-direction: column;
}
</style>