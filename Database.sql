USE [master]
GO
CREATE DATABASE [VehicleShowroomManagementSystem]
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VehicleShowroomManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [VehicleShowroomManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
USE [VehicleShowroomManagementSystem]


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetTotalCar](@id bigint) RETURNS INTEGER
AS
BEGIN
   DECLARE @num int;
	SET @num = (Select Sum(p.Quantity) - SUM(o.Quantity) 
		from PurchaseOrderDetails p
		inner join Car c on p.CarNo = c.CarNo
		inner join OrderDetails o on o.CarNo = c.CarNo
		where c.CarNo = @id
		group by p.CarNo)
	Return @num;
END
GO

--- TABLE PHÂN CÔNG ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assigning](
	[OrderID] [bigint] NOT NULL,
	[OnAssigning] [date] NOT NULL,
	[EmployeeID] [bigint] NOT NULL,
	[AssigningID] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Assigning] PRIMARY KEY CLUSTERED 
(
	[AssigningID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--- TABLE CAR -----
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Car](
	[CarNo] [bigint] IDENTITY(1,1) NOT NULL,
	[ModelName] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[Status] [bit] NULL,
	[AddInfor] [nvarchar](max) NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[CarNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


--- TABLE KHUNG XE ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CarModel](
	[ModelName] [varchar](50) NOT NULL,
	[AddInfor] [nvarchar](max) NULL,
	[ManufactoryID] [int] NOT NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_CarModel_1] PRIMARY KEY CLUSTERED 
(
	[ModelName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

--- TABLE KHÁCH HÀNG ----
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Sex] [bit] NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Phone] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--- TABLE BỘ PHẬN(CHỨC VỤ)---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Department_1] PRIMARY KEY CLUSTERED 
(
	[DepartmentName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


--- Table NHÂN VIÊN ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Sex] [bit] NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Phone] [int] NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[UserName] [varchar](20) NULL,
	[Password] [varchar](20) NULL,
	[Photo] [varbinary](max) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
--- TABLE NHÀ MÁY SẢN XUẤT ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Manufactory](
	[ManufactoryID] [int] IDENTITY(1,1) NOT NULL,
	[ManufactoryName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Phone] [int] NOT NULL,
	[AddInfor] [nvarchar](max) NULL,
	[Logo] [varbinary](max) NULL,
 CONSTRAINT [PK_Manufactory] PRIMARY KEY CLUSTERED 
(
	[ManufactoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO


---- TABLE ĐẶT HÀNG ----
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[OnOrder] [date] NOT NULL,
	[EmployeeID] [bigint] NOT NULL,
	[Request] [nvarchar](100) NULL,
	[Confirmation] [bit] NOT NULL,
 CONSTRAINT [PK_SalesOrder] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



--- TABLE CHI TIẾT ĐẶT HÀNG ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderID] [bigint] NOT NULL,
	[CarNo] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_SalesOrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[CarNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



--- TABLE ĐƠN ĐẶT HÀNG ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[PurchaseOrderID] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[EmployeeID] [bigint] NULL,
 CONSTRAINT [PK_CarReceipt] PRIMARY KEY CLUSTERED 
(
	[PurchaseOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



--- TABLE CHI TIẾT ĐƠN ĐẶT HÀNG  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrderDetails](
	[PurchaseOrderID] [bigint] NOT NULL,
	[CarNo] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_PurchaseOrderDetails] PRIMARY KEY CLUSTERED 
(
	[PurchaseOrderID] ASC,
	[CarNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



--- TABLE DỊCH VỤ ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



--- TABLE CHI TIẾT DỊCH VỤ ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceDetails](
	[CarNo] [bigint] NOT NULL,
	[ServiceID] [int] NOT NULL,
 CONSTRAINT [PK_ServiceDetails] PRIMARY KEY CLUSTERED 
(
	[CarNo] ASC,
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


--- INSERT TABLE PHÂN CÔNG ---
SET IDENTITY_INSERT [dbo].[Assigning] ON 
INSERT [dbo].[Assigning] ([OrderID], [OnAssigning], [EmployeeID], [AssigningID]) VALUES (1, CAST(N'2023-03-08' AS Date), 1, 1)
INSERT [dbo].[Assigning] ([OrderID], [OnAssigning], [EmployeeID], [AssigningID]) VALUES (3, CAST(N'2023-04-20' AS Date), 1, 2)
INSERT [dbo].[Assigning] ([OrderID], [OnAssigning], [EmployeeID], [AssigningID]) VALUES (5, CAST(N'2023-08-22' AS Date), 1, 4)
INSERT [dbo].[Assigning] ([OrderID], [OnAssigning], [EmployeeID], [AssigningID]) VALUES (1, CAST(N'2023-03-24' AS Date), 1, 5)
INSERT [dbo].[Assigning] ([OrderID], [OnAssigning], [EmployeeID], [AssigningID]) VALUES (13, CAST(N'2023-03-24' AS Date), 1, 6)
INSERT [dbo].[Assigning] ([OrderID], [OnAssigning], [EmployeeID], [AssigningID]) VALUES (13, CAST(N'2023-03-24' AS Date), 1, 7)
INSERT [dbo].[Assigning] ([OrderID], [OnAssigning], [EmployeeID], [AssigningID]) VALUES (13, CAST(N'2023-03-24' AS Date), 1, 8)
SET IDENTITY_INSERT [dbo].[Assigning] OFF



--- INSERT TABLE KHÁCH HÀNG ---
SET IDENTITY_INSERT [dbo].[Customer] ON 
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Sex], [DateOfBirth], [Address], [Phone]) 
VALUES (1, N'Quyên', N'Đỗ Thu', 0, CAST(N'1992-03-13' AS Date), N'Vĩnh Yên - Vĩnh Phúc', 0713057391)
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Sex], [DateOfBirth], [Address], [Phone]) 
VALUES (3, N'Anh', N'Nguyễn Ngọc', 0, CAST(N'1985-09-22' AS Date), N'Hà Nội', 0312345679)
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Sex], [DateOfBirth], [Address], [Phone]) 
VALUES (6, N'Hưng', N'Nguyễn Phi', 0, CAST(N'1997-05-24' AS Date), N'Hà Đông - Hà Nội', 0387473271)
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Sex], [DateOfBirth], [Address], [Phone]) 
VALUES (7, N'Khánh', N'Hà Đăng', 1, CAST(N'1993-12-24' AS Date), N'Hàng Gà - Hà Nội', 0979823706)
SET IDENTITY_INSERT [dbo].[Customer] OFF


