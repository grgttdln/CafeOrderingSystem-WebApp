DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS AuthUsers;
DROP TABLE IF EXISTS InfoUsers;
DROP TABLE IF EXISTS ProductInfo;
DROP TABLE IF EXISTS ProductPrice;
DROP TABLE IF EXISTS CartItems;
DROP TABLE IF EXISTS OrderItems;
DROP TABLE IF EXISTS OrderForm;


-- Users Table
CREATE TABLE Users(
	username VARCHAR(50) NOT NULL PRIMARY KEY
);

-- AuthUsers Table
CREATE TABLE AuthUsers(
	username VARCHAR(50) NOT NULL,
	userPass VARCHAR(50) NOT NULL,
	FOREIGN KEY (username) REFERENCES Users(username)
);

-- InfoUsers Table
CREATE TABLE InfoUsers(
    username VARCHAR(50) NOT NULL,
    fname VARCHAR(50) NOT NULL,
    lname VARCHAR(50) NOT NULL,
    userAddress VARCHAR(100) NOT NULL,
    phoneNum VARCHAR(11) NOT NULL,
    totalOrder INT NOT NULL,
    typeUser VARCHAR(20) NOT NULL DEFAULT 'user',
    FOREIGN KEY (username) REFERENCES Users(username),
    CONSTRAINT CHK_typeUser CHECK (typeUser IN ('admin', 'staff', 'user')),
    CONSTRAINT CHK_phoneNum CHECK (phoneNum LIKE '09%')
);

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

-- ProductInfo Table
CREATE TABLE ProductInfo (
    prodID VARCHAR(5) NOT NULL PRIMARY KEY,
    prodName VARCHAR(50) NOT NULL,
    prodDesc VARCHAR(255) NOT NULL,
    prodType VARCHAR(50) NOT NULL,
    CONSTRAINT CHK_prodType CHECK (prodType IN ('coffee', 'non-coffee', 'frappe', 'food'))
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

-- ProductPrice Table
CREATE TABLE ProductPrice (
	prodID VARCHAR(5) NOT NULL,
	price FLOAT NOT NULL,
	size VARCHAR(10) NOT NULL,
	prodAvail BIT NOT NULL,
	FOREIGN KEY (prodID) REFERENCES ProductInfo(prodID)
);

-- Cart Items
CREATE TABLE CartItems (
	prodID VARCHAR(5) NOT NULL,
	quantity INT NOT NULL,
	size VARCHAR(25) NOT NULL,
	cartID VARCHAR(50) NOT NULL,
	FOREIGN KEY (prodID) REFERENCES ProductInfo(prodID)
);




INSERT INTO Users VALUES('admin');
INSERT INTO AuthUsers VALUES('admin', 'admin');
INSERT INTO InfoUsers VALUES('admin', 'John', 'Doe', 'Cabuyao, Laguna',
'0966657787', '0', 'admin');

INSERT INTO Users VALUES('staff');
INSERT INTO AuthUsers VALUES('staff', 'staff');
INSERT INTO InfoUsers VALUES('staff', 'Ada', 'Smith', 'Cabuyao, Laguna',
'0966657712', '0', 'staff');


INSERT INTO Users VALUES('Dalen');
INSERT INTO AuthUsers VALUES('Dalen', 'Dalen');
INSERT INTO InfoUsers VALUES('Dalen', 'Dalen', 'Dalen', 'Cabuyao, Laguna',
'0966657712', '1', 'user');

