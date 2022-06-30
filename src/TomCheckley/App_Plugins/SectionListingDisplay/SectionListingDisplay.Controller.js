(function () {
    angular.module("umbraco")
        .controller("sectionListingDisplayCtrl", ["$scope", "elementTypeResource",
            function ($scope, elementTypeResource) {
                $scope.modules = [];
                console.log($scope.block)
                var elementTypes;
                elementTypeResource.getAll().then(elTypes => {
                    elementTypes = elTypes;

                    $scope.block.data.modules.contentData.forEach(module => {
                        var blockElementType = elementTypes.filter(x => x.key == module.contentTypeKey)[0];

                        $scope.modules.push({ ...module, blockElementType });
                    });
                });
            }
        ])
})();
