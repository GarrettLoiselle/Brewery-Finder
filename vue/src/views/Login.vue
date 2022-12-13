<template>
  <div id="login" class="text-center">

    <form class="form-signing" @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal">Please Sign In</h1>
      <div class="alert alert-danger" role="alert" v-if="invalidCredentials" id="badlogin">
        Invalid username and password!
      </div>
      <div class="alert alert-success" role="alert" v-if="this.$route.query.registration">
        Thank you for registering, please sign in.
        </div>
        <div id="username">

      <label for="username" class="sr-only">Username: </label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
        </div>
        <div id="password">
      <label for="password" class="sr-only">Password: </label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
        </div>
        <div id="needaccount">
      <router-link :to="{ name: 'register' }" >Need an account?</router-link>
        </div>
        <div id="signin">
      <button type="submit">Sign in</button>
        </div>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>
<style>

.form-signing{
display: flex;
  flex-direction: column;
  align-items: center;
  border: groove 20px #644536;
  background-color: black;
}
h1{
  font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
  color: rgb(180, 85, 21);
}
 div{
  justify-content: center;
 }
 div#username{
   border: groove 10px #C4A381;
  background-color: black;
  padding: 5px;
  margin: 5px;
 }
  div#password{
   border: groove 10px #C4A381;
  background-color: black;
  padding: 5px;
  margin: 5px;
 }

</style>