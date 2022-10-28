namespace KodeFoxx.SimpleBroadcast.UnitTests.Common.DomainDrivenDesign.TestDomain;

internal abstract class TestDomainEntity : Entity<long>
{
    public TestDomainEntity(long id) : base(id) { }
}
