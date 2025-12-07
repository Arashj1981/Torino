using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torino.Domain.Entities
{
    public class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public string CreatedBy { get; private set; } = string.Empty;

    protected BaseEntity() { }

    public void SetCreatedAt()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public void SetUpdatedAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetCreatedBy(string user)
    {
        CreatedBy = user;
    }
}

}
