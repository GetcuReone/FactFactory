﻿using GetcuReone.FactFactory;

namespace Versioned_MovieServiceExample.Facts
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
