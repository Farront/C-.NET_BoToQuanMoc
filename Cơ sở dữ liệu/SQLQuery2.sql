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