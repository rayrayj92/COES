using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COES
{
    class crudVO
    {
        private crudDAO cdao;
        private String _itemname;
        private Double _itemcost;
        private Int32 _quantity;

        private Int32 _customerID;
        private String _customername;
        private String _customeraddress;
        private Int32 _customerphone;
        private String _ordertype;
        private Int32 _itemid;
        private Double _totalcost;

        private Int32 _orderid;
        private DateTime _orderdate;

        public crudVO()
        {

        }
        //Item
        public String itemname
        {
            get { return _itemname; }
            set { _itemname = value; }
        }
        public Double itemcost
        {
            get { return _itemcost; }
            set { _itemcost = value; }
        }
        public Int32 quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public Int32 itemid
        {
            get { return _itemid; }
            set { _itemid = value; }
        }
        //Customers
        public Int32 customerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }
        public String customername
        {
            get { return _customername; }
            set { _customername = value; }
        }
        public String customeraddress
        {
            get { return _customeraddress; }
            set { _customeraddress = value; }
        }
        public Int32 customerphone
        {
            get { return _customerphone; }
            set { _customerphone = value; }
        }
        public String ordertype
        {
            get { return _ordertype; }
            set { _ordertype = value; }
        }
        public Double totalcost
        {
            get { return _totalcost; }
            set { _totalcost = value; }
        }
        //Order
        public Int32 orderid
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        public DateTime orderdate
        {
            get { return _orderdate; }
            set { _orderdate = value; }
        }
        //Methods
        public void Insert()
        {
            cdao = new crudDAO();
            cdao.InsertData(itemname, itemcost, quantity, orderid);
        }
        public void Update()
        {
            cdao = new crudDAO();
            cdao.UpdateData(itemid, itemname, itemcost, quantity);
        }
        public void Delete()
        {
            cdao = new crudDAO();
            cdao.DeleteData(itemid);
        }

        public void completeOrder()
        {
            cdao = new crudDAO();
            cdao.CompleteData(orderid, customerID, orderdate, totalcost);
        }

        public void InsertCustomer()
        {
            cdao = new crudDAO();
            cdao.InsertCustomer(customerID, ordertype, customername, customeraddress, customerphone);
        }
    }
}
