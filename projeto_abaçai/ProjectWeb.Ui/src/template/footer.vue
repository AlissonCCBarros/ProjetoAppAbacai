<template>

    <footer>
        <div class="footer">
            <div class="row">
                <div class="content-960 clearfix">
                    <a href="#" title="Copyright © - Todos os direitos reservados.">Copyright © - Todos os direitos reservados.</a>
                    <a href="#" title="Política de Privacidade">Política de uso</a>
                </div>
            </div>

            <b-modal v-if="changelog" :no-close-on-backdrop="true" size="lg" :no-close-on-esc="true" centered v-model="dialogChangeLog" :hide-footer="true" :title="'Versão de ' + changelog.data">
                <div v-html="changelog.detalhes"></div>
            </b-modal>
        </div>
    </footer>

</template>
<script>

    export default {
        name: "footer-abracai",
        data() {
            return {
                changelog: null,
                dialogChangeLog: false
            };
        },
        mounted() {
        }

    };
</script>