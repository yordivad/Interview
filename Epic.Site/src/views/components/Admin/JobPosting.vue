<template lang="pug">

form(novalidate='' @submit.prevent='validate')
  md-content
    h2 New Job Posting
        md-field(md-clearable)
            label(for='name') Name:
            md-input#name(autocomplete='Name' required v-model='nameMaxLength' maxlength='50' md-placeholder="Insert Name Here")
        md-field(md-clearable)
            label(for='description') Description:
            md-textarea#description(required)
        md-chips(v-model="skills" md-placeholder="Add Required Skills")

</template>

<script>
    export default {
        name: "JobPosting",
        data: () =>({
            nameMaxLength: null,
            skills: ['awefwe', 'awefawef', 'afwfe']
        })
    }
</script>

<style scoped lang="sass">

</style>