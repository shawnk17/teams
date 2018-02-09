using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Interfaces;
using System.Linq;

namespace Infrastructure
{
    public class ResortRepoEF : IResortPostsRepo
    {
        public readonly ResortDbContext _dbContext;

        public ResortRepoEF (ResortDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(ResortPost newResortPost)
        {
            _dbContext.ResortPosts.Add(newResortPost);
           _dbContext.SaveChanges();
        }

        public void Delete(ResortPost newpost)
        {
            _dbContext.ResortPosts.Remove(newpost);
            _dbContext.SaveChanges();
        }

        public ResortPost GetById(int id)
        {
            return _dbContext.ResortPosts.Find(id);
        }

        public ResortPost GetPostByPermalink(string permalink)
        {
            return _dbContext.ResortPosts.FirstOrDefault(p => p.Permalink == permalink);
        }

        public List<ResortPost> ListAll()
        {
            return _dbContext.ResortPosts.ToList();
        }

        public void Update(ResortPost newpost)
        {
            _dbContext.ResortPosts.Update(newpost);
            _dbContext.SaveChanges();
        }
    }
}
