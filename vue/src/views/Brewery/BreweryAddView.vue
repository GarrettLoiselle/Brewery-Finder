<template>
  <div>
      <add-brewery/>  
      <add-beer/> 
  </div>
</template>

<script>

import AddBrewery from '../../components/Brewery/AddBrewery.vue'
import AddBeer from '../../components/Beer/AddBeer.vue'
export default {
    components:{
        AddBrewery,
        AddBeer
    }

}
</script>

