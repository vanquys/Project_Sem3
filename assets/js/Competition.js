
document.addEventListener('DOMContentLoaded', () => {
    var closebtns = document.getElementsByClassName("close-btn");
    var rgtbtns = document.getElementsByClassName("cp-btn-rgt");
    var dialog = document.querySelector('.dialog');
    var i;

    for (i = 0; i < closebtns.length; i++) {
        closebtns[i].addEventListener("click", function () {

            dialog.classList.add('hidden')
        });
    }


    for (i = 0; i < rgtbtns.length; i++) {
        rgtbtns[i].addEventListener("click", function () {
            var id = this.getAttribute('data-id');
            dialog.classList.remove('hidden')
            dialog.querySelector('.dialog-Id').innerHTML = id
        });
    }
    $('.btn-delete').click(function (event) {
        event.preventDefault();
        var id = $(this).data('id');
        if (confirm("Are you want deleted this user?")) {
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