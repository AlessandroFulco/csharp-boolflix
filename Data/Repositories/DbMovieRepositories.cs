﻿using csharp_boolflix.Data.Form;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Build.Tasks;
using Microsoft.EntityFrameworkCore;

namespace csharp_boolflix.Data.Repositories
{
    public class DbMovieRepositories : IDbMovieRepositories
    {
        private BoolflixDbContext db;
        IDbActorRepositories actorRepositories;
        IDbCategoryRepositories categoryRepositories;

        public DbMovieRepositories(BoolflixDbContext _db, IDbActorRepositories _actorRepositories, IDbCategoryRepositories _categoryRepositories)
        {
            db = _db;
            actorRepositories = _actorRepositories;
            categoryRepositories = _categoryRepositories;
        }

        public List<Movie> All()
        {
            return db.Movies.ToList();
        }
        public Movie GetById(int id)
        {
            return db.Movies.Where(m => m.Id == id).Include("Actors").Include("Categories").FirstOrDefault();
        }

        public void Create(Movie movie, List<Actor> actors, List<Category> categories)
        {
            movie.Actors = actors;
            movie.Categories = categories;

            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Update(Movie movie, Movie formData, List<int> areCheckedActors, List<int> areCheckedCategories)
        {
            if(areCheckedActors == null)
            {
                areCheckedActors = new List<int>();
            }

            if(areCheckedCategories == null)
            {
                areCheckedCategories = new List<int>();
            }

            movie.Title = formData.Title;
            movie.Language = formData.Language;
            movie.Director = formData.Director;
            movie.Year = formData.Year;
            movie.Duration = formData.Duration;

            movie.Actors.Clear();
            foreach(int idActor in areCheckedActors)
            {
                Actor actor = actorRepositories.GetById(idActor);
                movie.Actors.Add(actor);
            }

            movie.Categories.Clear();
            foreach (int idCategories in areCheckedCategories)
            {
                Category category = categoryRepositories.GetById(idCategories);
                movie.Categories.Add(category);
            }

            db.SaveChanges();
        }

    }
}
