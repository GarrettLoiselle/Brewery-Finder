<template>
  <div>
      <singleBrewery />
      <breweryNews />
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
<style scoped>

div{
  margin:5px;
}
</style>