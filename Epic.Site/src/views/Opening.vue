<template lang="pug">
    md-content
        HomeNavigation
        div
            md-table(v-model="searched" md-card)
                md-table-toolbar
                    h1(class="md-title") Available Jobs
                    md-field(md-clearable class="md-toolbar-section-end")
                        md-input(placeholder="Search by name..." v-model="search" @input="searchOnTable")
                md-table-empty-state(md-label="No matching jobs found")
                md-table-row(slot="md-table-row" slot-scope="{ item }")
                    md-table-cell(md-label="Name" md-sort-by="name") {{ item.name }}
                    md-table-cell(md-label="Type" md-sort-by="name") {{ item.type }}

</template>

<script>
    import HomeNavigation from "./components/Home/HomeNavigation.vue"
    import OpeningForm from "./components/Opening/OpeningForm.vue"

    const searchByName = (items, term) => {
        if (term) {
        return items.filter(item => toLower(item.name).includes(toLower(term)))
        }
        return items
    }
    const toLower = text => {
        return text.toString().toLowerCase()
    }

    export default {
        name: "Opening",
        components:{
            HomeNavigation,
            OpeningForm
        },
        data: () => ({
            jobs: [
                {
                id: 1,
                name: 'Senior Automation QA',
                type: 'QA'
                },
                {
                id: 2,
                name: 'Senior Java Developer',
                type: 'Developer'
                },
                {
                id: 3,
                name: 'Senior Cloud Software Architect',
                type: 'Architect'
                },
                {
                id: 4,
                name: 'Azure/AWS DevOps Engineer',
                type: 'DevOps'
                }
            ],
            search: null,
            searched: []
            }),
            methods: {
                searchOnTable () {
                    this.searched = searchByName(this.users, this.search);
                }
            },
            created () {
                this.searched = this.jobs
            }
    }
</script>

<style scoped lang="sass">

</style>