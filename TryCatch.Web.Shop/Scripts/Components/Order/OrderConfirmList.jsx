var OrderConfirmList = React.createClass({
   
    getInitialState: function () {
        return null;
    },

    render: function () {

        var items = [];
        var key = 0;
        var total = 0;
        var that = this;

        this.props.ids.map((id) => {
            var data = $.grep(this.props.itemData, function (p) { return p.id == id; })[0];
            items.push(<OrderConfirmListItem key={++key} data={data} />);
            total += data.price;
        })

        return ( 
            <table className="table table-condensed order-items-list">
                <thead>
                    <tr>
                        <th>{Resources.products.thName}</th>
                        <th className="text-right">{Resources.products.thPrice}</th>
                        <th className="text-right">{Resources.products.thVat} {window.vat * 100}&#37;</th>
                        <th className="text-right">{Resources.products.thPriceWithVat}</th>
                    </tr>
                </thead>
                <tbody>{items}</tbody>
                <tfoot>
                    <tr>
                        <td className="text-right">{Resources.order.total}:</td>
                        <td className="text-right"><strong>€&nbsp;{total.toFixed(2)}</strong></td>
                        <td className="text-right"><strong>€&nbsp;{(total * window.vat).toFixed(2)}</strong></td>
                        <td className="text-right"><strong>€&nbsp;{(total * (1 + window.vat)).toFixed(2)}</strong></td>
                    </tr>
                </tfoot>
            </table>
        );
    }
});



