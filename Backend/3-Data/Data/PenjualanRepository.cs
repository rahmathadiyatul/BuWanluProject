using BuWanluWeb._3_Data.Data.Interface;
using MySqlX.XDevAPI.Common;

namespace BuWanluWeb._3_Data.Data
{
    public class PenjualanRepository : IPenjualanRepository
    {
        public string GetPenjualan()
        {
            var result = "SELECT P.PK_Penjualan_ID, PE.Nama NamaPelanggan, PA.Nama NamaPakaian, " +
                "P.Quantity, PA.Harga*P.Quantity TotalHarga, PE.Cabang, P.Tanggal_Transaksi " +
                "FROM PENJUALAN P INNER JOIN PAKAIAN PA on PA.PK_Pakaian_ID = P.FK_Pakaian_ID " +
                "INNER JOIN PELANGGAN PE on PE.PK_Pelanggan_ID = P.FK_Pelanggan_ID";
            return result;
        }

        public string GetRevenueByYear()
        {
            var result = "SELECT SUM(P.Quantity * PA.Harga) Total_Revenue_Tahunan FROM PENJUALAN P INNER JOIN PAKAIAN PA " +
                "ON PA.PK_Pakaian_ID = P.FK_Pakaian_ID INNER JOIN PELANGGAN PE " +
                "ON PE.PK_Pelanggan_ID = P.FK_Pelanggan_ID WHERE PE.Cabang = @Cabang " +
                "AND YEAR(P.Tanggal_Transaksi) = YEAR(GETDATE())";
            return result;
        }

        public string GetSalesGrowth()
        {
            var result = "SELECT P.Nama, \r\n    (SELECT SUM(Quantity) \r\n     FROM PENJUALAN \r\n     WHERE FK_Pakaian_ID = P.PK_Pakaian_ID \r\n       AND MONTH(Tanggal_Transaksi) = MONTH(GETDATE()) \r\n       AND YEAR(Tanggal_Transaksi) = YEAR(GETDATE())) AS Quantity_Sold_This_Month,\r\n    (SELECT SUM(Quantity) \r\n     FROM PENJUALAN \r\n     WHERE FK_Pakaian_ID = P.PK_Pakaian_ID \r\n       AND MONTH(Tanggal_Transaksi) = MONTH(DATEADD(MONTH, -1, GETDATE())) \r\n       AND YEAR(Tanggal_Transaksi) = YEAR(DATEADD(MONTH, -1, GETDATE()))) AS Quantity_Sold_Last_Month,\r\n    (SELECT SUM(Quantity) \r\n     FROM PENJUALAN \r\n     WHERE FK_Pakaian_ID = P.PK_Pakaian_ID \r\n       AND MONTH(Tanggal_Transaksi) = MONTH(GETDATE()) \r\n       AND YEAR(Tanggal_Transaksi) = YEAR(GETDATE())) \r\n     - (SELECT SUM(Quantity) \r\n        FROM PENJUALAN \r\n        WHERE FK_Pakaian_ID = P.PK_Pakaian_ID \r\n          AND MONTH(Tanggal_Transaksi) = MONTH(DATEADD(MONTH, -1, GETDATE())) \r\n          AND YEAR(Tanggal_Transaksi) = YEAR(DATEADD(MONTH, -1, GETDATE()))) AS Increase_In_Sales\r\nFROM PAKAIAN P\r\nWHERE EXISTS (SELECT 1 \r\n              FROM PENJUALAN \r\n              WHERE FK_Pakaian_ID = P.PK_Pakaian_ID \r\n                AND MONTH(Tanggal_Transaksi) = MONTH(GETDATE()) \r\n                AND YEAR(Tanggal_Transaksi) = YEAR(GETDATE()))\r\n  AND EXISTS (SELECT 1 \r\n              FROM PENJUALAN \r\n              WHERE FK_Pakaian_ID = P.PK_Pakaian_ID \r\n                AND MONTH(Tanggal_Transaksi) = MONTH(DATEADD(MONTH, -1, GETDATE())) \r\n                AND YEAR(Tanggal_Transaksi) = YEAR(DATEADD(MONTH, -1, GETDATE())))\r\nORDER BY Increase_In_Sales DESC\r\nOFFSET 0 ROWS\r\nFETCH NEXT 5 ROWS ONLY;\r\n";
            return result;
        }

        public string GetTopPenjualanPakaian()
        {
            var result = "SELECT TOP 10 PAK.Nama AS Nama_Pakaian, SUM(PEN.Quantity) AS Total_Quantity, " +
                "PEL.Cabang FROM PENJUALAN PEN INNER JOIN PAKAIAN PAK ON PEN.FK_Pakaian_ID = PAK.PK_Pakaian_ID " +
                "INNER JOIN PELANGGAN PEL ON PEN.FK_Pelanggan_ID = PEL.PK_Pelanggan_ID " +
                "WHERE MONTH(PEN.Tanggal_Transaksi) = @Bulan GROUP BY PAK.Nama, PEL.Cabang " +
                "HAVING PEL.Cabang = @Cabang ORDER BY PEL.Cabang, Total_Quantity DESC";
            return result;
        }

        public string GetTopSpenders()
        {
            var result = "SELECT TOP 10 P.PK_Pelanggan_ID, P.Nama, P.Cabang, SUM(PJ.Quantity * PA.Harga) AS TotalBelanja " +
                "FROM PENJUALAN PJ INNER JOIN PAKAIAN PA ON PJ.FK_Pakaian_ID = PA.PK_Pakaian_ID " +
                "INNER JOIN PELANGGAN P ON PJ.FK_Pelanggan_ID = P.PK_Pelanggan_ID " +
                "WHERE MONTH(PJ.Tanggal_Transaksi) = @Bulan GROUP BY P.PK_Pelanggan_ID, " +
                "P.Nama, P.Cabang HAVING P.Cabang = @Cabang ORDER BY P.Cabang, TotalBelanja DESC";
            return result;
        }
    }
}
