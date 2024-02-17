using AutoFixture.Helper;
using Microsoft.Extensions.Options;
using Moq;

namespace AutoFixture.Moq.Helper;

/// <summary>
/// Customization of .NET Option using Moq 
/// </summary>
/// <typeparam name="TOption"></typeparam>
public class OptionMoqCustomization<TOption> : ICustomization
    where TOption : class, new()
{
    private CustomizationBuilder _customizationBuilder = new();

    /// <summary>
    /// Adds customization for .NET Option using Moq
    /// </summary>
    /// <param name="fixture"></param>
    public void Customize(IFixture fixture)
    {
        _customizationBuilder.Add(customization =>
        {
            fixture.Customize(customization);
        }, 
        typeof(OptionCustomization<TOption>));

        fixture.Customize<Mock<IOptionsFactory<TOption>>>(f => f.FromFactory(() =>
        {
            var moq = new Mock<IOptionsFactory<TOption>>();
            var option = fixture.Freeze<TOption>();
            moq.Setup(f => f.Create(It.IsAny<string>())).Returns(option);
            return moq;
        }));
    }
}
