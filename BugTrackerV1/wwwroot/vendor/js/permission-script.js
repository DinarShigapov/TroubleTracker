$(document).ready(function () {
    console.log("Document ready");

    $('#roleSelect').change(function () {
        var roleId = $(this).val();
        console.log("Role selected: " + roleId);
        if (roleId) {
            $.ajax({
                url: '/Permission/GetRolePermissions',
                type: 'GET',
                data: { roleId: roleId },
                success: function (data) {
                    console.log("Role permissions received");
                    $('#rolePermissionsContainer').html(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.error("Error loading role permissions: " + textStatus);
                }
            });
        } else {
            $('#rolePermissionsContainer').html('');
        }
    });

    $('#userSelect').change(function () {
        var userId = $(this).val();
        console.log("User selected: " + userId);
        if (userId) {
            $.ajax({
                url: '/Permission/GetUserPermissions',
                type: 'GET',
                data: { userId: userId },
                success: function (data) {
                    console.log("User permissions received");
                    $('#userPermissionsContainer').html(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.error("Error loading user permissions: " + textStatus);
                }
            });
        } else {
            $('#userPermissionsContainer').html('');
        }
    });
});