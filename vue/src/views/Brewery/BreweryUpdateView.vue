<template>
  <div>
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
        DeleteBeer
    }

}
</script>

