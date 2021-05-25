use Labstudy;

declare @TableName char(11)
set @TableName = 'Customers'
exec('select * from '+@TableName)
set @TableName = 'Salespeople'
exec('select * from '+@TableName)
