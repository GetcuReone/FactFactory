namespace GivenWhenThen.TestAdapter.Entities
{
    public abstract class BlockBase
    {
        internal object Result { get; set; }
    }

    public abstract class BlockBase<TResult> : BlockBase
    {

    }
}
