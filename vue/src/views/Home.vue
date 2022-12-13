<template>
  <div class="home">
    <h1>Home</h1>
    <p>Thank you for logging in!</p>
    <img src="favicon.ico" alt="icon">
  </div>
</template>

<script>
export default {
  name: "home"
};
</script>
<style scoped>
div.home{
  display: flex;
  flex-direction: column;
 border: groove 20px #644536;
  background-color: black;
    margin:50px 500px 0px 500px;
    align-items: center;
    justify-content: space-between;
    
}
div.home img{
  height: 75%;
  width: 50%;
  border: groove 10px #c4a381;
  margin: 10px;
  padding: 10px;
}
div.home p{
       font-family:cursive;
  color: rgb(236, 230, 230);
}

</style>