using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Interfaces;

namespace Infrastructure
{
    public class ResortRepoEF : IResortPostsRepo
    {
        public readonly ResortRepoEF _dbContext;

        public void Add(ResortPost newResortPost)
        {
            _dbContext.Add(newResortPost)
           _dbContext.SaveChages();
        }

        public void Delete(ResortPost newpost)
        {
            _dbContext.Delete(newpost);
        }

        public void Details(ResortPost newpost)
        {
            _dbContext.Details(newpost);
        }

        public void Edit(ResortPost newpost)
        {
            _dbContext.Edit(newpost);
        }

        public ResortPost GetById(int id)
        {
            return _dbContext.GetById(id);
        }

        public ResortPost GetPostByPermalink(string permalink)
        {
            return _dbContext.GetPostByPermalink(permalink);
        }

        public List<ResortPost> ListAll()
        {
            return _dbContext.ListAll();
        }
    }


    //    public void Delete(ResortPost newpost)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Details(ResortPost newpost)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Edit(ResortPost newpost)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ResortPost GetById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ResortPost GetPostByPermalink(string permalink)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<ResortPost> ListAll()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
