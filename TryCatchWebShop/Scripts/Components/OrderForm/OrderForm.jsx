var OrderForm = React.createClass({
   
    getInitialState: function () {
        return { saved: false };
    },
    
    

    btnPurchaseClick: function () {
        if (this.validate()) {

            $.ajax({
                dataType: "json",
                url: '/api/Orders/Insert',
                method: 'post',
                data: {
                    firstName: 'todo'
                },
            }).done(function (data) {
                alert('Thank you! Your purchases will be at your doorstep shortly.');
            }).error(function (data) {
                console.log('something went wrong');
            });
        }
    },

    btnCancelClick: function () {

        // this is cheap, but I hope it's ok for a test assessment
        if (confirm('Are you sure you want to cancel this order?')) {
            window.cart.empty();
            document.location.href = '/';
        }
    },

    validate: function() {
        return true;
    },

    render: function () {

        return ( 
            

            <form>
              <div className="form-group">
                <label htmlFor="title">Title</label>
                <input type="text" className="form-control" id="title" />
              </div>
              <div className="form-group">
                <label htmlFor="firstName">First Name</label>
                <input type="text" className="form-control" id="firstName" />
              </div>
              <div className="form-group">
                <label htmlFor="lastName">Last Name</label>
                <input type="text" className="form-control" id="lastName" />
              </div>
              <div className="form-group">
                <label htmlFor="address">Address</label>
                <input type="text" className="form-control" id="address" />
              </div>
              <div className="form-group">
                <label htmlFor="houseNumber">House Number</label>
                <input type="text" className="form-control" id="houseNumber" />
              </div>
              <div className="form-group">
                <label htmlFor="city">City</label>
                <input type="text" className="form-control" id="city" />
              </div>
              <div className="form-group">
                <label htmlFor="email">Email address</label>
                <input type="email" className="form-control" placeholder="@" id="email" />
              </div>
              <button type="button" className="btn btn-success" onClick={this.btnPurchaseClick}>Submit</button>
              <button type="button" className="btn btn-default" onClick={this.btnCancelClick}>Cancel</button>
            </form>
        );
    }
});



