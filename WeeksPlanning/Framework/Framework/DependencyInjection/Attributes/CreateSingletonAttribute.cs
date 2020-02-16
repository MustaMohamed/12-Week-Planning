using System;

namespace Framework.DependencyInjection.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CreateSingletonAttribute : Attribute
    {
    }
}