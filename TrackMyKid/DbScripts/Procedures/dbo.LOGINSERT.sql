/*
Author: Vinodh 
Description: This procedure is being used by log4net for logging purpose.

Modified log
modified datetime	By	Commeents
----------------------------------------
*/

CREATE PROCEDURE dbo.LOGINSERT(
@log_date datetime
,@log_thread varchar(50)
,@log_level varchar(50)
,@log_source varchar(50)
,@log_message varchar(500)
,@exception varchar(4000) 
)
AS 
BEGIN

insert into dbo.APP_ERR_LOG(
log_date
,log_thread
,log_level
,log_source
,log_message
,exception
)
values(
@log_date
,@log_thread
,@log_level
,@log_source
,@log_message
,@exception
)

END