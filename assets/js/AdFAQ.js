
document.addEventListener('DOMContentLoaded', () => {
    var btnEdit = document.querySelectorAll('.btn-edit-faqs');
    const dialog = document.querySelector('.dialog-edit');

    $('.btn-delete').click(function (event) {
        event.preventDefault();
        var id = $(this).data('id');
        if (confirm("Are you want deleted this FAQ ?")) {
            $.ajax({
                url: '/FAQs/Delete',
                type: 'POST',
                data: { id: id },
                success: function (result) {
                    if (result.success) {
                        location.reload();
                        alert(result.message);
                    } else {
                        alert("Cannot be deleted !");
                        console.log(result.message);
                    }
                },
                error: function (E) {
                    alert('Error' + E.message);
                }
            });
        }
    });

    document.querySelectorAll('.close-btn').forEach(btn => {
        btn.addEventListener('click', () => dialog.classList.add('hidden-edit'));
    });

    for (i = 0; i < btnEdit.length; i++) {
        btnEdit[i].addEventListener("click", function () {
            const id = this.closest('tr').querySelector('.no p').textContent;
            const question = this.closest('tr').querySelector('.Question p').textContent;
            const answer = this.closest('tr').querySelector('.Answer p').textContent;

            dialog.querySelector('#id').value = id;
            dialog.querySelector('#question').value = question;
            dialog.querySelector('#answer').value = answer;
            dialog.classList.remove('hidden-edit');

        });
    }
    });
