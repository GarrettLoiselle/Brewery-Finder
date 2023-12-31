import Vue from 'vue'
import Router from 'vue-router'
import store from '../store/index'

import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import NotFound from '@/views/NotFound.vue'
import Brewery from '@/views/Brewery/Brewery.vue'
import BreweryAddView from '@/views/Brewery/BreweryAddView.vue'
import BreweryUpdateView from '@/views/Brewery/BreweryUpdateView.vue'
import BeersView from'@/views/Beer/BeersView.vue'
import AllBeersView from'@/views/Beer/AllBeersView.vue'
import SingleBeerView from'@/views/Beer/SingleBeerView.vue'
import SingleBreweryView from'@/views/Brewery/SingleBreweryView.vue'
Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "*",
      name: "not-found",
      component: NotFound,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/brewery",
      name: "brewery",
      component: Brewery,
      meta: {
        requiresAuth: false
      }
    },
    {
      path:"/addBrewery",
      name:"addBrewery",
      component: BreweryAddView,
    meta:{requiresAuth:false /* Change later*/}
    },
    {
      path:"/updateBrewery",
      name:"updateBrewery",
      component: BreweryUpdateView,
    meta:{requiresAuth:false /* Change later*/}
    },
    {
      path:"/beers/:breweryId",
      name:"beersList",
      component: BeersView,
    meta:{requiresAuth:false}
    },
    {
      path:"/beers",
      name:"allBeersList",
      component: AllBeersView,
    meta:{requiresAuth:false}
    },
    {
      path:"/singleBeer/:beerId",
      name:"singleBeer",
      component: SingleBeerView,
    meta:{requiresAuth:false}
    },
    {
      path:"/singleBrewery/:breweryId",
      name:"singleBrewery",
      component: SingleBreweryView,
    meta:{requiresAuth:false}
    },
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
