drop table dbo.APP_ERR_LOG 

create table dbo.APP_ERR_LOG(
row_id int identity(1000,1),
[log_date] Datetime NOT NULL,
[log_thread] varchar(50)NOT NULL,
[log_level] varchar(50) NOT NULL,
[log_source] varchar(500) NOT NULL,
[log_message] varchar(4000) NOT NULL,
[exception] varchar(4000) NULL,
constraint [pk_APP_ERR_LOG] PRIMARY KEY ([row_id] asc )
)
go