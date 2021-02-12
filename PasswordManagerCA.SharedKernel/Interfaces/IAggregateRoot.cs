namespace PasswordManagerCA.SharedKernel.Interfaces
{
    /// <summary>
    /// Repositories will only work with aggregate roots entites 
    /// <br>
    /// Aggregate roots are the only objects that the client code loads
    /// </br>
    /// 
    /// <para>
    /// The repository encapsulates access to child objects. 
    /// From a caller's perspective it automatically loads them, 
    /// either at the same time the root is loaded or when they're 
    /// actually needed (as with lazy loading)
    /// </para>
    /// 
    /// </summary>
    public interface IAggregateRoot
    {
    }
}
