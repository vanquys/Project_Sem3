document.addEventListener('DOMContentLoaded', () => {
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

    document.querySelectorAll('.btn-edit-faqs').forEach(btn => {
        const id = btn.closest('tr').querySelector('.no p').textContent;
        const question = btn.closest('tr').querySelector('.Question p').textContent;
        const answer = btn.closest('tr').querySelector('.Answer p').textContent;

        dialog.querySelector('#id').value = id;
        dialog.querySelector('#question').value = question;
        dialog.querySelector('#answer').value = answer;
        btn.addEventListener('click', () => dialog.classList.remove('hidden-edit'));

    });
   
});