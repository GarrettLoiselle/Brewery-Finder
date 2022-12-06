<template>
  <div class="brewery">
    <table>
      <thead>
          <tr>
              <th>Brewery ID</th>
              <th>Brewery Name</th>
              <th>Brewery Zip</th>
          </tr>
      </thead>
      <tbody>
          <tr 
          v-for="(brewery, index) in brewerys"
          v-bind:key="index">
          </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: "Brewery",
};
</script>

<style>
</style>