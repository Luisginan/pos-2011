'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
Imports System
Imports System.Data
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Data.Common
Imports System.Collections.Generic
Imports Telerik.OpenAccess
Imports Telerik.OpenAccess.Metadata


Namespace EntitiesModel	
	
	Public Partial Class Vw_LaporanBarang

		Private _par As Integer? 
		Public Overridable Property Par As Integer? 
			Get
		        Return Me._par
			End Get
			Set(ByVal value As Integer?)
		        Me._par = value
			End Set
		End Property

		Private _nama As String 
		Public Overridable Property Nama As String 
			Get
		        Return Me._nama
			End Get
			Set(ByVal value As String)
		        Me._nama = value
			End Set
		End Property

		Private _lokasi As String 
		Public Overridable Property Lokasi As String 
			Get
		        Return Me._lokasi
			End Get
			Set(ByVal value As String)
		        Me._lokasi = value
			End Set
		End Property

		Private _kdSatuan As String 
		Public Overridable Property KdSatuan As String 
			Get
		        Return Me._kdSatuan
			End Get
			Set(ByVal value As String)
		        Me._kdSatuan = value
			End Set
		End Property

		Private _kdKategori As String 
		Public Overridable Property KdKategori As String 
			Get
		        Return Me._kdKategori
			End Get
			Set(ByVal value As String)
		        Me._kdKategori = value
			End Set
		End Property

		Private _hargaJual As Decimal? 
		Public Overridable Property HargaJual As Decimal? 
			Get
		        Return Me._hargaJual
			End Get
			Set(ByVal value As Decimal?)
		        Me._hargaJual = value
			End Set
		End Property

		Private _hargaBeli As Decimal? 
		Public Overridable Property HargaBeli As Decimal? 
			Get
		        Return Me._hargaBeli
			End Get
			Set(ByVal value As Decimal?)
		        Me._hargaBeli = value
			End Set
		End Property

		Private _kdBarang As String 
		Public Overridable Property KdBarang As String 
			Get
		        Return Me._kdBarang
			End Get
			Set(ByVal value As String)
		        Me._kdBarang = value
			End Set
		End Property

	End Class
End Namespace