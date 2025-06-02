<template>
  <nav class="container">
    <ul>
      <li>
        <NuxtLink to="/">
          <strong>Pokemon Card Tracker</strong>
        </NuxtLink>
      </li>
    </ul>
    <ul>
      <li>
        <NuxtLink :to="{ name: 'card' }">Cards</NuxtLink>
      </li>
      <li>
        <NuxtLink href="#">My Collection</NuxtLink>
      </li>
      <li>
        <NuxtLink href="#">Search</NuxtLink>
      </li>
    </ul>
  </nav>
</template>
