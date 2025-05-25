create table Users
(
	 [ID]           int  PRIMARY KEY identity (1,1),			-- Mã
    [Username]      NVARCHAR(20)   null,						-- Tên đăng nhập
    [Password]      NVARCHAR(20)   null,						-- Mật khẩu
    [Role]          varchar(10)    null,						-- Mã phân quyền
	[profile_image] VARCHAR(max)   null,						-- Ảnh đại diện
	[Status]        NVARCHAR(10)   null,						-- Tình trạng
	[date_regist]   date           null							-- Ngày đăng ký
)
select * from Users
drop table Users
INSERT INTO users (username, password, profile_image, role, status, date_regist)
VALUES('admin', '123', '', 'Admin','Active' , '2024-1-1')

CREATE TABLE Products
(
id INT PRIMARY KEY Identity(1,1),
Prod_id VARCHAR (MAX) NULl,
Prod_name VARCHAR (MAX) NULl,
Prod_type VARCHAR (MAX) NULl,
prod_stock INT NULl,
prod_price FLOAT NULL,
Prod_status VARCHAR (MAX) NULl,
prod_image VARCHAR (MAx) NULl,
date_insert DATE NULL,
date_update DATE NULl,
date_delete DATE NULL,
)

select * from Products

create TABLE Orders
(
Id INT PRIMARY KEY IDENTITY(1,1),
Customer_id int null,
Prod_id VARCHAR (MAX) NULl,
Prod_name VARCHAR (MAX) NULL,
Prod_type VARCHAR (MAX) NULl,
prod_price FLOAT NULl,
Order_date DATE NULL,
delete_order date null,
qty int null
)

drop table Orders

CREATE TABLE customers
(
id INT PRIMARY KEY IDENTITY(1,1),
customer_id INT NULl,
total_price FLOAT NULl,
date DATE NULL,
amount float null,
change float null
)

drop table customers