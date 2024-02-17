using AutoFixture.Helper;
using Microsoft.Extensions.Options;
using NSubstitute;

namespace AutoFixture.NSubstitute.Helper;

/// <summary>
/// Customization of .NET Option using NSubstitute
/// </summary>
/// <typeparam name="TOption"></typeparam>
public class OptionNSubstituteCustomization<TOption> : ICustomization
    where TOption : class, new()
{
    private CustomizationBuilder _customizationBuilder = new();

    /// <summary>
    /// Adds customization for .NET Option using NSubstitute
    /// </summary>
    /// <param name="fixture"></param>
    public void Customize(IFixture fixture)
    {
        _customizationBuilder.Add(customization =>
        {
            fixture.Customize(customization);
        },
        typeof(OptionCustomization<TOption>));

        fixture.Customize<IOptionsFactory<TOption>>(f => f.FromFactory(() =>
        {
            var optionsFactory = Substitute.For<IOptionsFactory<TOption>>();
            optionsFactory.Create(Arg.Any<string>())
                .Returns(fixture.Freeze<TOption>());
            return optionsFactory;
        }));
    }
}