using System;
using System.Collections.Generic;
using System.Text;

namespace ScanText.Test.ApplicationTest.Builders
{
    public abstract class BaseTestBuilder<M>
    {
        protected M Model;

        public M Build()
        {
            return Model;
        }
    }
}
