
document.addEventListener('DOMContentLoaded', () => {
    var closebtns = document.getElementsByClassName("close-btn");
    var btnDialog = document.getElementsByClassName("btn-dialog");
    var dialog = document.querySelector('.dialog');
    var i;

    // dialog
    for (i = 0; i < closebtns.length; i++) {
        closebtns[i].addEventListener("click", function () {

            dialog.classList.add('hidden')
        });
    }
    for (i = 0; i < btnDialog.length; i++) {
        btnDialog[i].addEventListener("click", function () {
            var title = this.getAttribute('data-title');
            dialog.classList.remove('hidden')
            dialog.querySelector('dialog-title').innerHTML = title
        }); 
    }
    // edit 
/*
    $('.btn-edit').click(function () {
        event.preventDefault();
        var id = $(this).data('id');
        if (confirm("Are you want deleted this competition ?")) {
            $.ajax({
                url: '/Competitions/Delete',
                type: 'POST',
                async: true,
                data: { id: id },
                success: function (result) {
                    if (result.success) {
                        location.reload();
                        alert(result.message);
                    } else {
                        alert(result.message);
                    }
                },
                error: function () {
                    alert('Error');
                }
            });
        }

    });
*/
    /// delete
    $('.btn-delete').click(function (event) {
        event.preventDefault();
        var id = $(this).data('id');
        if (confirm("Are you want deleted this competition ?")) {
            $.ajax({
                url: '/Competitions/Delete',
                type: 'POST',
                async: true,
                data: { id: id },
                success: function (result) {
                    if (result.success) {
                        location.reload();
                        alert(result.message);
                    } else {
                        alert(result.message);
                    }
                },
                error: function () {
                    alert('Error');
                }
            });
        }
    });


});

