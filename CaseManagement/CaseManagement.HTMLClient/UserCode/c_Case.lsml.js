/// <reference path="../GeneratedArtifacts/viewModel.js" />

myapp.c_Case.created = function (entity) {
    // Write code here.
    entity.Id = "00000000-0000-0000-0000-000000000000";
    entity.CreatedOnUtc = new Date();
    entity.LastUpdatedOnUtc = new Date();
    entity.Address = new myapp.Address();
    entity.Person = new myapp.Person();
};