var SuccessMessage = React.createClass({

    getInitialState: function () {
        return null;
    },

    render: function () {

        return (

            <div className="alert alert-success">
                {this.props.text}
            </div>

        );
    }

});


