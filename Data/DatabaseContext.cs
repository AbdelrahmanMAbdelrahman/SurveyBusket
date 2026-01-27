using Microsoft.EntityFrameworkCore;

namespace SurveyBasket.Data
{
    public class DatabaseContext(DbContextOptions options):DbContext(options)
    {
    }
}
