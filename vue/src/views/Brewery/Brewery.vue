<template>
<div id="breweryDiv">
  <h2 id="breweryH2"></h2>
  <brewery></brewery>
</div>
</template>

<script>
import Brewery from "../../components/Brewery/Brewery.vue"
export default {
  components:{
    Brewery
  }

}
</script>

<style>
div#breweryDiv {
display: flex;
flex-direction: column;
align-items: center;
justify-content: center;
}

</style>
