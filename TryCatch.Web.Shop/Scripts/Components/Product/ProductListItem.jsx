var ProductListItem = React.createClass({

    showDetails: product => {

        $.ajax({
            dataType: "json",
            url: '/api/Products/GetDetails',
            data: { id: product.id },
        }).done(function (data) {

            ReactDOM.render(<ProductDetails details={data} product={product} />,
                document.getElementById('details-container-' + product.id));

        }).fail(function (data) {
            alert('Error getting product details.');
        });
    },

    render: function () {

        return (
             <tr className="item">
                <td className="name">
                    <div id={"details-container-" + this.props.item.id}></div>
                    <a onClick={() => { this.showDetails(this.props.item)}}>
                        {this.props.item.name}
                    </a>
                </td>
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