using Microsoft.Extensions.DependencyInjection;

namespace ProjectCommonCode
{
    public class RegisterDependencyAttribute : Attribute
    {
        public ServiceLifetime Scope { get; }
         

        public RegisterDependencyAttribute(ServiceLifetime serviceLifetime)
        {
           Scope = serviceLifetime;
        }


        public class RegistSingletonAttribute: RegisterDependencyAttribute
        {
            public RegistSingletonAttribute():base(ServiceLifetime.Singleton) { }
        }

        public class RegisterScopedAttribute: RegisterDependencyAttribute
        {
            public RegisterScopedAttribute():base(ServiceLifetime.Scoped) { }
        }


        public class RegisterTransientAttribute: RegisterDependencyAttribute
        {
            public RegisterTransientAttribute():base(ServiceLifetime.Transient) { } 
        }

    }
}
