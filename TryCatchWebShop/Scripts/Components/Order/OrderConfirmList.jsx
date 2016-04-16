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
                        <th>Name</th>
                        <th className="text-right">Price</th>
                        <th className="text-right">VAT {window.vat * 100}&#37;</th>
                        <th className="text-right">Price inc. VAT</th>
                    </tr>
                </thead>
                <tbody>{items}</tbody>
                <tfoot>
                    <tr>
                        <td className="text-right">total:</td>
                        <td className="text-right"><strong>€&nbsp;{total.toFixed(2)}</strong></td>
                        <td className="text-right"><strong>€&nbsp;{(total * window.vat).toFixed(2)}</strong></td>
                        <td className="text-right"><strong>€&nbsp;{(total * (1 + window.vat)).toFixed(2)}</strong></td>
                    </tr>
                </tfoot>
            </table>
        );
    }
});



