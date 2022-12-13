<template>
<div>

  <div class="breweryView">
      <add-brewery/>  

  </div>
</div>
</template>

<script>

import AddBrewery from '../../components/Brewery/AddBrewery.vue'
export default {
    components:{
        AddBrewery,

    }

}
</script>
<style>
div.breweryView{
  border: groove 20px #644536;
  background-color: black;
  margin: 20px;
}

</style>

