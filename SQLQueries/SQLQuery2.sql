SELECT P.PK_Penjualan_ID, PE.Nama NamaPelanggan, PA.Nama NamaPakaian, P.Quantity, PA.Harga*P.Quantity TotalHarga, P.Cabang, P.Tanggal_Transaksi FROM PENJUALAN P INNER JOIN PAKAIAN PA on PA.PK_Pakaian_ID = P.FK_Pakaian_ID INNER JOIN PELANGGAN PE on PE.PK_Pelanggan_ID = P.FK_Pelanggan_ID

INSERT INTO PELANGGAN (Nama, Tanggal_Bergabung)
	VALUES	('Ridwan','2023-01-15'),('Jonathan','2023-02-02')

SELECT * FROM PELANGGAN
SELECT * FROM PENJUALAN
INSERT INTO PENJUALAN (FK_Pakaian_ID,FK_Pelanggan_ID,Quantity,Tanggal_Transaksi,Cabang)
	VALUES	(1,1,5,'2023-02-28','Medan'),
			(3,1,10,'2023-02-28','Medan'),
			(2,2,2,'2023-01-25','Jakarta'),
			(3,2,20,'2023-01-25','Jakarta'),
			(1,3,5,'2023-03-12','Medan'),
			(2,3,5,'2023-03-12','Jakarta'),
			(3,3,5,'2023-03-12','Jakarta')