Option Strict On

Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class InicializadorIdentity
    Public Shared Sub CrearRolesYUsuarios()
        Dim contexto As New ContextoIdentity()
        Dim rolManager As New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(contexto))
        Dim userManager As New UserManager(Of IdentityUser)(New UserStore(Of IdentityUser)(contexto))

        userManager.UserValidator = New UserValidator(Of IdentityUser)(userManager) With {
            .AllowOnlyAlphanumericUserNames = False
        }
        userManager.PasswordValidator = New PasswordValidator With {
            .RequiredLength = 6
        }

        If Not rolManager.RoleExists("Administrador") Then
            rolManager.Create(New IdentityRole("Administrador"))
        End If
        If Not rolManager.RoleExists("Recepcion") Then
            rolManager.Create(New IdentityRole("Recepcion"))
        End If

        CrearUsuario(userManager, "admin@apas.local", "Administrador")
        CrearUsuario(userManager, "recepcion1@apas.local", "Recepcion")
        CrearUsuario(userManager, "recepcion2@apas.local", "Recepcion")
    End Sub

    Private Shared Sub CrearUsuario(manager As UserManager(Of IdentityUser), correo As String, rol As String)
        If manager.FindByName(correo) Is Nothing Then
            Dim usuario As New IdentityUser With {.UserName = correo, .Email = correo}
            Dim resultado As IdentityResult = manager.Create(usuario, "Acopio2026")
            If resultado.Succeeded Then
                manager.AddToRole(usuario.Id, rol)
            End If
        End If
    End Sub
End Class