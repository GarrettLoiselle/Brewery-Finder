<template>
  <div class="breweryView">
      <brewery-update/>   
      <add-beer/>  
      <delete-beer/>
      <upload-images/>
  </div>
</template>

<script>

import BreweryUpdate from '../../components/Brewery/BreweryUpdate.vue'
import AddBeer from '../../components/Beer/AddBeer.vue'
import DeleteBeer from '../../components/Beer/DeleteBeer.vue'
import UploadImages from '../../components/UploadImages.vue'
export default {
    components:{
        BreweryUpdate,
        AddBeer,
        DeleteBeer,
        UploadImages,
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

