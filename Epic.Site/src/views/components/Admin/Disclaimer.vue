<template lang="pug">
    
    .disclaimer
        md-content
            h2 Disclaimer
            h3 Title:
            md-field(md-clearable)
                label Write Title Here
                md-input(v-model='titleMaxLength' maxlength='50' required)
            h3 Text:
            md-field(md-clearable)
                label Write Disclaimer Text Here
                md-textarea(required)

</template>

<script>
    export default {
        name: 'Disclaimer',
        data: () =>({
            titleMaxLength: null
        })
    }
</script>

<style scoped>

</style>