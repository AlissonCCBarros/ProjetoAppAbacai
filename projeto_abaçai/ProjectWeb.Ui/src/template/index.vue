<template>

    <div>
        <loading />
        <header-abracai/>
        <router-view />
        <!--<footer-abracai/>-->
    </div>

</template>
<script>

    import footerAbracai from '@/template/footer'
    import headerAbracai from '@/template/header'
    import loading from '@/common/components/loading'

    export default {
        name: "Template",
        components: { footerAbracai, headerAbracai, loading },
        data() {
            return {

            };
        },
        mounted() {
           
        },
        beforeDestroy() {
        },
    };
</script>
