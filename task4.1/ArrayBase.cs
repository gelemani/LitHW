using System;

public abstract class ArrayBase : IArrayBase
{
    public abstract void Print();
    protected abstract void RandFill();
    protected abstract void HandFill();
}