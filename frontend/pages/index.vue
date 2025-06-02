<template>
  <div>
    <article v-if="status === 'pending'" aria-busy="true" />
    <article v-else-if="error">
      <h2 class="text-2xl font-bold mb-4 error">Error loading cards</h2>
      <p>{{ error.statusMessage }}</p>
    </article>
    <div v-else>
      <article class="card">
        <h2 class="text-2xl font-bold mb-4">{{ cardName }}</h2>
        <img :src="cardImageUrl" :alt="cardName" class="w-48" />
      </article>
    </div>
  </div>
</template>

<script lang="ts" setup>
import type { PokemonCardViewModel } from "~/types/PokemonCardViewModel";

const config = useRuntimeConfig();

const {
  data: card,
  error,
  status,
} = await useFetch<PokemonCardViewModel>(
  () => `${config.public.apiBase}api/home/card`,
  { lazy: true }
);

const cardName = computed(() => card.value?.cardName);
const cardImageUrl = computed(() => card.value?.cardImageUrl);
</script>
