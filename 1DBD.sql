USE [Diplom]
GO
/****** Object:  Table [dbo].[Specialization]    Script Date: 09.06.2024 13:12:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialization](
	[Name] [nvarchar](50) NOT NULL,
	[Number_of_Seats] [int] NOT NULL,
	[Group_Status] [nvarchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Spaces_Left] [int] NULL,
 CONSTRAINT [PK_Specialization] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_Role]    Script Date: 09.06.2024 13:12:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Role](
	[ID] [int] NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Table_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[The_Applicant]    Script Date: 09.06.2024 13:12:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[The_Applicant](
	[Full_Name] [nvarchar](50) NOT NULL,
	[Passport_Data] [bigint] NOT NULL,
	[Date_of_birth] [date] NOT NULL,
	[Phone_Number] [bigint] NOT NULL,
	[Place_of_Residence] [nvarchar](100) NOT NULL,
	[Specialization] [int] NOT NULL,
	[Average_Score] [float] NOT NULL,
	[Status] [nvarchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_The_Applicant] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 09.06.2024 13:12:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [int] NOT NULL,
	[ID] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Specialization] ON 

INSERT [dbo].[Specialization] ([Name], [Number_of_Seats], [Group_Status], [ID], [Spaces_Left]) VALUES (N'ИСП-20', 25, N'Утверждено', 1, 23)
INSERT [dbo].[Specialization] ([Name], [Number_of_Seats], [Group_Status], [ID], [Spaces_Left]) VALUES (N'МЧС-20', 25, N'Не утверждена', 2, 27)
INSERT [dbo].[Specialization] ([Name], [Number_of_Seats], [Group_Status], [ID], [Spaces_Left]) VALUES (N'ПД-20', 20, N'Утверждено', 4, 0)
SET IDENTITY_INSERT [dbo].[Specialization] OFF
GO
INSERT [dbo].[Table_Role] ([ID], [Role]) VALUES (1, N'Секретарь')
INSERT [dbo].[Table_Role] ([ID], [Role]) VALUES (2, N'Заместитель руководителя')
INSERT [dbo].[Table_Role] ([ID], [Role]) VALUES (3, N'Администратор')
GO
SET IDENTITY_INSERT [dbo].[The_Applicant] ON 

INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Шубин Даниэль Григорьевич', 4680765337, CAST(N'1975-12-28' AS Date), 89717955061, N'Россия, г. Елец, Почтовая ул., д. 25 кв.82', 4, 3, N'Зачислен', 10)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Харитонов Даниил Николаевич', 4673129509, CAST(N'1969-12-06' AS Date), 89312273718, N'Россия, г. Хасавюрт, Березовая ул., д. 8 кв.25', 4, 3, N'Зачислен', 18)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Селиванова Кристина Давидовна', 4272243512, CAST(N'1988-08-09' AS Date), 89252699414, N'Россия, г. Нижневартовск, Якуба Коласа ул., д. 1 кв.30', 4, 4, N'Зачислен', 19)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Карпов Иван Львович', 4822426011, CAST(N'1960-11-20' AS Date), 89973056740, N'Россия, г. Новороссийск, Дачная ул., д. 8 кв.48', 4, 3.3, N'Зачислен', 20)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Иванов Давид Николаевич', 4120706450, CAST(N'1982-12-15' AS Date), 89382326049, N'Россия, г. Прокопьевск, Колхозный пер., д. 23 кв.13', 4, 3.7, N'Зачислен', 21)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Михайлова Ксения Александровна', 4195180793, CAST(N'1977-06-21' AS Date), 89682716572, N'Россия, г. Нефтеюганск, Молодежная ул., д. 8 кв.25', 4, 4.1, N'Зачислен', 22)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Васильева Каролина Алексеевна', 4953846350, CAST(N'2004-08-05' AS Date), 89853889296, N'Россия, г. Сыктывкар, Вишневая ул., д. 18 кв.37', 4, 4.7, N'Зачислен', 23)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Симонов Ярослав Кириллович', 4860658018, CAST(N'1989-06-13' AS Date), 89736202754, N'Россия, г. Красноярск, Интернациональная ул., д. 22 кв.42', 4, 3.6, N'Зачислен', 24)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Шаповалов Платон Артёмович', 4170597040, CAST(N'1969-06-08' AS Date), 89066792982, N'Россия, г. Красноярск, Зеленый пер., д. 14 кв.154', 4, 4.4, N'Зачислен', 25)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Романова Алия Максимовна', 4641171614, CAST(N'1965-10-28' AS Date), 89157903387, N'Россия, г. Орск, Космонавтов ул., д. 8 кв.47', 4, 4.9, N'Зачислен', 26)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Селиванов Григорий Кириллович', 4996600087, CAST(N'1983-04-06' AS Date), 89214166286, N'Россия, г. Владивосток, Дорожная ул., д. 10 кв.38', 4, 3.2, N'Зачислен', 27)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Иванов Дамир Иванович', 4461550733, CAST(N'1969-01-06' AS Date), 89467441967, N'Россия, г. Элиста, Лесной пер., д. 20 кв.74', 4, 3.8, N'Зачислен', 28)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Субботин Артём Михайлович', 4349114515, CAST(N'1978-02-23' AS Date), 89514279861, N'Россия, г. Невинномысск, Школьная ул., д. 6 кв.40', 4, 4.8, N'Зачислен', 29)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Воробьева Виктория Елисеевна', 4342710672, CAST(N'1976-11-15' AS Date), 89978823934, N'Россия, г. Хасавюрт, Приозерная ул., д. 8 кв.105', 4, 4.3, N'Зачислен', 30)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Павлов Никита Александрович', 4712914813, CAST(N'1988-12-12' AS Date), 89297836723, N'Россия, г. Рубцовск, Мира ул., д. 18 кв.59', 4, 4.2, N'Зачислен', 31)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Шаповалова Анна Фёдоровна', 4132353891, CAST(N'1982-03-26' AS Date), 89903112245, N'Россия, г. Муром, Озерный пер., д. 12 кв.29', 4, 3.1, N'Зачислен', 32)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Бабушкина Елизавета Романовна', 4473505281, CAST(N'1979-01-23' AS Date), 89637043936, N'Россия, г. Кострома, Южная ул., д. 5 кв.132', 4, 3.4, N'Зачислен', 33)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Мельникова Мария Георгиевна', 4725423747, CAST(N'1974-03-26' AS Date), 89305787428, N'Россия, г. Орск, Березовая ул., д. 4 кв.12', 4, 3.5, N'Зачислен', 34)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Степанов Даниэль Михайлович', 4534906695, CAST(N'1966-04-22' AS Date), 89874916446, N'Россия, г. Пушкино, Якуба Коласа ул., д. 15 кв.134', 4, 3.9, N'Зачислен', 35)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Дмитриев Иван Михайлович', 4826512188, CAST(N'1996-09-11' AS Date), 89516003192, N'Россия, г. Сыктывкар, ЯнкиКупалы ул., д. 9 кв.86', 4, 4.3, N'Зачислен', 36)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Пирогов Иван Матвеевич', 4096813482, CAST(N'1981-08-12' AS Date), 89978915873, N'Россия, г. Новочеркасск, Сосновая ул., д. 23 кв.167', 1, 4.7, N'Зачислен', 37)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Кузьмина Екатерина Данииловна', 4759917125, CAST(N'1999-08-12' AS Date), 89461388246, N'Россия, г. Красноярск, Первомайская ул., д. 4 кв.94', 1, 4.5, N'Зачислен', 38)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Гущин Иван Ярославович', 4996825230, CAST(N'1979-08-28' AS Date), 89993314097, N'Россия, г. Обнинск, Дружная ул., д. 8 кв.96', 1, 4.6, N'Зачислен', 39)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Сорокина Вера Макаровна', 4896305639, CAST(N'1984-04-02' AS Date), 89927118215, N'Россия, г. Иркутск, Пионерская ул., д. 15 кв.35', 2, 4, N'В рассмотрении', 40)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Миронов Дмитрий Кириллович', 4784413733, CAST(N'1986-05-10' AS Date), 89461388246, N'Россия, г. Сергиев Посад, Садовая ул., д. 15 кв.130', 2, 5, N'Зачислен', 41)
INSERT [dbo].[The_Applicant] ([Full_Name], [Passport_Data], [Date_of_birth], [Phone_Number], [Place_of_Residence], [Specialization], [Average_Score], [Status], [ID]) VALUES (N'Карпов Александр Кириллович', 4770333192, CAST(N'1963-09-04' AS Date), 89461388246, N'Россия, г. Южно-Сахалинск, Красноармейская ул., д. 24 кв.178', 2, 3, N'Не зачислен', 42)
SET IDENTITY_INSERT [dbo].[The_Applicant] OFF
GO
INSERT [dbo].[User] ([Login], [Password], [Role], [ID]) VALUES (N'Ваня', N'Ваня', 3, 1)
INSERT [dbo].[User] ([Login], [Password], [Role], [ID]) VALUES (N'Максим', N'321', 2, 2)
INSERT [dbo].[User] ([Login], [Password], [Role], [ID]) VALUES (N'Олег', N'123', 1, 3)
GO
ALTER TABLE [dbo].[The_Applicant]  WITH CHECK ADD  CONSTRAINT [FK_The_Applicant_Specialization] FOREIGN KEY([Specialization])
REFERENCES [dbo].[Specialization] ([ID])
GO
ALTER TABLE [dbo].[The_Applicant] CHECK CONSTRAINT [FK_The_Applicant_Specialization]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Table_Role] FOREIGN KEY([Role])
REFERENCES [dbo].[Table_Role] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Table_Role]
GO
