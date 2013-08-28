namespace Projecteuler
{
    public interface IProblem
    {
        int Ref{ get; }

        string Description{ get; }

        long Resolve();
    }
}