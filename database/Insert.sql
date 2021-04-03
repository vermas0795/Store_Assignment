Use [Store]

SET IDENTITY_INSERT [dbo].[AppRole] OFF;
Insert Into [dbo].[AppRole] Values('N','Normal',0,GETDATE(),GETDATE(),1)
Insert Into [dbo].[AppRole] Values('P','Privileged',2,GETDATE(),GETDATE(),1)

SET IDENTITY_INSERT [dbo].[AppUser] OFF;
Insert Into [dbo].[AppUser] Values('vermas0795','Abhishek Verma','vermas0795@gmail.com',NULL,'UGFzc3dvcmQ=',1,GETDATE(),GETDATE(),1)
Insert Into [dbo].[AppUser] Values('verma_0795','Abhishek Verma','vermas0795@yahoo.com',NULL,'UGFzc3dvcmQ=',2,GETDATE(),GETDATE(),1)