--- INSERT TABLE NHÀ MÁY SẢN XUẤT ---
SET IDENTITY_INSERT [dbo].[Manufactory] ON 
INSERT [dbo].[Manufactory] ([ManufactoryID], [ManufactoryName], [Address], [Phone], [AddInfor], [Logo]) 
VALUES (1, N'Mercedes Automobile', N'811-813 Nguyễn Văn Linh, Phường Tân Phong, Quận 7, TP.HCM', 0901224896, N'hotro.mercedes@gmail.com', NULL)
INSERT [dbo].[Manufactory] ([ManufactoryID], [ManufactoryName], [Address], [Phone], [AddInfor], [Logo]) 
VALUES (2, N'BENTLEY HO CHI MINH', N'Lô DVTM-1A, đường số 7 KCX, Tân Thuận, Thành phố Hồ Chí Minh', 0369388888, N'www.bentleymotors.com', NULL)
INSERT [dbo].[Manufactory] ([ManufactoryID], [ManufactoryName], [Address], [Phone], [AddInfor], [Logo]) 
VALUES (3, N'Latest Ferrari', N'Saigon Ho Chi Minh City HCMC', 0394421371, N'Best Price of Ferrari KC23 2023 in Vietnam', NULL)

SET IDENTITY_INSERT [dbo].[Manufactory] OFF

