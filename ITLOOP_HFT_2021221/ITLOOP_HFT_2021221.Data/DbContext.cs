using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLOOP_HFT_2021221.Data
{
    class DbContext
    {
        modelBuilder.Entity<Post>().OwnsOne(p => p.AuthorName).HasData(
        new { StudentId = 1, FirstName = "Andriy", LastName = "Svyryd" },
        new { StudentId = 2, FirstName = "Diego", LastName = "Vega" });
        using (var context = new DataSeedingContext())
            {
    object p = context.Database.EnsureCreated();
        var testBlog = context.StudentId.FirstOrDefault(b => b.Url == "http://test.com");
        if (testBlog == null)
            {
                context.StudentId.Add(new StudentId { Url = "http://test.com" });
            }
        context.SaveChanges();
    
    }
}
