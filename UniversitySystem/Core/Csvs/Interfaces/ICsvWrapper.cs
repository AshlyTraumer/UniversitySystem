namespace UniversitySystem.Core.Csvs.Interfaces
{
    public interface ICsvWrapper
    {
        byte[] Export();
        void Import(byte[] zipContent);
    }
}
