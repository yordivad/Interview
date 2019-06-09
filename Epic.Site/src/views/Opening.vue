<template>
    <form novalidate @submit.prevent="validate">



        <md-content>
            <md-steppers md-alternative md-elevation="0">
                <md-step id="first" md-label="Personal Information">

                    <md-field>
                        <label for="name">Name</label>
                        <md-input id="name" autocomplete="Name"/>
                    </md-field>

                    <md-field>
                        <label for="lastName">Last Name</label>
                        <md-input id="lastName" autocomplete="Last Name"/>
                    </md-field>

                    <md-field>
                        <label for="email">Email</label>
                        <md-input id="email" type="email" autocomplete="Email"/>
                    </md-field>

                    <md-field>
                        <label for="phone">Phone</label>
                        <md-input id="phone"/>
                    </md-field>

                    <md-field>
                        <label for="linked">Linked Profile</label>
                        <md-input id="linked"/>
                    </md-field>


                </md-step>
                <md-step id="second" md-label="Position">

                    <md-field>
                        <label for="food">Developer</label>
                        <md-select id="position">
                            <md-optgroup label="Development">
                                <md-option value="apple-pie">.Net</md-option>
                                <md-option value="chocolate-cake">Java</md-option>
                            </md-optgroup>

                            <md-optgroup label="QA">
                                <md-option value="apples">Automation</md-option>
                            </md-optgroup>

                            <md-optgroup label="DevOps">
                                <md-option value="broccoli">Amazon</md-option>
                                <md-option value="carrots">Azure</md-option>
                            </md-optgroup>
                        </md-select>
                    </md-field>

                    <md-field>
                        <label for="name">Availability</label>
                        <md-select id="availability">
                            <md-option value="chocolate-cake">Immediately</md-option>
                            <md-option value="apples">two weeks</md-option>
                            <md-option value="broccoli">one month</md-option>
                        </md-select>
                    </md-field>

                    <md-field>
                        <label for="name">Offer Source</label>
                        <md-select id="availability">
                            <md-option value="chocolate-cake">Email</md-option>
                            <md-option value="apples">Linked Link</md-option>
                            <md-option value="broccoli">Referral</md-option>
                            <md-option value="broccoli">Other</md-option>

                        </md-select>
                    </md-field>

                    <md-field>
                        <label>Upload Resume</label>
                        <md-file  />
                    </md-field>


                </md-step>
                <md-step id="third" md-label="Status">
                    <md-field>
                        <label for="phone">Nationality</label>
                        <md-select id="position">
                            <md-option value="apple-pie">Costa Rica</md-option>
                            <md-option value="chocolate-cake">USA</md-option>
                            <md-option value="apples">Spain</md-option>
                            <md-option value="broccoli">Nigeria</md-option>
                            <md-option value="carrots">German</md-option>
                        </md-select>
                    </md-field>



                        <md-switch>Are you available to work</md-switch>


                </md-step>
                <md-step id="fourth" md-label="Experience">

                    <md-table>
                        <md-table-row>
                            <md-table-head >Experience</md-table-head>
                            <md-table-head >Technology</md-table-head>
                            <md-table-head>Years</md-table-head>
                            <md-table-head>Domain</md-table-head>

                        </md-table-row>

                        <md-table-row>
                            <md-table-cell> <md-checkbox></md-checkbox> </md-table-cell>
                            <md-table-cell> <md-field type="label">Java</md-field>  </md-table-cell>
                            <md-table-cell> <md-field> <md-input type="number"/> </md-field></md-table-cell>
                            <md-table-cell><md-field> <md-input type="range"/> </md-field></md-table-cell>
                        </md-table-row>


                        <md-table-row>
                            <md-table-cell> <md-checkbox></md-checkbox> </md-table-cell>
                            <md-table-cell> <md-field type="label">.Net</md-field>  </md-table-cell>
                            <md-table-cell> <md-field> <md-input type="number"/>  </md-field></md-table-cell>
                            <md-table-cell><md-field> <md-input type="range"/>
                                <md-tooltip >Advance</md-tooltip> </md-field>
                            </md-table-cell>
                        </md-table-row>

                        <md-table-row>
                            <md-table-cell> <md-checkbox></md-checkbox> </md-table-cell>
                            <md-table-cell> <md-field type="label">Microsoft Sql</md-field>  </md-table-cell>
                            <md-table-cell> <md-field> <md-input type="number"/>  </md-field></md-table-cell>
                            <md-table-cell><md-field> <md-input type="range"/>
                                <md-tooltip >Advance</md-tooltip> </md-field>
                            </md-table-cell>
                        </md-table-row>

                        <md-table-row>
                            <md-table-cell> <md-checkbox></md-checkbox> </md-table-cell>
                            <md-table-cell> <md-field type="label">Oracle</md-field>  </md-table-cell>
                            <md-table-cell> <md-field> <md-input type="number"/>  </md-field></md-table-cell>
                            <md-table-cell><md-field> <md-input type="range"/>
                                <md-tooltip >Advance</md-tooltip> </md-field>
                            </md-table-cell>
                        </md-table-row>
                    </md-table>

                </md-step>
                <md-step id="fifth" md-label="Language">

                    <md-field>
                        <label for="name">English Speaking</label>
                        <md-select id="speak">
                            <md-option value="chocolate-cake">Beginner</md-option>
                            <md-option value="apples">Medium</md-option>
                            <md-option value="broccoli">Advance</md-option>
                            <md-option value="carrots">Native</md-option>
                        </md-select>
                    </md-field>

                    <md-field>
                        <label for="name">English Writing</label>
                        <md-select id="write">
                            <md-option value="chocolate-cake">Beginner</md-option>
                            <md-option value="apples">Medium</md-option>
                            <md-option value="broccoli">Advance</md-option>
                            <md-option value="carrots">Native</md-option>
                        </md-select>
                    </md-field>


                </md-step>

            </md-steppers>

        </md-content>

    </form>
</template>

<script>
    export default {
        name: "Opening"
    }
</script>

<style scoped lang="sass">

</style>