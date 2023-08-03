﻿namespace ConceptArchitect.Collections
{
    public interface IIndexedList<X>
    {
        X this[int index] { get; set; }
        int Length { get; }
        void Add(X item);
        int IndexOf(X value);
    }
}