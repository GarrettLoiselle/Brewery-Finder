<template>
<div>
  <h2>You have reached Brewery view</h2>
  <brewery></brewery>
</div>
</template>

<script>
import Brewery from "../components/Brewery.vue"
export default {
  components:{
    Brewery
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