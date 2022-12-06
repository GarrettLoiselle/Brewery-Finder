<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">&nbsp;|&nbsp; Logout</router-link>
      <router-link v-bind:to="{name: 'brewery'}">&nbsp;|&nbsp; Brewery</router-link>
      <router-link v-bind:to="{name: 'addBrewery'}">&nbsp;|&nbsp;Add Brewery</router-link>
      <router-link v-bind:to="{name: 'updateBrewery'}">&nbsp;|&nbsp;Update Brewery</router-link>
      <p v-if="$store.state.user.username"> User is {{$store.state.user.username}}</p>
    </div>
    <router-view />
  </div>
</template>
<script>


export default {
  name: "App"
}
</script>

<style>
/*color Palette: brown 644536, camel C4A381, Offwhite EEF1BD */
#app{
  text-align: center;
}
#nav{
  padding: 30px
}

</style>