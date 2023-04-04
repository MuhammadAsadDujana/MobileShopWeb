function deleteProduct(ProductId) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Product/Delete/",
                type: "Delete",
                data: { "ProductId": ProductId },
                success: function (data) {

                    if (data.success) {
                        toastr.success(data.msg)
                        window.location.reload();
                    }
                    else {
                        toastr.error(data.msg)
                    }
                }
            })
        }
    })

} 