create database ProductDB
use ProductDB
create table Products
(
    productid int identity(1,1) primary key,
    productname varchar(50) ,
    productdescription varchar(500),
    quantity int ,
    price decimal(10,2) 

)
select * from Products