DROP TABLE IF EXISTS ProductInfo;
DROP TABLE IF EXISTS ProductPrice;

-- ProductInfo Table
CREATE TABLE ProductInfo (
	prodID VARCHAR(5) NOT NULL PRIMARY KEY,
	prodName VARCHAR(50) NOT NULL,
	prodDesc VARCHAR(255) NOT NULL,
	prodType VARCHAR(50) NOT NULL
);

-- ProductPrice Table
CREATE TABLE ProductPrice (
	prodID VARCHAR(5) NOT NULL,
	price FLOAT NOT NULL,
	size VARCHAR(10) NOT NULL,
	prodAvail BIT NOT NULL,
	FOREIGN KEY (prodID) REFERENCES ProductInfo(prodID)
);

