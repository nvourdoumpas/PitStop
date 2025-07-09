<template>
  <!-- <header>
    <img alt="Vue logo" class="logo" src="@/assets/logo.svg" width="125" height="125" />

    <div class="wrapper">
      <HelloWorld msg="You did it!" />

      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/about">About</RouterLink>
      </nav>
    </div>
  </header>

  <RouterView /> -->
  <NavBar />

  <div>
    <h2>Weather Forecast</h2>
    <ul v-if="forecasts.length">
      <li v-for="(forecast, index) in forecasts" :key="index">
        {{ forecast.date }} - {{ forecast.summary }} ({{ forecast.temperatureC }}°C)
      </li>
    </ul>
    <p v-else>Loading...</p>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue"
import { getWeatherForecastService, type WeatherForecast } from "@/api"
import NavBar from "./components/layout/NavBar.vue"

//import { RouterLink, RouterView } from 'vue-router'
// Create a ref to hold the data

const forecasts = ref<WeatherForecast[]>([])

// Fetch on mount
onMounted(async () => {
  try {
    const { getWeatherForecast } = getWeatherForecastService()
    const response = await getWeatherForecast()
    forecasts.value = response
  } catch (error) {
    console.error("Failed to fetch forecast:", error)
  }
})
</script>

<style scoped></style>
