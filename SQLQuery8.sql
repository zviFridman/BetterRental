
CREATE TABLE T_productDiscontGrup
(Gpid INT not null,
Gid INT not null,
 PDid        int     PRIMARY KEY      identity(1000,1) not null,
AddDate DATETIME,
Remarks NVARCHAR(MAX),
Status BIT,
companyCode int,
Discount FLOAT,)
