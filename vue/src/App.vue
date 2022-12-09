<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">&nbsp; Logout</router-link>
      <router-link v-bind:to="{name: 'brewery'}">&nbsp;Brewery</router-link>
      <router-link v-bind:to="{name: 'allBeersList'}">&nbsp;Beer</router-link>
      <router-link v-bind:to="{name: 'addBrewery'}">&nbsp;Add Brewery</router-link>
      <router-link v-bind:to="{name: 'updateBrewery'}">&nbsp;Update Brewery</router-link>
      <p v-if="$store.state.user.username"> User is {{$store.state.user.username}}</p>
    </div>
    <router-view />
    <footer>
      Thank you for viewing our page. 
    </footer>
  </div>
</template>
<script>


export default {
  name: "App"
}
</script>

<style>
/*color Palette: brown 644536, camel C4A381, Offwhite EEF1BD */
#app {
  display:grid;
  text-align: center;
  grid-template-areas:
  'header header header'
  'side main side '
  'footer footer footer';
  grid-template-columns: 1fr;
  grid-template-rows: 1fr 4fr 1fr;
  color: #EEF1BD;
}
body{
   background: url("https://t3.ftcdn.net/jpg/03/08/47/58/360_F_308475881_m7o04LTdIbwWWnSJDqjFTjOnWvU0yj8b.jpg") no-repeat center fixed;
   background-size: cover;
   width: 100%;
   height: 100%;
   min-height: 1260px;
}
#nav {
  display: flex;
  justify-content: space-evenly;
  background-color: #C4A381;
  grid-area: header;
  align-items: center;
  height: 8vh;
  width: 100%;
}

a:visited {
  color: #eef1bd;
  text-decoration: none;
}

a:hover {
  color: white;
  text-decoration: underline;
}


div#side{
  grid-area: side;
}

footer{
  background-color:#644536;
  grid-area: footer;
  bottom: 0;
  width: 100%;
  height: 8vh;
  display: flex;
  position: fixed;
  align-items: center;
  justify-content: center;
}

router-view {
  grid-area: main;
}
</style>
