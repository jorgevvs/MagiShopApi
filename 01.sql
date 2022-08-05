CREATE DATABASE MagicShopDB
go
use MagicShopDB
CREATE TABLE Card(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Title varchar(20) NULL,
	Price decimal(10, 2) NULL,
	Image varchar(200) NULL,
	Colection varchar(5) NULL
)
go



