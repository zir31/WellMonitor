namespace WellMonitor.Core.Exceptions
{
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException(string entity)
            : base($"The requested {entity} was not found") { }

        public EntityNotFoundException(string entity, string additionalInfo)
            : base($"The requested {entity} was not found. Additional info : {additionalInfo}") { }
    }
}
