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