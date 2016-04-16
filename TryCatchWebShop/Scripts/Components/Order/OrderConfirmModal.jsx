
var OrderConfirmModal = React.createClass({
   
    getInitialState: function () {
        return null;
    },

    componentDidMount: function () {

        var that = this;
        $('#order-modal').on('show.bs.modal', (e) => {
            that.loadItems();
        })
    },

    loadItems: function () {

        var ids = Cookies.getJSON('products') || [];
        var that = this;
        $.ajax({
            dataType: "json",
            url: '/api/Products/GetMany',
            data: { 
                ids: ids.filter((value, index, self) => { return self.indexOf(value) == index })  // only uniques
            }, 
        }).done(function (data) {
            ReactDOM.render(<OrderItemsList itemData={data} ids={ids} />, $('#order-modal .modal-body')[0]);
        });
    },

    btnConfirmClick: function () {
        $('#product-list-container').fadeOut(400, () => {
            window.orderForm = ReactDOM.render(<OrderForm />, $('#order-form-container')[0]);
        });
    },

    render: function () {

        return (

                <div id="order-modal" className="modal fade" tabIndex="-1" role="dialog">
                  <div className="modal-dialog">
                    <div className="modal-content">
                      <div className="modal-header">
                        <button type="button" className="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 className="modal-title">Confirm Purchase</h4>
                      </div>
                      <div className="modal-body">
                          loading....
                      </div>
                      <div className="modal-footer">
                          <button type="button" className="btn btn-success" data-dismiss="modal" onClick={this.btnConfirmClick}>Confirm</button>
                          <button type="button" className="btn btn-default" data-dismiss="modal" onClick={this.btnCancelClick}>Cancel</button>
                      </div>
                    </div>
                  </div>
                </div>

            );
    }
});



