(function () {

    'use strict';

    angular
        .module('DeviceCheckout')
        .controller('HomeCtrl', HomeCtrl);

    HomeCtrl.inject = ['DeviceCheckout'];

    function HomeCtrl(DeviceCheckout, $q) {

        // Page Variables:
        var vm = this;

        // Binding:
        vm.getPage1 = getPage1;
        vm.getPage2 = getPage2;
        vm.getPage3 = getPage3;

        vm.bsulogo = "http://brandstandards.boisestate.edu/wp-content/uploads/2013/01/boisestate-primarylogo-2color-RGB.jpg";

        function activate() {
            vm.page1 = true;
        }

        activate();


        var promises = [getStudentInfo(), getDevicePreset()];
        $q.all(promises);

        // This gets the student's username:
        function getStudentInfo() {
            return DeviceCheckout.getStudentInfo()
            .then(function (result) {
                vm.studentName = result.data[0].studentName;
            });
        }

        //This gets info from Device Preset

        function getDevicePreset() {
            return DeviceCheckout.getDevicePreset()
            .then(function (result) {
                vm.devicePreset = result.data;
            });
        }

        // This function switches the hide function on pages from true to false to allow user proceed through app
        function getPage1(input) {

            return DeviceCheckout.getDeviceInfoUrl(input)
            .then(function (result) {

                vm.getDeviceInfoUrl = [];
                vm.zoneDetail = [];

                for (var x = 0; x < result.data.length; x++) {
                    vm.getDeviceInfoUrl.push(result.data[x].deviceInfo0);
                    vm.zoneDetail.push(result.data[x].zoneInfo);
                }
                vm.page1 = false;
                vm.page2 = true;
             });
        }

        function getPage2() {
            var date = new Date();

            if (date.getHours() < 8 || date.getHours() > 5) {
                vm.hour1 = "8";
                vm.hour2 = "8";
                vm.date1 = date.getDate();
                vm.date1 = date.getDate();
            } else {
                vm.hour1 = date.getHours();
                vm.hour2 = date.getHours();
                vm.date1 = date.getDate();
                vm.date1 = date.getDate();
            }

            vm.min1 = "00";
            vm.min2 = "00";

            vm.page2 = false;
            vm.page3 = true;
        }

        function getPage3() {
            vm.loc = "MBEB";
            vm.random = Math.floor((Math.random() * 1001) + 2304);


            vm.page3 = false;
            vm.page4 = true;
 
        }

    }

})();