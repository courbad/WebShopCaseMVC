var OrderConfirmListItem = React.createClass({
   
    getInitialState: function () {
        return null;
    },

    render: function () {

        return ( 
            <tr>
                <td>{this.props.data.name}</td>
                <td className="text-right">€&nbsp;{this.props.data.price.toFixed(2)}</td>
                <td className="text-right">€&nbsp;{(this.props.data.price * window.vat).toFixed(2)}</td>
                <td className="text-right">€&nbsp;{(this.props.data.price * (1 + window.vat)).toFixed(2)}</td>
            </tr>
        );
    }
});