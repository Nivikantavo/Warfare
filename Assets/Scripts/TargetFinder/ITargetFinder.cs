using System.Collections.Generic;

public interface ITargetFinder
{
    public List<T> Find<T>()where T : ITarget;
}