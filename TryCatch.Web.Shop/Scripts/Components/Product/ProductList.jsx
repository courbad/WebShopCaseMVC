
var ProductList = React.createClass({

    pageSize: 10,

    getInitialState: function () {
        return { items: [], activePage: 1 };
    },

    componentDidMount: function () {
        this.loadPage(1);
    },

    loadPage: function (pageNumber) {

        var that = this;
        $.ajax({
            dataType: "json",
            url: '/api/Products/GetList',
            data: { count: 10, offset: (pageNumber - 1) * this.pageSize },
        }).done(function (data) {
            that.setState({ items: data, activePage: pageNumber });
        });
    },

    loadPreviousPage: function () {
        this.loadPage(this.state.activePage - 1);
    },

    loadNextPage: function (pageCount) {
        this.loadPage(this.state.activePage + 1);
    },

    render: function () {

        var items = [];
        this.state.items.map((item, i) => {
            items.push(<ProductListItem item={item} key={i} />);
        });

        return (

        <div className="product-list">
            <table className="table">

                <thead>
                    <tr>
                        <th>{Resources.products.thName}</th>
                        <th className="text-right">{Resources.products.thPriceExVat}</th>
                        <th></th>
                    </tr>
                </thead>

                <tbody>{items}</tbody>

                <tfoot>
                </tfoot>
            </table>



            <Paging activePage={this.state.activePage} />

        </div>
        );
    }
});
