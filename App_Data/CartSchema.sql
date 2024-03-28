﻿DROP TABLE IF EXISTS CartItems;

-- Cart Items
CREATE TABLE CartItems (
	prodID VARCHAR(5) NOT NULL,
	quantity INT NOT NULL,
	size VARCHAR(25) NOT NULL,
	cartID VARCHAR(50) NOT NULL,
	FOREIGN KEY (prodID) REFERENCES ProductInfo(prodID)
);
