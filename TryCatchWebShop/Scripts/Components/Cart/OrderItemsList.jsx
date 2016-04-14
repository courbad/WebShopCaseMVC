var OrderItemsList = React.createClass({
   
    getInitialState: function () {
        return null;
    },

    render: function () {

        var items = [];
        var key = 0;
        var total = 0;
        this.props.ids.map((id) => {
            var data = $.grep(this.props.itemData, function (p) { return p.id == id; })[0];
            items.push(<tr key={++key}><td>{data.name}</td><td>{data.price.toFixed(2)}</td></tr>);
            total += data.price;
        })

        return ( 
            <table className="table table-condensed order-items-list">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>{items}</tbody>
                <tfoot>
                    <tr>
                        <td className="text-right">total:</td>
                        <td><strong>€&nbsp;{total}</strong></td>
                    </tr>
                </tfoot>
            </table>
        );
    }
});



