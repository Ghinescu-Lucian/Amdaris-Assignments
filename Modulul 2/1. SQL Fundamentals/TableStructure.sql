use [Ghini-Bikes];

CREATE TABLE Users(
		ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
		Username NVARCHAR(30) NOT NULL UNIQUE,
		Email NVARCHAR(50) NOT NULL,
		Password NVARCHAR(50) NOT NULL
);

CREATE TABLE Orders(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserID INT NOT NULL FOREIGN KEY REFERENCES Users(ID),
	Name NVARCHAR(50) NOT NULL,
	Address NVARCHAR(50) NOT NULL,
	TelephoneNo NVARCHAR(13) NOT NULL,
	Status NVARCHAR(30) NOT NULL,
	Payment NVARCHAR(30) NOT NULL,
	TotalCost MONEY NOT NULL,
	ShippingMethod NVARCHAR(20) NOT NULL,
	Date DATETIME DEFAULT(getdate())
);

CREATE TABLE Products(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Manufacturer NVARCHAR(50) NOT NULL,
	Model NVARCHAR(50) NOT NULL,
	Year INT NOT NULL,
	Price MONEY NOT NULL,
	Description NVARCHAR(300) NOT NULL,
	Quantity INT NOT NULL,
	Category INT NOT NULL
);

CREATE TABLE OrdersItems(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders(ID),
	ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ID),
	Quantity INT NOT NULL
)


