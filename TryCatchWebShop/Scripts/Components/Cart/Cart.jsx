
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

    btnPurchaseClick: function() {

        Cookies.remove('products');
        this.setState({ items: [] });
    },

    render: function () {

        return ( 
            <div className="cart">
                <p className="text-success"><strong>Shopping cart</strong></p>
                <p className="count"><span id="count">({this.state.items.length})</span>items in cart</p>
                <button type="button" 
                        className="btn btn-danger" 
                        onClick={this.btnPurchaseClick}
                        disabled={this.state.items.length == 0}
                        >Buy</button>
            </div>

        );
    }
});



