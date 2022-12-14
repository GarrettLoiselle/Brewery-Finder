
<template>
  <div id="app">
    <div id="nav">
      <router-link class="navLink" v-bind:to="{ name: 'home' }" >Home</router-link>
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''" class="navLink">&nbsp; Logout</router-link>
      <router-link v-bind:to="{name: 'brewery'}" class="navLink">&nbsp;Brewery</router-link>
      <router-link v-bind:to="{name: 'allBeersList'}" class="navLink">&nbsp;Beer</router-link>
      <router-link v-bind:to="{name: 'addBrewery'}" class="navLink">&nbsp;Admin Functions</router-link>
      <router-link v-bind:to="{name: 'updateBrewery'}" class="navLink">&nbsp;Brewer Functions</router-link>
      <p v-if="$store.state.user.username" class="navLink"> Welcome {{$store.state.user.username}}, {{$store.state.user.role}}</p>
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
}
#nav {
  display: flex;
  justify-content: space-evenly;
  background-image: url("https://media.istockphoto.com/id/588995040/vector/beer-foam-background-lager-light-bitter.jpg?s=170667a&w=0&k=20&c=Ws2VAZsDZqtkyaZHPazpDDDbS1zgtEu7gX_ImoNlAKA=");
  grid-area: header;
  align-items: center;
  height: 8vh;
  width: 100%;
  border: solid 1px black;
}

a:link{
  text-decoration: none;
    color: rgb(180, 85, 21);
}
a:visited {
      color: rgb(180, 85, 21);
  text-decoration: none;
}

a:hover {
  color: #CF0A0A;
  text-decoration: underline;
}
a.navLink{
  color: #644536;

}
p.navLink{
  color: #644536;
}


footer{
  background:url("https://cdn.shopify.com/s/files/1/0556/0759/0985/articles/Slate-Countertop-Benefits_800x.jpg?v=1644894574");
  grid-area: footer;
  bottom: 0;
  width: 100%;
  height: 5vh;
  display: flex;
  position: fixed;
  align-items: center;
  justify-content: center;
  border:solid 1px black
}

router-view {
 grid-area: main;
}
</style>
