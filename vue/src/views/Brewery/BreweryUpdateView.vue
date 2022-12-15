<template>
  <div class="breweryView">
      <brewery-update/>   
      <add-beer/>  
      <delete-beer/>
  </div>
</template>

<script>

import BreweryUpdate from '../../components/Brewery/BreweryUpdate.vue'
import AddBeer from '../../components/Beer/AddBeer.vue'
import DeleteBeer from '../../components/Beer/DeleteBeer.vue'
export default {
    components:{
        BreweryUpdate,
        AddBeer,
        DeleteBeer,
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

