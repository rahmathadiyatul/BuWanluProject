SELECT SUM(P.Quantity * PA.Harga) Total_Revenue_Tahunan FROM PENJUALAN P INNER JOIN PAKAIAN PA 
ON PA.PK_Pakaian_ID = P.FK_Pakaian_ID INNER JOIN PELANGGAN PE
ON PE.PK_Pelanggan_ID = P.FK_Pelanggan_ID WHERE PE.Cabang = 'Medan'
AND YEAR(P.Tanggal_Transaksi) = YEAR(GETDATE())

SELECT * FROM PAKAIAN

SELECT P.Nama, 
    (SELECT SUM(Quantity) 
     FROM PENJUALAN 
     WHERE FK_Pakaian_ID = P.PK_Pakaian_ID 
       AND MONTH(Tanggal_Transaksi) = MONTH(GETDATE()) 
       AND YEAR(Tanggal_Transaksi) = YEAR(GETDATE())) AS Quantity_Sold_This_Month,
    (SELECT SUM(Quantity) 
     FROM PENJUALAN 
     WHERE FK_Pakaian_ID = P.PK_Pakaian_ID 
       AND MONTH(Tanggal_Transaksi) = MONTH(DATEADD(MONTH, -1, GETDATE())) 
       AND YEAR(Tanggal_Transaksi) = YEAR(DATEADD(MONTH, -1, GETDATE()))) AS Quantity_Sold_Last_Month,
    (SELECT SUM(Quantity) 
     FROM PENJUALAN 
     WHERE FK_Pakaian_ID = P.PK_Pakaian_ID 
       AND MONTH(Tanggal_Transaksi) = MONTH(GETDATE()) 
       AND YEAR(Tanggal_Transaksi) = YEAR(GETDATE())) 
     - (SELECT SUM(Quantity) 
        FROM PENJUALAN 
        WHERE FK_Pakaian_ID = P.PK_Pakaian_ID 
          AND MONTH(Tanggal_Transaksi) = MONTH(DATEADD(MONTH, -1, GETDATE())) 
          AND YEAR(Tanggal_Transaksi) = YEAR(DATEADD(MONTH, -1, GETDATE()))) AS Increase_In_Sales
FROM PAKAIAN P
WHERE EXISTS (SELECT 1 
              FROM PENJUALAN 
              WHERE FK_Pakaian_ID = P.PK_Pakaian_ID 
                AND MONTH(Tanggal_Transaksi) = MONTH(GETDATE()) 
                AND YEAR(Tanggal_Transaksi) = YEAR(GETDATE()))
  AND EXISTS (SELECT 1 
              FROM PENJUALAN 
              WHERE FK_Pakaian_ID = P.PK_Pakaian_ID 
                AND MONTH(Tanggal_Transaksi) = MONTH(DATEADD(MONTH, -1, GETDATE())) 
                AND YEAR(Tanggal_Transaksi) = YEAR(DATEADD(MONTH, -1, GETDATE())))
ORDER BY Increase_In_Sales DESC
OFFSET 0 ROWS
FETCH NEXT 5 ROWS ONLY;


DECLARE @StartDate DATE = '2023-04-01';
DECLARE @EndDate DATE = '2023-04-30';

WITH cte AS (
  SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS rn
  FROM sys.objects
), pakaian_cte AS (
  SELECT PK_Pakaian_ID, Nama, Harga
  FROM PAKAIAN
  WHERE PK_Pakaian_ID BETWEEN 1 AND 23
), pelanggan_cte AS (
  SELECT PK_Pelanggan_ID, Nama
  FROM PELANGGAN
  WHERE PK_Pelanggan_ID BETWEEN 1 AND 23
)
INSERT INTO PENJUALAN (FK_Pakaian_ID, FK_Pelanggan_ID, Quantity, Tanggal_Transaksi)
SELECT pc.PK_Pakaian_ID, pl.PK_Pelanggan_ID, ABS(CHECKSUM(NEWID())) % 10 + 1 AS Quantity, 
  DATEADD(DAY, ABS(CHECKSUM(NEWID())) % DATEDIFF(DAY, @StartDate, @EndDate), @StartDate) AS Tanggal_Transaksi
FROM pakaian_cte pc
CROSS JOIN pelanggan_cte pl
CROSS JOIN cte
WHERE cte.rn <= 20;

DELETE FROM PENJUALAN WHERE PK_Penjualan_ID > 200;
