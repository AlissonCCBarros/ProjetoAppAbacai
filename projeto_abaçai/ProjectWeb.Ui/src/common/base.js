import pagination from '@/common/components/pagination'

export default {
    components: { pagination },
    data: () => ({
        mask_data: '##/##/####',
        mask_cnpj: '##.###.###/####-##',
        mask_cpf: '###.###.###-##',
        mask_rg: '##.###.###-#',
        mask_tel: '(##)####-####',
        mask_cel: '(##)#####-####',
        mask_cep: '#####-###',
        mask_ddd: '##',
        money: {
            decimal: ',',
            thousands: '.',
            precision: 2,
            masked: false,
        },
    }),
    methods: {

        defaultPageChanged: function (filter, index) {
            filter.pageIndex = index;
            return filter;
        },
        defaultOrderBy: function (filter, field) {
            let type = 0;
            if (filter.orderByType == 0) type = 1;
            filter.orderFields = field;
            filter.orderByType = type;
            filter.isOrderByDynamic = true;
            return filter;
        },

        defaultWarningResult: function (msg) {
            this.hideLoading();
            this.$eventHub.$emit('show-notification', {
                type: 'warning',
                title: 'Informação',
                text: msg
            })
        },

        defaultInfoResult: function (msg) {
            this.hideLoading();
            this.$eventHub.$emit('show-notification', {
                type: 'info',
                title: 'Informação',
                text: msg
            })
        },

        defaultSuccessResult: function (msg) {
            this.hideLoading();
            this.$eventHub.$emit('show-notification', {
                type: 'success',
                title: 'Sucesso',
                text: msg
            })
        },
        defaultErrorResult: function (err) {
            this.hideLoading();
            if (err.data && err.data.errors) {
                for (var i = 0; i < err.data.errors.length; i++) {
                    this.$eventHub.$emit('show-notification', {
                        type: 'error',
                        title: 'Atenção',
                        text: err.data.errors[i]
                    })
                }
            }

            else
                this.$eventHub.$emit('show-notification', {
                    type: 'error',
                    title: 'Atenção',
                    text: err
                })
        },
        configNotification() {
            this.$eventHub.$on('show-notification', (data) => {
                this.$notify({
                    type: data.type,
                    title: data.title,
                    text: data.text,
                    duration: 10000,
                    speed: 1000
                })
            })
        },
        showLoading: function () {
            this.$eventHub.$emit('show-loading', true)
        },
        hideLoading: function () {
            this.$eventHub.$emit('show-loading', false)
        },
        failLoading: function () {
            this.$eventHub.$emit('show-loading', false)
        },

    },
    mounted() {
        window.scrollTo(0, 0);
    },
}
