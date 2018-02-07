namespace ResortProperties.Controllers
{
    internal interface IResortPostsRepo
    {
        string GetById(int id);
        string ListAll();
        void Add(ResortPost newBlogPost);
    }
}