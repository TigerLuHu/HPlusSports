// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addToCart(id, name, category) {
  var items = getCartItems();

  if (!items) {
    items = [];
  }

  var prodSize = $("input[name='size']:checked").val();
  var prodQuantity = $("input[name='quantity']").val();
  items.push({
    "id": id,
    "name": name,
    "quantity": prodQuantity,
    "category": category,
    "size": prodSize
  });
  localStorage.setItem("cartItems", JSON.stringify(items));
  window.location.href = "/Cart/Index";
}

function getCartItems() {
  var items = localStorage.getItem("cartItems");
  return JSON.parse(items);
}

function clearCart() {
  localStorage.removeItem("cartItems");
}