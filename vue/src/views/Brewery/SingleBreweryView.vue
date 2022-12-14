<template>
  <div>
    <h2></h2>
    <div>
      <singleBrewery />
      <breweryNews />
    </div>
  </div>
</template>

<script>
import SingleBrewery from "../../components/Brewery/SingleBrewery.vue";
import BreweryNews from "../../components/Brewery/BreweryNews.vue";
export default {
  components: {
    SingleBrewery,
    BreweryNews,
  },
};
</script>