using System;
using Machine.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    public class Context
    {
        Establish context = () =>
        {
            
        };
    }

    #region Constructor Tests

    public class when_I_Construct : Context
    {
        static bool test;

        Establish context = () =>
        {
            test = false;
        };

        Because of = () => 
            test = true;

        It Constructs = () => test.ShouldBeTrue();
    }

    #endregion
}
