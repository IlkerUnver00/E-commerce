function AddToBasket(productid) {
    console.log('hello');
    $.ajax({
        url: '/addtobasket2',
        type: 'post',
        data: { 'productid': productid },
        success: function (response) {
            if (response.status) {
                alert('eklendi')
            }
            else {
                alert(response.message);
            }
        },
        error: function (err) {
            console.log(err.responseText)
        }
    });
}


function LoadBasket() {
    $.ajax({
        url: '/loadcart',
        type: 'get',
        success: function (response) {
            $('#cart-container').html(response)
        },
        error: function (err) {
            console.log(err.responseText)
        }
    })
}