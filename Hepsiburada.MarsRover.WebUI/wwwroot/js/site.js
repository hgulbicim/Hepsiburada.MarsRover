$(document).on('click', '#btnAddNewRover', function () {
    var index = $(".dv-rover").length;
    $.get('/Rover/RoverContent', function (roverItemContent) {
        var content = roverItemContent.split('RoverList[0]').join('RoverList[' + index + ']');
        content = content.split('RoverList_0').join('RoverList_' + index);
        $('#dvRoverList').append(content);
    });
});

$(document).on('click', '.btn-add-new-command', function (e) {
    var row = this.name;
    var command = $("[name*='" + row + ".DirectionType']").val();
    var currentCommands = $("[name*='" + row + ".CommandParameters']").val();
    $("[name*='" + row + ".CommandParameters']").val(currentCommands + command);
});