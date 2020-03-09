using GetcuReone.FactFactory.Facts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieServiceExample.Facts
{
    /// <summary>
    /// Fact stores movie id information
    /// </summary>
    public class MovieIdFact : FactBase<int>
    {
        public MovieIdFact(int value) : base(value)
        {
        }
    }
}