--- INSERT TABLE KHUNG XE ---
INSERT [dbo].[CarModel] ([ModelName], [AddInfor], [ManufactoryID], [Image]) 
VALUES (N'MercedesAvantgarde Plus', N'Showroom Ferrari Vietnam: biểu tượng của sự sang trọng, phong cách và tốc độ. 
									Một huyền thoại được xây dựng dựa trên sự tinh tế, vẻ đẹp trong từng đường nét thiết kế 
									và sự độc đáo mang đậm tính cá nhân hóa.', 1, NULL)
INSERT [dbo].[CarModel] ([ModelName], [AddInfor], [ManufactoryID], [Image]) 
VALUES (N'MercedesAvantgarde', N'Điểm khác biệt duy nhất ở ngoại thất trên hai phiên bản chính là mâm xe. C200 Avantgarde sở hữu Mâm 
									hợp kim 17-inch thiết kế 10 chấu kép, C200 Avantgarde Plus sở hữu Mâm hợp kim 18-inch thiết kế đa 
									chấu.', 1, NULL)
INSERT [dbo].[CarModel] ([ModelName], [AddInfor], [ManufactoryID], [Image]) 
VALUES (N'BBENTAYGA', N'Bentayga S kế thừa sức mạnh và khả năng vận hành của Bentayga, đồng thời bổ sung thêm chút góc cạnh, 
						đường nét khoẻ khoắn cùng hiệu suất cao hơn. Với bánh xe lớn 22 inch và các chi tiết màu đen hầm hố, 
						đây là một chiếc xe bạn không thể bỏ qua.', 2, NULL)
INSERT [dbo].[CarModel] ([ModelName], [AddInfor], [ManufactoryID], [Image]) 
VALUES (N'BFLYING SPUR', N'Những chi tiết trang trí Mulliner tinh tế mang đến bản sắc riêng cho chiếc xe này ngay từ ánh nhìn đầu tiên, 
						từ các lỗ thông gió trên cánh và biểu tượng Mulliner cho đến nắp gương sơn bạc xa tanh. Nhìn từ phía đầu xe, 
						lưới tản nhiệt Mulliner hình con thoi kép, chất liệu crôm sáng được kết hợp với các tấm lưới tản nhiệt cản trước phía dưới, 
						cũng có cùng tông màu crôm sáng.', 2, NULL)
INSERT [dbo].[CarModel] ([ModelName], [AddInfor], [ManufactoryID], [Image]) 
VALUES (N'BentleyMulsanne', N'Thế hệ mới với diện mạo của sự xa hoa và đẳng cấp thời thượng của một chiếc xe siêu sang mà khách hàng nào cũng muốn 
								sở hữu đặc biệt là trang bị nội thất hiện đại bên trong xe luôn là điểm phấn khích các 
								khách hàng trải nghiệm.', 2, NULL)	
INSERT [dbo].[CarModel] ([ModelName], [AddInfor], [ManufactoryID], [Image]) 
VALUES (N'FerrariAsento Plus', N'Ferrari KC23 2023 Price in Vietnam is VNM 12,242,550,000 (US$510,000)
								Latest Update: 2023 Ferrari KC23 has announced in July 2023. We expect KC23 to cost around $510,000.
								Just a short while ago, Ferrari thrilled car enthusiasts with the debut of the SF90 XX, and now they’ve pulled 
								yet another rabbit out of their hat.', 3, NULL)

select * from CarModel
select * from Car
--- INSERT TABLE CAR ---
SET IDENTITY_INSERT [dbo].[Car] ON 
INSERT [dbo].[Car] ([CarNo], [ModelName], [Name], [Price], [Status], [AddInfor]) 
VALUES (1, N'MercedesAvantgarde Plus', N'Mercedes C200 Plus', 1200000, 1, N'- Nội thất bọc da Artico 
							- Hàng ghế trước chỉnh điện và nhớ 3 vị trí (hàng ghế trước, vô lăng & gương chiếu hậu) 
							- Màn hình Tablo dạng kỹ thuật số 12,3 inch Màn hình giải trí trung tâm 11,9 inch tích hợp Apple Carplay và Android Auto không dây
							- Có sạc không dây
							- Điều hoà 2 vùng độc lập 
							- Vô lăng 3 chấu được bọc da, thiết kế kiểu dáng thể thao 
							- Hệ thống đèn viền trang trí nội thất 64 màu tuỳ chỉnh
							- Ở phiên bản 2023, C200 có thêm Hệ thống lọc không khí ENERGIZING AIR CONTROL')
INSERT [dbo].[Car] ([CarNo], [ModelName], [Name], [Price], [Status], [AddInfor]) 
VALUES (2, N'MercedesAvantgarde', N'Mercedes GLC 300 4MATIC', 2300000, 1, N' là dòng SUV hạng sang tầm trung rất được ưa chuộng tại thị trường Việt Nam 
																			kể từ những ngày đầu ra mắt tới thời điểm này. ')

INSERT [dbo].[Car] ([CarNo], [ModelName], [Name], [Price], [Status], [AddInfor]) 
VALUES (3, N'BFLYING SPUR', N'FLYING SPUR MULLINER', 7985000, 1, N'Chiếc Flying Spur Mulliner là đỉnh cao của dòng Flying Spur và là một trong những mẫu 
																xe sang trọng nhất đã lăn bánh khỏi xưởng Bentley tính đến thời điểm hiện tại.')
INSERT [dbo].[Car] ([CarNo], [ModelName], [Name], [Price], [Status], [AddInfor]) 
VALUES (4, N'BBENTAYGA', N'BENTAYGA AZURE', 8730000, 1, N'Bentayga Azure tập trung tối đa vào sự thoải mái và đảm bảo sức khoẻ thể chất, tinh thần 
															cho mọi người trên xe. Nếu bạn đang tìm kiếm một chiếc SUV kết hợp giữa thiết kế thanh lịch, 
															vượt thời gian với sức mạnh vô song và công nghệ tiên tiến, đơn giản là không có sự lựa chọn nào 
															tốt hơn, ngoài chiếc Azure này.')

INSERT [dbo].[Car] ([CarNo], [ModelName], [Name], [Price], [Status], [AddInfor]) 
VALUES (5, N'FerrariAsento Plus', N'Ferrari 488 Pista', 9050000, 1, N'Ferrari 488 Pista 2023 là mẫu xe đua thể thao chất lượng được thừa hưởng và trang 
																	bị nhiều công nghệ, động cơ hiện đại không thua kém so với các mẫu xe trong phân khúc hiện nay.')
INSERT [dbo].[Car] ([CarNo], [ModelName], [Name], [Price], [Status], [AddInfor]) 
VALUES (6, N'FerrariAsento Plus', N'Ferrari F12 Berlinetta', 8900000, 1, N'Siêu xe Ferrari F12 Berlinetta 2023 chính là một mẫu xe cuối cùng được thiết kế với 
																			sự hợp tác của nhà thiết kế trứ danh Pininfarina. Khi so với phiên bản Ferrari 599 Fiorano 
																			thì chiếc F12 Berlinetta có kích thước nhỏ hơn là 4.618mm x 1.942mm  x 1.273mm 
																			tương ứng với dài x rộng x cao. ')
SET IDENTITY_INSERT [dbo].[Car] OFF


--- INSERT TABLE DỊCH VỤ ---
SET IDENTITY_INSERT [dbo].[Service] ON 
INSERT [dbo].[Service] ([ServiceID], [Name], [Description]) 
VALUES (1, N'Bảo hành động cơ', N'Bảo hành bao gồm:
- Động cơ
- Hộp số')
INSERT [dbo].[Service] ([ServiceID], [Name], [Description]) 
VALUES (2, N'Bảo dưỡng định kỳ', N'Thông tin đang cập nhật...')
INSERT [dbo].[Service] ([ServiceID], [Name], [Description]) 
VALUES (3, N'phụ tùng -  phụ tùng chính hãng', N'Thông tin đang cập nhật...')
INSERT [dbo].[Service] ([ServiceID], [Name], [Description]) 
VALUES (4, N'Bảo dưỡng định kỳ', N'Thông tin đang cập nhật...')
INSERT [dbo].[Service] ([ServiceID], [Name], [Description]) 
VALUES (5, N'dịch vụ chăm sóc làm đẹp xe, ', N'Thông tin đang cập nhật...')

SET IDENTITY_INSERT [dbo].[Service] OFF

select * from Customer


--- INSERT TABLE BỘ PHẬN(CHỨC VỤ) ---
INSERT [dbo].[Department] ([DepartmentName]) VALUES (N'Accounting')
INSERT [dbo].[Department] ([DepartmentName]) VALUES (N'Car Manager')
INSERT [dbo].[Department] ([DepartmentName]) VALUES (N'HR')
INSERT [dbo].[Department] ([DepartmentName]) VALUES (N'Sales')
INSERT [dbo].[Department] ([DepartmentName]) VALUES (N'Sercurity')




--- INSERT TABLE NHÂN VIÊN ---
SET IDENTITY_INSERT [dbo].[Employee] ON 
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [Sex], [DateOfBirth], [Address], [Phone], [DepartmentName], [UserName], [Password], [Photo]) 
VALUES (2, N'Phong', N'Hoàng Văn', 1, CAST(N'1996-03-07' AS Date), N'Gia Lâm  -  Hà Nội', 1234567899, N'Sales', N'phong', N'123456', NULL)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [Sex], [DateOfBirth], [Address], [Phone], [DepartmentName], [UserName], [Password], [Photo]) 
VALUES (3, N'Bình', N'Phạm Văn', 1, CAST(N'1980-05-22' AS Date), N'Đông Anh - Hà Nội', 1687875733, N'HR', N'binh', N'123456', NULL)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [Sex], [DateOfBirth], [Address], [Phone], [DepartmentName], [UserName], [Password], [Photo]) 
VALUES (4, N'Tiến', N'Vũ Trần', 1, CAST(N'1998-03-03' AS Date), N'Đông Anh - Hà Nội', 1687875733, N'Car Manager', N'tien', N'123456', NULL)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [Sex], [DateOfBirth], [Address], [Phone], [DepartmentName], [UserName], [Password], [Photo])
VALUES (5, N'Quy', N'Nguyễn Xuân', 1, CAST(N'1990-03-22' AS Date), N'Sóc Sơn - Hà Nội', 1623985420, N'Sercurity', N'quy', N'123456', NULL)


INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [Sex], [DateOfBirth], [Address], [Phone], [DepartmentName], [UserName], [Password], [Photo])
				VALUES (1, N'Phúc', N'Đậu Hồng', 1, CAST(N'2003-12-01' AS Date), N'Đức Thọ - Hà Tĩnh', 394421371, N'HR', N'admin', N'000000', NULL)


SET IDENTITY_INSERT [dbo].[Employee] OFF

select * from  Employee






--- INSERT TABLE ĐẶT HÀNG ---
SET IDENTITY_INSERT [dbo].[Order] ON 
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OnOrder], [EmployeeID], [Request], [Confirmation]) 
					VALUES (1, 1, CAST(N'2023-03-03' AS Date), 1, N'', 1)
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OnOrder], [EmployeeID], [Request], [Confirmation]) 
VALUES (3, 1, CAST(N'2023-03-19' AS Date), 1, N'', 1)
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OnOrder], [EmployeeID], [Request], [Confirmation]) 
VALUES (5, 1, CAST(N'2023-03-22' AS Date), 1, N'This car is new', 0)
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OnOrder], [EmployeeID], [Request], [Confirmation]) 
VALUES (7, 7, CAST(N'2023-03-24' AS Date), 1, N'', 0)
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OnOrder], [EmployeeID], [Request], [Confirmation]) 
VALUES (8, 6, CAST(N'2023-03-24' AS Date), 1, N'', 0)
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OnOrder], [EmployeeID], [Request], [Confirmation]) 
VALUES (9, 6, CAST(N'2023-03-24' AS Date), 1, N'', 0)
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OnOrder], [EmployeeID], [Request], [Confirmation]) 
VALUES (12, 1, CAST(N'2023-04-20' AS Date), 1, N'', 0)
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OnOrder], [EmployeeID], [Request], [Confirmation]) 
VALUES (13, 7, CAST(N'2023-04-24' AS Date), 1, N'', 1)
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OnOrder], [EmployeeID], [Request], [Confirmation]) 
VALUES (14, 3, CAST(N'2023-08-29' AS Date), 5, N'', 1)
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OnOrder], [EmployeeID], [Request], [Confirmation]) 
VALUES (15, 7, CAST(N'2023-08-02' AS Date), 3, N'', 1)

