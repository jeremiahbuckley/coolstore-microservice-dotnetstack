using CartService.Models;

namespace CartService.Services {
    public interface IShoppingCartService {
        ShoppingCart getShoppingCart(string cartId);

        Product getProduct(string itemId);

        ShoppingCart deleteItem(string cartId, string itemId, int quantity);

        ShoppingCart checkout(string cartId);

        ShoppingCart addItem(string cartId, string itemId, int quantity);

        ShoppingCart set(string cartId, string tmpId);

        void priceShoppingCart(ShoppingCart sc);
    }

}