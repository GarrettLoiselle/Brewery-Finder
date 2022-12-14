<template>
  <div id='singleBreweryPage'>
    <div id='singleBrewery'>
      <singleBrewery />
    </div>
    <div id='singleNews'>
      <breweryNews />
    </div>
    <div id='singleEvents'>
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
<style scoped>
div#singleBreweryPage{
  display: grid;
  grid-template-areas: 
  'singleBrewery singleNews'
  'singleBrewery singleEvents';
}
div#singleBrewery{
  grid-area: singleBrewery;
}
div#singleNews{
  grid-area: singleNews;
}
div#singleEvents{
  grid-area: singleEvents;
}

div{
  margin:5px;
}
</style>