SET IDENTITY_INSERT [dbo].[Order] OFF

--- INSERT TABLE CHI TIẾT ĐẶT HÀNG ---
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (1, 2, 1)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (1, 5, 1)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (3, 2, 7)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (3, 5, 2)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (5, 2, 1)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (5, 5, 3)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (7, 5, 1)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (8, 2, 1)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (8, 5, 1)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (9, 5, 1)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (12, 5, 1)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (13, 2, 1)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (13, 5, 2)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (14, 2, 1)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (14, 5, 2)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (15, 2, 1)
INSERT [dbo].[OrderDetails] ([OrderID], [CarNo], [Quantity]) VALUES (15, 5, 2)



--- INSERT TABLE ĐƠN ĐẶT HÀNG ---
SET IDENTITY_INSERT [dbo].[PurchaseOrder] ON 
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderID], [Date], [EmployeeID]) VALUES (15, CAST(N'2023-03-06' AS Date), 1)
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderID], [Date], [EmployeeID]) VALUES (24, CAST(N'2023-03-05' AS Date), 1)
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderID], [Date], [EmployeeID]) VALUES (25, CAST(N'2023-03-24' AS Date), 4)
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderID], [Date], [EmployeeID]) VALUES (26, CAST(N'2023-03-25' AS Date), 4)
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderID], [Date], [EmployeeID]) VALUES (27, CAST(N'2023-03-26' AS Date), 4)
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderID], [Date], [EmployeeID]) VALUES (28, CAST(N'2023-04-01' AS Date), 4)
INSERT [dbo].[PurchaseOrder] ([PurchaseOrderID], [Date], [EmployeeID]) VALUES (29, CAST(N'2023-04-02' AS Date), 3)

SET IDENTITY_INSERT [dbo].[PurchaseOrder] OFF


--- INSERT TABLE CHI TIẾT ĐƠN ĐẶT HÀNG ---
INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderID], [CarNo], [Quantity], [Price]) VALUES (15, 2, 2, 2300000)
INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderID], [CarNo], [Quantity], [Price]) VALUES (24, 2, 2, 2300000)
INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderID], [CarNo], [Quantity], [Price]) VALUES (25, 2, 1, 2300000)
INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderID], [CarNo], [Quantity], [Price]) VALUES (26, 2, 1, 2300000)
INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderID], [CarNo], [Quantity], [Price]) VALUES (27, 2, 1, 2300000)
INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderID], [CarNo], [Quantity], [Price]) VALUES (28, 2, 1, 2300000)
INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderID], [CarNo], [Quantity], [Price]) VALUES (28, 5, 2, 9050000)
INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderID], [CarNo], [Quantity], [Price]) VALUES (29, 2, 10, 2300000)
INSERT [dbo].[PurchaseOrderDetails] ([PurchaseOrderID], [CarNo], [Quantity], [Price]) VALUES (29, 5, 12, 9050000)





