var ProductDetails = React.createClass({

    componentDidMount: function () {
        var elModal = $("#product-details-modal")
        elModal.modal('show');

        elModal.on('hidden.bs.modal', () => {
            ReactDOM.unmountComponentAtNode(document.getElementById('details-container-' + this.props.product.id))
        });
    },

    render: function () {

        return (
              <div id="product-details-modal" className="modal fade" tabIndex="-1" role="dialog">
                  <div className="modal-dialog">
                    <div className="modal-content">
                      <div className="modal-header">
                        <button type="button" className="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 className="modal-title">{Resources.productDetails.title}</h4>
                      </div>
                      <div className="modal-body">
                          <div className="product-details">
                              <div><h3>{this.props.product.name}</h3></div>
                              <div className="image-wrapper">
                                  <img src={"Images/" + this.props.details.imageFileName} alt="this.props.imageFileName"/>
                              </div>
                              <div className="popularity">
                                  {this.props.details.popularity}
                              </div>
                          </div>
                      </div>
                      <div className="modal-footer">
                          <button type="button" className="btn btn-default" data-dismiss="modal" >{Resources.common.btnClose}</button>
                      </div>
                    </div>
                  </div>
              </div>

        );
    },
});