const uri = 'api/employee';
let employee = null;
function getCount(data) {
    const el = $('#counter');
    let name = 'Employee';
    if (data) {
        if (data > 1) {
            name = 'Employees';
        }
        el.text(data + ' ' + name);
    } else {
        el.html('No ' + name);
    }
}

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: 'GET',
        url: uri,
        success: function (data) {
            $('#employee').empty();
            getCount(data.length);
            $.each(data, function (key, item) {
                $('<tr>' +
                    '<td>' + item.name + '</td>' +
                    '<td>' + item.lastn + '</td>' +
                    '<td>' + item.age + '</td>' +
                    '<td>' + item.entryDate + '</td>' +
                    '<td>' + item.area + '</td>' +
                    '<td>' + item.role + '</td>' +
                    '<td class="NoTable"><button onclick="editItem(' + item.id + ')">Edit</button></td>' +
                    '<td class="NoTable"><button onclick="deleteItem(' + item.id + ')">Delete</button></td>' +
                    '</tr>').appendTo($('#employee'));
            });

            employee = data;
        }
    });
}

function addItem() {
    const item = {
        'name': $('#add-name').val(),
        'lastn': $('#add-lastn').val(),
        'age': $('#add-age').val(),
        'entryDate': $('#add-entryDate').val(),
        'area': $('#add-area').val(),
        'role': $('#add-role').val(),
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Error');
        },
        success: function (result) {
            getData();
            $('#add-name').val('');
            $('#add-lastn').val('');
            $('#add-age').val('');
            $('#add-entryDate').val('');
            $('#add-area').val('');
            $('#add-role').val('');
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        success: function (result) {
            getData();
        }
    });
}

function editItem(id) {
    $.each(employee, function (key, item) {
        if (item.id === id) {
            $('#edit-id').val(item.id);
            $('#edit-name').val(item.name);
            $('#edit-lastn').val(item.lastn);
            $('#edit-age').val(item.age);
            $('#edit-entryDate').val(item.entryDate);
            $('#edit-area').val(item.area);
            $('#edit-role').val(item.role);
        }
    });
    $('#spoiler').css({ 'display': 'block' });
}

$('.my-form').on('submit', function () {

    const item = {
        'name': $('#edit-name').val(),
        'lastn': $('#edit-lastn').val(),
        'age': $('#edit-age').val(),
        'entryDate': $('#edit-entryDate').val(),
        'area': $('#edit-area').val(),
        'role': $('#edit-role').val(),
    };

    $.ajax({
        url: uri + '/' + $('#edit-id').val(),
        type: 'PUT',
        accepts: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $('#spoiler').css({ 'display': 'none' });
}