--- INSERT TABLE THÔNG TIN DỊCH VỤ ---
INSERT [dbo].[ServiceDetails] ([CarNo], [ServiceID]) VALUES (2, 1)
INSERT [dbo].[ServiceDetails] ([CarNo], [ServiceID]) VALUES (2, 2)
INSERT [dbo].[ServiceDetails] ([CarNo], [ServiceID]) VALUES (5, 1)



--- RÀNG BUỘC KHÓA ---
ALTER TABLE [dbo].[Assigning]  WITH CHECK ADD  CONSTRAINT [FK_Assigning_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Assigning] CHECK CONSTRAINT [FK_Assigning_Employee]
GO
ALTER TABLE [dbo].[Assigning]  WITH CHECK ADD  CONSTRAINT [FK_Assigning_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[Assigning] CHECK CONSTRAINT [FK_Assigning_Order]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [FK_Car_CarModel] FOREIGN KEY([ModelName])
REFERENCES [dbo].[CarModel] ([ModelName])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_CarModel]
GO
ALTER TABLE [dbo].[CarModel]  WITH CHECK ADD  CONSTRAINT [FK_CarModel_Manufactory] FOREIGN KEY([ManufactoryID])
REFERENCES [dbo].[Manufactory] ([ManufactoryID])
GO
ALTER TABLE [dbo].[CarModel] CHECK CONSTRAINT [FK_CarModel_Manufactory]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentName])
REFERENCES [dbo].[Department] ([DepartmentName])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Employee]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Car] FOREIGN KEY([CarNo])
REFERENCES [dbo].[Car] ([CarNo])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Car]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Order]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Employee]
GO
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrderDetails_Car] FOREIGN KEY([CarNo])
REFERENCES [dbo].[Car] ([CarNo])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK_PurchaseOrderDetails_Car]
GO
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrderDetails_PurchaseOrder] FOREIGN KEY([PurchaseOrderID])
REFERENCES [dbo].[PurchaseOrder] ([PurchaseOrderID])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK_PurchaseOrderDetails_PurchaseOrder]
GO
ALTER TABLE [dbo].[ServiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_ServiceDetails_Car] FOREIGN KEY([CarNo])
REFERENCES [dbo].[Car] ([CarNo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ServiceDetails] CHECK CONSTRAINT [FK_ServiceDetails_Car]
GO
ALTER TABLE [dbo].[ServiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_ServiceDetails_Service] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ServiceID])
GO
ALTER TABLE [dbo].[ServiceDetails] CHECK CONSTRAINT [FK_ServiceDetails_Service]
GO
--- StoredProcedure [dbo].[deleteCustomer] ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[deleteCustomer]
@CustomerID bigint
as
	delete from Customer where CustomerID = @CustomerID
GO


--- StoredProcedure [dbo].[deleteDepartment]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteDepartment]
@DepartmentName nvarchar(50)
as
	delete from Department where DepartmentName = DepartmentName
GO



--- StoredProcedure [dbo].[deleteModel]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteModel]
@ModelName varchar(50)
as
delete from CarModel where ModelName = (@ModelName)
GO



--- StoredProcedure [dbo].[deleteOrderDetails] ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteOrderDetails]
@OrderID bigint, @CarNo bigint
as
delete from OrderDetails where OrderID = @OrderID and CarNo = @CarNo
GO



---  StoredProcedure [dbo].[deletePurchaseOrderDetails] ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deletePurchaseOrderDetails]
@PurchaseOrderID bigint, @CarNo bigint
as
	delete from PurchaseOrderDetails where PurchaseOrderID = @PurchaseOrderID and CarNo = @CarNo
GO


--- StoredProcedure [dbo].[deleteService]   ---
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteService]
@ServiceID int
as
	delete from [Service] where ServiceID = @ServiceID
GO



---  StoredProcedure [dbo].[deleteServiceDetails]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[deleteServiceDetails]
@CarNo bigint
as
	delete ServiceDetails where CarNo = @CarNo
GO



--- StoredProcedure [dbo].[getAssigningByID]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getAssigningByID]
@AssigningID bigint
as
	select * from Assigning where AssigningID = @AssigningID
GO



--- StoredProcedure [dbo].[getCustomerByID]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getCustomerByID]
@CustomerID bigint
as
	select * from Customer where CustomerID = @CustomerID
GO



---  StoredProcedure [dbo].[getEmployee]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getEmployee]
@UserName varchar(20), @Password varchar(20), @DepartmentName nvarchar(50)
as
	select * from Employee where UserName = @UserName and [Password] = @Password and DepartmentName = @DepartmentName;
GO



---  StoredProcedure [dbo].[getManufactoryByID]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[getManufactoryByID]
 @ManufactoryID nvarchar(50)
 as
	select * from Manufactory where ManufactoryID = @ManufactoryID
GO



--- StoredProcedure [dbo].[getManufactoryByName]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[getManufactoryByName]
 @Name nvarchar(50)
 as
	select * from Manufactory where ManufactoryName = @Name
GO



---  StoredProcedure [dbo].[getModelByName]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getModelByName]
@ModelName varchar(50)
as
select * from CarModel where ModelName = (@ModelName)
GO



--- StoredProcedure [dbo].[getNewIdentity]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getNewIdentity]
@tableName varchar(20)
as
	select ident_current (@tableName)+1 as ID
GO



--- StoredProcedure [dbo].[getOrderDetails]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getOrderDetails]
@OrderID bigint
as
	select OrderDetails.Quantity, Car.* from [Order] inner join OrderDetails on [Order].OrderID = OrderDetails.OrderID 
	inner join Car on OrderDetails.CarNo = Car.CarNo where [Order].OrderID = @OrderID
GO



---  StoredProcedure [dbo].[getPurchaseOrderDetails]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getPurchaseOrderDetails]
@PurchaseOrderID bigint
as
	select * from PurchaseOrder inner join PurchaseOrderDetails on PurchaseOrder.PurchaseOrderID= PurchaseOrderDetails.PurchaseOrderID
	inner join Car on PurchaseOrderDetails.CarNo = Car.CarNo where PurchaseOrder.PurchaseOrderID = @PurchaseOrderID;
