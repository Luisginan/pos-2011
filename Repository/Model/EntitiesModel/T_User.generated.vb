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
	
	Public Partial Class T_User

		Private _userName As String 
		Public Overridable Property UserName As String 
			Get
		        Return Me._userName
			End Get
			Set(ByVal value As String)
		        Me._userName = value
			End Set
		End Property

		Private _levelUser As String 
		Public Overridable Property LevelUser As String 
			Get
		        Return Me._levelUser
			End Get
			Set(ByVal value As String)
		        Me._levelUser = value
			End Set
		End Property

		Private _passwordUser As String 
		Public Overridable Property PasswordUser As String 
			Get
		        Return Me._passwordUser
			End Get
			Set(ByVal value As String)
		        Me._passwordUser = value
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

		Private _isStatus As Boolean? 
		Public Overridable Property IsStatus As Boolean? 
			Get
		        Return Me._isStatus
			End Get
			Set(ByVal value As Boolean?)
		        Me._isStatus = value
			End Set
		End Property

		Private _userInput As String 
		Public Overridable Property UserInput As String 
			Get
		        Return Me._userInput
			End Get
			Set(ByVal value As String)
		        Me._userInput = value
			End Set
		End Property

	End Class
End Namespace
