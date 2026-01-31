using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchbox
{
    public class FilmItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string CoverPath { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public bool IsLiked { get; set; }
        public DateTime? WatchedAt { get; set; }
        public bool IsWatched => WatchedAt != null;

        public override string ToString()
        {
            return $"{Title} ({Year})";
        }
    }
}