GO



--- StoredProcedure [dbo].[getReceipt]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getReceipt]
@ReceiptID bigint, @PurchaseOrderID bigint
as
	select * from CarReceipt where ReceiptID = (@ReceiptID) and PurchaseOrderID = (@PurchaseOrderID)
GO



---  StoredProcedure [dbo].[getReceiptByID] ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getReceiptByID]
@ReceiptID bigint
as
	select * from CarReceipt where ReceiptID = (@ReceiptID)





GO
--- StoredProcedure [dbo].[getServiceIDByName]   
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getServiceIDByName]
@ServiceName nvarchar(50)
as
	select ServiceID from Service where Name = @ServiceName
GO



--- StoredProcedure [dbo].[insertAssigning] ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertAssigning]
@OrderID bigint, @EmployeeID bigint, @OnAssigning date
as
insert into Assigning (OrderID, EmployeeID, OnAssigning) values(@OrderID, @EmployeeID, @OnAssigning)
GO



--- StoredProcedure [dbo].[insertCar]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertCar]
@ModelName varchar(50), @Name varchar(50), @Price float, @AddInfor nvarchar(100), @Status bit 
as
insert into Car (ModelName , Name, Price, AddInfor, [Status]) values(@ModelName , @Name, @Price, @AddInfor, @Status)
GO



---  StoredProcedure [dbo].[insertCustomer]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertCustomer]
@FirstName nvarchar(20), @LastName nvarchar(20), @Sex bit, @DateOfBirth date, @Address nvarchar(20), @Phone int
as
insert into Customer(FirstName, LastName, Sex, DateOfBirth, [Address], Phone) values(@FirstName, @LastName, @Sex, @DateOfBirth, @Address, @Phone) 
GO



--- StoredProcedure [dbo].[insertDepartment]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertDepartment]
@DepartmentName nvarchar(50)
as
	insert into Department values (@DepartmentName)
GO



--- StoredProcedure [dbo].[insertEmployee]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertEmployee]
@DepartmentName nvarchar(50), 
@FirstName nvarchar(20), 
@LastName nvarchar(20), 
@Photo varbinary(Max), 
@Sex bit, 
@DateOfBirth date,
@Address nvarchar(100), 
@Phone int, 
@UserName varchar(20),
@Password varchar(20)
as
	insert into Employee(DepartmentName, FirstName, LastName, Photo, Sex, DateOfBirth, [Address], Phone, UserName, [Password]) 
	values(@DepartmentName, @FirstName, @LastName, @Photo, @Sex, @DateOfBirth, @Address, @Phone, @UserName, @Password)
GO



--- StoredProcedure [dbo].[insertManufactory]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertManufactory]
@Name nvarchar(50), @Address nvarchar(100), @Phone int, @Logo varbinary(max), @AddInfor nvarchar(100)
as
	insert into Manufactory (ManufactoryName, Address, Phone, Logo, AddInfor) 
	values(@Name, @Address, @Phone, @Logo, @AddInfor)
GO



---  StoredProcedure [dbo].[insertModel]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertModel]
@ModelName varchar(50), @AddInfor nvarchar(100), @Image varbinary(max), @ManufactoryID int
as
	insert into CarModel (ModelName, AddInfor, [Image], ManufactoryID) values(@ModelName, @AddInfor, @Image, @ManufactoryID)
GO



--- StoredProcedure [dbo].[insertOrder]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[insertOrder]
 @CustomerID bigint, @OnOrder date, @EmployeeID bigint, @Request nvarchar(100), @Confirmation bit
 as
	insert into [Order] (CustomerID, OnOrder, EmployeeID, Request, Confirmation) values(@CustomerID, @OnOrder, @EmployeeID, @Request, @Confirmation)
GO



--- StoredProcedure [dbo].[insertOrderDetails]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertOrderDetails]
@OrderID bigint, @CarNo bigint, @Quantity int
as
	insert into OrderDetails (OrderID, CarNo, Quantity) values(@OrderID, @CarNo, @Quantity)
GO



---  StoredProcedure [dbo].[insertPurchaseOrder]    ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertPurchaseOrder]
@Date date, @EmployeeID bigint
as
	insert into PurchaseOrder ([Date], EmployeeID) values(@Date, @EmployeeID)
GO



--- StoredProcedure [dbo].[insertPurchaseOrderDetails] ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertPurchaseOrderDetails]
@PurchaseOrderID bigint, @CarNo bigint, @Quantity int, @Price float
as
	insert into PurchaseOrderDetails (PurchaseOrderID, CarNO, Quantity, Price) values(@PurchaseOrderID, @CarNo, @Quantity, @Price) 
GO



--- StoredProcedure [dbo].[insertReceipt]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertReceipt]
@Date date, @EmployeeID bigint, @PurchaseOrderID bigint
as
insert into CarReceipt ([Date], EmployeeID, PurchaseOrderID) values(@Date, @EmployeeID, @PurchaseOrderID)
GO



--- StoredProcedure [dbo].[insertService]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertService]
@Name nvarchar(50), @Description nvarchar(200)
as
	insert into Service(Name, [Description] )values(@Name, @Description)
GO



---  StoredProcedure [dbo].[insertServiceDetails] ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertServiceDetails]
@CarNo bigint, @ServiceID int
as
	insert into ServiceDetails values(@CarNo, @ServiceID)
GO



---  StoredProcedure [dbo].[isExistCar]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[isExistCar]
@CarNo bigint
as
	select COUNT(*) from Car where Car.CarNo in (select CarNo from OrderDetails where CarNo = @CarNo) 
	or Car.CarNo in (select CarNo from PurchaseOrderDetails where CarNo = @CarNo)
GO



