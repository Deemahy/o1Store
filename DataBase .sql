Create Database Sote ;
CREATE TABLE [dbo].[User] (
    [UserID] INT IDENTITY(1,1) PRIMARY KEY,
    [UserName] NVARCHAR(100) NOT NULL,
    [Password] NVARCHAR(255) NOT NULL,
    [Email] NVARCHAR(255) NOT NULL,
    [Phone] NVARCHAR(20),
    [UserType] NVARCHAR(50) NOT NULL,
    [ProfilePictureURL] NVARCHAR(255),
    [Status] NVARCHAR(50),
    [DateCreated] DATETIME DEFAULT GETDATE(),
    [LastLoginDate] DATETIME NULL
);

CREATE TABLE [dbo].[Address] (
    [AddressID] INT IDENTITY(1,1) PRIMARY KEY,
    [UserID] INT NOT NULL,
    [StreetAddress] NVARCHAR(255) NOT NULL,
    [Apartment] NVARCHAR(255),
    [City] NVARCHAR(100) NOT NULL,
    [State] NVARCHAR(100) NOT NULL,
    [ZipCode] NVARCHAR(20) NOT NULL,
    [Country] NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_Address_User FOREIGN KEY ([UserID]) REFERENCES [dbo].[User]([UserID])
);


CREATE TABLE [dbo].[Category] (
    [CategoryID] INT IDENTITY(1,1) PRIMARY KEY,
    [CategoryName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX),
    [ImageURL] NVARCHAR(255)
);


CREATE TABLE [dbo].[Product] (
    [ProductID] INT IDENTITY(1,1) PRIMARY KEY,
    [ProductName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX),
    [Price] DECIMAL(18, 2) NOT NULL,
    [StockQuantity] INT NOT NULL,
    [CategoryID] INT NOT NULL,
    [ImageURL] NVARCHAR(255),
    [Discount] DECIMAL(18, 2) DEFAULT 0,
    [DiscountStartDate] DATETIME NULL,
    [DiscountEndDate] DATETIME NULL,
    CONSTRAINT FK_Product_Category FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category]([CategoryID])
);


CREATE TABLE [dbo].[ShoppingCart] (
    [CartID] INT IDENTITY(1,1) PRIMARY KEY,
    [UserID] INT NOT NULL,
    [CreatedDate] DATETIME NOT NULL,
    CONSTRAINT FK_ShoppingCart_User FOREIGN KEY ([UserID]) REFERENCES [dbo].[User]([UserID])
);


CREATE TABLE [dbo].[ShoppingCartItem] (
    [CartItemID] INT IDENTITY(1,1) PRIMARY KEY,
    [CartID] INT NOT NULL,
    [ProductID] INT NOT NULL,
    [Quantity] INT NOT NULL,
    CONSTRAINT FK_ShoppingCartItem_Cart FOREIGN KEY ([CartID]) REFERENCES [dbo].[ShoppingCart]([CartID]),
    CONSTRAINT FK_ShoppingCartItem_Product FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product]([ProductID])
);


CREATE TABLE [dbo].[Order] (
    [OrderID] INT IDENTITY(1,1) PRIMARY KEY,
    [OrderDate] DATETIME NOT NULL,
    [UserID] INT NOT NULL,
    [TotalAmount] DECIMAL(18, 2) NOT NULL,
    [Status] NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_Order_User FOREIGN KEY ([UserID]) REFERENCES [dbo].[User]([UserID])
);


CREATE TABLE [dbo].[OrderItem] (
    [OrderItemID] INT IDENTITY(1,1) PRIMARY KEY,
    [OrderID] INT NOT NULL,
    [ProductID] INT NOT NULL,
    [Quantity] INT NOT NULL,
    [Price] DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_OrderItem_Order FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order]([OrderID]),
    CONSTRAINT FK_OrderItem_Product FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product]([ProductID])
);


CREATE TABLE [dbo].[Payment] (
    [PaymentID] INT IDENTITY(1,1) PRIMARY KEY,
    [OrderID] INT NOT NULL,
    [PaymentDate] DATETIME NOT NULL,
    [PaymentMethod] NVARCHAR(50) NOT NULL,
    [Amount] DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_Payment_Order FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order]([OrderID])
);



INSERT INTO [dbo].[User] (UserName, Password, Email, Phone, UserType, ProfilePictureURL, Status)
VALUES 
('buyer1', 'password123', 'buyer1@example.com', '1234567890', 'Buyer', NULL, 'Active'),
('buyer2', 'password123', 'buyer2@example.com', '1234567891', 'Buyer', NULL, 'Active'),
('buyer3', 'password123', 'buyer3@example.com', '1234567892', 'Buyer', NULL, 'Active'),
('admin1', 'password123', 'admin1@example.com', '1234567893', 'Admin', NULL, 'Active'),
('admin2', 'password123', 'admin2@example.com', '1234567894', 'Admin', NULL, 'Active');



