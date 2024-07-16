namespace BluDay.Net.Abstractions.Models;

public interface IModel
{
    Guid Id { get; init; }

    DateTime? CreatedAt { get; set; }

    DateTime? UpdatedAt { get; set; }

    DateTime? DeletedAt { get; set; }
}