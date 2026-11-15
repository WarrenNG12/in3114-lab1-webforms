Imports Microsoft.AspNet.Identity.EntityFramework

Public Class ContextoIdentity
    Inherits IdentityDbContext(Of IdentityUser)

    Public Sub New()
        MyBase.New("DefaultConnection")
    End Sub
End Class