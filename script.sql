
use CardDb
go

declare @fecha datetime = getdate() -16

if(object_id('parameters')is null)
begin
  create table parameters(
    id int identity primary key,
    name varchar(20),
    description varchar(100),
    value varchar(150)
  )
  
  SET IDENTITY_INSERT parameters ON
  insert into parameters(id, name, description, value) values(1, 'INTEREST_PERCENT', 'Porcentaje de interes', '0.25')
  insert into parameters(id, name, description, value) values(2, 'MIN_BALANCE_PERCENT', 'Porcentaje de saldo minimo ', '0.05')  
  SET IDENTITY_INSERT parameters OFF
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
    
  insert cards(card_number, name, current_balance, limit, available_balance) values('123456789012', 'John', 3000, 4000, 1000)
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
  
  
  insert into payments(card_number, payment_date, amount, status) values('123456789012', getdate(), 200, 'APPROVED')
  insert into payments(card_number, payment_date, amount, status) values('123456789012', getdate(), 300, 'APPROVED')
  insert into payments(card_number, payment_date, amount, status) values('123456789012', getdate(), 100, 'APPROVED')

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
  
  
  INSERT INTO purchases (card_number, payment_date, description, amount, status) 
  VALUES ('123456789012', getdate(), 'Compra de suministros de oficina', 150.75, 'COMPLETED');

  INSERT INTO purchases (card_number, payment_date, description, amount, status)
  VALUES ('123456789012', getdate(), 'Suscripción de software en línea', 99.99, 'COMPLETED');

  INSERT INTO purchases (card_number, payment_date, description, amount, status)
  VALUES ('123456789012', getdate(), 'Factura mensual de Internet', 45.50, 'COMPLETED');

  INSERT INTO purchases (card_number, payment_date, description, amount, status)
  VALUES ('123456789012', getdate(), 'Compra de computadora portátil', 1200.00, 'COMPLETED');

  INSERT INTO purchases (card_number, payment_date, description, amount, status)
  VALUES ('123456789012', getdate(), 'Compra de boleto para conferencia', 350.00, 'COMPLETED');

  INSERT INTO purchases (card_number, payment_date, description, amount, status)
  VALUES ('123456789012', getdate(), 'Compra de comestibles', 85.25, 'COMPLETED');

  INSERT INTO purchases (card_number, payment_date, description, amount, status)
  VALUES ('123456789012', getdate(), 'Compra en librería', 40.99, 'COMPLETED');

  INSERT INTO purchases (card_number, payment_date, description, amount, status)
  VALUES ('123456789012', getdate(), 'Pago en restaurante', 65.80, 'COMPLETED');

  INSERT INTO purchases (card_number, payment_date, description, amount, status)
  VALUES ('123456789012', getdate(), 'Cuota de membresía del gimnasio', 55.00, 'COMPLETED');

  INSERT INTO purchases (card_number, payment_date, description, amount, status)
  VALUES ('123456789012', getdate(), 'Compra de boletos de cine', 12.50, 'COMPLETED');
end
go


