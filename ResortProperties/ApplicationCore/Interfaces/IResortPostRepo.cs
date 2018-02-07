using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IResortPostsRepo
    {
        IResortRepository<ResortPost> ListAll();
        ResortPost GetPostByPermalink(string permalink);

        void Add(ResortPost newpost);
        void Edit(ResortPost newpost);
        void Delete(ResortPost newpost);
        void Details(ResortPost newpost);
        ResortPost GetById(int id);
    }
}
