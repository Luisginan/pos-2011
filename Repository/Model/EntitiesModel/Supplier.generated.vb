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
	
	Public Partial Class Supplier

		Private _kdSupplier As String 
		Public Overridable Property KdSupplier As String 
			Get
		        Return Me._kdSupplier
			End Get
			Set(ByVal value As String)
		        Me._kdSupplier = value
			End Set
		End Property

		Private _nmSup As String 
		Public Overridable Property NmSup As String 
			Get
		        Return Me._nmSup
			End Get
			Set(ByVal value As String)
		        Me._nmSup = value
			End Set
		End Property

		Private _almtSup As String 
		Public Overridable Property AlmtSup As String 
			Get
		        Return Me._almtSup
			End Get
			Set(ByVal value As String)
		        Me._almtSup = value
			End Set
		End Property

		Private _kota As String 
		Public Overridable Property Kota As String 
			Get
		        Return Me._kota
			End Get
			Set(ByVal value As String)
		        Me._kota = value
			End Set
		End Property

		Private _tlpSup As String 
		Public Overridable Property TlpSup As String 
			Get
		        Return Me._tlpSup
			End Get
			Set(ByVal value As String)
		        Me._tlpSup = value
			End Set
		End Property

		Private _faxSup As String 
		Public Overridable Property FaxSup As String 
			Get
		        Return Me._faxSup
			End Get
			Set(ByVal value As String)
		        Me._faxSup = value
			End Set
		End Property

		Private _hpSup As String 
		Public Overridable Property HpSup As String 
			Get
		        Return Me._hpSup
			End Get
			Set(ByVal value As String)
		        Me._hpSup = value
			End Set
		End Property

		Private _isStatus As Boolean? 
		Public Overridable Property IsStatus As Boolean? 
			Get
		        Return Me._isStatus
			End Get
			Set(ByVal value As Boolean?)
		        Me._isStatus = value
			End Set
		End Property

		Private _userName As String 
		Public Overridable Property UserName As String 
			Get
		        Return Me._userName
			End Get
			Set(ByVal value As String)
		        Me._userName = value
			End Set
		End Property

		Private _tglInput As Date? 
		Public Overridable Property TglInput As Date? 
			Get
		        Return Me._tglInput
			End Get
			Set(ByVal value As Date?)
		        Me._tglInput = value
			End Set
		End Property

		Private _tglUpdate As Date? 
		Public Overridable Property TglUpdate As Date? 
			Get
		        Return Me._tglUpdate
			End Get
			Set(ByVal value As Date?)
		        Me._tglUpdate = value
			End Set
		End Property

		Private _formName As String 
		Public Overridable Property FormName As String 
			Get
		        Return Me._formName
			End Get
			Set(ByVal value As String)
		        Me._formName = value
			End Set
		End Property

	End Class
End Namespace