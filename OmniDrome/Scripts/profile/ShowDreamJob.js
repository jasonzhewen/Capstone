personalInfoModule.controller('ShowDreamJobCtrl', function ($scope, $filter, $state, personalInfoService) {

    $scope.DreamJobModel =
      {
         ID: '',
         companyName: '',
         startDate: '',
         description: '',
         UserInfoID:''
      };

    var GetDJInfo = personalInfoService.getDreamJobInfo();
    GetDJInfo.then(function (data) {     
        if (data.data !== "") {
            $scope.DreamJobModel.ID = data.data.ID;
            $scope.DreamJobModel.companyName = data.data.companyName;
            $scope.DreamJobModel.description = data.data.description;
            $scope.DreamJobModel.position = data.data.position;
            $scope.DreamJobModel.startDate = $filter('date')(new Date(parseInt(data.data.startDate.substr(6))), "yyyy-MM-dd");
            $scope.DreamJobModel.UserInfoID = data.data.UserInfoID;
        }
        //console.log($scope.isEmpty($scope.DreamJobModel));
    });
    //$filter('date')(new Date(parseInt(data.data.startDate.substr(6))), "yyyy-MM-dd");
   // $filter('date')(new Date(), "yyyy-MM-dd");

    $scope.isEmpty = function (obj) {
        var isEmpty = true;
        angular.forEach(obj, function (value, key) {
            if (value !== '') {
                isEmpty = false;
            }
        });
        return isEmpty;
    };

    $scope.DeleteDreamJob = function (dreamjobinfoID) {
        var dD = personalInfoService.deleteDreamJob(dreamjobinfoID);
        dD.then(function (mess) {
            $state.go('ShowInfo');
        })
    };
});