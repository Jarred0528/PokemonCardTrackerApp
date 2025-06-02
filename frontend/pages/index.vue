<template>
  <div>
    <article v-if="status === 'pending'" aria-busy="true" />
    <article v-else-if="error">
      <h2 class="text-2xl font-bold mb-4 error">Error loading cards</h2>
      <p>{{ error.statusMessage }}</p>
    </article>
    <div v-else>
      <article v-for="card in cards" :key="card.id" class="card">
        <h3 class="text-xl font-bold">{{ card.title }}</h3>
        <p>
          {{ card.description }}
        </p>
      </article>
    </div>
  </div>
</template>

<script lang="ts" setup>
const {
  data: cards,
  error,
  status,
} = await useFetch("/api/card", {
  lazy: true,
});
</script>
