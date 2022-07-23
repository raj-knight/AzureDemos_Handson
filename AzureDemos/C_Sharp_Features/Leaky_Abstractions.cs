using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Features
{
    internal class Leaky_Abstractions
    {

        // The promise of LINQ is you dont need to worry about where the data is coming from
        // Database(IQueryable) or
        // In-Memory(IEnumerable)
        // The where query works and returns data.

        // String.StartsWith() is case sensitive whereas database query on sql, oracle might behave differently
        // Though it will run, without errors. the output might be different. which we need to know
        // Hence LINQ is called leaky abstraction

        // The promise of abstraction has leaked away and we need to know some implementation details

        public List<Person> Find_Jon(IQueryable<Person> people)
        {   
            // PersonTable
            // Name
            // Jonathan
            // JON Skeet

            return people.Where(p => p.Name.StartsWith("Jon") ).ToList();
        }

        public List<Article> Find_Tags(IQueryable<Article> article)
        {
            // ArticleTable
            // Tags
            // c#,java
            // bc#

            return article.Where(p => p.Tags.Contains("c#")).ToList();

            // Select * from ArticleTable where Tags LIKE '%c#%'
            
            // This will do full table index scan and fail on indexing and bring the db down 
            
            // Though this LINQ works fine for in-memory lists

            // So you shud know that you cant run this query on sql, which is a leak in the abstraction
        }
    }

    internal class Person
    {      
        public string Name { get; set; }
    }

    internal class Article
    {
        public string Tags { get; set; }
    }
}
