--create table TappeKontrol(
--Process_Ordre_Nr	int				not null,
--Tidspunkt			datetime		not null,
--Daase_Nr			int				not null,
--Laag_Nr				int				not null,
--Helhed				Nvarchar(10)	null,
--Kamera_Tjek			Nvarchar(10)	null,
--CCP					Nvarchar(10)	null,
--Vaeske_Temp			float			not null,
--Kontrol_Temp		float			not null,
--Tunnel_PH_Tjek		Nvarchar(35)	null,
--Vaegt_Kontrol		float			null,
--Smag_Test_Nr		int				null,
--Smag_Test			Nvarchar(10)	null,
--Kvitter_Proeve		Nvarchar(30)	null,
--Sukker_Tjek			Nvarchar(10)	null,
--CO2_Kontrol			float			null,
--Signatur			Nvarchar(10)	not null,
--primary key (Process_Ordre_Nr,Tidspunkt),
--foreign key (Process_Ordre_Nr) references ProcessOrdre(Process_Ordre_Nr),
--foreign key (Signatur) references Ansatte(Initialer)
--);



--db til hvilke hoteller der har hvilke hotel faciliteter
--CREATE TABLE [dbo].[DemoHotelFaciliteter] (
--    [Hotel_No] INT NOT NULL,
--    [Facil_No] INT NOT NULL,
--    PRIMARY KEY CLUSTERED ([Hotel_No] ASC, [Facil_No] ASC),
--    FOREIGN KEY ([Hotel_No]) REFERENCES [dbo].[DemoHotel] ([Hotel_No]) ON UPDATE CASCADE
--);


--CREATE TABLE DemoRoom(
--         Room_No   int    NOT NULL,
--     Hotel_No  int    NOT NULL,
--     Types     CHAR(1)   DEFAULT 'S',
--     Price     FLOAT,
--        CONSTRAINT checkType 
--        CHECK (Types IN ('D','F','S') OR Types IS NULL),
--        CONSTRAINT checkPrice 
--        CHECK (price BETWEEN 0 AND 9999),


--        FOREIGN KEY (Hotel_No) REFERENCES DemoHotel (Hotel_No)
--        ON UPDATE CASCADE ON DELETE NO ACTION,
--        Primary KEY (Room_No, Hotel_No)
--);


--CREATE TABLE DemoGuest (
--     Guest_No  int  NOT NULL PRIMARY KEY,
--     Name      VARCHAR(30)      NOT NULL,
--     Address   VARCHAR(50)   NOT NULL
--);


--CREATE TABLE DemoBooking(
--     Booking_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
--         Hotel_No  int   NOT NULL,
--     Guest_No  int   NOT NULL,
--     Date_From DATE  NOT NULL,
--     Date_To   DATE  NOT NULL,
--     Room_No   int   NOT NULL,
--     FOREIGN KEY(Guest_No) REFERENCES DemoGuest(Guest_No),
--         FOREIGN KEY(Room_No, Hotel_No) REFERENCES DemoRoom(Room_No, Hotel_No)
--);

--PRIMARY KEY (Process_Order_Nr, Tidspunkt),
--FOREIGN KEY (Process_Order_Nr) REFERENCES ProcessOrdre (Process_Ordre_Nr)
--);

CREATE DATABASE RoyalHotel2019;


CREATE TABLE Hotels(
	Hotel_Id int NOT NULL PRIMARY KEY,
	City Nvarchar(70) NOT NULL
);



CREATE TABLE Hoteltemps(
	Tempe_Date datetime NOT NULL default getdate(),
	Hotel_Id int NOT NULL,
	Tempe_Value float,

Primary KEY (Tempe_Date, Hotel_Id),
FOREIGN KEY (Hotel_Id) REFERENCES Hotels (Hotel_Id)
);