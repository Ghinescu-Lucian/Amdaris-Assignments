USE [Ghini-Bikes];

INSERT INTO dbo.Users (Username,Email,Password) VALUES
('Luky','luky@gmail.com','1234'),
('Lucian','lucian@gmail.com','1234'),
('Gigi','becali@gmail.com','1234'),
('Lionel','messi@gmail.com','1234'),
('Cristiano','ronaldo@gmail.com','1234'),
('Lewis','hamilton@gmail.com','1234'),
('Mark','verstappen@gmail.com','1234'),
('Gica','hagi@gmail.com','1234'),
('Simona','halep@gmail.com','1234'),
('Micutzu','mcn@gmail.com','1234')

INSERT INTO dbo.Products (Manufacturer,Model, Year, Price,Category,Description,Quantity) VALUES
('Focus','HIGHLAND PEAK',2015,1890,2,'MTB with duralumin frame and fork suspension', 2),
('Focus','HIGHLAND PEAK',2020,2400,2,'MTB with duralumin frame and fork suspension', 2),
('Focus','Raven',2022,6890,2,'MTB with carbon frame and fork suspension', 3),
('Cube','AIM SL',2022,3799,2,'MTB with duralumin frame and fork suspension', 1),
('Cube','Stereo Hybrid',2022,11900,3,'Electric bike with duralumin frame and fork suspension', 1),
('Ghost','Lanao',2020,1890,1,'Bike with duralumin frame', 2),
('Trelock','LS-450',2022,250,4,'Ligth', 5),
('Trelock','Secure XL',2022,190,4,'Anti-theft device', 5),
('Shimano','Altus R',2022,230,5,'Rear derailleur', 2),
('Shimnao','V-Break',2022,200,5,'mechanic break lever', 5)

INSERT INTO dbo.Orders (UserID,Name, Address, TelephoneNo,Status,Payment,ShippingMethod,TotalCost) VALUES
(1,'Luky','Strada x','0727217169','In procesare','Ramburs','Courier',1890),
(1,'Luky','Strada x','0727217169','In procesare','Ramburs','Courier',2600),
(10,'Micutzu','Strada x','0727217169','Livrata','Ramburs','Courier',3799),
(2,'Lucian Ghinescu','Strada x,nr 1, Jud. Caras-Severin','0727217169','In procesare','Ramburs','Courier',400),
(2,'Daniel','Strada x','0727217169','In procesare','Ramburs','Courier',380),
(3,'Becali Gheorghe','Strada x','0727217169','In procesare','Card','Persnoal',11900),
(3,'MM Stoica','Strada x','0727217169','In procesare','Ramburs','Courier',2400),
(3,'Tanase','Strada x','0727217169','In procesare','Ramburs','Courier',1890),
(7,'Mark','Strada x','0727217169','In procesare','Ramburs','Courier',6890),
(7,'Mark','Strada x','0727217169','In procesare','Ramburs','Courier',1890)

INSERT INTO dbo.OrdersItems (OrderID,ProductID,Quantity) VALUES
(1,1,1),
(2,2,1),
(2,10,1),
(3,4,1),
(4,10,2),
(5,8,2),
(6,5,1),
(7,2,1),
(8,6,1),
(9,3,1),
(10,6,1)