---  StoredProcedure [dbo].[isExistCarNoInOrderDetails]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[isExistCarNoInOrderDetails]
@OrderID bigint, @CarNo bigint
as
	select COUNT(*) from OrderDetails where OrderID = @OrderID and CarNo = @CarNo
GO



--- StoredProcedure [dbo].[isExistCarNoInPurchaseOrderDetails] ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[isExistCarNoInPurchaseOrderDetails]
@PurchaseOrderID bigint, @CarNo bigint
as
	select COUNT(*) from PurchaseOrderDetails where PurchaseOrderID = @PurchaseOrderID and CarNo = @CarNo
GO



--- StoredProcedure [dbo].[isExistCustomer]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[isExistCustomer]
@CustomerID bigint
as
	select COUNT(*) from Customer inner join [Order] on Customer.CustomerID = [Order].CustomerID  where Customer.CustomerID = @CustomerID
GO



---  StoredProcedure [dbo].[isExistDepartmentName]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[isExistDepartmentName]
@DepartmentName nvarchar(50)
as
	select COUNT(*) from Department where DepartmentName = @DepartmentName
GO



--- StoredProcedure [dbo].[isExistDepartmentName2]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[isExistDepartmentName2]
@DepartmentName nvarchar(50)
as
	select COUNT(*) from Department inner join Employee on Department.DepartmentName = Employee.DepartmentName where Department.DepartmentName = @DepartmentName
GO



--- StoredProcedure [dbo].[isExistEmployee]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[isExistEmployee]
@EmployeeID bigint
as
	select COUNT(*) from Employee where Employee.EmployeeID in (select EmployeeID from [Order] where EmployeeID = @EmployeeID) or Employee.EmployeeID 
	in (select EmployeeID from Assigning where EmployeeID = @EmployeeID) or Employee.EmployeeID in (select EmployeeID from CarReceipt where EmployeeID = Employee.EmployeeID)
	or Employee.EmployeeID in (select EmployeeID from PurchaseOrder where EmployeeID = @EmployeeID)
GO



--- StoredProcedure [dbo].[isExistManufactory]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[isExistManufactory]
 @ManufactoryID int
 as
	select COUNT(*) from Manufactory inner join CarModel on Manufactory.ManufactoryID = CarModel.ManufactoryID where Manufactory.ManufactoryID = @ManufactoryID
GO
---  StoredProcedure [dbo].[isExistModel]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[isExistModel]
@ModelName varchar(50)
as
select count(*) from CarModel where ModelName in (select ModelName from Car where ModelName = @ModelName)
GO



--- StoredProcedure [dbo].[isExistOrder]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[isExistOrder]
 @OrderID bigint
 as
	select COUNT(*) from [Order] where [Order].OrderID in (select OrderID from Assigning where OrderID = @OrderID) or
	[Order].OrderID in (select OrderID from OrderDetails where OrderID = @OrderID)
GO



--- StoredProcedure [dbo].[isExistPurchaseOrder] ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[isExistPurchaseOrder]
@PurchaseOrderID bigint
as
	select COUNT(*) from PurchaseOrder where PurchaseOrder.PurchaseOrderID in (select PurchaseOrderID from CarReceipt where PurchaseOrderID = @PurchaseOrderID)
	or PurchaseOrder.PurchaseOrderID in (select PurchaseOrderID from PurchaseOrderDetails where PurchaseOrderID = @PurchaseOrderID)
GO



--- StoredProcedure [dbo].[isExistPurchaseOrderID]  
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[isExistPurchaseOrderID]
	@ID bigint
as
	select COUNT(*) from PurchaseOrderDetails inner join PurchaseOrder on PurchaseOrder.PurchaseOrderID = PurchaseOrderDetails.PurchaseOrderID
	inner join CarReceipt on CarReceipt.PurchaseOrderID = PurchaseOrderDetails.PurchaseOrderID where PurchaseOrder.PurchaseOrderID = @ID
GO



--- StoredProcedure [dbo].[isExistService]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[isExistService]
@ServiceID int
as
	select COUNT(*) from [Service] where ServiceID in(select ServiceID from ServiceDetails where ServiceID = @ServiceID)
GO



--- StoredProcedure [dbo].[searchAssigning]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[searchAssigning]
@keyword date
as
	select * from Assigning where OnAssigning = @keyword
GO



---  StoredProcedure [dbo].[searchCar]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[searchCar]
@keyword varchar(50)
as
	select * from Car where Name like '%'+@keyword+'%' or ModelName like '%'+@keyword+'%'
GO



--- StoredProcedure [dbo].[searchCustomer]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[searchCustomer]
@keyword nvarchar(50)
as
	select * from Customer where FirstName like '%' +@keyword+'%' or LastName like '%' +@keyword+'%'
GO



---  StoredProcedure [dbo].[searchEmployee]    ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[searchEmployee]
@keyword nvarchar(50)
as
	select * from Employee  where FirstName like '%' +@keyword+'%' or LastName like '%' +@keyword+'%' or DepartmentName like '%' +@keyword+'%'
GO



---  StoredProcedure [dbo].[searchManufactory]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[searchManufactory]
@keyword nvarchar(50)
as
	select * from Manufactory where ManufactoryName like '%'+@keyword+'%'
GO



--- StoredProcedure [dbo].[searchModel]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[searchModel]
@keyword varchar(50)
as
	select * from CarModel inner join Manufactory on CarModel.ManufactoryID = Manufactory.ManufactoryID
	where ModelName like '%'+ @keyword+'%' or Manufactory.ManufactoryName like '%'+@keyword+'%'
GO



--- StoredProcedure [dbo].[searchOrder]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[searchOrder]
@keyword date
as
	select * from [Order] where OnOrder  = @keyword
GO



--- StoredProcedure [dbo].[searchPurchaseOrder]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[searchPurchaseOrder]
@keyword date
as
	select * from PurchaseOrder where [Date] = @keyword
GO



