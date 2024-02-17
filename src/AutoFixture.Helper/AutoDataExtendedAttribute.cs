using AutoFixture.Xunit2;

namespace AutoFixture.Helper;

/// <summary>
/// Custom attribute for providing auto-generated data specimens using AutoFixture.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class AutoDataExtendedAttribute : AutoDataAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AutoDataExtendedAttribute"/> class with a custom fixture factory.
    /// </summary>
    /// <param name="fixtureFactory">A function that creates an instance of <see cref="IFixture"/>.</param>
    protected AutoDataExtendedAttribute(Func<IFixture> fixtureFactory)
        : base(fixtureFactory)
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AutoDataExtendedAttribute"/> class with the default fixture.
    /// </summary>
    public AutoDataExtendedAttribute()
        : base(() => new Fixture())
    {

    }
}
