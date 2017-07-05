(function () {

    'use strict';

    angular
        .module('DeviceCheckout')
        .factory('DeviceCheckout', DeviceCheckout)

    DeviceCheckout.inject = ['$http'];

    function DeviceCheckout($http) {

        var server = "http://localhost:8000/api/";

        return {
            getStudentInfo: getStudentInfo,
            getDevicePreset: getDevicePreset,
            getDeviceInfoUrl: getDeviceInfoUrl
        };

        // Get: /api/getstudentinfo
        function getStudentInfo() {
            return $http.get(server + "getstudentinfo", { cache: false });
        }

        // Get: /api/getdevicepreset
        function getDevicePreset() {
            return $http.get(server + "getdevicepreset", { cache: false });
        }

        // Get: /api/getdeviceinfourl
        function getDeviceInfoUrl(input) {
            return $http.get(server + "getdeviceinfourl?input=" + input, { cache: false });
        }

    }

})();