--- StoredProcedure [dbo].[searchReceipt]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[searchReceipt]
@keyword date
as
	select * from CarReceipt where [Date] = @keyword
GO



--- StoredProcedure [dbo].[totalCar]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[totalCar]
@id bigint
As
begin
	DECLARE @num int;
SET @num = (Select Sum(p.Quantity) - SUM(o.Quantity) from PurchaseOrderDetails p
					 inner join Car c on p.CarNo = c.CarNo
					 inner join OrderDetails o on o.CarNo = c.CarNo
					 where c.CarNo = @id
					 group by p.CarNo)
Return @num;
end
GO



---  StoredProcedure [dbo].[totalOrderPrice]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[totalOrderPrice]
@OrderID bigint
as
	select SUM(Quantity*Car.Price) from [Order] inner join OrderDetails  on [Order].OrderID = OrderDetails.OrderID
	inner join Car on OrderDetails.CarNo = Car.CarNo where [Order].OrderID = @OrderID 
GO



---  StoredProcedure [dbo].[totalPurchaseOrderPrice]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[totalPurchaseOrderPrice]
@PurchaseOrderID bigint
as
	select SUM(Quantity*Price) from PurchaseOrder inner join PurchaseOrderDetails  on PurchaseOrder.PurchaseOrderID = PurchaseOrderDetails.PurchaseOrderID
	where PurchaseOrder.PurchaseOrderID = @PurchaseOrderID
GO



---  StoredProcedure [dbo].[updateAssigning]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[updateAssigning]
@OrderID bigint, @OnAssigning date, @AssigningID bigint
as
	update Assigning set  OrderID = @OrderID, OnAssigning = (@OnAssigning)  where AssigningID = (@AssigningID)
GO



---  StoredProcedure [dbo].[updateCar]    ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[updateCar]
@ModelName varchar(50), @Name varchar(50), @Price float, @AddInfor nvarchar(100), @Status bit, @CarNo bigint 
as
	update Car set ModelName = (@ModelName), Name = (@Name), Price = (@Price), AddInfor = (@AddInfor), [Status] = (@Status) where CarNo = (@CarNo)
GO



---  StoredProcedure [dbo].[updateCustomer]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateCustomer]
@FirstName nvarchar(20), @LastName nvarchar(20), @Sex bit, @DateOfBirth date, @Address nvarchar(20), @Phone int, @CustomerID bigint
as
	update Customer set FirstName = @FirstName, LastName = @LastName, Sex = @Sex, DateOfBirth = @DateOfBirth, [Address] = @Address, Phone = @Phone where CustomerID = @CustomerID
GO



--- StoredProcedure [dbo].[updateEmployee]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[updateEmployee]
	@DepartmentName nvarchar(50), @FirstName nvarchar(20), @LastName nvarchar(20), @Photo varbinary(Max), @Sex bit, @DateOfBirth date, @Address nvarchar(100), @Phone int, @UserName varchar(20), @Password varchar(20), @EmployeeID bigint
as
	update Employee set DepartmentName = @DepartmentName, FirstName = @FirstName, LastName = @LastName, Photo = @Photo, Sex = @Sex, DateOfBirth = @DateOfBirth, [Address] = @Address, Phone = @Phone, UserName = @UserName, [Password] = @Password where EmployeeID = @EmployeeID
GO



---  StoredProcedure [dbo].[updateManufactory]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE proc [dbo].[updateManufactory]
 @Name nvarchar(50), @Address nvarchar(100), @Phone int, @Logo varbinary(max), @AddInfor nvarchar(100), @ManufactoryID int
 as
	update Manufactory set ManufactoryName = (@Name), [Address] = (@Address), Phone = (@Phone), Logo = (@Logo), AddInfor = (@AddInfor) where ManufactoryID = (@ManufactoryID)
GO



---  StoredProcedure [dbo].[updateModel]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateModel]
@AddInfor nvarchar(100), @Image varbinary(max), @ManufactoryID int, @ModelName varchar(50)
as
	update CarModel set AddInfor = (@AddInfor), [Image] = (@Image), ManufactoryID = (@ManufactoryID)   where ModelName = (@ModelName)
GO



--- StoredProcedure [dbo].[updateOrder]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateOrder]
 @OnOrder date, @Request nvarchar(100), @Confirmation bit, @OrderID bigint
 as
	update [Order] set OnOrder = (@OnOrder), Request = (@Request), Confirmation = (@Confirmation) where OrderID = (@OrderID)
GO



--- StoredProcedure [dbo].[updateOrderDetails]  ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateOrderDetails]
@CarNo bigint, @Quantity int, @OrderID bigint
as
	update OrderDetails set Quantity = @Quantity where OrderID = @OrderID and CarNo = @CarNo
GO



---  StoredProcedure [dbo].[updatePurchaseOrder] ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updatePurchaseOrder]
@Date date, @PurchaseOrderID bigint
as
	update PurchaseOrder set Date = (@Date) where PurchaseOrderID = (@PurchaseOrderID)
GO



---  StoredProcedure [dbo].[updatePurchaseOrderDetails]   ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updatePurchaseOrderDetails]
@Quantity int, @Price float, @PurchaseOrderID bigint, @CarNo bigint
as
	update PurchaseOrderDetails set Quantity = @Quantity, Price = @Price where PurchaseOrderID = @PurchaseOrderID and CarNo = @CarNo
GO



--- StoredProcedure [dbo].[updateReceipt] ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateReceipt]
@Date date, @EmployeeID bigint, @ReceiptID bigint, @PurchaseOrderID bigint
as
	update CarReceipt set [Date] = (@Date), EmployeeID = @EmployeeID, PurchaseOrderID = @PurchaseOrderID where ReceiptID = @ReceiptID
GO



--- StoredProcedure [dbo].[updateService] ---
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateService]
@Name nvarchar(50), @Description nvarchar(200), @ServiceID int
as
	update Service set Name = @Name, [Description] = @Description where ServiceID = @ServiceID
GO


