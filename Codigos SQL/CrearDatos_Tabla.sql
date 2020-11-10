DECLARE @cnt INT = 0;
while @cnt < 5
Begin
	insert into Dispositivo values (2,RAND()*(80-10)+10,'2020-11-09 12:00:00','Engativa');
	set @cnt = @cnt+1;
end; 

--PARSE('2:35:00pm, Friday, 20 July 2018' AS smalldatetime)