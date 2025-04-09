// Initialize tooltips
$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

// Cart functionality
let cartCount = 0;

function updateCartCount() {
    $('.cart-count').text(cartCount);
}

// Example add to cart function
function addToCart(productId, quantity = 1) {
    cartCount += quantity;
    updateCartCount();
    
    // Show notification
    toastr.success('Đã thêm sản phẩm vào giỏ hàng');
    
    // In a real app, you would make an AJAX call here
    // to add the product to the server-side cart
}

// Initialize quantity controls
$('.quantity-btn').click(function() {
    const input = $(this).siblings('.quantity-input');
    let value = parseInt(input.val());
    
    if ($(this).hasClass('plus')) {
        if (value < 10) value++;
    } else {
        if (value > 1) value--;
    }
    
    input.val(value);
});

// Product image zoom on hover
$('.product-img-container').hover(
    function() {
        $(this).find('.product-img').css('transform', 'scale(1.05)');
    },
    function() {
        $(this).find('.product-img').css('transform', 'scale(1)');
    }
);
