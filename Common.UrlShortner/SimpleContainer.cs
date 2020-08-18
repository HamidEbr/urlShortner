using SimpleInjector;
using System;

namespace Common.UrlShortner
{
    public sealed class SimpleContainer
    {
        private static readonly Lazy<Container> _container =
            new Lazy<Container>(() => new Container());

        private SimpleContainer() { }

        public static Container Container => _container.Value;
    }
}
