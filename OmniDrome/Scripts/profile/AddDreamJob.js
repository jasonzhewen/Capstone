personalInfoModule.controller('AddDreamJobCtrl', function ($scope, $filter, $state, personalInfoService) {
    $scope.searchString = '';
    $scope.noc = '';
    $scope.dreamJobModel = {
        ID: '',
        position:'',
        companyName: '',
        startDate: '',
        description: '',
        UserInfoID: ''
    };


    $scope.titleModel = {
        TitleID: '',
        Titl: '',
        NocCode: ''
    };

    $scope.dutyModel = {
        TitleID: '',
        Titl: '',
        NocCode: ''
    };

    $scope.requirementModel = {
        RequirementId:'',
        Req: '',
        NocCode: ''
    };




    $scope.titleList = [];
    $scope.dutyList = [];
    $scope.requirementList = [];
    var des = '';
    var desduty = '';

    $scope.GetJobTitles = function () {
        var getTitles = personalInfoService.getJobTitles($scope.searchString);
        getTitles.then(function (data) {
            console.log(data);
            $scope.titleList = data.data;
            //$scope.apply();
        })
    }


    $scope.GetSomeDuties = function () {
        var getDut = personalInfoService.getDutiesForTitle($scope.noc);
        getDut.then(function (data) {
            //console.log(data);
            $scope.dutyList = data.data;
            //$scope.$apply();
        })

        
    }


    $scope.GetSomeRequirements = function () {
        var getReq = personalInfoService.getReqForTitle($scope.noc);
        getReq.then(function (data) {
            console.log(data);
            $scope.requirementList = data.data;
           
            //$scope.$apply();
        })
    }

    $scope.Cancel = function () {
        window.history.back();
    }
  

    $scope.AddDreamJobToTable = function () {
        //$scope.CurrentPositionModel.startDate = $filter('date')(new Date($scope.CurrentPositionModel.startDate), "yyyy-MM-dd");
        for (var i = 0; i < $scope.requirementList.length; ++i) {
            des += $scope.requirementList[i].Req;
        }
        for (var j = 0; j < $scope.dutyList.length; j++) {
            desduty += $scope.dutyList[j].Titl;
        }

        var ddlselected = document.getElementById("ddl_titles");
        var titleselected = ddlselected.options[ddlselected.selectedIndex].text;
        $scope.dreamJobModel.position = titleselected;
        $scope.dreamJobModel.description = des + desduty;
        personalInfoService.addDreamJobInfo($scope.dreamJobModel);
        $state.go('ShowInfo');
        console.log($scope.dreamJobModel);
    }


    $scope.getTitleName = function (mytitle) {
        var ddlselected = document.getElementById("ddl_titles");
        var titleselected = ddlselected.options[ddlselected.selectedIndex].text;
        //var titname = $.grep($scope.titleList, function (mytitle) {
        //    return title = titleselected;
        //})[0].Titl;
      //alert("selected title is:  " + titleselected);
    }

    //this.setTab = function(setTab) {
    //    this.tab = setTab;
    //};
	
    //this.isSelected = function(checkTab) {
    //    return this.tab === checkTab;
    //};
	
    //this.notSelected = function(checkTab) {
    //    return !(this.isSelected(checkTab));
    //};
	
    //this.getTab = function() {
    //    return this.tab;
    //};
	
    //this.setIsDefault = function() {
    //    this.isDefault = true;
    //};
	
    //this.getIsDefault = function() {
    //    return this.isDefault;
    //};
});

