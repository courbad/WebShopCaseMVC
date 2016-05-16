﻿var OrderForm = React.createClass({
   
    getInitialState: function () {
        return { saved: false };
    },
    
    btnSubmitClick: function () {

        var that = this;
        $('#btnSubmit').prop('disabled', true);
        this.clearErrors();

        var order = this.getFormData();
        order.productIds = Cookies.getJSON('products');

        $.ajax({
            dataType: "json",
            url: '/api/Orders/PostOrder',
            method: 'post',
            data: order

        }).done(function (data) {

            Cookies.remove('products');
            window.cart.empty();
            ReactDOM.unmountComponentAtNode(ReactDOM.findDOMNode(that).parentNode);
            ReactDOM.render(<SuccessMessage text={Resources.orderForm.successMsg} />, $('.body-content')[0]);

        }).always(function (data) {

            $('#btnSubmit').prop('disabled', false);

        }).fail(function (data) {
            
            if (_.has(data, 'responseJSON.modelState')) {
                that.displayErrors(data.responseJSON.modelState);
            } else {
                alert(data.message || 'Error saving order.');
                console.log(data);
            }
        });
    },

    displayErrors: function (messages) {

        for (var propertyName in messages) {

            var input = $('#' + camelize(propertyName.substring(6)), $('#order-form'));
            input.closest('.form-group')
                .addClass('has-error')
                .append($('<p>', { class: 'error', text: messages[propertyName].join(' ') }));
        }
    },

    clearErrors: function () {
        $('#order-form .form-group')
            .removeClass('has-error')
            .find('p.error').remove();
    },

    btnCancelClick: function () {

        if (confirm('Are you sure you want to cancel this order?')) {
            ReactDOM.unmountComponentAtNode(ReactDOM.findDOMNode(this).parentNode);
            $('#product-list-container').fadeIn();
        }
    },

    getFormData: function () {
        var data = {};
        $('#order-form input').each((i, elem) => {
            data[elem.id] = elem.value;
        });

        return data;
    },

    render: function () {

        return ( 

            <form id="order-form">
              <div className="form-group">
                <label className="control-label" htmlFor="title">{Resources.orderForm.title}</label>
                <input type="text" className="form-control" id="title" />
              </div>
              <div className="form-group">
                <label className="control-label" htmlFor="firstName">{Resources.orderForm.firstName}</label>
                <input type="text" className="form-control" id="firstName" />
              </div>
              <div className="form-group">
                <label className="control-label" htmlFor="lastName">{Resources.orderForm.lastName}</label>
                <input type="text" className="form-control" id="lastName" />
              </div>
              <div className="form-group">
                <label className="control-label" htmlFor="address">{Resources.orderForm.address}</label>
                <input type="text" className="form-control" id="address" />
              </div>
              <div className="form-group">
                <label className="control-label" htmlFor="houseNumber">{Resources.orderForm.houseNumber}</label>
                <input type="text" className="form-control" id="houseNumber" />
              </div>
              <div className="form-group">
                <label className="control-label" htmlFor="city">{Resources.orderForm.city}</label>
                <input type="text" className="form-control" id="city" />
              </div>
              <div className="form-group">
                <label className="control-label" htmlFor="zipCode">{Resources.orderForm.zip}</label>
                <input type="text" className="form-control" id="zipCode" />
              </div>
              <div className="form-group">
                <label className="control-label" htmlFor="email">{Resources.orderForm.email}</label>
                <input type="email" className="form-control" placeholder="@" id="email" />
              </div>
              <div className="button-area">
                  <button type="button" className="btn btn-success" id="btnSubmit" onClick={this.btnSubmitClick}>Submit</button>
                  <button type="button" className="btn btn-default" id="btnCancel" onClick={this.btnCancelClick}>Cancel</button>
              </div>
            </form>
        );
    }
});



