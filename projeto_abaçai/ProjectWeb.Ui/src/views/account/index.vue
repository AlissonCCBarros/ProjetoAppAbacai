<template>
    <main>
        <section>
            <div class="content-960">
                <div class="row">
                    <section class="col-sm-12">
                        <button class="btn-large-40 btn-primary uppercase pull-right btn-header mr-1" @click="showHideFiltros()">
                            Filtros
                        </button>
                    </section>
                </div>
            </div>

            <div class="content-960 mobile-row mt-4" v-if="showFiltros">
                <div class="wrapper-960 clearfix">
                    <div class="titles icons icon-news-middle">
                        <h2 class="uppercase"><b>Filtros</b></h2>
                    </div>

                    <div class="mold-txt-center">
                        <form v-on:submit.prevent="executeFilter(filter)">
                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label for="name">Nome</label>
                                    <input type="text" class="form-control" name="name" placeholder="Name" v-model="filter.name" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="email">E-mail</label>
                                    <input type="text" class="form-control" name="email" placeholder="E-mail" v-model="filter.email" />
                                </div>
                            </div>
                            <button type="button" class="btn-large-40 btn-red uppercase" @click="executeFilter(filter)">Buscar</button>
                        </form>
                    </div>
                </div>
            </div>

            <br/>
            <br/>

            <div class="content-960 mobile-row">
                <div class="wrapper-960 clearfix">
                    <div class="titles icons icon-news-middle">
                        <h2 class="uppercase"><b>Contas</b></h2>
                    </div>

                    <div class="table-responsive standard-table header-cinza">
                        <table>
                            <thead>
                                <tr>
                                    <th>Nome<i @click="executeOrderBy('Name')" class="fa fa-sort"></i></th>
                                    <th>E-mail<i @click="executeOrderBy('Email')" class="fa fa-sort"></i></th>

                                    <th class="text-center" width="150"><i class="fa fa-cog"></i></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="item in result.items" class="animated fadeIn">
                                    <td>{{ item.name }}</td>
                                    <td>{{ item.email }}</td>

                                    <td class="text-center">
                                        <button type="button" class="btn btn-sm btn-danger" @click="openRemove({ accountId: item.accountId })">
                                            <i class="fa fa-trash-o"></i>
                                        </button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <div class="card-block no-padding">
                        <pagination :total="result.total" :page-size="filter.pageSize" :callback="executePageChanged"></pagination>
                    </div>

                </div>
            </div>
        </section>

        <b-modal :no-close-on-backdrop="true" :no-close-on-esc="true" centered v-model="dialogRemove" title="Confirmação">
            <p>Tem certeza que deseja remover este item?</p>
            <div slot="modal-footer">
                <button class="btn btn-sm btn-danger" @click="executeRemove()">
                    Remover
                </button>
            </div>
        </b-modal>

    </main>

</template>
<script>

    import base from '@/common/base.js'
    import { Api } from '@/common/api'

    import formCreate from './form-create'
    import formEdit from './form-edit'

    export default {
        name: 'account',
        mixins: [base],
        components: { formCreate, formEdit },
        data() {
            return {

                resources: {
                    filter: 'account',
                    remove: 'account'
                },

                showFiltros: false,
                dialogRemove: false,
                dialogCreate: false,
                dialogEdit: false,

                model: {},
                filter: {
                    pageSize: 50,
                    pageIndex: 1,
                    isPagination: true,
                },

                result: {
                    total: 0,
                    items: []
                }
            }
        },
        methods: {
            showHideFiltros: function () {
                this.showFiltros = !this.showFiltros;
            },
            openEdit: function (model) {
                this.accountId = model.accountId;
                this.dialogEdit = true;
            },
            openCreate: function () {
                this.dialogCreate = true;
            },
            onSaved: function () {
                this.hideAll();
                this.executeLoad();
            },
            hideAll: function () {
                this.dialogCreate = false;
                this.dialogEdit = false;
                this.dialogRemove = false;
            },

            openRemove: function (model) {
                this.dialogRemove = true;
                this.model = model;
            },
            executeRemove: function (model) {
                if (model) this.model = model;
                new Api(this.resources.remove).delete(this.model).then(() => {
                    this.defaultSuccessResult("Item removido com sucesso");
                    this.hideAll();
                    this.executeLoad();
                }, err => {
                    this.defaultErrorResult(err);
                })
            },

            executeFilter: function (filter) {
                if (filter) this.filter = filter;
                this.executeLoad();
            },
            executePageChanged: function (index) {
                this.filter = this.defaultPageChanged(this.filter, index);
                this.executeLoad();
            },
            executeOrderBy: function (field) {
                this.filter = this.defaultOrderBy(this.filter, field);
                this.executeLoad();
            },
            executeLoad: function () {
                this.showLoading();
                new Api(this.resources.filter).get(this.filter).then(data => {
                    if (data.summary) this.result.total = data.summary.total;
                    this.result.items = data.dataList;
                    this.hideLoading();
                }, (err) => {
                    this.failLoading();
                    if (err && err.data && err.data.errors) {
                        this.$eventHub.$emit('show-notification', {
                            type: 'error',
                            title: 'Atenção',
                            text: err.data.errors[0]
                        })
                    }
                });
            },

        },

        mounted() {
            this.executeFilter();
        }

    };
</script>