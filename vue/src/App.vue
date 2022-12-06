<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">&nbsp;|&nbsp; Logout</router-link>
      <router-link v-bind:to="{name: 'brewery'}"> Brewery</router-link>
      <p v-if="$store.state.user.username"> User is {{$store.state.user.username}}</p>
    </div>
    <router-view />
  </div>
</template>
