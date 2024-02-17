using AutoFixture.Moq.Helper;
using AutoFixture.Xunit2;

namespace AutoFixture.Helper
{
    /// <summary>
    /// Custom attribute for providing inline data with customizations using AutoFixture.
    /// </summary>
    public class InlineDataWithCustomizationAttribute : InlineAutoDataAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineDataWithCustomizationAttribute"/> class.
        /// </summary>
        /// <param name="customizations">An array of customization types to apply.</param>
        /// <param name="values">Additional values for the test method parameters.</param>
        public InlineDataWithCustomizationAttribute(
            Type[] customizations,
            params object[] values)
            : base(new AutoDataWithCustomization(customizations), values) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineDataWithCustomizationAttribute"/> class.
        /// </summary>
        /// <param name="customization">A single customization type to apply.</param>
        /// <param name="values">Additional values for the test method parameters.</param>
        public InlineDataWithCustomizationAttribute(
            Type customization,
            params object[] values)
            : base(new AutoDataWithCustomization(customization), values) { }
    }
}