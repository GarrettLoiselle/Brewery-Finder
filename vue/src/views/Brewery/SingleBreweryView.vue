<template>
  <div>
    <h2></h2>
    <div>
      <singleBrewery />
      <breweryNews />
      <breweryEvents/>
    </div>
  </div>
</template>

<script>
import SingleBrewery from "../../components/Brewery/SingleBrewery.vue";
import BreweryNews from "../../components/Brewery/BreweryNews.vue";
import BreweryEvents from "../../components/Brewery/BreweryEvents.vue";
export default {
  components: {
    SingleBrewery,
    BreweryNews,
    BreweryEvents,
  },
};
</script>