INSERT INTO [dbo].[Address] ( UserID, StreetAddress, Apartment, City, State, ZipCode, Country)
VALUES 
( 1, '123 Main St', 'Apt 4B', 'CityA', 'StateA', '12345', 'CountryA'),
( 1, '456 Elm St', '', 'CityA', 'StateA', '12345', 'CountryA'),
( 2, '789 Market St', 'Suite 5C', 'CityB', 'StateB', '67890', 'CountryB'),
( 3, '1010 Oak St', '', 'CityC', 'StateC', '54321', 'CountryC'),
( 4, '1111 Pine St', '', 'CityD', 'StateD', '13579', 'CountryD'),
( 5, '2222 Cedar St', 'Bldg 3', 'CityE', 'StateE', '24680', 'CountryE');

INSERT INTO [category] (CategoryName, Description, ImageURL) VALUES 
('Electronics', 'Electronic items like smartphones, laptops, etc.', 'https://example.com/images/electronics.jpg'),
('Books', 'Various kinds of books including novels and textbooks.', 'https://example.com/images/books.jpg'),
('Fashion', 'Clothing, accessories, and footwear.', 'https://example.com/images/fashion.jpg'),
('Home & Kitchen', 'Furniture, appliances, and home decor.', 'https://example.com/images/home_kitchen.jpg');


INSERT INTO [product] ( ProductName, Description, Price, StockQuantity, CategoryID, ImageURL, Discount, DiscountStartDate, DiscountEndDate) VALUES 
( 'Smartphone', 'Latest model smartphone', 699.99, 50, 1, 'https://example.com/images/smartphone.jpg', 0.00, NULL, NULL),
( 'Laptop', 'High performance laptop', 999.99, 30, 1, 'https://example.com/images/laptop.jpg', 0.00, NULL, NULL),
( 'Novel', 'Bestselling novel', 19.99, 100, 2, 'https://example.com/images/novel.jpg', 0.00, NULL, NULL),
( 'Tablet', 'Newest tablet on the market', 499.99, 40, 1, 'https://example.com/images/tablet.jpg', 0.00, NULL, NULL),
( 'T-Shirt', 'Casual cotton t-shirt', 29.99, 200, 3, 'https://example.com/images/tshirt.jpg', 10.00, '2024-01-01 00:00:00', '2024-01-31 23:59:59'),
( 'Coffee Maker', 'Automatic drip coffee maker', 89.99, 25, 4, 'https://example.com/images/coffeemaker.jpg', 5.00, '2024-02-01 00:00:00', '2024-02-15 23:59:59'),
( 'Headphones', 'Noise-cancelling over-ear headphones', 199.99, 15, 1, 'https://example.com/images/headphones.jpg', 20.00, '2024-01-10 00:00:00', '2024-01-20 23:59:59'),
( 'Fiction Book', 'Engaging fiction book', 15.99, 80, 2, 'https://example.com/images/fictionbook.jpg', 0.00, NULL, NULL),
( 'Sofa', 'Comfortable three-seater sofa', 499.99, 10, 4, 'https://example.com/images/sofa.jpg', 100.00, '2024-02-10 00:00:00', '2024-02-20 23:59:59'),
( 'Sneakers', 'Stylish running shoes', 59.99, 50, 3, 'https://example.com/images/sneakers.jpg', 0.00, NULL, NULL);


INSERT INTO [shoppingcart] (UserID, CreatedDate) VALUES 
(1, '2024-01-15 14:30:00'),
(2, '2024-01-20 15:30:00'),
(1, '2024-02-25 16:00:00'),
(3, '2024-02-28 10:00:00'),
(4, '2024-03-05 11:00:00');


INSERT INTO [shoppingcartitem] (CartID, ProductID, Quantity) VALUES 
(1, 1, 1),
(1, 2, 2),
(2, 3, 1),
(3, 5, 1),
(3, 4, 1),
(4, 6, 1),
(5, 1, 2);


INSERT INTO [order] (OrderDate, UserID, TotalAmount, Status) VALUES 
('2024-01-15 14:30:00', 1, 1000.00, 'Completed'),
('2024-02-20 16:00:00', 2, 300.00, 'Pending'),
('2024-01-25 12:00:00', 1, 500.00, 'Completed'),
('2024-02-18 10:00:00', 3, 200.00, 'Cancelled'),
('2024-03-05 11:00:00', 4, 1500.00, 'Completed');


INSERT INTO orderitem (OrderID, ProductID, Quantity, Price) VALUES 
(1, 1, 1, 699.99),
(1, 2, 1, 999.99),
(2, 5, 2, 59.98),
(3, 3, 3, 59.97),
(4, 4, 1, 499.99),
(5, 6, 2, 179.98),
(5, 1, 1, 699.99);



INSERT INTO payment (OrderID, PaymentDate, PaymentMethod, Amount) VALUES 
(1, '2024-01-15 14:31:00', 'Credit Card', 1000.00),
(2, '2024-02-20 16:01:00', 'PayPal', 300.00),
(3, '2024-01-25 12:01:00', 'Credit Card', 500.00),
(4, '2024-02-18 10:01:00', 'Bank Transfer', 200.00),
(5, '2024-03-05 11:01:00', 'Credit Card', 1500.00);
