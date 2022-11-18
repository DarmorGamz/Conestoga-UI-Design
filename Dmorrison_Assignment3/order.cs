/**
 * @file         order.cs
 * @author	     Darren Morrison
 * @date         2022-10-09
 * @brief        User Interface Assignment 3
 * @details      Class to handle order system, and different ordertypes.
 */
using System.Text.RegularExpressions;

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

    public virtual void PrintRecipt() {
        Console.Write(
            "Date: " + DateTime.Now.ToString("y/MM/dd") +
            "\nTime: " + DateTime.Now.ToString("HH:mm:ss") +
            "\n\nCustomer Name: " + this.Name +
             "\nCustomer Phone Number: " + this.PhoneNumber +
             "\nProduct 1 Quantity: " + this.ProductOneQuantity +
             "\nProduct 2 Quantity: " + this.ProductTwoQuantity +
             "\nTotal Cost(before tax): $" + String.Format("{0:0.00}", Convert.ToDouble((this.ProductOneQuantity * this.ProductOneCost) + (this.ProductTwoQuantity * this.ProductTwoCost))) +
             "\nTotal Cost(after tax): $" + String.Format("{0:0.00}", (Convert.ToDouble((this.ProductOneQuantity * this.ProductOneCost) + (this.ProductTwoQuantity * this.ProductTwoCost)) * this.SalesTax)) + "\n\n\n"
             );
    }
}

class Pickup: Order {
    private int iPickupTime;
    protected int PickupTime {
        get {
            return iPickupTime;
        }
        set {
            iPickupTime = value;
        }
    }
    public Pickup() : base() {
        iPickupTime = 0;
    }

    public Pickup(string sNameTemp, string sPhoneNumberTemp, int iProductOneQuantityTemp, int iProductTwoQuantityTemp, int iPickupTimeTemp) : base(sNameTemp, sPhoneNumberTemp, iProductOneQuantityTemp, iProductTwoQuantityTemp) {
        iPickupTime = iPickupTimeTemp;
    }

    public override void PrintRecipt() {
        Console.Write(
            "Date: " + DateTime.Now.ToString("y/MM/dd") +
            "\nTime: " + DateTime.Now.ToString("HH:mm:ss") +
            "\n\nCustomer Name: " + this.Name +
             "\nCustomer Phone Number: " + this.PhoneNumber +
             "\nCustomer Pickup Time: " + this.PickupTime +
             "\nProduct 1 Quantity: " + this.ProductOneQuantity +
             "\nProduct 2 Quantity: " + this.ProductTwoQuantity +
             "\nTotal Cost(before tax): $" + String.Format("{0:0.00}", Convert.ToDouble((this.ProductOneQuantity * this.ProductOneCost) + (this.ProductTwoQuantity * this.ProductTwoCost))) +
             "\nTotal Cost(after tax): $" + String.Format("{0:0.00}", (Convert.ToDouble((this.ProductOneQuantity * this.ProductOneCost) + (this.ProductTwoQuantity * this.ProductTwoCost)) * this.SalesTax)) + "\n\n\n"
             );
    }
}

class Delivery: Order {
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

    public Delivery(): base() {
        sAddress = "";
    }

    public Delivery(string sNameTemp, string sPhoneNumberTemp, int iProductOneQuantityTemp, int iProductTwoQuantityTemp, string sAddressTemp) : base(sNameTemp, sPhoneNumberTemp, iProductOneQuantityTemp, iProductTwoQuantityTemp) {
        sAddress = sAddressTemp;
    }

