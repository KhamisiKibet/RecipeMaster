using SQLite;

namespace RecipeMaster.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string ImagePath { get; set; }

        // New properties
        public int CategoryId { get; set; }
        public string Tags { get; set; } // Use comma-separated values or another format
        public bool Favorite { get; set; } // Bool, default false
        public string DateAdded { get; set; } // date, default today
    }
}
