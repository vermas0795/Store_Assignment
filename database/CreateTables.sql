Use [Store]

Create Table [dbo].[AppRole]
(
Id bigint Primary key identity(1,1),
Code nvarchar(100) not null,
Description nvarchar(300) null,
Discount decimal null,
CreatedDate datetime not null,
UpdatedDate datetime null,
IsActive bit not null
)
------------------------------------------------------------
Create Table [dbo].[AppUser]
(
Id bigint Primary key identity(1,1),
LoginName nvarchar(100) not null UNIQUE,
UserName nvarchar(500) null,
EmailId nvarchar(200) null UNIQUE,
Contact nvarchar(15) null,
Password nvarchar(500) not null,
Role_Id bigint references [dbo].[AppRole](Id) not null,
CreatedDate datetime not null,
UpdatedDate datetime null,
IsActive bit not null
)
----------------------------------------------------------------------------------

Create Table [dbo].[EstimationLogs]
(
Id bigint Primary key identity(1,1),
AppUser_Id bigint references [dbo].[AppUser](Id) not null,
Discount decimal not null,
PricePerGram decimal not null,
Weight decimal not null,
TotalPrice decimal not null,
CreatedDate datetime not null,
UpdatedDate datetime null,
IsActive bit not null
)
-----------------------------------------------------------------------------
