namespace App.Interfaces
{
    public interface ICompanyRepository
    {
        bool Get(int id, out Company company);
    }
}