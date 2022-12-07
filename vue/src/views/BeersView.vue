<template>
<div>
  <h2>You have reached Beer view</h2>
  <beers/>
</div>
</template>

<script>
import Beers from '../components/Beers.vue'
export default {
  components:{
    Beers
  }

}
</script>

<style>
div {
  height: 84vh;
  display: grid;
   grid-template-areas: 
  'header header header'
  'main main main'

}
h2 {
  grid-area: header;
}

</style>