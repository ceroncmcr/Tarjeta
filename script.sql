
use CardDb
go

if(object_id('parameters')is null)
begin
  create table parameters(
    id int identity primary key,
    name varchar(20),
    description varchar(100),
    value varchar(150)
  )  

  SET IDENTITY_INSERT [dbo].[parameters] ON 	
	INSERT [dbo].[parameters] ([id], [name], [description], [value]) VALUES (1, N'INTEREST_PERCENT', N'Porcentaje de interes', N'0.25')	
	INSERT [dbo].[parameters] ([id], [name], [description], [value]) VALUES (2, N'MIN_BALANCE_PERCENT', N'Porcentaje de saldo minimo ', N'0.05')	
	SET IDENTITY_INSERT [dbo].[parameters] OFF

end
go

if(object_id('cards')is null)
begin
  create table cards(
    card_number varchar(13) primary key,
    name varchar(20),
    current_balance decimal(18,2),
    limit decimal(18,2),
    available_balance decimal(18,2)
  )
    
  insert cards(card_number, name, current_balance, limit, available_balance) values('123456789012', 'César Cerón', 1894.22, 4000, 2549.22)
end
go

if(object_id('payments')is null)
begin
  create table payments(
    payment_id int primary key identity,
    card_number varchar(13) references cards(card_number),
    payment_date datetime,
    amount decimal(18,2),
    status varchar(20)
  )
  
  SET IDENTITY_INSERT [dbo].[payments] ON 
  INSERT [dbo].[payments] ([payment_id], [card_number], [payment_date], [amount], [status]) VALUES (1, N'123456789012', CAST(N'2024-08-16T17:01:23.157' AS DateTime), CAST(200.00 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[payments] ([payment_id], [card_number], [payment_date], [amount], [status]) VALUES (2, N'123456789012', CAST(N'2024-08-16T17:01:23.163' AS DateTime), CAST(300.00 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[payments] ([payment_id], [card_number], [payment_date], [amount], [status]) VALUES (3, N'123456789012', CAST(N'2024-08-16T17:01:23.163' AS DateTime), CAST(100.00 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[payments] ([payment_id], [card_number], [payment_date], [amount], [status]) VALUES (4, N'123456789012', CAST(N'2024-08-17T16:08:25.610' AS DateTime), CAST(10.00 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[payments] ([payment_id], [card_number], [payment_date], [amount], [status]) VALUES (5, N'123456789012', CAST(N'2024-08-17T16:08:25.610' AS DateTime), CAST(10.00 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[payments] ([payment_id], [card_number], [payment_date], [amount], [status]) VALUES (6, N'123456789012', CAST(N'2024-08-17T00:00:00.000' AS DateTime), CAST(10.00 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[payments] ([payment_id], [card_number], [payment_date], [amount], [status]) VALUES (7, N'123456789012', CAST(N'2024-08-17T00:00:00.000' AS DateTime), CAST(15.00 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[payments] ([payment_id], [card_number], [payment_date], [amount], [status]) VALUES (8, N'123456789012', CAST(N'2024-08-17T16:08:25.610' AS DateTime), CAST(10.00 AS Decimal(18, 2)), N'COMPLETED')
  SET IDENTITY_INSERT [dbo].[payments] OFF
end
go

if(object_id('purchases')is null)
begin
  create table purchases(
    purchase_id int primary key identity,
    card_number varchar(13) references cards(card_number),
    payment_date datetime,
    description varchar(150),
    amount decimal(18,2),
    status varchar(20)
  )
  
  
  SET IDENTITY_INSERT [dbo].[purchases] ON 
  INSERT [dbo].[purchases] ([purchase_id], [card_number], [payment_date], [description], [amount], [status]) VALUES (1, N'123456789012', CAST(N'2024-08-01T17:12:13.670' AS DateTime), N'Compra de suministros de oficina', CAST(150.75 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[purchases] ([purchase_id], [card_number], [payment_date], [description], [amount], [status]) VALUES (2, N'123456789012', CAST(N'2024-07-31T17:06:20.493' AS DateTime), N'Suscripción de software en línea', CAST(99.99 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[purchases] ([purchase_id], [card_number], [payment_date], [description], [amount], [status]) VALUES (3, N'123456789012', CAST(N'2024-08-16T17:05:11.970' AS DateTime), N'Factura mensual de Internet', CAST(45.50 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[purchases] ([purchase_id], [card_number], [payment_date], [description], [amount], [status]) VALUES (4, N'123456789012', CAST(N'2024-08-16T17:05:11.973' AS DateTime), N'Compra de computadora portátil', CAST(1200.00 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[purchases] ([purchase_id], [card_number], [payment_date], [description], [amount], [status]) VALUES (5, N'123456789012', CAST(N'2024-08-16T17:05:11.977' AS DateTime), N'Compra de boleto para conferencia', CAST(350.00 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[purchases] ([purchase_id], [card_number], [payment_date], [description], [amount], [status]) VALUES (6, N'123456789012', CAST(N'2024-08-16T17:05:11.980' AS DateTime), N'Compra de comestibles', CAST(85.25 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[purchases] ([purchase_id], [card_number], [payment_date], [description], [amount], [status]) VALUES (7, N'123456789012', CAST(N'2024-08-16T17:05:11.983' AS DateTime), N'Compra en librería', CAST(40.99 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[purchases] ([purchase_id], [card_number], [payment_date], [description], [amount], [status]) VALUES (8, N'123456789012', CAST(N'2024-08-16T17:05:11.987' AS DateTime), N'Pa en restaurante', CAST(65.80 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[purchases] ([purchase_id], [card_number], [payment_date], [description], [amount], [status]) VALUES (9, N'123456789012', CAST(N'2024-08-16T17:05:11.990' AS DateTime), N'Cuota de membresía del gimnasio', CAST(55.00 AS Decimal(18, 2)), N'COMPLETED')
  INSERT [dbo].[purchases] ([purchase_id], [card_number], [payment_date], [description], [amount], [status]) VALUES (10, N'123456789012', CAST(N'2024-08-16T17:05:11.990' AS DateTime), N'Compra de boletos de cine', CAST(12.50 AS Decimal(18, 2)), N'COMPLETED')
  SET IDENTITY_INSERT [dbo].[purchases] OFF
end
go

create or alter procedure [dbo].[add_payment](
	@card_number varchar(13), 
	@payment_date datetime, 	
	@amount decimal(18,2),
	@id int output
	)
as
begin

	insert into payments(card_number, payment_date, amount, status)
	values(@card_number, @payment_date, @amount, 'COMPLETED');

	select @id = SCOPE_IDENTITY();

	update cards 
	set available_balance = available_balance + @amount,
		current_balance = current_balance - @amount
	where card_number = @card_number;	
end
GO

create or alter  procedure [dbo].[add_purchase](
	@card_number varchar(13), 
	@payment_date datetime, 
	@description varchar(150), 
	@amount decimal(18,2),
	@id int output
	)
as
begin
	declare @available_balance decimal(18,2);	

	select 
		@available_balance = available_balance	 
	from cards
	where card_number = @card_number;

	if (@available_balance >= @amount)
	begin
		insert into purchases (card_number, payment_date, description, amount, status)
		values(@card_number, @payment_date, @description, @amount, 'COMPLETED');

		select @id = SCOPE_IDENTITY();

		update cards 
		set available_balance = @available_balance - @amount,
			current_balance = current_balance + @amount
		where card_number = @card_number;		
	end;
end
GO

create or alter procedure [dbo].[details_card](@card_number varchar(13))
as
begin
	declare @INTEREST_PERCENT decimal(18,2);
	declare @MIN_BALANCE_PERCENT decimal(18,2);	

	select 
		@INTEREST_PERCENT = [value]	 
	from parameters
	where [name] = 'INTEREST_PERCENT';

	select 
		@MIN_BALANCE_PERCENT = [value]	 
	from parameters
	where [name] = 'MIN_BALANCE_PERCENT';	

	select 
		name,
		CardNumber = card_number,
		CurrentBalance = current_balance,
		limit,
		AvailableBalance = available_balance,
		BonusableInterets = current_balance * @INTEREST_PERCENT,
		MinPaymentDue = current_balance * @MIN_BALANCE_PERCENT ,
		PaymentWithInterest = current_balance + (current_balance * @INTEREST_PERCENT) 
	from cards
	where card_number = @card_number
end
GO

create or alter procedure [dbo].[get_purchase](@card_number varchar(13), @month int)
as
begin
	select card_number, payment_date, transaction_type = 'COMPRA', amount, [description]
	from purchases 
	where [status] = 'COMPLETED'
	and month(payment_date) = @month
end
GO

create or alter procedure [dbo].[transaction_history](@card_number varchar(13), @month int)
as
begin
	select * from (
		select card_number, payment_date, transaction_type = 'PAGO', amount , [description] = 'Pago realizado' 
		from payments 
		where [status] = 'COMPLETED'
		and month(payment_date) = @month
		union
		select card_number, payment_date, transaction_type = 'COMPRA', amount, [description]
		from purchases 
		where [status] = 'COMPLETED'
		and month(payment_date) = @month
	)s order by payment_date desc
end
GO