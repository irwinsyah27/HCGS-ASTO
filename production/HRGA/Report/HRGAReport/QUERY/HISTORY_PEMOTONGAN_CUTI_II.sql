/****** Script for SelectTopNRows command from SSMS  ******/

  
DECLARE @TblTemp TABLE (
[NomorST] varchar(20),
[Nrp] varchar(20),
[Ultah] datetime,
[TglST] datetime,
[Ambil_Tahunan] int,
[Ambil_Besar] int,
[Cuti_Ultah] varchar(10),
[SisaCuti1] int,
[SisaCuti2] int,
[SisaCuti3] int,
[SisaCuti_Tahunan] int,
[SisaCuti_Besar] int,
[Status] varchar(20))

INSERT INTO @TblTemp ([NomorST], Nrp, Ultah, TglST, Ambil_Tahunan, Ambil_Besar, Cuti_Ultah, SisaCuti1, SisaCuti2, SisaCuti3, SisaCuti_Tahunan, SisaCuti_Besar, [Status])
SELECT [NomorST]
      ,Convert(varchar(30),[Nrp]) AS Nrp
      ,(Select TglMasukPama FROM tblKaryawan Where NRP = Sutu.NRP) AS Ultah
      ,[tglST]
      ,[C_Tahunan] AS Ambil_Tahunan
      ,[C_Besar] AS Ambil_Besar
      ,CASE WHEN
      (DATEPART(YEAR,tglST) = 2010) AND
      tglST >= (Select '2010-'+Convert(varchar,DATEPART(MONTH,TglMasukPama))+'-'+Convert(varchar,DATEPART(DAY,TglMasukPama)) FROM tblKaryawan Where NRP = Sutu.NRP) THEN '1/2010'
      WHEN
      (DATEPART(YEAR,tglST) = 2010) AND
      tglST < (Select '2010-'+Convert(varchar,DATEPART(MONTH,TglMasukPama))+'-'+Convert(varchar,DATEPART(DAY,TglMasukPama)) FROM tblKaryawan Where NRP = Sutu.NRP) THEN '2/2010'
      WHEN
      (DATEPART(YEAR,tglST) = 2011) AND
      tglST >= (Select '2011-'+Convert(varchar,DATEPART(MONTH,TglMasukPama))+'-'+Convert(varchar,DATEPART(DAY,TglMasukPama)) FROM tblKaryawan Where NRP = Sutu.NRP) THEN '1/2011' 
      WHEN
      (DATEPART(YEAR,tglST) = 2011) AND
      tglST < (Select '2011-'+Convert(varchar,DATEPART(MONTH,TglMasukPama))+'-'+Convert(varchar,DATEPART(DAY,TglMasukPama)) FROM tblKaryawan Where NRP = Sutu.NRP) THEN '2/2011' 
      WHEN
      (DATEPART(YEAR,tglST) = 2012) AND
      tglST >= (Select '2012-'+Convert(varchar,DATEPART(MONTH,TglMasukPama))+'-'+Convert(varchar,DATEPART(DAY,TglMasukPama)) FROM tblKaryawan Where NRP = Sutu.NRP) THEN '1/2012'
      WHEN
      (DATEPART(YEAR,tglST) = 2012) AND
      tglST < (Select '2012-'+Convert(varchar,DATEPART(MONTH,TglMasukPama))+'-'+Convert(varchar,DATEPART(DAY,TglMasukPama)) FROM tblKaryawan Where NRP = Sutu.NRP) THEN '2/2012' END AS Cuti_Ultah
      ,Convert(INT,Replace(RIGHT([SisaCuti1],7),'hari','')) AS SisaCuti1
      ,Convert(INT,Replace(RIGHT([SisaCuti2],7),'hari','')) AS SisaCuti2
      ,[SisaCuti3]
      ,[SisaCuti_Tahunan]
      ,[SisaCuti_Besar]
      ,[Status]
  FROM [Persis].[dbo].[tblSutu] AS Sutu
  where Hari IS NOT NULL AND Status = 'Complete' AND Keperluan = 'CUTI' AND tglST >= '2010-01-01' AND ([C_Tahunan] > 0 OR [C_Besar] > 0) AND
  (Select TglMasukPama FROM tblKaryawan Where NRP = Sutu.NRP) IS NOT NULL
  
  -------------------------------------------------------------------------------------------------------------------------------------------
 
  ----------- CUTI 2012 -------------------------------------------------------------------------------------------- 
 
  Select Nrp, Ultah, TambahCuti_Tahunan, Cuti1_Awal, Cuti2_Awal, Ambil1_2010, Ambil2_2010, Cuti1_2010, Cuti2_2010,
  Ambil1_2011, Ambil2_2011,
  Cuti1_2011, Cuti2_2011, 
  Ambil1_2012, Ambil2_2012,
  CASE TambahCuti_Tahunan 
  WHEN 3 THEN CASE WHEN CT1+12 - Ambil1_2012<0 THEN 0 ELSE CT1+12 - Ambil1_2012 END 
  WHEN 2 THEN CASE WHEN CT1+12 - Ambil1_2012<0 THEN 0 ELSE CT1+12 - Ambil1_2012 END
  WHEN 1 THEN CASE WHEN CT1+12 - Ambil1_2012<0 THEN 0 ELSE CT1+12 - Ambil1_2012 END
  END AS Cuti1_2012
  , CASE TambahCuti_Tahunan 
  WHEN 3 THEN CT1
  WHEN 2 THEN CT1
  WHEN 1 THEN CT1
  END AS Cuti2_2012
  From(
 
 
  Select Nrp, Ultah, TambahCuti_Tahunan, Cuti1_Awal, Cuti2_Awal, Ambil1_2010, Ambil2_2010, Cuti1_2010, Cuti2_2010, 
  Ambil1_2011, Ambil2_2011,
  Cuti1_2011, Cuti2_2011,
  Ambil1_2012, Ambil2_2012, 
  CASE TambahCuti_Tahunan 
  WHEN 3 THEN CASE WHEN Cuti1_2011 - Ambil2_2012<0 THEN 0 ELSE Cuti1_2011 - Ambil2_2012 END 
  WHEN 2 THEN CASE WHEN Cuti1_2011 - Ambil2_2012<0 THEN 0 ELSE Cuti1_2011 - Ambil2_2012 END
  WHEN 1 THEN CASE WHEN Cuti1_2011 - Ambil2_2012<0 THEN 0 ELSE Cuti1_2011 - Ambil2_2012 END
  END AS CT1
  , CASE TambahCuti_Tahunan 
  WHEN 3 THEN CASE WHEN Cuti1_2011 - Ambil2_2012<0 THEN Cuti2_2011 + (Cuti1_2011 - Ambil2_2012) ELSE Cuti2_2011 END 
  WHEN 2 THEN CASE WHEN Cuti1_2011 - Ambil2_2012<0 THEN Cuti2_2011 + (Cuti1_2011 - Ambil2_2012) ELSE Cuti2_2011 END
  WHEN 1 THEN CASE WHEN Cuti1_2011 - Ambil2_2012<0 THEN Cuti2_2011 + (Cuti1_2011 - Ambil2_2012) ELSE Cuti2_2011 END
  END AS CT2
  From( 
 
 ----------- CUTI 2011 --------------------------------------------------------------------------------------------
 
 
  Select Nrp, Ultah, TambahCuti_Tahunan, Cuti1_Awal, Cuti2_Awal, Ambil1_2010, Ambil2_2010, Cuti1_2010, Cuti2_2010,
  Ambil1_2011, Ambil2_2011,
  CASE TambahCuti_Tahunan 
  WHEN 3 THEN CASE WHEN CT1+12 - Ambil1_2011<0 THEN 0 ELSE CT1+12 - Ambil1_2011 END 
  WHEN 2 THEN CASE WHEN CT1+12 - Ambil1_2011<0 THEN 0 ELSE CT1+12 - Ambil1_2011 END
  WHEN 1 THEN Cuti1_Awal
  END AS Cuti1_2011
  , CASE TambahCuti_Tahunan 
  WHEN 3 THEN CT1
  WHEN 2 THEN CT1
  WHEN 1 THEN Cuti2_Awal
  END AS Cuti2_2011, 
  Ambil1_2012, Ambil2_2012
  From(
 
 
  Select Nrp, Ultah, TambahCuti_Tahunan, Cuti1_Awal, Cuti2_Awal, Ambil1_2010, Ambil2_2010, Cuti1_2010, Cuti2_2010, 
  Ambil1_2011, Ambil2_2011, 
  CASE TambahCuti_Tahunan 
  WHEN 3 THEN CASE WHEN Cuti1_2010 - Ambil2_2011<0 THEN 0 ELSE Cuti1_2010 - Ambil2_2011 END 
  WHEN 2 THEN CASE WHEN Cuti1_2010 - Ambil2_2011<0 THEN 0 ELSE Cuti1_2010 - Ambil2_2011 END
  WHEN 1 THEN Cuti1_Awal
  END AS CT1
  , CASE TambahCuti_Tahunan 
  WHEN 3 THEN CASE WHEN Cuti1_2010 - Ambil2_2011<0 THEN Cuti2_2010 + (Cuti1_2010 - Ambil2_2011) ELSE Cuti2_2010 END 
  WHEN 2 THEN CASE WHEN Cuti1_2010 - Ambil2_2011<0 THEN Cuti2_2010 + (Cuti1_2010 - Ambil2_2011) ELSE Cuti2_2010 END
  WHEN 1 THEN Cuti2_2010
  END AS CT2,
  Ambil1_2012, Ambil2_2012
  From( 
 
 ----------- CUTI 2010 --------------------------------------------------------------------------------------------
 
  Select Nrp, Ultah, TambahCuti_Tahunan, Cuti1_Awal, Cuti2_Awal, Ambil1_2010, Ambil2_2010,
  CASE TambahCuti_Tahunan 
  WHEN 3 THEN CASE WHEN CT1+12 - Ambil1_2010<0 THEN 0 ELSE CT1+12 - Ambil1_2010 END 
  WHEN 2 THEN Cuti1_Awal
  WHEN 1 THEN Cuti1_Awal
  END AS Cuti1_2010
  , CASE TambahCuti_Tahunan 
  WHEN 3 THEN CT1
  WHEN 2 THEN Cuti2_Awal
  WHEN 1 THEN Cuti2_Awal
  END AS Cuti2_2010, 
  Ambil1_2011, Ambil2_2011, Ambil1_2012, Ambil2_2012
  From(
   
  Select Nrp, Ultah, TambahCuti_Tahunan, Cuti_Tahunan1_LAMA AS Cuti1_Awal, Cuti_Tahunan2_LAMA AS Cuti2_Awal
  , SUM(Ambil_Tahunan1_2010) AS Ambil1_2010
  , SUM(Ambil_Tahunan2_2010) AS Ambil2_2010
  , SUM(Ambil_Tahunan1_2011) AS Ambil1_2011
  , SUM(Ambil_Tahunan2_2011) AS Ambil2_2011
  , SUM(Ambil_Tahunan1_2012) AS Ambil1_2012
  , SUM(Ambil_Tahunan2_2012) AS Ambil2_2012
  , CASE TambahCuti_Tahunan 
  WHEN 3 THEN CASE WHEN Cuti_Tahunan1_LAMA - SUM(Ambil_Tahunan2_2010)<0 THEN 0 ELSE Cuti_Tahunan1_LAMA - SUM(Ambil_Tahunan2_2010) END 
  WHEN 2 THEN Cuti_Tahunan1_LAMA
  WHEN 1 THEN Cuti_Tahunan1_LAMA
  END AS CT1
  , CASE TambahCuti_Tahunan 
  WHEN 3 THEN CASE WHEN Cuti_Tahunan1_LAMA - SUM(Ambil_Tahunan2_2010)<0 THEN Cuti_Tahunan2_LAMA + (Cuti_Tahunan1_LAMA - SUM(Ambil_Tahunan2_2010)) ELSE Cuti_Tahunan2_LAMA END 
  WHEN 2 THEN Cuti_Tahunan2_LAMA
  WHEN 1 THEN Cuti_Tahunan2_LAMA
  END AS CT2
  From(
  
  Select [NomorST], Nrp, Ultah, TglST
  , CASE (Select TOP 1 DATEPART(YEAR,TglST) From @TblTemp where Nrp = Tbl1.Nrp ORDER BY TglST) WHEN 2010 THEN 3 WHEN 2011 THEN 2 WHEN 2012 THEN 1 END AS TambahCuti_Tahunan
  , Convert(datetime,'2010-'+Convert(varchar,DATEPART(MONTH,Ultah))+'-'+Convert(varchar,DATEPART(DAY,Ultah))) AS Tambah_Tahunan_2010
  , Convert(datetime,'2011-'+Convert(varchar,DATEPART(MONTH,Ultah))+'-'+Convert(varchar,DATEPART(DAY,Ultah))) AS Tambah_Tahunan_2011
  , Convert(datetime,'2012-'+Convert(varchar,DATEPART(MONTH,Ultah))+'-'+Convert(varchar,DATEPART(DAY,Ultah))) AS Tambah_Tahunan_2012
  , (Select TOP 1 SisaCuti1 From @TblTemp where Nrp = Tbl1.Nrp AND TglST >=  '2010-01-01' ORDER BY TglST) AS Cuti_Tahunan1_LAMA
  , (Select TOP 1 SisaCuti2 From @TblTemp where Nrp = Tbl1.Nrp AND TglST >=  '2010-01-01' ORDER BY TglST) AS Cuti_Tahunan2_LAMA
  , CASE WHEN Cuti_Ultah='1/2010' THEN Ambil_Tahunan ELSE 0 END AS Ambil_Tahunan1_2010 
  , CASE WHEN Cuti_Ultah='2/2010' THEN Ambil_Tahunan ELSE 0 END AS Ambil_Tahunan2_2010
  , CASE WHEN Cuti_Ultah='1/2011' THEN Ambil_Tahunan ELSE 0 END AS Ambil_Tahunan1_2011
  , CASE WHEN Cuti_Ultah='2/2011' THEN Ambil_Tahunan ELSE 0 END AS Ambil_Tahunan2_2011
  , CASE WHEN Cuti_Ultah='1/2012' THEN Ambil_Tahunan ELSE 0 END AS Ambil_Tahunan1_2012
  , CASE WHEN Cuti_Ultah='2/2012' THEN Ambil_Tahunan ELSE 0 END AS Ambil_Tahunan2_2012
  From @TblTemp AS Tbl1
  
  ) AS Hitung1
  GROUP BY Nrp, Ultah, TambahCuti_Tahunan, Tambah_Tahunan_2010, Tambah_Tahunan_2011, Tambah_Tahunan_2012, Cuti_Tahunan1_LAMA, Cuti_Tahunan2_LAMA
 
 
  ) AS Hitung2
  
  ----------- CUTI 2010 --------------------------------------------------------------------------------------------
  
  ) AS Hitung3
  
  ) AS Hitung4
  
  ----------- CUTI 2011 --------------------------------------------------------------------------------------------
  
  ) AS Hitung5
  
  ) AS Hitung6
  
  ----------- CUTI 2012 --------------------------------------------------------------------------------------------
  