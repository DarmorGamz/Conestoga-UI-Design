class Order {
    private double dSalesTax = 1.13;
    protected double SalesTax {
        get {
            return dSalesTax;
        }
    }
    private int iProductOneCost = 5;
    protected int ProductOneCost {
        get {
            return iProductOneCost;
        }
    }
    private int iProductTwoCost = 10;
    protected int ProductTwoCost {
        get {
            return iProductTwoCost;
        }
    }

    private string sName;
    protected string Name {
        get {
            return sName;
        }
        set {
            sName = value;
        }
    }
    private string sPhoneNumber;
    protected string PhoneNumber {
        get {
            return sPhoneNumber;
        }
        set {
            sPhoneNumber = value;
        }
    }
    private int iProductOneQuantity;
    protected int ProductOneQuantity {
        get {
            return iProductOneQuantity;
        }
        set {
            iProductOneQuantity = value;
        }
    }
    private int iProductTwoQuantity;
    protected int ProductTwoQuantity {
        get {
            return iProductTwoQuantity;
        }
        set {
            iProductTwoQuantity = value;
        }
    }

    public Order() {
        sName = "";
        sPhoneNumber = "";
        iProductOneQuantity = 0;
        iProductTwoQuantity = 0;
    }
    public Order(string sNameTemp, string sPhoneNumberTemp, int iProductOneQuantityTemp, int iProductTwoQuantityTemp) {
        sName = sNameTemp;
        sPhoneNumber = sPhoneNumberTemp;
        iProductOneQuantity = iProductOneQuantityTemp;
        iProductTwoQuantity = iProductTwoQuantityTemp;
    }

    public virtual string PrintRecipt() {
        string result =
            "Date: " + DateTime.Now.ToString("y/MM/dd") +
            "\r\nTime: " + DateTime.Now.ToString("HH:mm:ss") +
            "\r\n\nCustomer Name: " + this.Name +
             "\r\nCustomer Phone Number: " + this.PhoneNumber +
             "\r\nProduct 1 Quantity: " + this.ProductOneQuantity +
             "\r\nProduct 2 Quantity: " + this.ProductTwoQuantity +
             "\r\nTotal Cost(before tax): $" + String.Format("{0:0.00}", Convert.ToDouble((this.ProductOneQuantity * this.ProductOneCost) + (this.ProductTwoQuantity * this.ProductTwoCost))) +
             "\r\nTotal Cost(after tax): $" + String.Format("{0:0.00}", (Convert.ToDouble((this.ProductOneQuantity * this.ProductOneCost) + (this.ProductTwoQuantity * this.ProductTwoCost)) * this.SalesTax)) + "\n\n\n"
             ;
        return result;
    }
}

class Pickup : Order {
    private string iPickupTime;
    protected string PickupTime {
        get {
            return iPickupTime;
        }
        set {
            iPickupTime = value;
        }
    }
    public Pickup() : base() {
        iPickupTime = "";
    }

    public Pickup(string sNameTemp, string sPhoneNumberTemp, int iProductOneQuantityTemp, int iProductTwoQuantityTemp, string iPickupTimeTemp) : base(sNameTemp, sPhoneNumberTemp, iProductOneQuantityTemp, iProductTwoQuantityTemp) {
        iPickupTime = iPickupTimeTemp;
    }

    public override string PrintRecipt() {
        string result = 
            "Date: " + DateTime.Now.ToString("y/MM/dd") +
            "\r\nTime: " + DateTime.Now.ToString("HH:mm:ss") +
            "\r\n\nCustomer Name: " + this.Name +
             "\r\nCustomer Phone Number: " + this.PhoneNumber +
             "\r\nCustomer Pickup Time: " + this.PickupTime +
             "\r\nProduct 1 Quantity: " + this.ProductOneQuantity +
             "\r\nProduct 2 Quantity: " + this.ProductTwoQuantity +
             "\r\nTotal Cost(before tax): $" + String.Format("{0:0.00}", Convert.ToDouble((this.ProductOneQuantity * this.ProductOneCost) + (this.ProductTwoQuantity * this.ProductTwoCost))) +
             "\r\nTotal Cost(after tax): $" + String.Format("{0:0.00}", (Convert.ToDouble((this.ProductOneQuantity * this.ProductOneCost) + (this.ProductTwoQuantity * this.ProductTwoCost)) * this.SalesTax)) + "\n\n\n"
             ;
        return result;
    }
}

class Delivery : Order {
    private string sAddress;
    protected string Address {
        get {
            return sAddress;
        }
        set {
            sAddress = value;
        }
    }

    private int iShippingCost = 15;
    protected int ShippingCost {
        get {
            return iShippingCost;
        }
    }

    public Delivery() : base() {
        sAddress = "";
    }

    public Delivery(string sNameTemp, string sPhoneNumberTemp, int iProductOneQuantityTemp, int iProductTwoQuantityTemp, string sAddressTemp) : base(sNameTemp, sPhoneNumberTemp, iProductOneQuantityTemp, iProductTwoQuantityTemp) {
        sAddress = sAddressTemp;
    }

    public override string PrintRecipt() {
        string result =
            "Date: " + DateTime.Now.ToString("y/MM/dd") +
            "\r\nTime: " + DateTime.Now.ToString("HH:mm:ss") +
            "\r\n\nCustomer Name: " + this.Name +
             "\r\nCustomer Phone Number: " + this.PhoneNumber +
             "\r\nCustomer Address: " + this.Address +
             "\r\nProduct 1 Quantity: " + this.ProductOneQuantity +
             "\r\nProduct 2 Quantity: " + this.ProductTwoQuantity +
             "\r\nTotal Cost(before tax): $" + String.Format("{0:0.00}", Convert.ToDouble((this.ProductOneQuantity * this.ProductOneCost) + (this.ProductTwoQuantity * this.ProductTwoCost))) +
             "\r\nTotal Cost(after tax + shipping): $" + String.Format("{0:0.00}", (Convert.ToDouble((this.ProductOneQuantity * this.ProductOneCost) + (this.ProductTwoQuantity * this.ProductTwoCost)) * this.SalesTax) + this.ShippingCost) + "\n\n\n"
             ;

        return result;
    }
}
