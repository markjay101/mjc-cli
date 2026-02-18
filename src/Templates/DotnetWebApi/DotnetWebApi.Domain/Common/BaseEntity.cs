using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetWebApi.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key] public Guid Id { get; protected set; }
        private readonly List<BaseEvent> _domainEvents = [];

        [NotMapped]
        public IReadOnlyList<BaseEvent> DomainEvents => _domainEvents;

        public void AddDomainEvent(BaseEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(BaseEvent eventItem)
        {
            _domainEvents.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
