namespace AutoFixture.Helper
{
    /// <summary>
    /// Builder for creating a list of customizations using AutoFixture.
    /// </summary>
    public class CustomizationBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomizationBuilder"/> class with a single customization.
        /// </summary>
        /// <param name="customization">The type of customization to apply.</param>
        internal CustomizationBuilder(Type customization)
        {
            this.Customizations = new List<ICustomization>() {
                this.CreateCustomization(customization) };
        }

        /// <summary>
        /// Adds a composite customization based on the provided callback and customization types.
        /// </summary>
        public CustomizationBuilder()
        {

        }

        /// <summary>
        /// generates a customization that invokes <paramref name="callback"/>
        /// </summary>
        /// <param name="customization"></param>
        /// <param name="callback"></param>
        public void Add(Action<CompositeCustomization> callback, params Type[] customization)
        {
            callback(new CompositeCustomization(customization.Select(f => CreateCustomization(f))));
        }

        /// <summary>
        /// Gets the list of accumulated customizations in the builder.
        /// </summary>
        internal List<ICustomization> Customizations { get; private set; } = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomizationBuilder"/> class with a collection of customizations.
        /// </summary>
        /// <param name="customizations">The collection of customization types to apply.</param>
        internal CustomizationBuilder(Type[] customizations)
        {
            this.Customizations = customizations
                .Select(f => this.CreateCustomization(f))
                .ToList();
        }

        /// <summary>
        /// Adds a single customization to the builder.
        /// </summary>
        /// <param name="customization">The type of customization to add.</param>
        internal void Add(Type customization)
        {
            this.Customizations.Add(CreateCustomization(customization));
        }

        /// <summary>
        /// builds the customization and returns CompositeCustomization
        /// </summary>
        /// <returns></returns>
        internal CompositeCustomization Build()
        {
            return new CompositeCustomization(Customizations);
        }

        private ICustomization CreateCustomization(Type customization)
        {

#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(customization, nameof(customization));
#else 
            if (customization is null)
                throw new ArgumentNullException(nameof(customization), $"'{nameof(customization)}' is null.");
#endif


            if (!typeof(ICustomization).IsAssignableFrom(customization))
            {
                throw new ArgumentException("The customization type must implement ICustomization", nameof(customization));
            }

            var instance = Activator.CreateInstance(customization);


#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(instance, nameof(customization));
#else
            if (instance is  null)
                throw new ArgumentNullException(nameof(customization), $"'{nameof(customization)}' is null.");
#endif

            return (ICustomization)instance;
        }
    }
}
