window.productList = ReactDOM.render(<ProductList />, document.getElementById('product-list-container'));
window.cart = ReactDOM.render(<Cart />, document.getElementById('cart-container'));
window.orderConfirmModal = ReactDOM.render(<OrderConfirmModal />, document.getElementById('confirmation-modal-container'));
window.vat = 0.21; // normally it would be taken from some kind of coniguration table for a respective country