DECLARE @cnt INT = 0;
while @cnt < 10
Begin
	insert into Dispositivo values (2,RAND(),GETDATE(),RAND());
	set @cnt = @cnt+1;
end; 