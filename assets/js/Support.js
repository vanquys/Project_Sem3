// Wait for the DOM to load before running the code
document.addEventListener('DOMContentLoaded', function () {

     //Get references to DOM elements
    var closeBtns = document.getElementsByClassName('close-btn');
    var btnEdit = document.getElementsByClassName('btn-dialog-edit');
    var btnAdd = document.getElementsByClassName('btn-dialog-add');
    var dialogAdd = document.querySelector('.dialog-add');
    var dialogEdit = document.querySelector('.dialog-edit');
    var btntest = document.getElementsByClassName('test');


    
    // Set up event listeners for closing dialogs
    for (var i = 0; i < closeBtns.length; i++) {
        closeBtns[i].addEventListener('click', function () {
            dialogAdd.classList.remove('showDialog');
            dialogEdit.classList.remove('showDialog');
        });
    }
    
    

    // Set up event listeners for editing supporters
    for (var i = 0; i < btnEdit.length; i++) {
        btnEdit[i].addEventListener('click', function () {
            const id = this.closest('.sp-item').querySelector('.sp-id p').textContent;
            const currentImage = this.closest('.sp-item').querySelector('.sp-currentImage p').textContent;
            const name = this.closest('.sp-item').querySelector('.infor-name').textContent.trim();
            
            const phone = this.closest('.sp-item').querySelector('.phone p').textContent;
            const email = this.closest('.sp-item').querySelector('.email p').textContent;
            const position = this.closest('.sp-item').querySelector('.infor-position').textContent;


            dialogEdit.querySelector('#id').value = id;
            dialogEdit.querySelector('#currentImage').value = currentImage;
            dialogEdit.querySelector('#name').value = name;
            dialogEdit.querySelector('#phone').value = phone;
            dialogEdit.querySelector('#email').value = email;
            dialogEdit.querySelector('#position').value = position;

            dialogEdit.classList.add('showDialog');

        });
    }

     //Set up event listeners for adding supporters

    for (var i = 0; i < btnAdd.length; i++) {
        btnAdd[i].addEventListener('click', function () {
            dialogAdd.classList.add('showDialog');
        });
    }

     //Set up event listeners for deleting supporters
    $('.btn-delete').click(function (event) {
        event.preventDefault();
        var id = $(this).data('id');
        if (confirm('Are you sure you want to delete this supporter?')) {
            $.ajax({
                url: '/Supports/Delete',
                type: 'POST',
                data: { id: id },
                success: function (result) {
                    if (result.success) {
                        location.reload();
                        alert(result.message);
                    } else {
                        alert('There are members participating in the contest, cannot be deleted!');
                        console.log(result.message);
                    }
                },
                error: function () {
                    alert('Error');
                }
            });
        }
    });

    

});