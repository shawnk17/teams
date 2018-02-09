using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IResortPostsRepo
    {
        List<ResortPost> ListAll();
        ResortPost GetPostByPermalink(string permalink);
        ResortPost GetById(int id);

        void Add(ResortPost newpost);
        void Update(ResortPost newpost);
        void Delete(ResortPost newpost);
            
    }
}
