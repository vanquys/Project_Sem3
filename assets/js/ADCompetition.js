
document.addEventListener('DOMContentLoaded', () => {
    var closebtns = document.getElementsByClassName("close-btn");
    var btnEdit= document.getElementsByClassName("btn-dialog-edit");
    var btnAdd = document.getElementsByClassName("btn-dialog-add");
    var dialogAdd = document.querySelector('.dialog-add');
    var dialogEdit = document.querySelector('.dialog-edit');
    var i;

    // dialog
    for (i = 0; i < closebtns.length; i++) {
        closebtns[i].addEventListener("click", function () {
            dialogAdd.classList.add('hidden')
            dialogEdit.classList.add('hidden')

        });
    }

    for (i = 0; i < btnAdd.length; i++) {
        btnAdd[i].addEventListener("click", function () {
            dialogAdd.classList.remove('hidden')
        });
    }

    for (i = 0; i < btnEdit.length; i++) {
        btnEdit[i].addEventListener("click", function () {

            const id = this.closest('tr').querySelector('.no p').textContent;
            const title = this.closest('tr').querySelector('.title p').textContent;
            const description = this.closest('tr').querySelector('.description p').textContent;
            const question = this.closest('tr').querySelector('.question p').textContent;
            const answer = this.closest('tr').querySelector('.answer p').textContent;
            // start date
            const start = this.closest('tr').querySelector('.date p').textContent.split( '-')[0];
            var startParts = start.split("/");
            var startDate = new Date(startParts[2], startParts[1] - 1, startParts[0]);
            var formatStartDate = startDate.toISOString().slice(0, 10);
            // end date
            const end = this.closest('tr').querySelector('.date p').textContent.split('-')[1];
            var endParts = end.split("/");
            var endDate = new Date(endParts[2], endParts[1] - 1, endParts[0]);
            var formatEndDate = endDate.toISOString().slice(0, 10);
             
            dialogEdit.classList.remove('hidden')

            dialogEdit.querySelector('#id').value = id;
            dialogEdit.querySelector('#title').value = title;
            dialogEdit.querySelector('#description').value = description;
            dialogEdit.querySelector('#startDate').value = formatStartDate;
            dialogEdit.querySelector('#endDate').value = formatEndDate;
            dialogEdit.querySelector('#question').value = question;
            dialogEdit.querySelector('#RightAnswer').value = answer;
        });
    }


    /// delete
    $('.btn-delete').click(function (event) {
        event.preventDefault();
        var id = $(this).data('id');
        if (confirm("Are you want deleted this competition ?")) {
            $.ajax({
                url: '/Competitions/Delete',
                type: 'POST',
                data: { id: id },
                success: function (result) {
                    if (result.success) {
                        location.reload();
                        alert(result.message);
                    } else {
                        alert("There are members participating in the contest, cannot be deleted !");
                        console.log(result.message);
                    }
                },
                error: function () {
                    alert('Error');
                }
            });
        }
    });

    $('.delete-btn').click(function () {
        var iduser = $(this).data('iduser');
        var idcp = $(this).data('idcp');
        console.log(iduser+  "_"  + idcp )
        if (confirm("Are you want deleted this user?")) {

            $.ajax({
                url: '/Competitions/DeleteAnswer',
                type: 'POST',
                data: { iduser: iduser, idcp: idcp },
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

