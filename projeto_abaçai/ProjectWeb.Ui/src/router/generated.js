
const routers = [
    { path: 'account', name: 'Contas', component: function (resolve) { require(['@/views/account'], resolve) } },
    { path: 'projeto', name: 'Projetos', component: function (resolve) { require(['@/views/projeto'], resolve) } },

];

export default routers