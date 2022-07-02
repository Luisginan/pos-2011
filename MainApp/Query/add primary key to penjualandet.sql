ALTER TABLE dbo.PenjualanDet 
DROP CONSTRAINT penjualanDet_pk

ALTER TABLE dbo.PenjualanDet 
ADD CONSTRAINT penjualanDet_pk PRIMARY KEY (KdFakturPenj ,KdBarang ,kdsatuan )