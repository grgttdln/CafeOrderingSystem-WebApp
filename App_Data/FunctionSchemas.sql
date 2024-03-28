-- a function to check the format of the username
CREATE FUNCTION CheckUsernameFormat(@username VARCHAR(50))
RETURNS BIT
AS
BEGIN
    DECLARE @isValid BIT;
    
    IF LEN(@username) >= 3 AND
       @username LIKE '[a-zA-Z][a-zA-Z0-9]%' OR -- Check if username starts with a letter and contains only letters and numbers
       @username IN ('admin', 'staff', 'user') -- Allow specific usernames
        SET @isValid = 1; -- Set @isValid to 1 if the username format is valid
    ELSE
        SET @isValid = 0; -- Set @isValid to 0 if the username format is invalid

    RETURN @isValid; -- Return the value of @isValid
END;


ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameFormat
CHECK (dbo.CheckUsernameFormat(username) = 1);

ALTER TABLE AuthUsers
ADD CONSTRAINT CHK_AuthUsers_UsernameFormat CHECK (dbo.CheckUsernameFormat(username) = 1);

ALTER TABLE InfoUsers
ADD CONSTRAINT CHK_InfoUsers_UsernameFormat CHECK (dbo.CheckUsernameFormat(username) = 1);



-- a function to check the format of the phone number
CREATE FUNCTION CheckPhoneNumberFormat(@phoneNum VARCHAR(11))
RETURNS BIT
AS
BEGIN
    DECLARE @isValid BIT;

    IF LEN(@phoneNum) = 11 AND
       @phoneNum LIKE '09%' AND
       ISNUMERIC(@phoneNum) = 1 -- Ensure all characters are numeric
        SET @isValid = 1; -- Set @isValid to 1 if the phone number format is valid
    ELSE
        SET @isValid = 0; -- Set @isValid to 0 if the phone number format is invalid

    RETURN @isValid; -- Return the value of @isValid
END;


-- a function to check the format of the orderID
CREATE FUNCTION CheckOrderIDFormat(@orderID VARCHAR(100), @username VARCHAR(50))
RETURNS BIT
AS
BEGIN
    -- Check if the orderID starts with "C-" followed by any characters, then a dash, and a numeric part
    IF @orderID LIKE 'C-' + @username + '-[0-9]' + '%' AND
       CHARINDEX('-', @orderID, CHARINDEX('-', @orderID) + 1) > 0
        RETURN 1; -- Return 1 if the orderID format is valid
    ELSE
        RETURN 0; -- Return 0 if the orderID format is invalid
    RETURN 0;
END;


ALTER TABLE OrderForm
ADD CONSTRAINT CHK_OrderIDFormat
CHECK (dbo.CheckOrderIDFormat(orderID, username) = 1);




