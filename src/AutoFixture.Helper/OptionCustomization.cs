namespace AutoFixture.Helper;

/// <summary>
/// Option customization
/// </summary>
/// <typeparam name="TOption"></typeparam>
public class OptionCustomization<TOption> : ICustomization
    where TOption : class, new()
{

    /// <summary>
    /// Adds customization for .NET Option
    /// </summary>
    /// <param name="fixture"></param>
    public void Customize(IFixture fixture)
    {
        fixture.Customize<TOption>(f => f.FromFactory(() =>
        {
            var t = fixture.Build<TOption>().WithAutoProperties().Create();
            return fixture.Build<TOption>().WithAutoProperties().Create();
        }));

    }
}
