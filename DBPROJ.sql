--- createing tables

CREATE TABLE Staff (
    Staff_ID INT PRIMARY KEY,
    Name VARCHAR(255),
    Salary FLOAT,
    ShiftSchedule VARCHAR(255),
    Type VARCHAR(255),
    Contact_info VARCHAR(255)
);

create table cashier(
c_ID int
foreign key(c_ID) references staff(staff_ID)  primary key 
);

create table cafe_manager(
CM_ID int
foreign key(CM_ID) references staff(staff_ID)  primary key 
);

create table inventory_manager(
IM_ID int
foreign key(IM_ID) references staff(staff_ID)  primary key 
);

create table Payments(
PaymentID int primary key,
Method varchar(255),
PaymentStatus VARCHAR(255),
staffID int
foreign key (staffID) references cashier(c_ID)
);

CREATE TABLE Loyalty_Program
(
  Program_ID int primary key,  
);

CREATE TABLE Loyalty_Program_Rewards_available
(
  Rewards_available int ,
  Program_ID int ,
  PRIMARY KEY (Rewards_available, Program_ID),
  FOREIGN KEY (Program_ID) REFERENCES Loyalty_Program(Program_ID)
);

create table Customers(
	CustomerID int primary key,
	 First_name  VARCHAR(255),
  Last_name VARCHAR(255),
  Email  VARCHAR(255),
  c_password  VARCHAR(255),
  phone_Number int,
  loyalty_Points int,
  programID int foreign key references loyalty_Program(Program_ID)
);

ALTER TABLE Customers
ALTER COLUMN phone_Number VARCHAR(255);

CREATE TABLE Feedbacks (
    Feedback_ID int primary key,
    Comments VARCHAR(255),
    Date DATETIME,
    Rating INT,
    CM_ID INT foreign key references cafe_manager(CM_ID),
	customerID INT foreign key references Customers(CustomerID)
);

create table Orders(
orderId int primary key,
price int,
staatus int,
orderTime DATETIME,
orderDate DATETIME,
PaymentID int foreign key references Payments(PaymentID),
customerID int foreign key references Customers(CustomerID),
);

CREATE TABLE Menu_Category (
    Category_ID INT PRIMARY KEY,
    Description VARCHAR(255),
    Name VARCHAR(255), 
	CM_ID INT foreign key references cafe_manager(CM_ID)

);
cREATE TABLE Menu_Items (
    Item_ID INT PRIMARY KEY,
    Name VARCHAR(255),
    Availability VARCHAR(255),
    Price int,
    Category_ID int FOREIGN KEy  REFERENCES Menu_Category(Category_ID)
    
);

CREATE TABLE orders_have_menu
(
  Order_id INT,
  Item_ID INT ,
  PRIMARY KEY (Order_id, Item_ID),
  FOREIGN KEY (Order_id) REFERENCES orders(Orderid),
  FOREIGN KEY (Item_ID) REFERENCES Menu_Items(Item_ID)
);

CREATE TABLE Feedbacks_Comments
(
  Comments INT ,
  Feedback_ID INT ,
  PRIMARY KEY (Comments, Feedback_ID),
  FOREIGN KEY (Feedback_ID) REFERENCES Feedbacks(Feedback_ID)
);


CREATE TABLE Inventory (
    inv_Item_ID INT PRIMARY KEY,
    Quantity INT,
    Capacity INT,
    IM_ID INT  FOREIGN KEY (IM_ID) REFERENCES inventory_manager(IM_ID)
);


CREATE TABLE Supplier (
    Supplier_ID INT PRIMARY KEY,
    Contact_no VARCHAR(255),
    Name VARCHAR(255),
    Address VARCHAR(255)
);


CREATE TABLE Transactions (
    Transaction_ID INT PRIMARY KEY,
    Transaction_type VARCHAR(255),
    Amount FLOAT,
    Status VARCHAR(255),
    Date DATETIME,
    CM_ID INT FOREIGN KEY (CM_ID) REFERENCES cafe_manager(CM_ID),
    SupplierID INT FOREIGN KEY (supplierID) REFERENCES Supplier(supplier_ID),
);
ALTER TABLE Transactions 
ADD CashierID INT;

ALTER TABLE Transactions
ADD FOREIGN KEY (CashierID) REFERENCES cashier(c_ID);

select * from Transactions


CREATE TABLE Products
(
  Product_ID int primary key,
  ProductName varchar(255),
  Price INT NOT NULL,
  inv_Item_ID INT FOREIGN KEY (inv_Item_ID) REFERENCES Inventory(inv_Item_ID)
);

CREATE TABLE trans_products
(
  Product_ID INT, 
  Transacion_ID INT,
  PRIMARY KEY (Product_ID, Transacion_ID),
  FOREIGN KEY (Product_ID) REFERENCES Products(Product_ID),
  FOREIGN KEY (Transacion_ID) REFERENCES Transactions(Transaction_ID)

);


CREATE TABLE Supplies
(
  Supplier_ID INT,
  Product_ID INT ,
  PRIMARY KEY (Supplier_ID, Product_ID),
  FOREIGN KEY (Supplier_ID) REFERENCES Supplier(Supplier_ID),
  FOREIGN KEY (Product_ID) REFERENCES Products(Product_ID)
);


CREATE TABLE UserAccount (
    UserID INT PRIMARY KEY IDENTITY,
    Username VARCHAR(255) UNIQUE,
    PasswordHash VARCHAR(255),
    Email VARCHAR(255),
    UserRole VARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE()
);


CREATE TABLE UserDetails (
    UserDetailsID INT PRIMARY KEY IDENTITY,
    UserID INT FOREIGN KEY REFERENCES UserAccount(UserID),
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    ContactInfo VARCHAR(255),
    AdditionalInfo VARCHAR(MAX) 
);


