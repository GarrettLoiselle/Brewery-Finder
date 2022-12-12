<template>
  <div>
      <brewery-update/>   
      <add-beer/>  
  </div>
</template>

<script>

import BreweryUpdate from '../../components/Brewery/BreweryUpdate.vue'
import AddBeer from '../../components/Beer/AddBeer.vue'
export default {
    components:{
        BreweryUpdate,
        AddBeer
    }

}
</script>

