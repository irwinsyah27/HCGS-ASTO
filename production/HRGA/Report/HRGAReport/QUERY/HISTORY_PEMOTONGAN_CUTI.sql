/****** Script for SelectTopNRows command from SSMS  ******/

  
DECLARE @TblTemp TABLE (
[NomorST] varchar(20),
[Nrp] varchar(20),
[Ultah] datetime,
[TglST] datetime,
[Ambil_Tahunan] int,
[Ambil_Besar] int,
[SisaCuti1] int,
[SisaCuti2] int,
[SisaCuti3] int,
[SisaCuti_Tahunan] int,
[SisaCuti_Besar] int,
[Status] varchar(20))

INSERT INTO @TblTemp ([NomorST], Nrp, Ultah, TglST, Ambil_Tahunan, Ambil_Besar, SisaCuti1, SisaCuti2, SisaCuti3, SisaCuti_Tahunan, SisaCuti_Besar, [Status])
SELECT [NomorST]
      ,Convert(varchar(30),[Nrp]) AS Nrp
      ,(Select TglMasukPama FROM tblKaryawan Where NRP = Sutu.NRP) AS Ultah
      ,[tglST]
      ,[C_Tahunan] AS Ambil_Tahunan
      ,[C_Besar] AS Ambil_Besar
      ,Convert(INT,Replace(RIGHT([SisaCuti1],7),'hari','')) AS SisaCuti1
      ,Convert(INT,Replace(RIGHT([SisaCuti2],7),'hari','')) AS SisaCuti2
      ,[SisaCuti3]
      ,[SisaCuti_Tahunan]
      ,[SisaCuti_Besar]
      ,[Status]
  FROM [Persis].[dbo].[tblSutu] AS Sutu
  where Hari IS NOT NULL AND Status = 'Complete' AND Keperluan = 'CUTI' AND tglST >= '2010-10-01' AND ([C_Tahunan] > 0 OR [C_Besar] > 0) AND
  (Select TglMasukPama FROM tblKaryawan Where NRP = Sutu.NRP) IS NOT NULL
  
  
  
Select Nrp, Ultah, CONVERT(varchar,DATEDIFF(DAY,'2010-10-01',GETDATE())/360)+' Tahun' AS Interval_Ultah, SUM(Ambil_Tahunan) AS Pernah_Ambil_Cuti_Tahunan, SUM(Ambil_Besar) AS Pernah_Ambil_Cuti_Besar, (Select TOP 1 SisaCuti1 From @TblTemp where Nrp = Tbl1.Nrp AND TglST >=  '2010-10-01' ORDER BY TglST) AS CutiPeriode1_LAMA
, (Select TOP 1 SisaCuti2 From @TblTemp where Nrp = Tbl1.Nrp AND TglST >=  '2010-10-01' ORDER BY TglST) AS CutiPeriode2_LAMA, (Select TOP 1 SisaCuti3 From @TblTemp where Nrp = Tbl1.Nrp AND TglST >=  '2010-10-01' ORDER BY TglST) AS CutiBesar_LAMA
, 24-SUM(Ambil_Tahunan) AS Cuti_Tahunan_SEKARANG, CASE WHEN 24-SUM(Ambil_Tahunan) >= 12 THEN 24-SUM(Ambil_Tahunan)-12 ELSE 0 END AS CutiPeriode1_SEKARANG
, CASE WHEN 24-SUM(Ambil_Tahunan) < 12 THEN 24-SUM(Ambil_Tahunan) ELSE 12 END AS CutiPeriode2_SEKARANG

FROM(Select * From @TblTemp) AS Tbl1
  GROUP BY Nrp, Ultah