<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">&nbsp; Logout</router-link>
      <router-link v-bind:to="{name: 'brewery'}">&nbsp;Brewery</router-link>
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
  'header'
  'main '
  'main '
  'main'
  'footer';
  grid-template-columns: 1fr;
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
  color: #644536;
}

a:hover {
  color: #eef1bd;
}

footer{
  background-color:#644536;
  grid-area: footer;
  bottom: 0;
  width: 100%;
  height: 8vh;
  display: flex;
  align-items: center;
  justify-content: center;
}

router-view {
  height: 84vh;
  grid-area: main;
  display:flex;
  align-items: center;
  justify-content: center;

}
</style>