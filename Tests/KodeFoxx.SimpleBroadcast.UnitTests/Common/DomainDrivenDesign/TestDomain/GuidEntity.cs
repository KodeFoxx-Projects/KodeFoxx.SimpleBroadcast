namespace KodeFoxx.SimpleBroadcast.UnitTests.Common.DomainDrivenDesign.TestDomain;

internal class GuidEntity : Entity<Guid?>
{
    public GuidEntity(Guid? id) : base(id) { }
}
