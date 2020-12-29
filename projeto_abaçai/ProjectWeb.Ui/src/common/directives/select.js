import Vue from 'vue'
import { Api } from '@/common/api'

//import 'choices.js/public/assets/styles/base.min.css'
import 'choices.js/public/assets/styles/choices.min.css'

import Choices from 'choices.js'

function _addOption(el, text, value, selected) {
    var option = document.createElement("option");
    option.text = text;
    option.value = value;
    if (selected) option.selected = true
    el.add(option);
}

function _addItems(el, items, value) {
    for (var i = 0; i < items.length; i++) {
        _addOption(el, items[i].name, items[i].id, items[i].id == value);
    }
}

Vue.directive('select', {
    twoWay: true,
    inserted: (el, binding, vnode) => {

        if (binding.value.default)
            _addOption(el, binding.value.default, "");

        var resource = binding.value.dataitem + "/dataitems";

        var filters = {};
        if (binding.value.filters)
            filters = binding.value.filters;

        var api = new Api(resource);
        api.dataItem(filters).then(data => {

            var value = getVModelValue(vnode);

            if (data.dataList)
                _addItems(el, data.dataList, value);

        });

        function findVModelName(vnode) {
            return vnode.data.directives.find(function (o) {
                return o.name === 'model';
            }).expression;
        }

        function getVModelValue(vnode) {
            var prop = findVModelName(vnode)
            return eval('vnode.context.' + prop)
        }

    }
})