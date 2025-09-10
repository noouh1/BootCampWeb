using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Base;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}