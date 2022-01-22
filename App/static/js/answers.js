function showAnswers(id) {
    var urlFrom = url + id;
    $("#answersFormDiv").load(urlFrom, function() {
        $("#answersModel").modal("show");
    })
}