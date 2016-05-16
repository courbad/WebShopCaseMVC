var ProductListItem = React.createClass({

    render: function () {

        return (
             <tr>
                <td className="name">{this.props.item.name}</td>
                <td className="text-right">€&nbsp;{this.props.item.price.toFixed(2)}</td>
                <td className="text-right">
                    <button type="button" className="btn btn-info" onClick={() => { window.cart.addProduct(this.props.item.id) }}>
                        <span className="glyphicon glyphicon-shopping-cart"></span>&nbsp;{Resources.productList.btnToCart}
                    </button>
                </td>
             </tr>

        );
    },
});