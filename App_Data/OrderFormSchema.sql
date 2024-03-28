DROP TABLE IF EXISTS OrderItems;
DROP TABLE IF EXISTS OrderForm;

-- OrderForm Table
CREATE TABLE OrderForm (
    orderID VARCHAR(50) NOT NULL PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    orderStatus VARCHAR(50) NOT NULL,
    orderTotal FLOAT NOT NULL DEFAULT 0,
    orderDate DATE NOT NULL,
    orderTime TIME NOT NULL,
    FOREIGN KEY (username) REFERENCES Users(username),
    CONSTRAINT CHK_orderStatus CHECK (orderStatus IN ('pending', 'in process', 'done', 'cancelled'))
);

-- OrderItems Table
CREATE TABLE OrderItems (
	orderID VARCHAR(50) NOT NULL,
	prodID VARCHAR(5) NOT NULL,
	quantity INT NOT NULL,
	size VARCHAR(25) NOT NULL,
	price FLOAT NOT NULL,
	FOREIGN KEY (prodID) REFERENCES ProductInfo(prodID),
);