﻿using GetcuReone.FactFactory.Versioned;
using Versioned_MovieServiceExample.Entities;

namespace Versioned_MovieServiceExample.Facts
{
    /// <summary>
    /// The fact stores information about the movie
    /// </summary>
    public class MovieFact : VersionedFactBase<Movie>
    {
        public MovieFact(Movie value) : base(value)
        {
        }
    }
}