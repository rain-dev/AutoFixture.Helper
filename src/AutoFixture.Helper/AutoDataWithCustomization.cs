using AutoFixture.Helper;

namespace AutoFixture.Moq.Helper;

/// <summary>
/// Custom attribute for providing auto-generated data specimens with customizations using AutoFixture.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class AutoDataWithCustomization : AutoDataExtendedAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AutoDataWithCustomization"/> class.
    /// </summary>
    /// <param name="customizations">An array of customization types to apply.</param>
    public AutoDataWithCustomization(
        params Type[] customizations)
        :base(() =>
        {
            var fixture = new Fixture();
            var customizationBuilder = new CustomizationBuilder(customizations);

            var compositeCustomization = customizationBuilder.Build();

            fixture.Customize(compositeCustomization);

            return fixture;

        })
    {
        
    }
}
