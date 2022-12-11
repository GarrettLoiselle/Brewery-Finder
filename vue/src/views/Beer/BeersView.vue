<template>
<div>
  <h2>You have reached Beer view</h2>
  <beers/>
</div>
</template>

<script>
import Beers from '../../components/Beer/Beers.vue'
export default {
  components:{
    Beers
  }

}
</script>

<style>
div {
  display: grid;
   grid-template-areas: 
  'header header header'
  'main main main'
;
}
h2 {
  grid-area: header;
}

.beers{
  grid-area: main;
}

</style>
