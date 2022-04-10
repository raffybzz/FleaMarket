using System.ComponentModel.DataAnnotations.Schema;

namespace FleaMarket.Data.Models;

public abstract class DbEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
}
