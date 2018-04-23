﻿Imports DevExpress.ExpressApp

Namespace AccessMasterObjectSolution.Module
    Public Class AccessMasterObjectController
        Inherits ViewController(Of ListView)

        Public Sub New()
            TargetViewNesting = Nesting.Nested
            TargetObjectType = GetType(MyTask)
        End Sub
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            If TypeOf View.CollectionSource Is PropertyCollectionSource Then
                Dim collectionSource As PropertyCollectionSource = CType(View.CollectionSource, PropertyCollectionSource)
                AddHandler collectionSource.MasterObjectChanged, AddressOf OnMasterObjectChanged
                If collectionSource.MasterObject IsNot Nothing Then
                    UpdateMasterObject(collectionSource.MasterObject)
                End If
            End If
        End Sub
        Private Sub UpdateMasterObject(ByVal masterObject As Object)
'INSTANT VB NOTE: The variable MasterObject was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
            Dim _MasterObject As MyPerson = DirectCast(masterObject, MyPerson)
            'Use the master object as required            
        End Sub
        Private Sub OnMasterObjectChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            UpdateMasterObject(DirectCast(sender, PropertyCollectionSource).MasterObject)
        End Sub
        Protected Overrides Sub OnDeactivated()
            If TypeOf View.CollectionSource Is PropertyCollectionSource Then
                Dim collectionSource As PropertyCollectionSource = CType(View.CollectionSource, PropertyCollectionSource)
                RemoveHandler collectionSource.MasterObjectChanged, AddressOf OnMasterObjectChanged
            End If
            MyBase.OnDeactivated()
        End Sub
    End Class
End Namespace
