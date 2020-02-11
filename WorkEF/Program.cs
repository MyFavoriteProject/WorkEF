using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkEF
{
    class Program
    {
        static void Main(string[] args)
        {
            #region First handling
            //var blogUsers = GetBlogUserEf();

            //foreach(var blogUser in blogUsers)
            //{
            //    Console.WriteLine($"Login: {blogUser.UserLogin}");
            //}
            #endregion

            #region SQL similar syntax
            //var context = new TestDbContext();

            //var transactions = from c in context.BlogUser
            //                   join o in context.Blog on c.UserId equals o.UserId

            //                   select new
            //                   {
            //                       UserLogin = c.UserLogin,
            //                       UserEmail = c.Email,
            //                       BlogUserName = o.Name,
            //                       Descr = o.Description==null?"":o.Description
            //                   };

            //foreach (var transaction in transactions)
            //{
            //    Console.WriteLine($"Login: {transaction.UserLogin}\tBlog Name: {transaction.BlogUserName}\tDescription: {transaction.Descr}\tEmail: {transaction.UserEmail}");
            //}
            #endregion

            #region Lazy Liding
            //var context = new TestDbContext();

            //var blog = context.BlogUser.Single(c => c.UserId == 1);

            //var orders = blog.Blog;
            #endregion

            #region Navigation Properties
            //var context = new TestDbContext();

            ////var blogUsers = context.BlogUser;
            //var blogUsers = context.BlogUser.Include("Blog");

            //foreach (var blogUser in blogUsers)
            //{
            //    Console.WriteLine($"{blogUser.UserLogin}:");
            //    foreach(var blog in blogUser.Blog)
            //    {
            //        Console.WriteLine($"\tBlog: {blog.Name}\tDate Time: {blog.CreatedDate}");
            //    }
            //}
            #endregion

            #region Change Data 
            //var context = new TestDbContext();

            ////var blogUsers = context.BlogUser;
            //var blogUsers = context.BlogUser.Single(c=>c.UserId==1);
            //blogUsers.FirstName = "Vova";

            //context.SaveChanges();
            #endregion

            #region Add New Information in DB
            var context = new TestDbContext();

            BlogUser blogUser = context.BlogUser.Add(new BlogUser
            {
                UserLogin = "Nimbus",
                FirstName = "Anton",
                SecondtName = "Frolov",
                Email = "Nimbus@list.ru",
                Password = "12345",
                RegistrationDate = DateTime.Now
            });

            Blog blog = context.Blog.Add(new Blog
            {
                Name = "Wethet",
                Description = "Good whether",
                BlogUser = blogUser,
                UserId = blogUser.UserId,
                CreatedDate = DateTime.Now
            });

            context.SaveChanges();
            #endregion

            Console.ReadKey();
        }

        #region First handling
        private static List<BlogUser> GetBlogUserEf()
        {
            var context = new TestDbContext();

            //IQueryable<BlogUser> query = context.BlogUser;
            //IQueryable<BlogUser> query = context.BlogUser.Where(c => c.UserId == 1);
            //IEnumerable<BlogUser> query = (context.BlogUser as IEnumerable<BlogUser>).Where(c => c.UserId == 1);

            var query = from c in context.BlogUser
                        where c.UserId == 1
                        select c; 

            List<BlogUser> blogUser = query.ToList();

            return blogUser;
        }
        #endregion
    }
}
