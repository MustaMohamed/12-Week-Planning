﻿using System;

namespace DependencyInjection.Config.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CreateSingletonAttribute : Attribute
    {
    }
}