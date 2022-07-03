USE [DevInfoSystem]
GO
/*Inserting migration history*/
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220616194229_InitialCreate', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220617180318_FirstMigration', N'5.0.17')
GO
/*Inserting Departments*/
INSERT INTO[dbo].[Departments] ([Id], [DepartmentName]) VALUES (N'a7c47175-51fe-498f-a624-0732b1f5904c', N'FrontEnd')
GO
INSERT INTO [dbo].[Departments] ([Id], [DepartmentName]) VALUES (N'5bde9712-ec90-40e0-a56d-32ef7ebda187', N'BackEnd')
GO
INSERT INTO[dbo].[Departments] ([Id], [DepartmentName]) VALUES (N'5fc08aaf-9178-45e4-b30d-e29d90177606', N'DataScience')
GO
INSERT INTO[dbo].[Departments] ([Id], [DepartmentName]) VALUES (N'570bb844-cae2-46a2-bf66-fab40adb1ac4', N'OnlineSecurity')
GO
/*Inserting Projects*/
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'a0cf834b-e27f-465a-b143-2157e77ebe89', N'MaximaWebPage')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'7d087dca-b199-403e-890b-592f46261173', N'OnlineShop')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'bbed5e32-2991-42dc-b30c-79ea14980da2', N'StreamingService')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'7c42c61b-b0b4-46f9-805f-88d587a68486', N'SocialWeb')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'f2b6b2e3-0387-4da6-bbdd-951084e7e0f4', N'ChatBot')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'e7da3506-5bf3-4602-8440-96968fa8c372', N'SafeBrowser')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'f7175979-5a43-4ad3-a839-ac34302d1c60', N'VirtualMuseum')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'b379e9c4-3125-4350-87ee-b278ab82fff2', N'OnlineCasino')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'b555cbaf-1bda-4b80-a8ae-ba4e352a1721', N'ComunityService')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'05567f80-564f-4499-8b0d-bf32f0b9567b', N'FastServer')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'dae95c43-fdc4-4184-b429-c934cdd61bbb', N'ElectroDroids')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'9a956e55-3834-47bc-bb60-cd4d3109b2bc', N'CryptoExchange')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'440fe525-1302-4b81-88ac-d214efe3be5b', N'OnlineDatabase')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'5908bc2d-297a-422d-80fc-d27fb940118e', N'CarSharingService')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'cd8f14f0-030d-4b53-831f-dd0431efa464', N'RestaurantApp')
GO
INSERT [dbo].[Projects] ([Id], [ProjectName]) VALUES (N'5da3eb3d-7871-4012-8a0c-e79ff7069f93', N'GamesDev')
GO
/*Inserting Developers*/
INSERT [dbo].[Developers] ([Id], [Name], [LastName], [DepartmentId]) VALUES (N'8dcca5d9-34e7-4968-a149-2932a9b1dd42', N'Lukas', N'Norvaisas', N'a7c47175-51fe-498f-a624-0732b1f5904c')
GO
INSERT [dbo].[Developers] ([Id], [Name], [LastName], [DepartmentId]) VALUES (N'f65952ef-6a25-4782-9971-2dae3ef8b352', N'Ben', N'Sapiro', N'a7c47175-51fe-498f-a624-0732b1f5904c')
GO
INSERT [dbo].[Developers] ([Id], [Name], [LastName], [DepartmentId]) VALUES (N'86391798-8369-4c91-aafe-37e804886f92', N'Andy', N'Hawk', N'a7c47175-51fe-498f-a624-0732b1f5904c')
GO
INSERT [dbo].[Developers] ([Id], [Name], [LastName], [DepartmentId]) VALUES (N'ffb30932-1bb6-4231-81ee-672598f2dc42', N'Mars', N'Jupiter', N'a7c47175-51fe-498f-a624-0732b1f5904c')
GO
INSERT [dbo].[Developers] ([Id], [Name], [LastName], [DepartmentId]) VALUES (N'06e7576a-3cc2-4895-bc03-69a0ddf0b682', N'Dandy', N'Holmes', N'a7c47175-51fe-498f-a624-0732b1f5904c')
GO
INSERT [dbo].[Developers] ([Id], [Name], [LastName], [DepartmentId]) VALUES (N'1f23a6bd-8183-4465-b2bf-9d67885fa792', N'Lary', N'King', N'a7c47175-51fe-498f-a624-0732b1f5904c')
GO
INSERT [dbo].[Developers] ([Id], [Name], [LastName], [DepartmentId]) VALUES (N'87e14ac8-777b-423e-8c45-a465aa6d95c2', N'Dandy', N'Spleen', N'a7c47175-51fe-498f-a624-0732b1f5904c')
GO
INSERT [dbo].[Developers] ([Id], [Name], [LastName], [DepartmentId]) VALUES (N'ffae86f5-f95a-42a9-aaf9-a656ceeab422', N'July', N'Atkinson', N'a7c47175-51fe-498f-a624-0732b1f5904c')
GO
INSERT [dbo].[Developers] ([Id], [Name], [LastName], [DepartmentId]) VALUES (N'edb2e329-5885-40b7-bc5d-cba159cb7522', N'Omar', N'Hajam', N'a7c47175-51fe-498f-a624-0732b1f5904c')
GO
INSERT [dbo].[Developers] ([Id], [Name], [LastName], [DepartmentId]) VALUES (N'16415cd0-6fd3-437e-b74d-d32d58d3dfb2', N'Caron', N'Nolifer', N'a7c47175-51fe-498f-a624-0732b1f5904c')
GO
INSERT [dbo].[Developers] ([Id], [Name], [LastName], [DepartmentId]) VALUES (N'de05b97b-7712-4f32-8263-f0a7211c1742', N'Barey', N'Honolu', N'a7c47175-51fe-498f-a624-0732b1f5904c')
GO