    public override void PrintRecipt() {
        Console.Write(
            "Date: " + DateTime.Now.ToString("y/MM/dd") +
            "\nTime: " + DateTime.Now.ToString("HH:mm:ss") +
            "\n\nCustomer Name: " + this.Name +
             "\nCustomer Phone Number: " + this.PhoneNumber +
             "\nCustomer Address: " + this.Address +
             "\nProduct 1 Quantity: " + this.ProductOneQuantity +
             "\nProduct 2 Quantity: " + this.ProductTwoQuantity +
             "\nTotal Cost(before tax): $" + String.Format("{0:0.00}", Convert.ToDouble((this.ProductOneQuantity * this.ProductOneCost) + (this.ProductTwoQuantity * this.ProductTwoCost))) +
             "\nTotal Cost(after tax + shipping): $" + String.Format("{0:0.00}", (Convert.ToDouble((this.ProductOneQuantity * this.ProductOneCost) + (this.ProductTwoQuantity * this.ProductTwoCost)) * this.SalesTax) + this.ShippingCost) + "\n\n\n"
             );
    }
}

class OrderSystem {
    private int OrderType = 0; // 1 for Pickup, 2 for Delivery.
    public OrderSystem() {

        // Start System.
        this.MainLoop();
    }

    /**
     *  Main menu. Used to start a game or exit program.
     *  @return void No return
     */
    private void MainLoop() {
        this.OrderType = 0;
        this.ClearTerminal();
        while(true) {
            Console.Write("| Main Menu |\n1. Pickup Order\n2. Delivery Order\n3. Exit Program\n: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string sInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if(Regex.IsMatch(sInput, @"^1$")) { this.ClearTerminal(); this.OrderType = 1; GetOrderInfo(); }
            else if(Regex.IsMatch(sInput, @"^2$")) { this.ClearTerminal(); this.OrderType = 2; GetOrderInfo(); }
            else if(Regex.IsMatch(sInput, @"^3$")) { this.ExitProgram(); }
            else {
                Console.Write("Invalid Selection. Please select 1, 2 or 3.\n\n");
            }
        }
    }

    /**
     *  Used to get OrderInfo and printreceipt.
     *  @return void No return
     */
    private void GetOrderInfo() {
        // Init vars.
        string sCustomerName = "";
        string sCustomerPhoneNumber = "";
        int iProductQuantityOne = 0;
        int iProductQuantityTwo = 0;
        int iCustomerPickupTime = 0;
        string sCustomerPostalCode = "";

        // Get Customer Name.
        bool Loop = true;
        while(Loop) {
            Console.Write("Enter Customer's name (Only letters and whitespace).\nEnter -1 to cancel order\nEnter -2 to exit program\n: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string sInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if(Regex.IsMatch(sInput, @"^-1$")) { this.MainLoop(); }
            else if(Regex.IsMatch(sInput, @"^-2$")) { this.ExitProgram(); }
            else if(Regex.IsMatch(sInput, @"^[A-Za-z ]+$")) { this.ClearTerminal(); sCustomerName = sInput; Loop = false;}
            else {
                this.ClearTerminal();
                Console.Write("Invalid Selection. Please enter a customer's name with only letters and whitespace. (Optional -1 to cancel order, -2 to exit program\n");
            }
        }

        // Get Customer Phone Number.
        Loop = true;
        while(Loop) {
            Console.Write("Enter Customer's phone number (Only 10 digit format).\nEnter -1 to cancel order\nEnter -2 to exit program\n: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string sInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if(Regex.IsMatch(sInput, @"^-1$")) { this.MainLoop(); }
            else if(Regex.IsMatch(sInput, @"^-2$")) { this.ExitProgram(); }
            else if(Regex.IsMatch(sInput, @"^[0-9]{10}$")) { this.ClearTerminal(); sCustomerPhoneNumber = sInput; Loop = false; }
            else {
                this.ClearTerminal();
                Console.Write("Invalid Selection. Please enter a customer's phone number with only 10 digits. (Optional -1 to cancel order, -2 to exit program\n");
            }
        }

        // Get Product Quantity 1.
        Loop = true;
        while(Loop) {
            Console.Write("Enter Product Quantity\nEnter -1 to cancel order\nEnter -2 to exit program\n: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string sInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if(Regex.IsMatch(sInput, @"^-1$")) { this.MainLoop(); }
            else if(Regex.IsMatch(sInput, @"^-2$")) { this.ExitProgram(); }
            else if(Regex.IsMatch(sInput, @"^[0-9]+$")) { this.ClearTerminal(); iProductQuantityOne = int.Parse(sInput); Loop = false; }
            else {
                this.ClearTerminal();
                Console.Write("Invalid Selection. Please enter a Product 1 Quantity (numeric only). (Optional -1 to cancel order, -2 to exit program\n");
            }
        }

        // Get Product Quantity 2.
        Loop = true;
        while(Loop) {
            Console.Write("Enter Product Quantity\nEnter -1 to cancel order\nEnter -2 to exit program\n: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string sInput = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if(Regex.IsMatch(sInput, @"^-1$")) { this.MainLoop(); }
            else if(Regex.IsMatch(sInput, @"^-2$")) { this.ExitProgram(); }
            else if(Regex.IsMatch(sInput, @"^[0-9]+$")) { this.ClearTerminal(); iProductQuantityTwo = int.Parse(sInput); Loop = false; }
            else {
                this.ClearTerminal();
                Console.Write("Invalid Selection. Please enter a Product 2 Quantity (numeric only). (Optional -1 to cancel order, -2 to exit program\n");
            }
        }

        // Get Customer Address or Pickup time.
        if(this.OrderType == 1) { // Pickup
            Loop = true;
            while(Loop) {
                Console.Write("Enter Customer pickup time(epoch)\nEnter -1 to cancel order\nEnter -2 to exit program\n: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string sInput = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if(Regex.IsMatch(sInput, @"^-1$")) { this.MainLoop(); }
                else if(Regex.IsMatch(sInput, @"^-2$")) { this.ExitProgram(); }
                else if(Regex.IsMatch(sInput, @"^[0-9]+$")) { this.ClearTerminal(); iCustomerPickupTime = int.Parse(sInput); Loop = false; }
                else {
                    this.ClearTerminal();
                    Console.Write("Invalid Selection. Please enter Customer pickup time(epoch). (Optional -1 to cancel order, -2 to exit program\n");
                }
            }
            Pickup pickupOrder = new Pickup(sCustomerName, sCustomerPhoneNumber, iProductQuantityOne, iProductQuantityTwo, iCustomerPickupTime);
            this.ClearTerminal();
            pickupOrder.PrintRecipt();
        }
        else {
            Loop = true;
            while(Loop) {
                Console.Write("Enter Customer's delivery address postal code(LDL DLD)\nEnter -1 to cancel order\nEnter -2 to exit program\n: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                string sInput = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if(Regex.IsMatch(sInput, @"^-1$")) { this.MainLoop(); }
                else if(Regex.IsMatch(sInput, @"^-2$")) { this.ExitProgram(); }
                else if(Regex.IsMatch(sInput, @"^[a-zA-Z][0-9][a-zA-Z] [0-9][a-zA-Z][0-9]$")) { this.ClearTerminal(); sCustomerPostalCode = sInput; Loop = false; }
                else {
                    this.ClearTerminal();
                    Console.Write("Invalid Selection. Please enter Customer's delivery address postal code(LDL DLD). (Optional -1 to cancel order, -2 to exit program\n");
                }
            }
            Delivery deliveryOrder = new Delivery(sCustomerName, sCustomerPhoneNumber, iProductQuantityOne, iProductQuantityTwo, sCustomerPostalCode);
            this.ClearTerminal();
            deliveryOrder.PrintRecipt();
        }
    }

    /**
    *  Exits program with exit message.
    *  @return void No return
    */
    public void ExitProgram() { this.ClearTerminal(); Console.Write("System shutdown!"); System.Environment.Exit(1); }

    public void ClearTerminal() { Console.Clear(); }
}