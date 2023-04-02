
document.addEventListener('DOMContentLoaded', () => {
    var btnEdit = document.querySelectorAll('.btn-edit-faqs');
    const dialogedit = document.querySelector('.dialog-edit');
    var btnAdd = document.querySelectorAll('.faq-btn-add');
    const dialogadd = document.querySelector('.dialog-add')


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
        btn.addEventListener('click', () => dialogedit.classList.remove('showDialog'));
        btn.addEventListener('click', () => dialogadd.classList.remove('showDialog'));
    });

    for (i = 0; i < btnEdit.length; i++) {
        btnEdit[i].addEventListener("click", function () {
            const id = this.closest('tr').querySelector('.no p').textContent;
            const question = this.closest('tr').querySelector('.Question p').textContent;
            const answer = this.closest('tr').querySelector('.Answer p').textContent;

            dialogedit.querySelector('#id').value = id;
            dialogedit.querySelector('#question').value = question;
            dialogedit.querySelector('#answer').value = answer;
            dialogedit.classList.add('showDialog');

        });
    }
    for (i = 0; i< btnAdd.length; i++) {
        btnAdd[i].addEventListener("click", function () {
            dialogadd.classList.add('showDialog');
            console.log('1');
        });
    }
});

