
var Cart = React.createClass({
   
    getInitialState: function () {
        return { items: Cookies.getJSON('products') || [] };
    },

    componentDidMount: function () {

    },
    
    addProduct: function (id) {

        var items = Cookies.getJSON('products') || [];
        items.push(id);
        Cookies.set('products', items);
        this.setState({ items: items });
    },

    btnEmptyClick: function () {
        this.empty();
    },

    empty: function(){

        Cookies.remove('products');
        this.setState({ items: [] });    
    },

    render: function () {

        return ( 
            <div className="cart">
                <p className="text-success"><strong>{Resources.cart.title}</strong></p>
                <p className="count"><span id="count">({this.state.items.length})</span>{Resources.cart.itemsInCart}</p>
                <button type="button" 
                        className="btn btn-danger" 
                        disabled={this.state.items.length == 0}
                        data-toggle="modal" data-target="#order-modal">
                    {Resources.cart.btnCheckOut}
                </button>
                <button type="button"
                        className="btn btn-default"
                        onClick={this.btnEmptyClick}
                        disabled={this.state.items.length == 0}>
                    {Resources.cart.btnEmptyCart}
                </button>
            </div>
        );
    }
});



