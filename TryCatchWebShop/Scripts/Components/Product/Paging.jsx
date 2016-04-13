
var Paging = React.createClass({

    pageSize: function() {
        return 10;
    },

    pageCount: 0,
   
    componentWillMount: function () {

        var that = this;
        $.ajax({
            dataType: "json",
            url: '/api/Products/GetTotalCount',
        }).done(function (totalCount) {
            that.pageCount = Math.ceil(totalCount / that.pageSize());
            that.setState({ pageCount: that.pageCount });
        });
    },

    render: function () {

        var buttons = [];
        for (var i = 1; i <= this.pageCount; i++) {
            buttons.push(<PagingButton number={i} key={i} isActive={i == this.props.activePage} />);
        }

        return (

             <div className="paging">
                 <button type="button" 
                         onClick={() => { window.productList.loadPreviousPage() }} 
                         className="btn"
                         disabled={this.props.activePage == 1}
                         >&laquo;</button>

                    {buttons}

                 <button type="button" 
                         onClick={() => { window.productList.loadNextPage() }}
                         className="btn"
                         disabled={this.props.activePage == this.pageCount}
                         >&raquo;</button>
             </div>

        );
    }
});



