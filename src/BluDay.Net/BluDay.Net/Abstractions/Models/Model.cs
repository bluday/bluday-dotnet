namespace BluDay.Net.Models;

/// <summary>
/// Represents the base class for a derived domain model class.
/// </summary>
public abstract class Model : IEquatable<Model>
{
    /// <summary>
    /// Gets the id of the model.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the date at which the model was created.
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Gets the date at which the model was updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Gets the date at which the model was deleted.
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    public bool Equals(Model? other)
    {
        return Id == other?.Id;
    }

    public int GetHashCode(Model obj)
    {
        return Id.GetHashCode();
    }
}