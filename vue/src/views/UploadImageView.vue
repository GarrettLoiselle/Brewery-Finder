<template>
  <div id="app">
      <upload-images></upload-images>
  </div>
</template>

<script>
import UploadImages from "@/components/UploadImages";

export default {
  name: "App",
  components: {
    UploadImages
  }
};
</script>