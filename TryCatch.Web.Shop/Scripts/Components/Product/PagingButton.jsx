var PagingButton = React.createClass({
    render: function () {
        return (

            <button type="button" 
                onClick={() => { window.productList.loadPage(this.props.number) }} 
                className={"btn" + (this.props.isActive ? " active" : "")}
                >{this.props.number}</button>
        );
    },

});