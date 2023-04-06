SELECT * FROM PELANGGAN PE
	ORDER BY PE.Tanggal_Bergabung

SELECT * FROM PELANGGAN

ALTER TABLE PENJUALAN
DROP COLUMN Cabang;

ALTER TABLE PELANGGAN
ADD Cabang VARCHAR(20);

UPDATE PELANGGAN
SET Cabang = 'Medan'
WHERE PK_Pelanggan_ID = 3;

INSERT INTO PELANGGAN (Nama, Tanggal_Bergabung, Cabang)
VALUES 
  ('David', '2022-03-01', 'Jakarta'),
  ('Andi', '2021-05-15', 'Jakarta'),
  ('Diana', '2022-02-20', 'Jakarta'),
  ('Rizky', '2022-01-03', 'Medan'),
  ('Siska', '2021-11-17', 'Jakarta'),
  ('Taufik', '2022-02-12', 'Jakarta'),
  ('Lina', '2021-08-08', 'Medan'),
  ('Yoga', '2022-03-22', 'Jakarta'),
  ('Nadia', '2021-12-31', 'Medan'),
  ('Rina', '2022-02-27', 'Jakarta'),
  ('Fajar', '2021-09-09', 'Medan'),
  ('Irfan', '2022-01-01', 'Jakarta'),
  ('Linda', '2021-10-20', 'Jakarta'),
  ('Ahmad', '2022-03-15', 'Medan'),
  ('Yuni', '2021-06-10', 'Jakarta'),
  ('Budi', '2022-02-18', 'Jakarta'),
  ('Wulan', '2021-07-05', 'Medan'),
  ('Nana', '2022-03-05', 'Jakarta'),
  ('Agus', '2021-11-25', 'Medan'),
  ('Rudi', '2022-01-28', 'Jakarta');


SELECT TOP 1 * FROM PELANGGAN WHERE CABANG = 'Jakarta' ORDER BY Tanggal_Bergabung ASC

SELECT * FROM PENJUALAN

INSERT INTO PAKAIAN (Nama, Harga)
VALUES
('Kemeja', 200000),
('Celana Panjang', 250000),
('Jaket', 300000),
('Topi', 50000),
('Kaos', 100000),
('Sepatu', 450000),
('Kacamata', 150000),
('Sandal', 80000),
('Kerudung', 75000),
('Rok', 175000),
('Jas', 600000),
('Blus', 125000),
('Tas', 350000),
('Sweater', 275000),
('Legging', 90000),
('Kaus Kaki', 45000),
('Kaos Olahraga', 125000),
('Hoodie', 225000),
('Rompi', 175000),
('Jam Tangan', 250000);

INSERT INTO PENJUALAN (FK_Pakaian_ID, FK_Pelanggan_ID, Quantity, Tanggal_Transaksi)
SELECT TOP 50
    ABS(CHECKSUM(NEWID())) % 20 + 4, -- generate FK_Pakaian_ID between 4-23
    ABS(CHECKSUM(NEWID())) % 20 + 4, -- generate FK_Pelanggan_ID between 4-23
    ABS(CHECKSUM(NEWID())) % 10 + 1, -- generate Quantity between 1-10
    DATEADD(day, ABS(CHECKSUM(NEWID())) % 90, '2023-01-01') -- generate Tanggal_Transaksi between January to March 2023
FROM sys.all_objects

SELECT TOP 10
    PAK.Nama AS Nama_Pakaian,
    SUM(PEN.Quantity) AS Total_Quantity,
    PEL.Cabang
FROM PENJUALAN PEN
INNER JOIN PAKAIAN PAK ON PEN.FK_Pakaian_ID = PAK.PK_Pakaian_ID
INNER JOIN PELANGGAN PEL ON PEN.FK_Pelanggan_ID = PEL.PK_Pelanggan_ID
WHERE MONTH(PEN.Tanggal_Transaksi) = 3
GROUP BY PAK.Nama, PEL.Cabang
HAVING PEL.Cabang = 'Medan'
ORDER BY PEL.Cabang, Total_Quantity DESC

SELECT * FROM PENJUALAN
